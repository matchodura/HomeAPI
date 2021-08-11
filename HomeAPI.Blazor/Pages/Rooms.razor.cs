using HomeAPI.Blazor.Repositories;
using HomeAPI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Blazor.Pages
{
    public partial class Rooms
    {
        public List<Room> RoomsList { get; set; } = new List<Room>();
        [Inject]
        public IRoomHttpRepository RoomRepo { get; set; }
        protected async override Task OnInitializedAsync()
        {
            RoomsList = await RoomRepo.GetRoomsData();
            //just for testing
            foreach (var room in RoomsList)
            {
                Console.WriteLine(room.Name);
            }
        }
    }
}
