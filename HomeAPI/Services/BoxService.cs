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
       
        private readonly ILogger<BoxService> _logger;
        private Timer _timer;
    
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
          
                //TimeSpan.FromMinutes(15));
                TimeSpan.FromMinutes(15));

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {           
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<HomeContext>();

                try
                { 
                    DHT dhtRecord = await GetBoxData();
                    dbContext.Add(dhtRecord);

                    //LightSensor lightSensorRecord = await GetLightSensorData();
                    //dbContext.Add(lightSensorRecord);
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
            string clientAdress = Constants.Constants.NODEMCU_IP_ADDRESS;
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
            dht.MeasureTime = DateTime.Now;
            dht.CalledBy = "service";
            return dht;          
        }


        public async Task<LightSensor> GetLightSensorData()
        {
            string responseMessage = "";
            string clientAdress = Constants.Constants.NODEMCU_IP_ADDRESS;
            int timeout = 10;

            var client = new HttpClient()
            {
                BaseAddress = new Uri(clientAdress),
                Timeout = TimeSpan.FromSeconds(timeout)
            };

            LightSensor lightSensor = new LightSensor();

            try
            {
                HttpResponseMessage response = await client.GetAsync(clientAdress + "/light");
                response.EnsureSuccessStatusCode();
                responseMessage = await response.Content.ReadAsStringAsync();

                if (response != null)
                {
                    lightSensor = JsonConvert.DeserializeObject<LightSensor>(responseMessage);
                }

            }

            catch (HttpRequestException e)
            {
                responseMessage = e.Message;
            }


            //box id will be changed in the future
            lightSensor.BoxId = 1;
            lightSensor.MeasureTime = DateTime.Now;
            lightSensor.CalledBy = "service";
            return lightSensor;
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
