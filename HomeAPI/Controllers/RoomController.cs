using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Controllers
{
    public class RoomController : Controller
    {
        [Route("api/[controller]")]       
        public IActionResult Index()
        {
            return View();
        }
    }
}
