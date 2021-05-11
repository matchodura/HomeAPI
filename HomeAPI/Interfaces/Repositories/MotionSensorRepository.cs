using HomeAPI.Data;
using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces.Repositories
{
    public class MotionSensorRepository : IMotionSensorRepository
    {
        private readonly HomeContext _context;
        public MotionSensorRepository(HomeContext context)
        {
            _context = context;
        }


        public List<MotionSensor> GetAllRecords()
        {
            throw new NotImplementedException();
        }

        public MotionSensor GetLastRecord()
        {
            throw new NotImplementedException();
        }

        public List<MotionSensor> GetRecordsByTime()
        {
            throw new NotImplementedException();
        }

        public void InsertRecord(int boxId, string deviceName, DateTime dateTime)
        {
            MotionSensor motionSensor = new MotionSensor();

            motionSensor.BoxId = boxId;
            motionSensor.Date = dateTime;
            motionSensor.Device = deviceName;

            _context.MotionSensors.Add(motionSensor);
            _context.SaveChanges();
        }
    }
}
