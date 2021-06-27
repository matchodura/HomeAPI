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
    public class MotionController : Controller
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
        [Route("records/box/{boxId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<MotionSensor>> GetAllRecordsByBoxId(int boxId)
        {          
            var allRecords = _motionSensorRepository.GetAllRecordsByBoxId(boxId);

            if (!allRecords.Any())
            {
                return NotFound();
            }

            return Json(allRecords);
        }


        [HttpGet]
        [Route("records/sensors/id/{sensorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<MotionSensor>> GetAllRecordsById(int sensorId)
        {
            var allRecords = _motionSensorRepository.GetAllRecordsById(sensorId);

            if (!allRecords.Any())
            {
                return NotFound();
            }

            return Json(allRecords);
        }


        [HttpGet]
        [Route("records/sensors/name/{sensorName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<MotionSensor>> GetAllRecordsByName(string sensorName)
        {
            var allRecords = _motionSensorRepository.GetAllRecordsByDeviceName(sensorName);

            if (!allRecords.Any())
            {                
                return NotFound();
            }
            
            return Json(allRecords);
            
        }


        [Route("on")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> MotionOn(string deviceName, int boxId)
        {
            string responseMessage = "";

            DateTime dateTime = DateTime.Now;
            
            responseMessage = $"{deviceName} {dateTime}";

           
            _motionSensorRepository.InsertRecord(boxId, deviceName, dateTime);


            await _hubContext.Clients.All.MotionOn(responseMessage);

           

            return responseMessage;
        }


        [Route("off")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> MotionOff(string deviceName, int boxId)
        {
            string responseMessage = "";

            DateTime dateTime = DateTime.Now;

            responseMessage = $"{deviceName} {dateTime}";
                      

            await _hubContext.Clients.All.MotionOff($"{deviceName} motion has stopped!");

            return responseMessage;
        }




        /// <summary>
        /// changes url to esp8266 motion sensor GET request back, when something is found in its range
        /// </summary>
        /// <returns></returns>
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
