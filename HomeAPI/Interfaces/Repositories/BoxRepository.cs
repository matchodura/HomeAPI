using HomeAPI.Data;
using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces.Repositories
{
    public class BoxRepository : IMotionSensorRepository
    {
        private readonly HomeContext _context;


        public BoxRepository(HomeContext context)
        {
            _context = context;
        }
    

        public List<MotionSensor> GetAllRecordsByBoxId(int boxId)
        {
            throw new NotImplementedException();
        }


        public List<MotionSensor> GetAllRecordsByDeviceName(string sensorName)
        {
            throw new NotImplementedException();
        }


        public List<MotionSensor> GetAllRecordsById(int sensorId)
        {
            throw new NotImplementedException();
        }


        public MotionSensor GetLastRecordById(int sensorId, int boxId)
        {
            throw new NotImplementedException();
        }


        public MotionSensor GetLastRecordByName(string sensorName, string boxName)
        {
            throw new NotImplementedException();
        }


        public List<MotionSensor> GetRecordsByTime()
        {
            throw new NotImplementedException();
        }

        public void InsertRecord(int boxId, string deviceName, DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
