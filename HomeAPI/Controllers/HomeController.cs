using HomeAPI.HubConfig;
using HomeAPI.Interfaces;
using HomeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IHubContext<MotionHub, INotifyHubClient> _hubContext;

        public HomeController(IHubContext<MotionHub, INotifyHubClient> hubContext)
        {
            _hubContext = hubContext;
        }




        // GET: api/<HomeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("GetIP")]
        public string GetIPAddress()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName()); // `Dns.Resolve()` method is deprecated.
            IPAddress ipAddress = ipHostInfo.AddressList[0];

            return ipAddress.ToString();
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
        public async Task<IActionResult> ChangeURL(string device)
        {
            string responseMessage = "";
            string clientAdress = "http://192.168.1.21";
            int timeout = 10;


            //URL query, as asp.net sometimes changes port number during execution/rerun todo to make it automatic
            string methodURL = "http://192.168.1.19:45457/api/home/motion?device=" + device;

            var client = new HttpClient()
            {
                BaseAddress = new Uri(clientAdress),
                Timeout = TimeSpan.FromSeconds(timeout)
            };

          

            try
            {
                StringContent httpContent = new StringContent(methodURL, System.Text.Encoding.UTF8, "text/plain");


                //HttpResponseMessage response = await client.GetAsync(clientAdress + "/changeurl");
                HttpResponseMessage response = await client.PostAsync(clientAdress + "/changeurl", httpContent);
                response.EnsureSuccessStatusCode();
                responseMessage = await response.Content.ReadAsStringAsync();

                if (response != null)
                {

                   
                }

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
