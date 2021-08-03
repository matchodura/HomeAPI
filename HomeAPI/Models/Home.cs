using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class Home
    {
        [JsonProperty("roomId")]
        public int RoomId { get; set; }

        [JsonProperty("roomName")]
        public string Name { get; set; }

        [JsonProperty("boxId")]
        public int BoxId { get; set; }

        [JsonProperty("dateModified")]
        public DateTime DateModified { get; set; }

        [JsonProperty("dateCreated")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("measureTime")]
        public DateTime MeasureTime { get; set; }

        [JsonProperty("currentTemperature")]
        public string CurrentTemperature { get; set; }

        [JsonProperty("currentHumidity")]
        public string CurrentHumidity { get; set; }

        [JsonProperty("currentLight")]
        public float CurrentLuxes { get; set; }

        [JsonProperty("lastAlarmTime")]
        public DateTime LastAlarm { get; set; }

        [JsonProperty("lastAlarmMessage")]
        public string AlarmMessage { get; set; }
      
    }
}
