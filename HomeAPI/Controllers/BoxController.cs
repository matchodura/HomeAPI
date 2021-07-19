using HomeAPI.Data;
using HomeAPI.Interfaces;
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
    public class BoxController : Controller
    {
        private readonly HomeContext _context;
        private readonly IBoxRepository _boxRepository;
     
        public BoxController(HomeContext context, IBoxRepository boxRepository)
        {         
            _context = context;
            _boxRepository = boxRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> CreateBox([FromBody] Box box)
        {
            box = _boxRepository.CreateBox(box);
            return Json(box);
        }


        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> UpdateBox([FromBody] Box box)
        {
            box = _boxRepository.UpdateBox(box);
            return Json(box);
        }    

        [HttpGet]
        [Route("GetMotionSensors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<DHT>> GetMotionSensors()
        {
            List<MotionSensor> motionSensors = _boxRepository.GetMotionSensors();
            return Json(motionSensors);
        }             

    }
}
