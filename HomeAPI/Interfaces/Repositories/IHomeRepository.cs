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
        public List<Room> GetAllRooms();
            
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
        public string DeleteRoom(string roomName);

        /// <summary>
        /// Updates specified room
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public Task<Room> UpdateRoom(string roomName);

        public List<Home> GetRoomsNames();

    }
}
