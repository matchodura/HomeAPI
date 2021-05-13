using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces.Repositories
{
    public interface IDHTRepository
    {
        public List<DHT> GetAllRecords();
        public List<DHT> GetRecordsByTime();
        public DHT GetLastRecord();
    }
}
