using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces.Repositories
{
    public interface IHomeRepository
    {

        /// <summary>
        /// Returns current values for specific room by it's id
        /// </summary>
        /// <param name="roomID"></param>
        /// <returns></returns>
        public Task<Room> GetRoom(int roomID);

        /// <summary>
        /// Returns List of all Rooms with current data
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Room>> GetRooms();                     

        /// <summary>
        /// Creates new room
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public Task<Room> Create(Room room);

        /// <summary>
        /// Updates specified room
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public Task<Room> Update(Room room);

        /// <summary>
        /// Updates specified room with data records
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public Task<Room> UpdateRecords(Room room);

        /// <summary>
        /// Deletes specified room
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public Task<string> Delete(Room room);

          

    }
}
