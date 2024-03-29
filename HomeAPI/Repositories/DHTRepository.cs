﻿using HomeAPI.Data;
using HomeAPI.Helpers;
using HomeAPI.Interfaces.Repositories;
using HomeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

        public async Task<IEnumerable<DHTSensor>> GetAllValues()
        {
            return await _context.DHTSensors.Distinct().ToListAsync();
        }

        public async Task<IEnumerable<DHTSensor>> GetValuesByDate(TimeFilter timeFilter)
        {
            string sortOrder = timeFilter.SortOrder.ToUpper();
            List<DHTSensor> results = new List<DHTSensor>();

            if (sortOrder == "DESC")
            {
                results = await _context.DHTSensors.Where(i => i.MeasureTime.Date >= timeFilter.DateBefore.Date && i.MeasureTime.Date <= timeFilter.DateAfter)
                                       .OrderByDescending(p => p.MeasureTime)
                                       .ToListAsync();
            }
            else
            {
                results =await  _context.DHTSensors.Where(i => i.MeasureTime.Date >= timeFilter.DateBefore.Date && i.MeasureTime.Date <= timeFilter.DateAfter)
                                       .OrderBy(p => p.MeasureTime)
                                       .ToListAsync();
            }

            return results;

        }

        public async Task<IEnumerable<DHTSensor>> GetValuesForSpecificSensor(int id)
        {
            return await _context.DHTSensors.Where(x => x.DeviceID == id).ToListAsync();
        }

        public async Task<DHTSensor> GetLastRecord(int id)
        {
            return await _context.DHTSensors.Where(x=> x.DeviceID == id).OrderByDescending(c => c.ID).FirstAsync();
        }

        public async Task<IEnumerable<DHTSensor>> GetLastRecords()
        {       

            return await _context.DHTSensors
                          .GroupBy(x => x.DeviceID)
                          .Select(g => g.Last())
                          .ToListAsync();
        }

        public async Task<IEnumerable<DHTSensor>> SortValues(string sortBy, string sortOrder)
        {                 
            return  await _context.DHTSensors.AsQueryable().OrderByPropertyName(sortBy, sortOrder).ToListAsync();
        }
    }
}
