using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Blazor.Repositories
{
    public interface IRoomHttpRepository
    {
        Task<List<Room>> GetRoomsData();
        Task<List<Home>> GetRoomsList();
    }
}
