using HomeAPI.Data;
using HomeAPI.Interfaces;
using HomeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Controllers
{
    public class BoxController : Controller, IBoxRepository
    {
        private readonly HomeContext _context;

        public BoxController(HomeContext context)
        {         
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public bool AddNewBox()
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
                
        public Box UpdateBox(Box currentBox)
        {
            throw new NotImplementedException();
        }
    }
}
