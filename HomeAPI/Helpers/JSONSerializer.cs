using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace HomeAPI.Helpers
{
    public static class JSONSerializer
    {
        public static string SerializeObject(object input)
        {                      
            return JsonSerializer.Serialize(input);
        }

    }
}
