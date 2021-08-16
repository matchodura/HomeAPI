using HomeAPI.Data;
using HomeAPI.Helpers;
using HomeAPI.Interfaces.Repositories;
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
        private readonly SensorDataLogging _sensorDataLogging;

        public BoxService(ILogger<BoxService> logger, IServiceScopeFactory scopeFactory, SensorDataLogging sensorDataLogging)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            _sensorDataLogging = sensorDataLogging;

            //_context = context;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,

                TimeSpan.FromMinutes(15));
            //TimeSpan.FromMinutes(1));


            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {           
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<HomeContext>();
                var homeRepo = scope.ServiceProvider.GetRequiredService<IHomeRepository>();
                DHTSensor dhtrecord1 = new DHTSensor();
                LightSensor lightSensorRecord1 = new LightSensor();
                RainSensor rainSensorRecord1 = new RainSensor();
                string calledBy = "service";
                             

                try
                {
                    DHTSensor dhtRecord = await _sensorDataLogging.GetDHTData(calledBy);
                    dbContext.Add(dhtRecord);

                    //LightSensor lightSensorRecord = await GetLightSensorData();
                    //dbContext.Add(lightSensorRecord);
                    dbContext.SaveChanges();

                    Thread.Sleep(5000);
                    LightSensor lightSensorRecord = await _sensorDataLogging.GetLightSensorData(calledBy);
                    dbContext.Add(lightSensorRecord);
                    dbContext.SaveChanges();

                    Thread.Sleep(5000);
                    RainSensor rainSensorRecord = await _sensorDataLogging.GetRainData(calledBy);
                    dbContext.Add(rainSensorRecord);
                    dbContext.SaveChanges();

                    Thread.Sleep(5000);

                    dhtrecord1 = dhtRecord;
                    lightSensorRecord1 = lightSensorRecord;
                    rainSensorRecord1 = rainSensorRecord;
                }

                catch (Exception e)
                {
                   
                    _logger.LogInformation($"{DateTime.Now} - Error occured in DHT data logging: {e}", e.GetType().Name);
                }


                Room room = new Room();
                room = dbContext.Rooms.SingleOrDefault(x => x.BoxId == dhtrecord1.BoxID);

                room.Temperature = dhtrecord1.Temperature.ToString();
                room.Humidity = dhtrecord1.Humidity.ToString();
                room.Luxes = lightSensorRecord1.Luxes;
                room.Rain = rainSensorRecord1.Rain;
                room.MeasureTime = dhtrecord1.MeasureTime;


                await homeRepo.UpdateRecords(room);
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
