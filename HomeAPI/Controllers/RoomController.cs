using HomeAPI.Data;
using HomeAPI.Interfaces.Repositories;
using HomeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
          
        public IActionResult Index()
        {
            return View();
        }


        private readonly HomeContext _context;
        private readonly IRoomRepository _roomRepository;

        public RoomController(HomeContext context, IRoomRepository roomRepository)
        {
            _context = context;
            _roomRepository = roomRepository;
        }


        [Route("CurrentValues")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CheckDHT()
        {
            string responseMessage = "";
            string clientAdress = Constants.Constants.NODEMCU_IP_ADDRESS;
            int timeout = 10;

            var client = new HttpClient()
            {

                BaseAddress = new Uri(clientAdress),
                Timeout = TimeSpan.FromSeconds(timeout)
            };

            Room room = new Room();

            try
            {
                HttpResponseMessage response = await client.GetAsync(clientAdress + "/AllValues");
                response.EnsureSuccessStatusCode();
                responseMessage = await response.Content.ReadAsStringAsync();

                if (response != null)
                {
                    room = JsonConvert.DeserializeObject<Room>(responseMessage);
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);

                responseMessage = e.Message;
            }      


            return Json(responseMessage);
        }

        //TODO
        [Route("GetAllValues")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSaveValues()
        {
            string responseMessage = "";
            string clientAdress = Constants.Constants.NODEMCU_IP_ADDRESS;
            int timeout = 10;

            var client = new HttpClient()
            {

                BaseAddress = new Uri(clientAdress),
                Timeout = TimeSpan.FromSeconds(timeout)
            };

            Room room = new Room();

            try
            {
                HttpResponseMessage response = await client.GetAsync(clientAdress + "/AllValues");
                response.EnsureSuccessStatusCode();
                responseMessage = await response.Content.ReadAsStringAsync();

                if (response != null)
                {
                    room = JsonConvert.DeserializeObject<Room>(responseMessage);
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);

                responseMessage = e.Message;
            }


            bool alreadyExists = _context.Rooms.Any(x => x.Name == room.Name);


            room.MeasureTime = DateTime.Now;
            room.CalledBy = "user";

            if (alreadyExists)
            {
                room.ID = _context.Rooms.SingleOrDefault(x => x.Name == room.Name).ID;
                _context.Rooms.Update(room);
                _context.SaveChanges();
            }

            else
            {
                //box id will be changed in the future
                
                _context.Rooms.Add(room);
                _context.SaveChanges();
            }
            


            return Json(responseMessage);
        }


    }
}
