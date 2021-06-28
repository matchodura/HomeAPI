using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class DHTConfig
    {     
        public int CurrentId { get; set; }

        public int NewId { get; set; }

        public int BoxId { get; set; }

        public string Device { get; set; }

        public DateTime DateModified { get; set; } = DateTime.Now;
    }
}
