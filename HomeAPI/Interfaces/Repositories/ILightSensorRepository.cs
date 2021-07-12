using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces.Repositories
{
    public interface ILightSensorRepository
    {
        public List<LightSensor> GetAllValues();
        public List<LightSensor> GetValuesByDate(TimeFilter timeFilter);
        public LightSensor GetLastRecord();
        public Task<List<LightSensor>> UpdateSettings(int oldId, DHTConfig newDHT);
        public List<LightSensor> GetRowsBySensorId(int id);
    }
}
