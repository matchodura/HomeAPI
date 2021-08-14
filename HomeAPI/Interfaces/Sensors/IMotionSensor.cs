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


    }
}
