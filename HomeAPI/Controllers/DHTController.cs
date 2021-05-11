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
    public class DHTController : Controller, IDHTSensor, IDHTRepository
    {

        private readonly HomeContext _context;

        public DHTController(HomeContext context)
        {
            _context = context;
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
            string clientAdress = "http://192.168.1.21";
            int timeout = 10;

            var client = new HttpClient() {

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
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);

                responseMessage = e.Message;
                                
            }


           //box id will be changed in the future
            dht.BoxId = 1;
            dht.Date = DateTime.Now;
            dht.CalledBy = "user";

            _context.DHTs.Add(dht);
            _context.SaveChanges();

           
            return Json(responseMessage);
        }


        [Route("GetLastRecord")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> GetLastRecord()
        {
            var lastRecord = _context.DHTs.OrderByDescending(p => p.Date)
                       .FirstOrDefault();

            return Json(lastRecord);
        }


        [Route("GetAllRecords")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> GetAllRecords()
        {

            var allRecords = _context.DHTs.OrderByDescending(p => p.Date).ToList();

            return Json(allRecords);
        }
                

        [Route("GetRecordsByTime")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> GetRecordsByTime([FromBody] Filter filter)
        {

            string sortOrder = filter.SortOrder.ToUpper();
            List<DHT> allRecords = new List<DHT>();


            if(sortOrder == "ASC")
            {
                allRecords = _context.DHTs.OrderBy(p => p.Date).ToList();
            }

            else if(sortOrder == "DESC")
            {

                allRecords = _context.DHTs.OrderByDescending(p => p.Date).ToList();
            }

            else
            {

            }
                        

            return Json(allRecords);
        }

        public string GetCurrentValue()
        {
            throw new NotImplementedException();
        }

        List<DHT> IDHTRepository.GetAllRecords()
        {
            throw new NotImplementedException();
        }

        public List<DHT> GetRecordsByTime()
        {
            throw new NotImplementedException();
        }

        DHT IDHTRepository.GetLastRecord()
        {
            throw new NotImplementedException();
        }
    }
}
