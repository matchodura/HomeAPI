using HomeAPI.Data;
using HomeAPI.HubConfig;
using HomeAPI.Interfaces;
using HomeAPI.Interfaces.Repositories;
using HomeAPI.Models;
using HomeAPI.TimerFeatures;
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

        private readonly HomeContext _context;
        private readonly IHomeRepository _homeRepository;

        public HomeController(HomeContext context, IHomeRepository homeRepository)
        {
            _context = context;
            _homeRepository = homeRepository;
        }


        [HttpGet]
        [Route("data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _homeRepository.GetRoomsData();

            return Ok(rooms);
        }


        [HttpGet]
        [Route("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRoomsList()
        {
            var rooms = await _homeRepository.GetRoomsList();

            return Ok(rooms);
        }


        [HttpGet]
        [Route("rooms/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Room> GetRoomById(int id)
        {               
            return Json(_homeRepository.GetRoom(id));
        }      


        [HttpPost]
        [Route("rooms/create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<string> Create([FromBody] Room room)
        {
            var message = _homeRepository.CreateRoom(room);

            return message;
        }


        [HttpPost]
        [Route("rooms/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Room> Update([FromBody] Room room)
        {
            var message = _homeRepository.UpdateRoom(room);

            return Json(message);
        }
    }
}
