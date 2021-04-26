using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class YeelightCommand
    {
        public string Method { get; set; }

        public string ControlMethod { get; set; }

        public int ControlValue { get; set; }

        public bool IsStringValue { get; set; }
        public bool IsIntValue { get; set; }
    }
}
