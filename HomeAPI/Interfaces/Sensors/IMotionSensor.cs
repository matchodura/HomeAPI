using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces.Sensors
{
    public interface IMotionSensor
    {
        public string ChangeURL(string port, string device);
        
    }
}
