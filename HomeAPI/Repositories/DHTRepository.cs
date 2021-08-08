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
    public class DHTRepository : IDHTRepository
    {

        private readonly HomeContext _context;

        public DHTRepository(HomeContext context)
        {
            _context = context;
        }

        public List<DHTSensorsensor> GetAllRecords()
        {
            throw new NotImplementedException();
        }

        public DHTSensorsensor GetLastRecord()
        {
            return _context.DHTSensors.OrderByDescending(c => c.ID).First();
        }

        public List<DHTSensorsensor> GetAllValues()
        {
            return _context.DHTSensors.Distinct().ToList();
        }

        public List<DHTSensorsensor> GetValuesByDate(TimeFilter timeFilter)
        {
            string sortOrder = timeFilter.SortOrder.ToUpper();
            List<DHTSensorsensor> results = new List<DHTSensorsensor>();

            if (sortOrder == "DESC")
            {
                results = _context.DHTSensors.Where(i => i.MeasureTime.Date >= timeFilter.DateBefore.Date && i.MeasureTime.Date <= timeFilter.DateAfter)
                                       .OrderByDescending(p => p.MeasureTime)
                                       .ToList();
            }
            else
            {
                results = _context.DHTSensors.Where(i => i.MeasureTime.Date >= timeFilter.DateBefore.Date && i.MeasureTime.Date <= timeFilter.DateAfter)
                                       .OrderBy(p => p.MeasureTime)
                                       .ToList();
            }
          
            return results;
           
        }

        public async Task<List<DHTSensorsensor>> UpdateSettings(int oldId, DHTConfig newDHT)
        {
            var DHTSensors = GetRowsBySensorId(oldId);

            foreach (var oldDht in DHTSensors)
            {
                DHTSensorsensor dht = new DHTSensorsensor();
                dht = oldDht;
                dht.BoxId = newDHT.BoxId;
                dht.DeviceID = newDHT.NewId;
                dht.Device = newDHT.Device;
                dht.DateModified = newDHT.DateModified;

                _context.DHTSensors.Update(dht);
                _context.SaveChanges();
            }
        

            var results = await _context.DHTSensors.ToListAsync();
            return results;
        }

        public List<DHTSensorsensor> GetRowsBySensorId(int id)
        {
            return _context.DHTSensors.Where(x => x.DeviceID == id).ToList();
        }
    }
}
