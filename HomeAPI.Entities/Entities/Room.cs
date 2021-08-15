using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string CreatedBy { get; set; } = "Mateusz";           

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

        [JsonProperty("rain")]
        public float Rain { get; set; }

        [JsonProperty("alarmMessage")]
        public string AlarmMessage { get; set; }
               
        public virtual ICollection<Box> Boxes { get; set; }
    }
}
