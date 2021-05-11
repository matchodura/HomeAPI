﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class Box
    {
        public int BoxId { get; set; }

        public string Name { get; set; }

        public ICollection<DHT> DHTs { get; set; }
    }
}
