using HomeAPI.Data;
using HomeAPI.Helpers;
using HomeAPI.Interfaces;
using HomeAPI.Interfaces.Repositories;
using HomeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class LightSensorController : Controller, IDataSensor
    {
        private readonly HomeContext _context;
        private readonly ILightSensorRepository _lightSensorRepository;
        private readonly SensorDataLogging _sensorDataLogging;

        public LightSensorController(HomeContext context, ILightSensorRepository lightSensorRepository, SensorDataLogging sensorDataLogging)
        {
            _context = context;
            _lightSensorRepository = lightSensorRepository;
            _sensorDataLogging = sensorDataLogging;
        }

        [HttpGet]
        [Route("light")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetValues()
        {
            var readings = await _lightSensorRepository.GetAllValues();
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        [HttpGet]
        [Route("light/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetValuesForSpecificSensor(int id)
        {
            var readings = await _lightSensorRepository.GetValuesForSpecificSensor(id);
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        [HttpGet]
        [Route("light/last/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLastRecord(int id)
        {
            var readings = await _lightSensorRepository.GetLastRecord(id);
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        [HttpGet]
        [Route("light/last")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLastRecords()
        {
            var readings = await _lightSensorRepository.GetLastRecords();
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        //TODO
        [HttpPost]
        [Route("light/filtered")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<IEnumerable<IActionResult>> GetFilteredResults(TimeFilter timeFilter)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("light/current")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCurrentValues()
        {

            string calledBy = "user";
            var responseMessage = await _sensorDataLogging.GetLightSensorData(calledBy);

            if (responseMessage == null)
                return NotFound();
            return Ok(responseMessage);

        }

    }
}
