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

        public DbSet<DHTSensor> DHTSensors { get; set; }

        public DbSet<Box> Boxes { get; set; }

        public DbSet<MotionSensor> MotionSensors { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<LightSensor> LightSensors { get; set; }
                    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                     
            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired();             
            });

            #region RoomSeed
            modelBuilder.Entity<Room>().HasData(
                new Room { ID = 1, Name = "Klatka" },
                new Room { ID = 2, Name = "Korytarz_parter" },
                new Room { ID = 3, Name = "Kuchnia_parter" },
                new Room { ID = 4, Name = "DuzyPokoj_parter" },
                new Room { ID = 5, Name = "MalyPokoj_parter" },
                new Room { ID = 6, Name = "Lazienka_parter" },
                new Room { ID = 7, Name = "Sypialnia_parter" },
                new Room { ID = 8, Name = "Lazienka_pietro" },
                new Room { ID = 9, Name = "Korytarz_pietro" },
                new Room { ID = 10, Name = "DuzyPokoj_pietro" },
                new Room { ID = 11, Name = "Sypialnia_pietro" },
                new Room { ID = 12, Name = "PokojMateusza_pietro" },
                new Room { ID = 13, Name = "Strych" },
                new Room { ID = 14, Name = "Piwnica" }
                );
            #endregion
        }

    }
}