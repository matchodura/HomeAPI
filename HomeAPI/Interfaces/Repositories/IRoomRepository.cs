using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces.Repositories
{
    public interface IRoomRepository
    {
        /// <summary>
        /// Gets values for specific room
        /// </summary>
        /// <returns></returns>
        public Room GetRoomData(int roomID);
    }
}
