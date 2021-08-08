﻿using Microsoft.EntityFrameworkCore;
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

        public DbSet<DHTSensorsensor> DHTSensors { get; set; }

        public DbSet<Box> Boxes { get; set; }

        public DbSet<MotionSensor> MotionSensors { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<LightSensor> LightSensors { get; set; }

        public DbSet<Home> Home { get; set; }
              

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Home>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).IsRequired();             
            });

            #region HomeSeed
            modelBuilder.Entity<Home>().HasData(
                new Home { ID = 1, Name = "Klatka" },
                new Home { ID = 2, Name = "Korytarz_parter" },
                new Home { ID = 3, Name = "Kuchnia_parter" },
                new Home { ID = 4, Name = "DuzyPokoj_parter" },
                new Home { ID = 5, Name = "MalyPokoj_parter" },
                new Home { ID = 6, Name = "Lazienka_parter" },
                new Home { ID = 7, Name = "Sypialnia_parter" },
                new Home { ID = 8, Name = "Lazienka_pietro" },
                new Home { ID = 9, Name = "Korytarz_pietro" },
                new Home { ID = 10, Name = "DuzyPokoj_pietro" },
                new Home { ID = 11, Name = "Sypialnia_pietro" },
                new Home { ID = 12, Name = "PokojMateusza_pietro" },
                new Home { ID = 13, Name = "Strych" },
                new Home { ID = 14, Name = "Piwnica" }
                );
            #endregion

            #region RoomSeed
            modelBuilder.Entity<Room>().HasData(
                new Room { ID = 1, HomeID = 1, Name = "Klatka" },
                new Room { ID = 2, HomeID = 2, Name = "Korytarz_parter" },
                new Room { ID = 3, HomeID = 3, Name = "Kuchnia_parter" },
                new Room { ID = 4, HomeID = 4, Name = "DuzyPokoj_parter" },
                new Room { ID = 5, HomeID = 5, Name = "MalyPokoj_parter" },
                new Room { ID = 6, HomeID = 6, Name = "Lazienka_parter" },
                new Room { ID = 7, HomeID = 7, Name = "Sypialnia_parter" },
                new Room { ID = 8, HomeID = 8, Name = "Lazienka_pietro" },
                new Room { ID = 9, HomeID = 9, Name = "Korytarz_pietro" },
                new Room { ID = 10, HomeID = 10, Name = "DuzyPokoj_pietro" },
                new Room { ID = 11, HomeID = 11, Name = "Sypialnia_pietro" },
                new Room { ID = 12, HomeID = 12, Name = "PokojMateusza_pietro" },
                new Room { ID = 13, HomeID = 13, Name = "Strych" },
                new Room { ID = 14, HomeID = 14, Name = "Piwnica" }
                );
            #endregion
        }

    }
}