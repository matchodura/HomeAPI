using HomeAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YeelightUDP;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YeelightController : ControllerBase
    {
        // GET: api/<ValuesController>
        //[HttpGet]
        [Route("GetDevices")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> GetDevices()
        {

            var device = Yeelight.GetAvailableDevices();
           

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
        [Route("Bulb/{option}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public ActionResult<string> BulbControl(string option)
        {
            var response = Yeelight.BulbCommand(option);

            return response;
        }



        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
