using Microsoft.EntityFrameworkCore;
using HomeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Data
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions<HomeContext> options) : base(options) { }

        public DbSet<Bulb> Bulbs { get; set; }

        public DbSet<BulbHistory> BulbsHistory { get; set; }

        public DbSet<DHT> DHTs { get; set; }

        public DbSet<Box> Boxes { get; set; }

        public DbSet<MotionSensor> MotionSensors { get; set; }
      
    }
}