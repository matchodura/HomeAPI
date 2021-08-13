using HomeAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HomeAPI.Blazor.Repositories
{
    public class RoomHttpRepository : IRoomHttpRepository
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;
        public RoomHttpRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<Room>> GetRoomsData()
        {
            var response = await _client.GetAsync("home/data");
            var content = await response.Content.ReadAsStringAsync();
            
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
                  
            var products = JsonConvert.DeserializeObject<List<Room>>(content);
            Console.WriteLine(products);
            return products;
        }


        public async Task<List<Room>> UpdateRoom()
        {
            var response = await _client.GetAsync("home/update");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var products = JsonConvert.DeserializeObject<List<Room>>(content);
            Console.WriteLine(products);
            return products;
        }
    }
}
