using HomeAPI.Data;
using HomeAPI.Helpers;
using HomeAPI.Interfaces;
using HomeAPI.Interfaces.Repositories;
using HomeAPI.Models;
using HomeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DHTController : Controller, ISensor
    {

        private readonly HomeContext _context;
        private readonly IDHTRepository _dhtRepository;
        private readonly SensorDataLogging _sensorDataLogging;


        public DHTController(HomeContext context, IDHTRepository dhtRepository, SensorDataLogging sensorDataLogging)
        {
            _context = context;
            _dhtRepository = dhtRepository;
            _sensorDataLogging = sensorDataLogging;
        }

        [HttpGet]
        [Route("dht")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetValues()
        {
            var readings = await _dhtRepository.GetAllValues();
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        [HttpGet]
        [Route("dht/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetValuesForSpecificSensor(int id)
        {
            var readings = await _dhtRepository.GetValuesForSpecificSensor(id);
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        [HttpGet]
        [Route("dht/last")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLastRecords()
        {
            var readings = await _dhtRepository.GetLastRecords();
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        [HttpGet]
        [Route("dht/last/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLastRecord(int id)
        {
            var readings = await _dhtRepository.GetLastRecord(id);
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        //TODO
        [HttpPost]
        [Route("dht/filtered")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<IActionResult>> GetFilteredResults([FromBody] TimeFilter timeFilter)
        {
            var readings = await _dhtRepository.GetValuesByDate(timeFilter);

            return (IEnumerable<IActionResult>)Ok(readings);
        }

        //[Route("dht/current")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public Task<IEnumerable<IActionResult>> GetCurrentValues()
        //{
        //    string responseMessage = "";      
        //    string clientAdress = Constants.Constants.NODEMCU_IP_ADDRESS;
        //    int timeout = 10;

        //    var client = new HttpClient() {

        //        BaseAddress = new Uri(clientAdress),
        //        Timeout = TimeSpan.FromSeconds(timeout)            
        //    };

        //    DHTSensor dht = new DHTSensor();

        //    try
        //    {
        //        HttpResponseMessage response = await client.GetAsync(clientAdress + "/values");
        //        response.EnsureSuccessStatusCode();
        //        responseMessage = await response.Content.ReadAsStringAsync();

        //        if (response != null)
        //        {                 
        //            dht = JsonConvert.DeserializeObject<DHTSensor>(responseMessage);                                       
        //        }

        //    }
        //    catch (HttpRequestException e)
        //    {
        //        Console.WriteLine("\nException Caught!");
        //        Console.WriteLine("Message :{0} ", e.Message);

        //        responseMessage = e.Message;                                
        //    }


        //   //box id will be changed in the future
        //    dht.BoxId = 1;
        //    dht.MeasureTime = DateTime.Now;
        //    dht.CalledBy = "user";

        //    _context.DHTSensors.Add(dht);
        //    _context.SaveChanges();


        //    return Json(responseMessage);
        //}

        [HttpPost]
        [Route("dht/current")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCurrentValuesForSpecificSensor()
        {         

            string calledBy = "user";
            var responseMessage = await _sensorDataLogging.GetDHTData(calledBy);

            if (responseMessage == null)
                return NotFound();
            return Ok(responseMessage);                        
         
        }

        [HttpPost]
        [Route("dht/config")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DHTSensor> ChangeConfig([FromBody] DHTConfig newDHT)
        {
            int oldId = newDHT.CurrentId; 
            //TODO wysylanie do node
            var updatedDHT = _dhtRepository.UpdateSettings(oldId, newDHT);
            return Json(updatedDHT);
        }

        //TODO:
        public Task<IEnumerable<IActionResult>> GetCurrentValues()
        {
            throw new NotImplementedException();
        }
    }
}
