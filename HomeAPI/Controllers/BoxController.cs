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


        [HttpGet]
        [Route("box")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBoxes()
        {
            var boxes = await _boxRepository.GetBoxes();
            if (boxes == null)
                return NotFound();
            return Ok(boxes);
        }


        [HttpGet]
        [Route("box/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBox(int id)
        {
            var box = await _boxRepository.GetBox(id);
            if (box == null)
                return NotFound();
            return Ok(box);
        }

   
        [HttpPost]
        [Route("box")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Create([FromBody] Box box)
        {
            var boxExists = await ValidateIfBoxExists(box);
            if (boxExists)
                return Conflict();

            var response = await _boxRepository.Create(box);

            return CreatedAtAction(nameof(GetBox), new { id = box.ID }, response);
        }


        [HttpPut]
        [Route("box")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Update([FromBody] Box box)
        {
            var boxExists = await ValidateIfBoxExists(box);
            if (!boxExists)
                return NotFound();

            var response = await _boxRepository.Update(box);
            return Ok(response);
        }


        [HttpDelete]
        [Route("box")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Delete([FromBody] Box box)
        {
            var boxExists = await ValidateIfBoxExists(box);
            if (!boxExists)
                return NotFound();

            var response = await _boxRepository.Delete(box);
            return Ok(response);
        }


        #region Helper Methods

        private async Task<bool> ValidateIfBoxExists(Box box)
        {
            var dbProduct = await _boxRepository.GetBox(box.ID);

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
