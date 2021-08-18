using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class RainSensor
    {
        [JsonProperty("recordID")]
        public int ID { get; set; }

        [ForeignKey("boxID")]
        [JsonProperty("boxID")]
        public int? BoxID { get; set; }

        [JsonProperty("deviceID")]
        public int DeviceID { get; set; }

        [JsonProperty("sensorType")]
        public string SensorType { get; set; }

        [JsonProperty("rain")]
        public int Rain { get; set; }

        [JsonProperty("rainStatus")]
        public string RainStatus { get; set; }

        public string CalledBy { get; set; }

        public DateTime MeasureTime { get; set; }

        public DateTime? DateModified { get; set; }

        public DateTime? DateCreated { get; set; }

        [JsonIgnore]
        public virtual Box Box { get; set; }
    }
}