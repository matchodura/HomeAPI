using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class MotionSensor
    {
        //public int Id { get; set; }


        //[ForeignKey("BoxId")]
        //public int? BoxId { get; set; }

        //public Box Box { get; set; }

        [JsonProperty("device")]
        public string Device { get; set; }
            
        [JsonProperty("date")]      
        public DateTime Date { get; set; }

      
    }
}
