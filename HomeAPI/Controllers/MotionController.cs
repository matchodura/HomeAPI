using HomeAPI.HubConfig;
using HomeAPI.Interfaces;
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

        public MotionController(IHubContext<MotionHub, INotifyHubClient> hubContext)
        {
            _hubContext = hubContext;
        }


        [Route("Motion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<string>> Motion(string device)
        {
            string responseMessage = "";

            DateTime dateTime = DateTime.Now;
            MotionSensor motionSensor = new MotionSensor();

            //responseMessage = JsonConvert.DeserializeObject<MotionSensor>(motionSensor);
            motionSensor.Date = dateTime;
            motionSensor.Device = device;

            responseMessage = $"{device} {dateTime}";

            // SendMessage(responseMessage);

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
    }
}
