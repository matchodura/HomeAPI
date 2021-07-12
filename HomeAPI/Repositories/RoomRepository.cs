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
        public Task<Room> GetAllData()
        {
            throw new NotImplementedException();
        }
    }
}
