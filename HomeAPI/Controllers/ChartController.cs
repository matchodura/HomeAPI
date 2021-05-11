using HomeAPI.Data;
using HomeAPI.HubConfig;
using HomeAPI.Models;
using HomeAPI.TimerFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : Controller
    {
        private readonly IHubContext<ChartHub> _hub;
        private readonly HomeContext _context;

        public ChartController(IHubContext<ChartHub> hub, HomeContext context)
        {
            _hub = hub;
            _context = context;
        }


        public IActionResult Get()
        {
            var records = _context.DHTs.ToList();
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", GetData(records)));
            return Ok(new { Message = "Request completed" });
        }


        public static List<ChartModel> GetData(List<DHT> records)
        {

            var lastRecord = records.OrderByDescending(p => p.Date)
                       .FirstOrDefault();

            var allTemps = records.OrderByDescending(p => p.Date).Select(t => t.Temperature).ToList();
            var allHumidity = records.OrderByDescending(p => p.Date).Select(t => t.Humidity).ToList();

            var allDates = records.OrderByDescending(p => p.Date).Select(t => t.Date).ToList();

          
            List<DataModel> dataModelsTemp = new List<DataModel>();
            List<DataModel> dataModelsHum = new List<DataModel>();

            foreach(var record in records)
            {
                dataModelsTemp.Add(new DataModel { x = record.Date , y = record.Temperature });
                dataModelsHum.Add(new DataModel { x = record.Date , y = record.Humidity });

            }

            return new List<ChartModel>
            {
                new ChartModel { Label = "temperature", Data = dataModelsTemp},
                new ChartModel { Label = "humidity", Data = dataModelsHum}
            };
                  
        }

    }
}

