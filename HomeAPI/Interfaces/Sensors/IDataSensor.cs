using HomeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces
{
    public interface IDataSensor
    {

        /// <summary>
        /// Gets current values from repository
        /// </summary>
        /// <returns></returns>
        public Task<IActionResult> GetValues();

        /// <summary>
        /// Gets current values from sensors
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<IActionResult> GetCurrentValues();
        public Task<IActionResult> GetLastRecord(int id);
        public Task<IActionResult> GetLastRecords(); 
        public Task<IEnumerable<IActionResult>> GetFilteredResults(TimeFilter timeFilter);

    }
}
