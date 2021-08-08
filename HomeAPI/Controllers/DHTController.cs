using HomeAPI.Data;
using HomeAPI.Interfaces;
using HomeAPI.Interfaces.Repositories;
using HomeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class DHTController : Controller, IDHTSensorsensor
    {

        private readonly HomeContext _context;
        private readonly IDHTRepository _dhtRepository;

        public DHTController(HomeContext context, IDHTRepository dhtRepository)
        {
            _context = context;
            _dhtRepository = dhtRepository;
        }


        public IActionResult Index()
        {
            return View();
        }


        [Route("GetValues")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CheckDHT()
        {
            string responseMessage = "";      
            string clientAdress = Constants.Constants.NODEMCU_IP_ADDRESS;
            int timeout = 10;

            var client = new HttpClient() {

                BaseAddress = new Uri(clientAdress),
                Timeout = TimeSpan.FromSeconds(timeout)            
            };

            DHTSensor dht = new DHTSensor();

            try
            {
                HttpResponseMessage response = await client.GetAsync(clientAdress + "/values");
                response.EnsureSuccessStatusCode();
                responseMessage = await response.Content.ReadAsStringAsync();

                if (response != null)
                {                 
                    dht = JsonConvert.DeserializeObject<DHTSensor>(responseMessage);                                       
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);

                responseMessage = e.Message;                                
            }


           //box id will be changed in the future
            dht.BoxId = 1;
            dht.MeasureTime = DateTime.Now;
            dht.CalledBy = "user";

            _context.DHTSensors.Add(dht);
            _context.SaveChanges();

           
            return Json(responseMessage);
        }


        [Route("GetLastRecord")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> GetLastRecord()
        {
            var lastRecord = _context.DHTSensors.OrderByDescending(p => p.MeasureTime)
                       .FirstOrDefault();

            return Json(lastRecord);
        }


        [HttpGet]
        [Route("GetDHTSensors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<DHTSensor>> GetDHTSensors()
        {
            List<DHTSensor> DHTSensors = _dhtRepository.GetAllValues();

            return Json(DHTSensors);
        }


        [HttpPost]
        [Route("GetDHTSensors/Filtered")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<DHTSensor>> GetDHTSensors([FromBody] TimeFilter timeFilter)
        {
            List<DHTSensor> DHTSensors = _dhtRepository.GetValuesByDate(timeFilter);

            return Json(DHTSensors);
        }

        [HttpGet]
        [Route("CurrentValues")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetCurrentValue()
        {
            string responseMessage = "";
            string clientAdress = Constants.Constants.NODEMCU_IP_ADDRESS;
            int timeout = 10;

            var client = new HttpClient()
            {
                BaseAddress = new Uri(clientAdress),
                Timeout = TimeSpan.FromSeconds(timeout)
            };

            DHTSensor dht = new DHTSensor();

            try
            {
                HttpResponseMessage response = await client.GetAsync(clientAdress + "/values");
                response.EnsureSuccessStatusCode();
                responseMessage = await response.Content.ReadAsStringAsync();

                if (response != null)
                {

                    dht = JsonConvert.DeserializeObject<DHTSensor>(responseMessage);
                }

            }

            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);

                responseMessage = e.Message;

            }

            dht.MeasureTime = DateTime.Now;
            return Json(dht);
        }

        [HttpPost]
        [Route("config")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DHTSensor> ChangeConfig([FromBody] DHTConfig newDHT)
        {
            int oldId = newDHT.CurrentId; 
            //TODO wysylanie do node
            var updatedDHT = _dhtRepository.UpdateSettings(oldId, newDHT);
            return Json(updatedDHT);
        }
    }
}
