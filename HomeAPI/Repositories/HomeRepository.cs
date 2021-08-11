using HomeAPI.Data;
using HomeAPI.Interfaces.Repositories;
using HomeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public string DeleteRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Room>> GetRoomsData()
        {
            return await _context.Rooms.Distinct().ToListAsync();
        }

        public Room GetRoom(int roomID)
        {
            return _context.Rooms.SingleOrDefault(x => x.ID == roomID);
        }

        public async Task<IEnumerable<Home>> GetRoomsList()
        {
            return await _context.Home.Distinct().ToListAsync();
        }

       
        public Room UpdateRoom(Room room)
        {
           //TODO
            var oldRoom = _context.Rooms.FirstOrDefault(item => item.HomeID == room.HomeID);
            var oldHome = _context.Home.FirstOrDefault(item => item.ID == room.HomeID);

            oldHome.Name = room.Name;
            oldRoom.Name = room.Name;
            oldRoom.DateModified = DateTime.Now;

            _context.Rooms.Update(room);
            _context.SaveChanges();

            _context.Home.Update(oldHome);
            _context.SaveChanges();


            return room;
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
