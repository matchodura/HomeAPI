using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class LightSensor
    {
        [JsonProperty("recordID")]
        public int ID { get; set; }

        [ForeignKey("boxID")]
        public int? BoxID { get; set; }

        [JsonProperty("deviceID")]
        public int DeviceID { get; set; }

        [JsonProperty("sensorType")]
        public string SensorType { get; set; }

        [JsonProperty("luxes")]
        public float Luxes { get; set; }

        public string CalledBy { get; set; }

        public DateTime MeasureTime { get; set; }

        public DateTime? DateModified { get; set; }

        public DateTime? DateCreated { get; set; }      

        public virtual Box Box { get; set; }
    }
}
