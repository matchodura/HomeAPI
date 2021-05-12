using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces.Repositories
{
    public interface IMotionSensorRepository
    {
        public List<MotionSensor> GetAllRecordsByDeviceName(string sensorName);
        public List<MotionSensor> GetAllRecordsById(int sensorId);
        public List<MotionSensor> GetAllRecordsByBoxId(int boxId);
        public List<MotionSensor> GetRecordsByTime();
        public MotionSensor GetLastRecordByName(string sensorName, string boxName);    
        public MotionSensor GetLastRecordById(int sensorId, int boxId);     
        public void InsertRecord(int boxId, string deviceName, DateTime dateTime);

    }
}
