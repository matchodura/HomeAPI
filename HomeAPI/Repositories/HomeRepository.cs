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

        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _context.Rooms.Distinct().ToListAsync();
        }

        public async Task<Room> GetRoom(int roomID)
        {
            return await _context.Rooms.SingleOrDefaultAsync(x => x.ID == roomID);
        }

        public async Task Create(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }             

        public async Task Update(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Room room)
        {
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }
                            

    }
}
