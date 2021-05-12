using HomeAPI.Data;
using HomeAPI.Interfaces;
using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Repositories
{
    public class BoxRepository : IBoxRepository
    {
        private readonly HomeContext _context;


        public BoxRepository(HomeContext context)
        {
            _context = context;
        }

        public bool CreateBox()
        {
            throw new NotImplementedException();
        }

        public bool DeleteBox()
        {
            throw new NotImplementedException();
        }

        public List<Box> GetAllBoxes()
        {
            throw new NotImplementedException();
        }

        public Box GetBoxById(int boxId)
        {
            throw new NotImplementedException();
        }

        public Box GetBoxByName(string boxName)
        {
            throw new NotImplementedException();
        }

        public Box UpdateBox(int boxId, string boxName)
        {
            throw new NotImplementedException();
        }
    }
}
