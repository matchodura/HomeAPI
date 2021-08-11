using HomeAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class Home
    {
        [Key]
        [JsonProperty("roomId")]       
        public int ID { get; set; }

        [JsonProperty("roomName")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
