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

        public async Task<Room> GetRoom(int roomID)
        {
            return await _context.Rooms.SingleOrDefaultAsync(x => x.ID == roomID);
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _context.Rooms.Distinct().ToListAsync();
        }            

        public async Task<Room> Create(Room room)
        {
            room.DateCreated = DateTime.Now;
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return await _context.Rooms.SingleOrDefaultAsync(x => x.ID == room.ID);
        }             

        public async Task<Room> Update(Room room)
        {
            var currentRoom = _context.Rooms.Find(room.ID);

            currentRoom.DateModified = DateTime.Now;
            currentRoom.Name = room.Name;
            currentRoom.BoxId = room.BoxId;     
            
            _context.Rooms.Update(currentRoom);
            await _context.SaveChangesAsync();

            return await _context.Rooms.SingleOrDefaultAsync(x => x.ID == room.ID);
        }

        public async Task<Room> UpdateRecords(Room room)
        {
            var currentRoom = _context.Rooms.Find(room.ID);

            currentRoom.MeasureTime = DateTime.Now;               

            _context.Rooms.Update(currentRoom);
            await _context.SaveChangesAsync();

            return await _context.Rooms.SingleOrDefaultAsync(x => x.ID == room.ID);
        }


        public async Task<string> Delete(Room room)
        {
            var currentRoom = _context.Rooms.Find(room.ID);

            _context.Rooms.Remove(currentRoom);
            await _context.SaveChangesAsync();
            return "object deleted!";
        }                            

    }
}
