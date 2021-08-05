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

        public DbSet<Room> Rooms { get; set; }

        public DbSet<LightSensor> LightSensors { get; set; }

        public DbSet<Home> Home { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySQL("Server=192.168.1.181; Port=3306; Database=homeapi; User=test2;Password=test;");
        //}

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
                entity.HasOne(d => d.Home)
                  .WithMany(p => p.Rooms);
            });
        }

    }
}