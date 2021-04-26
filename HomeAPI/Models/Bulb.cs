using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class Bulb
    {
        public int Id { get; set; }
        public int? LampId { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public int? CommandCount { get; set; }
    }
}
