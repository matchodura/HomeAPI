using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces.Repositories
{
    public interface IDHTRepository
    {      
        public List<DHTSensor> GetAllValues();
        public List<DHTSensor> GetValuesByDate(TimeFilter timeFilter);
        public DHTSensor GetLastRecord();
        public Task<List<DHTSensor>> UpdateSettings(int oldId, DHTConfig newDHT);
        public List<DHTSensor> GetRowsBySensorId(int id);
    }
}
