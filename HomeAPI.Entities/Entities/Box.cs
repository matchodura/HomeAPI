using HomeAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class Box
    {
        [Key]
        public int ID { get; set; }

        [JsonProperty("boxName")]
        public string BoxName { get; set; }

        [JsonProperty("roomId")]
        public int RoomId { get; set; }

        public string CreatedBy { get; set; } = "Mateusz";

        public DateTime DateModified { get; set; }

        public DateTime DateCreated { get; set; }

        [JsonProperty("dhtID")]
        public int DHTId { get; set; }

        [JsonProperty("motionSensorID")]
        public int MotionSensorId { get; set; }

        [JsonProperty("lightSensorID")]
        public int LightSensorID { get; set; }

        public virtual Room Rooms { get; set; }

        public virtual ICollection<DHTSensor> DHTSensors { get; set; }

        public virtual ICollection<MotionSensor> MotionSensors { get; set; }

        public virtual ICollection<LightSensor> LightSensors { get; set; }
    }
}
