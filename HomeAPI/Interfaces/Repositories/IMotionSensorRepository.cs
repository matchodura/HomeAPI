using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces.Repositories
{
    public interface IMotionSensorRepository
    {
        /// <summary>
        /// Get all readings in database
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<MotionSensor>> GetAllValues();

        /// <summary>
        /// Get all readings in database for specific time
        /// </summary>
        /// <param name="timeFilter"></param>
        /// <returns></returns>
        public Task<IEnumerable<MotionSensor>> GetValuesByDate(TimeFilter timeFilter);

        /// <summary>
        /// Get all reading for specified sensor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<IEnumerable<MotionSensor>> GetValuesForSpecificSensor(int id);

        /// <summary>
        /// Get last reading of specified sensor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<MotionSensor> GetLastRecord(int id);

        /// <summary>
        /// Get last readings of all sensors
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<MotionSensor>> GetLastRecords();

        public void InsertRecord(int boxId, DateTime dateTime);

    }
}
