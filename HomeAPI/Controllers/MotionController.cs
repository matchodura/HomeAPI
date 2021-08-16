using HomeAPI.Data;
using HomeAPI.HubConfig;
using HomeAPI.Interfaces;
using HomeAPI.Interfaces.Repositories;
using HomeAPI.Interfaces.Sensors;
using HomeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeAPI.Controllers
{
    [Route("api/[controller]")]
    public class MotionController : Controller, IMotionSensor
    {
        private readonly IHubContext<MotionHub, INotifyHubClient> _hubContext;
        private readonly HomeContext _context;
        private readonly IMotionSensorRepository _motionSensorRepository;

        public MotionController(IHubContext<MotionHub, INotifyHubClient> hubContext, HomeContext context, IMotionSensorRepository motionSensorRepository)
        {
            _hubContext = hubContext;
            _context = context;
            _motionSensorRepository = motionSensorRepository;
        }

        [HttpGet]
        [Route("motion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetValues()
        {
            var readings = await _motionSensorRepository.GetAllValues();
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        [HttpGet]
        [Route("motion/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetValuesForSpecificSensor(int id)
        {
            var readings = await _motionSensorRepository.GetValuesForSpecificSensor(id);
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        [HttpGet]
        [Route("motion/last")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLastRecords()
        {
            var readings = await _motionSensorRepository.GetLastRecords();
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        [HttpGet]
        [Route("motion/last/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLastRecord(int id)
        {
            var readings = await _motionSensorRepository.GetLastRecord(id);
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        //TODO:
        [HttpGet]
        [Route("motion/filtered")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<IActionResult>> GetFilteredResults(TimeFilter timeFilter)
        {
            var readings = await _motionSensorRepository.GetValuesByDate(timeFilter);

            return (IEnumerable<IActionResult>)Ok(readings);
        }

        [HttpPost]
        [Route("on")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> MotionOn(string deviceName, int boxId)
        {
            string responseMessage = "";

            DateTime dateTime = DateTime.Now;
            
            responseMessage = $"{deviceName} {dateTime}";
           
            _motionSensorRepository.InsertRecord(boxId, dateTime);

            await _hubContext.Clients.All.MotionOn(responseMessage);                       

            return Ok(responseMessage);
        }


        [HttpPost]
        [Route("off")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> MotionOff(string deviceName, int boxId)
        {
            string responseMessage = "";

            DateTime dateTime = DateTime.Now;

            responseMessage = $"{deviceName} {dateTime}";                      

            await _hubContext.Clients.All.MotionOff($"{deviceName} motion has stopped!");

            return Ok(responseMessage);
        }

        /// <summary>
        /// changes url to esp8266 motion sensor GET request back, when something is found in its range
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("ChangeUrl")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangeURL(string port, string motionType)
        {
            string responseMessage = "";
            string clientAdress = Constants.Constants.NODEMCU_IP_ADDRESS;
            string serverAdress = Constants.Constants.BACKEND_IP_ADDRESS;
            int timeout = 10;


            //URL query, as asp.net sometimes changes port number during execution/rerun todo to make it automatic
            string methodURL = serverAdress + port + "/api/motion/"+motionType;

            var client = new HttpClient()
            {
                BaseAddress = new Uri(clientAdress),
                Timeout = TimeSpan.FromSeconds(timeout)
            };

            try
            {
                StringContent httpContent = new StringContent(methodURL, System.Text.Encoding.UTF8, "text/plain");

                HttpResponseMessage response = await client.PostAsync(clientAdress + "/changeurl/"+motionType, httpContent);
                response.EnsureSuccessStatusCode();
                responseMessage = await response.Content.ReadAsStringAsync();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                responseMessage = e.Message;

            }

            return Json(responseMessage);
        }

    }
}
