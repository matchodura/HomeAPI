using HomeAPI.Data;
using HomeAPI.Helpers;
using HomeAPI.Interfaces;
using HomeAPI.Interfaces.Repositories;
using HomeAPI.Models;
using HomeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DHTController : Controller, IDataSensor
    {

        private readonly HomeContext _context;
        private readonly IDHTRepository _dhtRepository;
        private readonly SensorDataLogging _sensorDataLogging;


        public DHTController(HomeContext context, IDHTRepository dhtRepository, SensorDataLogging sensorDataLogging)
        {
            _context = context;
            _dhtRepository = dhtRepository;
            _sensorDataLogging = sensorDataLogging;
        }

        [HttpGet]
        [Route("get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetValues()
        {
            var readings = await _dhtRepository.GetAllValues();
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        [HttpGet]
        [Route("get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetValuesForSpecificSensor(int id)
        {
            var readings = await _dhtRepository.GetValuesForSpecificSensor(id);
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        [HttpGet]
        [Route("last")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLastRecords()
        {
            var readings = await _dhtRepository.GetLastRecords();
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        [HttpGet]
        [Route("last/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLastRecord(int id)
        {
            var readings = await _dhtRepository.GetLastRecord(id);
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        //TODO
        [HttpPost]
        [Route("dht/asasa/vavcz/czcas/asa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<IActionResult>> GetFilteredResults([FromBody] TimeFilter timeFilter)
        {
            var readings = await _dhtRepository.GetValuesByDate(timeFilter);

            return (IEnumerable<IActionResult>)Ok(readings);
        }

      
        [HttpGet]
        [Route("sorted")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSortedResults(string sortBy, string sortType)
        {
            var readings = await _dhtRepository.SortValues(sortBy.ToString(), sortType);

            return Ok(readings);
        }

        [HttpGet]
        [Route("current")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCurrentValues()
        {         

            string calledBy = "user";
            var responseMessage = await _sensorDataLogging.GetDHTData(calledBy);

            if (responseMessage == null)
                return NotFound();
            return Ok(responseMessage);                        
         
        }
    }
}
