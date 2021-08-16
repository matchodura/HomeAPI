using HomeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces.Sensors
{
    public interface IMotionSensor
    {
        public Task<IActionResult> ChangeURL(string port, string device);
        public  Task<IActionResult> MotionOn(string deviceName, int boxId);
        public  Task<IActionResult> MotionOff(string deviceName, int boxId);
        public Task<IActionResult> GetLastRecord(int id);
        public Task<IActionResult> GetLastRecords();
        public Task<IEnumerable<IActionResult>> GetFilteredResults(TimeFilter timeFilter);
    }
}
