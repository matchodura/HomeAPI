using HomeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces
{
    public interface ISensor
    {

        /// <summary>
        /// Gets current values for all sensors
        /// </summary>
        /// <returns></returns>
        public Task<IActionResult> GetValues();

        public Task<IActionResult> GetValuesForSpecificSensor(int id);
        public Task<IActionResult> GetLastRecord(int id);
        public Task<IActionResult> GetLastRecords(); 
        public Task<IEnumerable<IActionResult>> GetFilteredResults(TimeFilter timeFilter);

    }
}
