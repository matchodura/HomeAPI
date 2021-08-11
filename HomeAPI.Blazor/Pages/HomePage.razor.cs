using HomeAPI.Blazor.Repositories;
using HomeAPI.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Blazor.Pages
{
    public partial class HomePage
    {
        public List<Home> HomeList { get; set; } = new List<Home>();
        [Inject]
        public IRoomHttpRepository RoomRepo { get; set; }
        protected async override Task OnInitializedAsync()
        {
            HomeList = await RoomRepo.GetRoomsList();
            //just for testing
            foreach (var room in HomeList)
            {
                Console.WriteLine(room.Name);
            }
        }
    }
}
