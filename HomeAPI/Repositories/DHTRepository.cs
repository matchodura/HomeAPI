using HomeAPI.Data;
using HomeAPI.Interfaces.Repositories;
using HomeAPI.Models;
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
    }
}
