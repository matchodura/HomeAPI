using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces.Repositories
{
    public interface IDHTRepository
    {      
        public List<DHTSensorsensor> GetAllValues();
        public List<DHTSensorsensor> GetValuesByDate(TimeFilter timeFilter);
        public DHTSensorsensor GetLastRecord();
        public Task<List<DHTSensorsensor>> UpdateSettings(int oldId, DHTConfig newDHT);
        public List<DHTSensorsensor> GetRowsBySensorId(int id);
    }
}
