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
    [Route("api/[controller]")]
    public class BoxController : Controller
    {
        private readonly HomeContext _context;
        private readonly IBoxRepository _boxRepository;


        public BoxController(HomeContext context, IBoxRepository boxRepository)
        {         
            _context = context;
            _boxRepository = boxRepository;
        }


        public IActionResult Index()
        {
            return View();
        }


       
    }
}
