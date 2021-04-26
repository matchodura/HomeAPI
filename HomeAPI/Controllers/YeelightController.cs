using HomeAPI.Data;
using HomeAPI.Helpers;
using HomeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeAPI.Controllers;
using HomeAPI.Yeelight;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class YeelightController : Controller
    {

        private readonly HomeContext _context;

        public YeelightController(HomeContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }


        [Route("GetBulbs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<Bulb>> CheckDB()
        {
            var bulb = _context.Bulbs.ToList();

            if (!bulb.Any())
            {
                return NotFound();
            }

            else
            {
                return bulb;
            }
          
        }


        // GET: api/<ValuesController>
        //[HttpGet]
        [Route("GetDevices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> GetDevices()
        {
            var device = Yeelight.Yeelight.GetAvailableDevices();          

            if (!device.IsFound)
            {
                return NotFound();
            }
            else
            {
                var foundDevice = JSONSerializer.SerializeObject(device);
                return foundDevice;
            }           
        }
        
        
        [HttpPost]       
        [Route("Control")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> BulbControlAdvanced([FromBody] YeelightCommand yeelight)
        {

            string methodName = yeelight.Method; 
            string response = null;

            BulbHistory history = new BulbHistory();

            if (yeelight.IsIntValue && yeelight.IsStringValue)
            {
                response = "something wrong";
            }
            else
            {
                if (yeelight.IsIntValue)
                {

                    

                    int value = yeelight.ControlValue;
                    history.MethodValue = value.ToString();



                    response = Yeelight.Yeelight.BulbCommand (methodName, value);

                   

                    // id is temporary for now, will add bulb ids later                   


                }
                else if (yeelight.IsStringValue)
                {
                    string value = yeelight.ControlMethod;
                    history.MethodValue = value.ToString();

                    response = Yeelight.Yeelight.BulbCommand(methodName, value);
                   
                }
            };


            history.LampId = 1;
            history.MethodName = methodName;
            history.DateSent = DateTime.Now;
            history.Response = response;

            _context.BulbsHistory.Add(history);
            _context.SaveChanges();


            return response;
        }
   
    }
}
