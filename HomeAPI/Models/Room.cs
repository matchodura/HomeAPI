using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BoxId { get; set; }

        public string CreatedBy { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime DateCreated { get; set; }

        public string Temperature { get; set; }

        public string Humidity { get; set; }

        public DateTime LastAlarm { get; set; }

        public string AlarmMessage { get; set; }

        //public virtual ICollection<DHT> DHTs { get; set; }

        //public ICollection<MotionSensor> MotionSensors { get; set; }
    }
}
