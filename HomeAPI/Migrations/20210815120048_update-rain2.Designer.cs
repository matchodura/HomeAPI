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
    [Migration("20210815120048_update-rain2")]
    partial class updaterain2
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

                    b.Property<int>("LightSensorID")
                        .HasColumnType("int");

                    b.Property<int>("MotionSensorId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RoomId");

                    b.ToTable("Boxes");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            BoxName = "box_1",
                            CreatedBy = "Mateusz",
                            DHTId = 0,
                            DateCreated = new DateTime(2021, 8, 15, 14, 0, 47, 500, DateTimeKind.Local).AddTicks(2100),
                            DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LightSensorID = 0,
                            MotionSensorId = 0,
                            RoomId = 1
                        },
                        new
                        {
                            ID = 2,
                            BoxName = "box_2",
                            CreatedBy = "Mateusz",
                            DHTId = 0,
                            DateCreated = new DateTime(2021, 8, 15, 14, 0, 47, 502, DateTimeKind.Local).AddTicks(8735),
                            DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LightSensorID = 0,
                            MotionSensorId = 0,
                            RoomId = 2
                        });
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

            modelBuilder.Entity("HomeAPI.Models.DHTSensor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BoxID")
                        .HasColumnType("int");

                    b.Property<string>("CalledBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("DeviceID")
                        .HasColumnType("int");

                    b.Property<float>("Humidity")
                        .HasColumnType("float");

                    b.Property<DateTime>("MeasureTime")
                        .HasColumnType("datetime");

                    b.Property<string>("SensorType")
                        .HasColumnType("text");

                    b.Property<float>("Temperature")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("BoxID");

                    b.ToTable("DHTSensors");
                });

            modelBuilder.Entity("HomeAPI.Models.LightSensor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BoxID")
                        .HasColumnType("int");

                    b.Property<string>("CalledBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("DeviceID")
                        .HasColumnType("int");

                    b.Property<float>("Luxes")
                        .HasColumnType("float");

                    b.Property<DateTime>("MeasureTime")
                        .HasColumnType("datetime");

                    b.Property<string>("SensorType")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("BoxID");

                    b.ToTable("LightSensors");
                });

            modelBuilder.Entity("HomeAPI.Models.MotionSensor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AlarmMessage")
                        .HasColumnType("text");

                    b.Property<DateTime>("AlarmTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("BoxID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("DeviceID")
                        .HasColumnType("int");

                    b.Property<string>("SensorType")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("BoxID");

                    b.ToTable("MotionSensors");
                });

            modelBuilder.Entity("HomeAPI.Models.RainSensor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("BoxID")
                        .HasColumnType("int");

                    b.Property<string>("CalledBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<int>("DeviceID")
                        .HasColumnType("int");

                    b.Property<DateTime>("MeasureTime")
                        .HasColumnType("datetime");

                    b.Property<int>("Rain")
                        .HasColumnType("int");

                    b.Property<string>("SensorType")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("BoxID");

                    b.ToTable("RainSensors");
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

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

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

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            BoxId = 0,
                            CreatedBy = "Mateusz",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Luxes = 0f,
                            MeasureTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Klatka"
                        },
                        new
                        {
                            ID = 2,
                            BoxId = 0,
                            CreatedBy = "Mateusz",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Luxes = 0f,
                            MeasureTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Korytarz_parter"
                        },
                        new
                        {
                            ID = 3,
                            BoxId = 0,
                            CreatedBy = "Mateusz",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Luxes = 0f,
                            MeasureTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kuchnia_parter"
                        },
                        new
                        {
                            ID = 4,
                            BoxId = 0,
                            CreatedBy = "Mateusz",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Luxes = 0f,
                            MeasureTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "DuzyPokoj_parter"
                        },
                        new
                        {
                            ID = 5,
                            BoxId = 0,
                            CreatedBy = "Mateusz",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Luxes = 0f,
                            MeasureTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "MalyPokoj_parter"
                        },
                        new
                        {
                            ID = 6,
                            BoxId = 0,
                            CreatedBy = "Mateusz",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Luxes = 0f,
                            MeasureTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Lazienka_parter"
                        },
                        new
                        {
                            ID = 7,
                            BoxId = 0,
                            CreatedBy = "Mateusz",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Luxes = 0f,
                            MeasureTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sypialnia_parter"
                        },
                        new
                        {
                            ID = 8,
                            BoxId = 0,
                            CreatedBy = "Mateusz",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Luxes = 0f,
                            MeasureTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Lazienka_pietro"
                        },
                        new
                        {
                            ID = 9,
                            BoxId = 0,
                            CreatedBy = "Mateusz",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Luxes = 0f,
                            MeasureTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Korytarz_pietro"
                        },
                        new
                        {
                            ID = 10,
                            BoxId = 0,
                            CreatedBy = "Mateusz",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Luxes = 0f,
                            MeasureTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "DuzyPokoj_pietro"
                        },
                        new
                        {
                            ID = 11,
                            BoxId = 0,
                            CreatedBy = "Mateusz",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Luxes = 0f,
                            MeasureTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sypialnia_pietro"
                        },
                        new
                        {
                            ID = 12,
                            BoxId = 0,
                            CreatedBy = "Mateusz",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Luxes = 0f,
                            MeasureTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "PokojMateusza_pietro"
                        },
                        new
                        {
                            ID = 13,
                            BoxId = 0,
                            CreatedBy = "Mateusz",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Luxes = 0f,
                            MeasureTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Strych"
                        },
                        new
                        {
                            ID = 14,
                            BoxId = 0,
                            CreatedBy = "Mateusz",
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateModified = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Luxes = 0f,
                            MeasureTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Piwnica"
                        });
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

            modelBuilder.Entity("HomeAPI.Models.DHTSensor", b =>
                {
                    b.HasOne("HomeAPI.Models.Box", "Box")
                        .WithMany("DHTSensors")
                        .HasForeignKey("BoxID");

                    b.Navigation("Box");
                });

            modelBuilder.Entity("HomeAPI.Models.LightSensor", b =>
                {
                    b.HasOne("HomeAPI.Models.Box", "Box")
                        .WithMany("LightSensors")
                        .HasForeignKey("BoxID");

                    b.Navigation("Box");
                });

            modelBuilder.Entity("HomeAPI.Models.MotionSensor", b =>
                {
                    b.HasOne("HomeAPI.Models.Box", "Box")
                        .WithMany("MotionSensors")
                        .HasForeignKey("BoxID");

                    b.Navigation("Box");
                });

            modelBuilder.Entity("HomeAPI.Models.RainSensor", b =>
                {
                    b.HasOne("HomeAPI.Models.Box", "Box")
                        .WithMany("RainSensors")
                        .HasForeignKey("BoxID");

                    b.Navigation("Box");
                });

            modelBuilder.Entity("HomeAPI.Models.Box", b =>
                {
                    b.Navigation("DHTSensors");

                    b.Navigation("LightSensors");

                    b.Navigation("MotionSensors");

                    b.Navigation("RainSensors");
                });

            modelBuilder.Entity("HomeAPI.Models.Room", b =>
                {
                    b.Navigation("Boxes");
                });
#pragma warning restore 612, 618
        }
    }
}
