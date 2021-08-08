using HomeAPI.Data;
using HomeAPI.HubConfig;
using HomeAPI.Interfaces;
using HomeAPI.Interfaces.Repositories;
using HomeAPI.Models;
using HomeAPI.Repositories;
using Microsoft.AspNetCore.SignalR;
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
    public class DataUpdateService : IHostedService, IDisposable
    {

        private readonly ILogger<DataUpdateService> _logger;
        private Timer _timer;
        private readonly IHubContext<MotionHub, INotifyHubClient> _hubContext;
        private readonly IServiceScopeFactory _scopeFactory;

        public DataUpdateService(
                          ILogger<DataUpdateService> logger, 
                          IServiceScopeFactory scopeFactory,
                          IHubContext<MotionHub, INotifyHubClient> hubContext
                          )
        {
            _hubContext = hubContext;          
            _logger = logger;
            _scopeFactory = scopeFactory;
        }


        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                //TimeSpan.FromMinutes(15));
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dhtRepository = scope.ServiceProvider.GetRequiredService<IDHTRepository>();

                try
                {
                    DHTSensorsensor lastRecord =  dhtRepository.GetLastRecord();

                    _hubContext.Clients.All.BroadcastData(lastRecord);
                }

                catch (Exception e)
                {

                    _logger.LogInformation("Error occured in DHT data logging: {e}", e.GetType().Name);
                }

            }
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
