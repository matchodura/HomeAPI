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
        [Route("get")]
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
        [Route("get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetValuesForSpecificSensor(int id)
        {
            var readings = await _lightSensorRepository.GetValuesForSpecificSensor(id);
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        [Route("last")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetLastRecords()
        {
            var readings = await _lightSensorRepository.GetLastRecords();
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
            var readings = await _lightSensorRepository.GetLastRecord(id);
            if (readings == null)
                return NotFound();
            return Ok(readings);
        }

        [HttpGet]


        [HttpPost]
        [Route("sorted")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSortedResults(string sortBy, string sortType)
        {
            var readings = await _lightSensorRepository.SortValues(sortBy.ToString(), sortType);

            return Ok(readings);
        }

        [HttpPost]
        [Route("current")]
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
