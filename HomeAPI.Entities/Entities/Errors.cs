using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAPI.Models
{ 
    public class Error
    {
        public int ID { get; set; }

        public string ErrorMessage { get; set; }

        public DateTime ErrorTime { get; set; }
    }
}
