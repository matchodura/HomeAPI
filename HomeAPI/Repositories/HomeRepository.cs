using HomeAPI.Data;
using HomeAPI.Interfaces.Repositories;
using HomeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly HomeContext _context;

        public HomeRepository(HomeContext context)
        {
            _context = context;
        }

        public string CreateRoom(Room room)
        {
            string message = "";
            bool roomExists = CheckIfRoomExists(room.Name);

            if (roomExists)
            {
                message = $"{room.Name} already exists!";
            }
            else
            {
                room.DateCreated = DateTime.Now;
                room.DateModified = DateTime.Now;

                _context.Rooms.Add(room);
                _context.SaveChanges();
                message = $"Room named: {room.Name} has been created!";
            }

            return message;
        }

        public string DeleteRoom(string roomName)
        {
            string message = "";
            bool roomExists = CheckIfRoomExists(roomName);

            if (roomExists)
            {
                var roomToRemove = _context.Rooms.SingleOrDefault(x => x.Name == roomName); 

                if (roomToRemove != null)
                {
                    _context.Rooms.Remove(roomToRemove);
                    _context.SaveChanges();
                }
            }
            else
            {
                message = $"{roomName} doesn't exist!";
            }

            return message;
        }

        public List<Room> GetAllRooms()
        {
            return _context.Rooms.Distinct().ToList();
        }

        public Room GetRoom(string roomName)
        {
            return _context.Rooms.SingleOrDefault(x => x.Name == roomName);
        }

        public Task<Room> UpdateRoom(string roomName)
        {
            throw new NotImplementedException();
        }

        #region Helper Methods

        /// <summary>
        /// Returns true if room exists, otherwise returns false
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        internal bool CheckIfRoomExists(string roomName)
        {        
            return _context.Rooms.Any(x => x.Name == roomName);
        }

        #endregion
    }
}
