using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces
{
    public interface IBoxRepository
    {
        public List<Box> GetAllBoxes();
        public Box GetBoxById(int boxId);
        public Box GetBoxByName(string boxName);
        public Box CreateBox(Box box);
        public bool DeleteBox();
        public Box UpdateBox(Box box);     
        public List<MotionSensor> GetMotionSensors();

    }
}
