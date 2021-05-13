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
        public int Id { get; set; }

        [ForeignKey("BoxId")]
        public int? BoxId { get; set; }
      
        [JsonProperty("device")]
        public string Device { get; set; }       
        
        public int? DeviceId { get; set; }
        
        public DateTime MeasureTime { get; set; }     
        public DateTime? DateModified { get; set; }     
        public DateTime? DateCreated { get; set; }     

    }
}
