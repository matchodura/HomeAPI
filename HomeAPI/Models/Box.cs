using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class Box
    {
        public int Id { get; set; }

        public string BoxName { get; set; }
        
        public int RoomId { get; set; }
                      
        public string CreatedBy { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateCreated { get; set; }

        public int DHTId { get; set; }

        public int MotionSensorId { get; set; }

        public virtual ICollection<DHT> DHTs { get; set; }

        public ICollection<MotionSensor> MotionSensors { get; set; }
    }
}
