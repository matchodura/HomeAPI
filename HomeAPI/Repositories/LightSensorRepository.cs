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
    public class LightSensorRepository : ILightSensorRepository
    {
        private readonly HomeContext _context;

        public LightSensorRepository(HomeContext context)
        {
            _context = context;
        }

        public List<LightSensor> GetAllRecords()
        {
            throw new NotImplementedException();
        }

        public LightSensor GetLastRecord()
        {
            return _context.LightSensors.OrderByDescending(c => c.ID).First();
        }

        public List<LightSensor> GetAllValues()
        {
            return _context.LightSensors.Distinct().ToList();
        }

        public List<LightSensor> GetValuesByDate(TimeFilter timeFilter)
        {
            string sortOrder = timeFilter.SortOrder.ToUpper();
            List<LightSensor> results = new List<LightSensor>();

            if (sortOrder == "DESC")
            {
                results = _context.LightSensors.Where(i => i.MeasureTime.Date >= timeFilter.DateBefore.Date && i.MeasureTime.Date <= timeFilter.DateAfter)
                                       .OrderByDescending(p => p.MeasureTime)
                                       .ToList();
            }
            else
            {
                results = _context.LightSensors.Where(i => i.MeasureTime.Date >= timeFilter.DateBefore.Date && i.MeasureTime.Date <= timeFilter.DateAfter)
                                       .OrderBy(p => p.MeasureTime)
                                       .ToList();
            }

            return results;

        }

        public async Task<List<LightSensor>> UpdateSettings(int oldId, DHTConfig newDHT)
        {
            var DHTSensors = GetRowsBySensorId(oldId);

            foreach (var oldDht in DHTSensors)
            {
                LightSensor dht = new LightSensor();
                dht = oldDht;
                dht.BoxId = newDHT.BoxId;
                dht.DeviceID = newDHT.NewId;
                dht.Device = newDHT.Device;
                dht.DateModified = newDHT.DateModified;

                _context.LightSensors.Update(dht);
                _context.SaveChanges();
            }


            var results = await _context.LightSensors.ToListAsync();
            return results;
        }

        public List<LightSensor> GetRowsBySensorId(int id)
        {
            return _context.LightSensors.Where(x => x.DeviceID == id).ToList();
        }
    }
}
