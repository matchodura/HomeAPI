﻿// <auto-generated />
using System;
using HomeAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeAPI.Migrations
{
    [DbContext(typeof(HomeContext))]
    [Migration("20210808174707_InitialHomeSeedWithRoomNames")]
    partial class InitialHomeSeedWithRoomNames
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("HomeAPI.Models.Box", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BoxName")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<int>("DHTId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("MotionSensorId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RoomId");

                    b.ToTable("Boxes");
                });

            modelBuilder.Entity("HomeAPI.Models.Bulb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CommandCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime");

                    b.Property<int?>("LampId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Bulbs");
                });

            modelBuilder.Entity("HomeAPI.Models.DHTSensorsensor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BoxId")
                        .HasColumnType("int");

                    b.Property<string>("CalledBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Device")
                        .HasColumnType("text");

                    b.Property<int?>("DeviceID")
                        .HasColumnType("int");

                    b.Property<float>("Humidity")
                        .HasColumnType("float");

                    b.Property<DateTime>("MeasureTime")
                        .HasColumnType("datetime");

                    b.Property<float>("Temperature")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("BoxId");

                    b.ToTable("DHTSensors");
                });

            modelBuilder.Entity("HomeAPI.Models.Home", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Home");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Klatka"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Korytarz_parter"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Kuchnia_parter"
                        },
                        new
                        {
                            ID = 4,
                            Name = "DuzyPokoj_parter"
                        },
                        new
                        {
                            ID = 5,
                            Name = "MalyPokoj_parter"
                        },
                        new
                        {
                            ID = 6,
                            Name = "Lazienka_parter"
                        },
                        new
                        {
                            ID = 7,
                            Name = "Sypialnia_parter"
                        },
                        new
                        {
                            ID = 8,
                            Name = "Lazienka_pietro"
                        },
                        new
                        {
                            ID = 9,
                            Name = "Korytarz_pietro"
                        },
                        new
                        {
                            ID = 10,
                            Name = "DuzyPokoj_pietro"
                        },
                        new
                        {
                            ID = 11,
                            Name = "Sypialnia_pietro"
                        },
                        new
                        {
                            ID = 12,
                            Name = "PokojMateusza_pietro"
                        },
                        new
                        {
                            ID = 13,
                            Name = "Strych"
                        },
                        new
                        {
                            ID = 14,
                            Name = "Piwnica"
                        });
                });

            modelBuilder.Entity("HomeAPI.Models.LightSensor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BoxId")
                        .HasColumnType("int");

                    b.Property<string>("CalledBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Device")
                        .HasColumnType("text");

                    b.Property<int?>("DeviceID")
                        .HasColumnType("int");

                    b.Property<float>("Luxes")
                        .HasColumnType("float");

                    b.Property<DateTime>("MeasureTime")
                        .HasColumnType("datetime");

                    b.HasKey("ID");

                    b.HasIndex("BoxId");

                    b.ToTable("LightSensors");
                });

            modelBuilder.Entity("HomeAPI.Models.MotionSensor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AlarmMessage")
                        .HasColumnType("text");

                    b.Property<int?>("BoxId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<string>("Device")
                        .HasColumnType("text");

                    b.Property<int?>("DeviceID")
                        .HasColumnType("int");

                    b.Property<DateTime>("MeasureTime")
                        .HasColumnType("datetime");

                    b.HasKey("ID");

                    b.HasIndex("BoxId");

                    b.ToTable("MotionSensors");
                });

            modelBuilder.Entity("HomeAPI.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AlarmMessage")
                        .HasColumnType("text");

                    b.Property<int>("BoxId")
                        .HasColumnType("int");

                    b.Property<string>("CalledBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedBy")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int?>("HomeID")
                        .HasColumnType("int");

                    b.Property<string>("Humidity")
                        .HasColumnType("text");

                    b.Property<float>("Luxes")
                        .HasColumnType("float");

                    b.Property<DateTime>("MeasureTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Temperature")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("HomeID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HomeAPI.Models.Box", b =>
                {
                    b.HasOne("HomeAPI.Models.Room", "Rooms")
                        .WithMany("Boxes")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HomeAPI.Models.DHTSensorsensor", b =>
                {
                    b.HasOne("HomeAPI.Models.Box", "Box")
                        .WithMany("DHTSensors")
                        .HasForeignKey("BoxId");

                    b.Navigation("Box");
                });

            modelBuilder.Entity("HomeAPI.Models.LightSensor", b =>
                {
                    b.HasOne("HomeAPI.Models.Box", "Box")
                        .WithMany("LightSensors")
                        .HasForeignKey("BoxId");

                    b.Navigation("Box");
                });

            modelBuilder.Entity("HomeAPI.Models.MotionSensor", b =>
                {
                    b.HasOne("HomeAPI.Models.Box", "Box")
                        .WithMany("MotionSensors")
                        .HasForeignKey("BoxId");

                    b.Navigation("Box");
                });

            modelBuilder.Entity("HomeAPI.Models.Room", b =>
                {
                    b.HasOne("HomeAPI.Models.Home", "Home")
                        .WithMany("Rooms")
                        .HasForeignKey("HomeID");

                    b.Navigation("Home");
                });

            modelBuilder.Entity("HomeAPI.Models.Box", b =>
                {
                    b.Navigation("DHTSensors");

                    b.Navigation("LightSensors");

                    b.Navigation("MotionSensors");
                });

            modelBuilder.Entity("HomeAPI.Models.Home", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HomeAPI.Models.Room", b =>
                {
                    b.Navigation("Boxes");
                });
#pragma warning restore 612, 618
        }
    }
}
