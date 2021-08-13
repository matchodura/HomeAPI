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
        [Route("rooms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _homeRepository.GetRooms();
            if (rooms == null)
                return NotFound();
            return Ok(rooms);
        }


        [HttpGet]
        [Route("rooms/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRoom(int id)
        {
            var room = await _homeRepository.GetRoom(id);
            if (room == null)
                return NotFound();
            return Ok(room);
        }
                        
        //TODO: add ability to update specific room?
        [HttpPost]
        [Route("rooms")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create([FromBody] Room room)
        {
            var roomExists = await ValidateIfRoomExists(room);
            if (roomExists)
                return Conflict();

            var response = await _homeRepository.Create(room);

            return CreatedAtAction(nameof(GetRoom), new { id = room.ID }, response);
        }


        [HttpPut]
        [Route("rooms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update([FromBody] Room room)
        {
            var roomExists = await ValidateIfRoomExists(room);
            if (!roomExists)
                return NotFound();

            var response = await _homeRepository.Update(room);
            return Ok(response);
        }


        [HttpDelete]
        [Route("rooms")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Delete([FromBody] Room room)
        {
            var roomExists = await ValidateIfRoomExists(room);
            if (!roomExists)
                return NotFound();

            var response = await _homeRepository.Delete(room);
            return Ok(response);
        }


        #region Helper Methods

        private async Task<bool> ValidateIfRoomExists(Room room)
        {
            var dbProduct = await _homeRepository.GetRoom(room.ID);

            if (dbProduct != null)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
        #endregion
    }
}
