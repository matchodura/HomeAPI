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

        public List<DHT> GetAllRecords()
        {
            throw new NotImplementedException();
        }

        public DHT GetLastRecord()
        {
            return _context.DHTs.OrderByDescending(c => c.Id).First();
        }

        public List<DHT> GetAllValues()
        {
            return _context.DHTs.Distinct().ToList();
        }

        public List<DHT> GetValuesByDate(TimeFilter timeFilter)
        {
            string sortOrder = timeFilter.SortOrder.ToUpper();
            List<DHT> results = new List<DHT>();

            if (sortOrder == "DESC")
            {
                results = _context.DHTs.Where(i => i.MeasureTime.Date >= timeFilter.DateBefore.Date && i.MeasureTime.Date <= timeFilter.DateAfter)
                                       .OrderByDescending(p => p.MeasureTime)
                                       .ToList();
            }
            else
            {
                results = _context.DHTs.Where(i => i.MeasureTime.Date >= timeFilter.DateBefore.Date && i.MeasureTime.Date <= timeFilter.DateAfter)
                                       .OrderBy(p => p.MeasureTime)
                                       .ToList();
            }
          
            return results;
           
        }

        public async Task<List<DHT>> UpdateSettings(int oldId, DHTConfig newDHT)
        {
            var dHTs = GetRowsBySensorId(oldId);

            foreach (var oldDht in dHTs)
            {
                DHT dht = new DHT();
                dht = oldDht;
                dht.BoxId = newDHT.BoxId;
                dht.DeviceId = newDHT.NewId;
                dht.Device = newDHT.Device;
                dht.DateModified = newDHT.DateModified;

                _context.DHTs.Update(dht);
                _context.SaveChanges();
            }
        

            var results = await _context.DHTs.ToListAsync();
            return results;
        }

        public List<DHT> GetRowsBySensorId(int id)
        {
            return _context.DHTs.Where(x => x.DeviceId == id).ToList();
        }
    }
}
