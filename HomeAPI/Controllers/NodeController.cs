using HomeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //[Route("dht/config")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> ChangeConfiguration([FromBody] DHTConfig dHTConfig)
        //{
        //    string responseMessage = "";
        //    string clientAdress = Constants.Constants.NODEMCU_IP_ADDRESS;

        //    int timeout = 10;


        //    var client = new HttpClient()
        //    {
        //        BaseAddress = new Uri(clientAdress),
        //        Timeout = TimeSpan.FromSeconds(timeout)
        //    };

        //    try
        //    {
        //        StringContent httpContent = new StringContent(clientURL, System.Text.Encoding.UTF8, "text/plain");

        //        HttpResponseMessage response = await client.PostAsync(clientAdress + "/dht/config", httpContent);
        //        response.EnsureSuccessStatusCode();
        //        responseMessage = await response.Content.ReadAsStringAsync();

        //    }
        //    catch (HttpRequestException e)
        //    {
        //        Console.WriteLine("\nException Caught!");
        //        Console.WriteLine("Message :{0} ", e.Message);
        //        responseMessage = e.Message;

        //    }

        //    return Json(responseMessage);
        //}
    }
}
