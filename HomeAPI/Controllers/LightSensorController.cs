using HomeAPI.Data;
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
    public class LightSensorController : Controller
    {
        private readonly HomeContext _context;
        private readonly ILightSensorRepository _lightSensorRepository;

        public LightSensorController(HomeContext context, ILightSensorRepository dhtRepository)
        {
            _context = context;
            _lightSensorRepository = dhtRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        //gets current values
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
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);

                responseMessage = e.Message;

            }

            lightSensor.MeasureTime = DateTime.Now;
            return Json(lightSensor);
        }


        //gets current values and saves them to database
        [Route("GetValues")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSaveLuxesToDatabase()
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
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);

                responseMessage = e.Message;
            }


            //box id will be changed in the future
            lightSensor.BoxId = 1;
            lightSensor.MeasureTime = DateTime.Now;
            lightSensor.CalledBy = "user";

            _context.LightSensors.Add(lightSensor);
            _context.SaveChanges();


            return Json(responseMessage);
        }
    }
}
