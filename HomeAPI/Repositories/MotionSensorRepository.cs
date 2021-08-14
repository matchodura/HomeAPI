using HomeAPI.Data;
using HomeAPI.Interfaces.Repositories;
using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Repositories
{
    public class MotionSensorRepository : IMotionSensorRepository
    {
        private readonly HomeContext _context;


        public MotionSensorRepository(HomeContext context)
        {
            _context = context;
        }

        public List<MotionSensor> GetAllRecordsById(int sensorId)
        {
            List<MotionSensor> motionSensors;

            motionSensors = _context.MotionSensors.Where(i => i.DeviceID == sensorId).ToList();

            return motionSensors;
        }


        public List<MotionSensor> GetAllRecordsByBoxId(int boxId)
        {
            List<MotionSensor> motionSensors;

            motionSensors = _context.MotionSensors.Where(i => i.BoxId == boxId).ToList();

            return motionSensors;
        }

        public List<MotionSensor> GetRecordsByTime()
        {
            throw new NotImplementedException();
        }



        public MotionSensor GetLastRecordById(int sensorId, int boxId)
        {
            throw new NotImplementedException();
        }


        public void InsertRecord(int boxId, DateTime dateTime)
        {
            MotionSensor motionSensor = new MotionSensor();

            motionSensor.BoxId = boxId;
            motionSensor.AlarmTime = dateTime;
            motionSensor.DeviceID = 1234;

            _context.MotionSensors.Add(motionSensor);
            _context.SaveChanges();
        }
       
    }
}
