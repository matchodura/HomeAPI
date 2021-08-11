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
        /// Returns List of all Rooms with current data
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Room>> GetRoomsData();

        /// <summary>
        /// Gets names of rooms in home
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Home>> GetRoomsList();

        /// <summary>
        /// Returns current values for specific room by it's id
        /// </summary>
        /// <param name="roomID"></param>
        /// <returns></returns>
        public Room GetRoom(int roomID);

        /// <summary>
        /// Creates new room
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public string CreateRoom(Room room);

        /// <summary>
        /// Deletes specified room
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public string DeleteRoom(Room room);

        /// <summary>
        /// Updates specified room
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public Room UpdateRoom(Room room);

        

    }
}
