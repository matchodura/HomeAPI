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


        [Route("Motion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> Motion(string device)
        {
            string responseMessage = "";

            //to be changed in future
            int boxId = 1;

            DateTime dateTime = DateTime.Now;
            
            responseMessage = $"{device} {dateTime}";

           
            _motionSensorRepository.InsertRecord(boxId, device, dateTime);

            await _hubContext.Clients.All.BroadcastMessage(responseMessage);

            return responseMessage;
        }


        /// <summary>
        /// changes url to esp8266 motion sensor GET request back, when something is found in its range
        /// </summary>
        /// <returns></returns>
        [Route("ChangeUrl")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangeURL(string port, string device)
        {
            string responseMessage = "";
            string clientAdress = "http://192.168.1.21";
            int timeout = 10;

            //URL query, as asp.net sometimes changes port number during execution/rerun todo to make it automatic
            string methodURL = "http://192.168.1.19:" + port + "/api/motion/motion?device=" + device;

            var client = new HttpClient()
            {
                BaseAddress = new Uri(clientAdress),
                Timeout = TimeSpan.FromSeconds(timeout)
            };

            try
            {
                StringContent httpContent = new StringContent(methodURL, System.Text.Encoding.UTF8, "text/plain");

                HttpResponseMessage response = await client.PostAsync(clientAdress + "/changeurl", httpContent);
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

        string IMotionSensor.ChangeURL(string port, string device)
        {
            throw new NotImplementedException();
        }
    }
}
