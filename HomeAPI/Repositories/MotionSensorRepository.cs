using HomeAPI.Data;
using HomeAPI.Interfaces.Repositories;
using HomeAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<MotionSensor>> GetAllValues()
        {
            return await _context.MotionSensors.Distinct().ToListAsync();
        }

        public Task<IEnumerable<MotionSensor>> GetValuesByDate(TimeFilter timeFilter)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MotionSensor>> GetValuesForSpecificSensor(int id)
        {
            return await _context.MotionSensors.Where(x => x.DeviceID == id).ToListAsync();
        }

        public async Task<MotionSensor> GetLastRecord(int id)
        {
            return await _context.MotionSensors.Where(x => x.DeviceID == id).OrderByDescending(c => c.ID).FirstAsync();
        }

        public async Task<IEnumerable<MotionSensor>> GetLastRecords()
        {
            return await _context.MotionSensors
                          .GroupBy(x => x.DeviceID)
                          .Select(g => g.Last())
                          .ToListAsync();
        }

        public void InsertRecord(int boxId, DateTime dateTime)
        {
            MotionSensor motionSensor = new MotionSensor();

            motionSensor.BoxID = boxId;
            motionSensor.AlarmTime = dateTime;
            motionSensor.DeviceID = 1234;

            _context.MotionSensors.Add(motionSensor);
            _context.SaveChanges();
        }
       
    }
}
