using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class MotionSensor
    {     

        public int ID { get; set; }

        [ForeignKey("boxId")]
        public int? BoxId { get; set; }
      
        [JsonProperty("device")]
        public string Device { get; set; }

        public int? DeviceID { get; set; }

        [JsonProperty("alarmMessage")]
        public string AlarmMessage { get; set; }

        public DateTime MeasureTime { get; set; } 
        
        public DateTime? DateModified { get; set; }   
        
        public DateTime? DateCreated { get; set; }

        public virtual Box Box { get; set; }
    }
}
