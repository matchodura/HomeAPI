using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces.Repositories
{
    public interface IMotionSensorRepository
    {
        public List<MotionSensor> GetAllRecords();

        public List<MotionSensor> GetRecordsByTime();

        public MotionSensor GetLastRecord();

        public void InsertRecord(int boxId, string deviceName, DateTime dateTime);

    }
}
