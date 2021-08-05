using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class Room
    {
        [JsonProperty("roomId")]      
        public int ID { get; set; }

        [JsonProperty("roomName")]
        public string Name { get; set; }

        [JsonProperty("boxId")]
        public int BoxId { get; set; }

        [JsonProperty("createdBy")]
        public DateTime CreatedBy { get; set; }


        [JsonProperty("calledBy")]
        public string CalledBy { get; set; }

        [JsonProperty("dateModified")]
        public DateTime DateModified { get; set; }

        [JsonProperty("dateCreated")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("measureTime")]
        public DateTime MeasureTime { get; set; }

        [JsonProperty("temperature")]
        public string Temperature { get; set; }

        [JsonProperty("humidity")]
        public string Humidity { get; set; }

        [JsonProperty("luxes")]
        public float Luxes { get; set; }     

        [JsonProperty("aAlarmMessage")]
        public string AlarmMessage { get; set; }

        public virtual Home Home { get; set; }
        //public virtual ICollection<DHT> DHTs { get; set; }

        //public ICollection<MotionSensor> MotionSensors { get; set; }
    }
}
