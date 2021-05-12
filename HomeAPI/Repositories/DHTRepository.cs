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
            throw new NotImplementedException();
        }

        public List<DHT> GetRecordsByTime()
        {
            throw new NotImplementedException();
        }
    }
}
