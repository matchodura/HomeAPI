using HomeAPI.Data;
using HomeAPI.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace HomeAPI.Services
{
    public class BoxService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly ILogger<BoxService> _logger;
        private Timer _timer;
        private readonly HomeContext _context;
        private readonly IServiceScopeFactory _scopeFactory;

        public BoxService(ILogger<BoxService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            //_context = context;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {           
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<HomeContext>();

                try
                {
                    DHT record = await GetBoxData();
                    dbContext.Add(record);
                    dbContext.SaveChanges();
                }

                catch(Exception e)
                {
                   
                    _logger.LogInformation("Error occured in DHT data logging: {e}", e.GetType().Name);
                }
              
            }                
        }

        public async Task<DHT> GetBoxData()
        {
            string responseMessage = "";
            string clientAdress = "http://192.168.1.21";
            int timeout = 10;

            var client = new HttpClient()
            {
                BaseAddress = new Uri(clientAdress),
                Timeout = TimeSpan.FromSeconds(timeout)
            };

            DHT dht = new DHT();

            try
            {
                HttpResponseMessage response = await client.GetAsync(clientAdress + "/values");
                response.EnsureSuccessStatusCode();
                responseMessage = await response.Content.ReadAsStringAsync();

                if (response != null)
                {
                    dht = JsonConvert.DeserializeObject<DHT>(responseMessage);
                }

            }

            catch (HttpRequestException e)
            {               
                responseMessage = e.Message;
            }


            //box id will be changed in the future
            dht.BoxId = 1;
            dht.Date = DateTime.Now;
            dht.CalledBy = "service";
            return dht;          
        }


        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
