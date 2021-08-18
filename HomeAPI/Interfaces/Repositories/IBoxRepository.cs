using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Interfaces
{
    public interface IBoxRepository
    {
        public Task<Box> GetBox(int boxId);
        public Task<IEnumerable<Box>> GetBoxes();  
        public Task<Box> Create(Box box);
        public Task<Box> Update(Box box);
        public Task<string> Delete(Box box);

    }
}
