﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Models
{
    public class DHT
    {
        public int Id { get; set; }


        [ForeignKey("BoxId")] 
        public int? BoxId { get; set; }       

        //public Box Box { get; set; }

        [JsonProperty("device")]
        public string Device { get; set; }

        [JsonProperty("temp")]
        public string Temperature { get; set; }

        [JsonProperty("humidity")]
        public string Humidity { get; set; }
        public DateTime? Date { get; set; }


     
    }
}
