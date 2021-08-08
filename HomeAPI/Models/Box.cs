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
        
        public int RoomId { get; set; }
                      
        public string CreatedBy { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateCreated { get; set; }

        public int DHTId { get; set; }

        public int MotionSensorId { get; set; }

        public virtual Room Rooms { get; set; }

        public virtual ICollection<DHT> DHTs { get; set; }

        public virtual ICollection<MotionSensor> MotionSensors { get; set; }

        public virtual ICollection<LightSensor> LightSensors { get; set; }
    }
}
