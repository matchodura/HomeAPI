using HomeAPI.Data;
using HomeAPI.Interfaces.Repositories;
using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HomeContext _context;

        public RoomRepository(HomeContext context)
        {
            _context = context;
        }

        public Room GetRoomData(int roomID)
        {
            return _context.Rooms.FirstOrDefault(x => x.ID == roomID);
        }
    }
}
