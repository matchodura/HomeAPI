using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class TimeFilter 
    {
        public DateTime DateBefore { get; set; }
        public DateTime DateAfter { get; set; }
    }
}
