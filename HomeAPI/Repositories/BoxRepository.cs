using HomeAPI.Data;
using HomeAPI.Helpers;
using HomeAPI.Interfaces;
using HomeAPI.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Box> Create(Box box)
        {
            box.DateCreated = DateTime.Now;
            box.DateModified = DateTime.Now;
            _context.Boxes.Add(box);
            await _context.SaveChangesAsync();

            return await _context.Boxes.SingleOrDefaultAsync(x => x.ID == box.ID);
        }

        public async Task<string> Delete(Box box)
        {
            var currentBox = _context.Boxes.Find(box.ID);

            _context.Boxes.Remove(currentBox);
            await _context.SaveChangesAsync();
            return "object deleted!";
        }

        public async Task<Box> GetBox(int boxId)
        {
            return await _context.Boxes.SingleOrDefaultAsync(x => x.ID == boxId);
        }

        public async Task<IEnumerable<Box>> GetBoxes()
        {
            return await _context.Boxes.Distinct().ToListAsync();
        }

        public async Task<Box> Update(Box box)
        {
            var currentBox = _context.Boxes.Find(box.ID);

            currentBox.DateModified = DateTime.Now;
            currentBox.BoxName = box.BoxName;
            currentBox.RoomId = box.RoomId;
            currentBox.BoxIP = box.BoxIP;

            _context.Boxes.Update(currentBox);
            await _context.SaveChangesAsync();

            return await _context.Boxes.SingleOrDefaultAsync(x => x.ID == box.ID);
        }
    }
}
