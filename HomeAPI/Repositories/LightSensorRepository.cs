using HomeAPI.Data;
using HomeAPI.Helpers;
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

        public async Task<IEnumerable<LightSensor>> GetAllValues()
        {
            return await _context.LightSensors.Distinct().ToListAsync();
        }

        public async Task<IEnumerable<LightSensor>> GetValuesByDate(TimeFilter timeFilter)
        {
            string v = timeFilter.SortOrder.ToUpper();
            string sortOrder = v;
            List<LightSensor> results = new List<LightSensor>();

            if (sortOrder == "DESC")
            {
                results = await _context.LightSensors.Where(i => i.MeasureTime.Date >= timeFilter.DateBefore.Date && i.MeasureTime.Date <= timeFilter.DateAfter)
                                       .OrderByDescending(p => p.MeasureTime)
                                       .ToListAsync();
            }
            else
            {
                results = await _context.LightSensors.Where(i => i.MeasureTime.Date >= timeFilter.DateBefore.Date && i.MeasureTime.Date <= timeFilter.DateAfter)
                                       .OrderBy(p => p.MeasureTime)
                                       .ToListAsync();
            }

            return results;

        }

        public async Task<IEnumerable<LightSensor>> GetValuesForSpecificSensor(int id)
        {
            return await _context.LightSensors.Where(x => x.DeviceID == id).ToListAsync();
        }

        public async Task<LightSensor> GetLastRecord(int id)
        {
            return await _context.LightSensors.Where(x => x.DeviceID == id).OrderByDescending(c => c.ID).FirstAsync();
        }

        public async Task<IEnumerable<LightSensor>> GetLastRecords()
        {
            return await _context.LightSensors
                          .GroupBy(x => x.DeviceID)
                          .Select(g => g.Last())
                          .ToListAsync();
        }

        public async Task<IEnumerable<LightSensor>> SortValues(string sortBy, string sortOrder)
        {
            return await _context.LightSensors.AsQueryable().OrderByPropertyName(sortBy, sortOrder).ToListAsync();
        }
    }
}
