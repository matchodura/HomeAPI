﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace HomeAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bulbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LampId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    CommandCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bulbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BoxId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    MeasureTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Temperature = table.Column<string>(type: "text", nullable: true),
                    Humidity = table.Column<string>(type: "text", nullable: true),
                    Luxes = table.Column<float>(type: "float", nullable: false),
                    AlarmMessage = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Boxes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BoxName = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    DHTId = table.Column<int>(type: "int", nullable: false),
                    MotionSensorId = table.Column<int>(type: "int", nullable: false),
                    LightSensorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Boxes_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DHTSensors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BoxID = table.Column<int>(type: "int", nullable: true),
                    DeviceID = table.Column<int>(type: "int", nullable: false),
                    Temperature = table.Column<float>(type: "float", nullable: false),
                    SensorType = table.Column<string>(type: "text", nullable: true),
                    Humidity = table.Column<float>(type: "float", nullable: false),
                    CalledBy = table.Column<string>(type: "text", nullable: true),
                    MeasureTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DHTSensors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DHTSensors_Boxes_BoxID",
                        column: x => x.BoxID,
                        principalTable: "Boxes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LightSensors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BoxID = table.Column<int>(type: "int", nullable: true),
                    DeviceID = table.Column<int>(type: "int", nullable: false),
                    Luxes = table.Column<float>(type: "float", nullable: false),
                    CalledBy = table.Column<string>(type: "text", nullable: true),
                    MeasureTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightSensors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LightSensors_Boxes_BoxID",
                        column: x => x.BoxID,
                        principalTable: "Boxes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotionSensors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    BoxID = table.Column<int>(type: "int", nullable: true),
                    DeviceID = table.Column<int>(type: "int", nullable: false),
                    AlarmMessage = table.Column<string>(type: "text", nullable: true),
                    AlarmTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotionSensors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MotionSensors_Boxes_BoxID",
                        column: x => x.BoxID,
                        principalTable: "Boxes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "ID", "AlarmMessage", "BoxId", "CreatedBy", "DateCreated", "DateModified", "Humidity", "Luxes", "MeasureTime", "Name", "Temperature" },
                values: new object[,]
                {
                    { 1, null, 0, "Mateusz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Klatka", null },
                    { 2, null, 0, "Mateusz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Korytarz_parter", null },
                    { 3, null, 0, "Mateusz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kuchnia_parter", null },
                    { 4, null, 0, "Mateusz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DuzyPokoj_parter", null },
                    { 5, null, 0, "Mateusz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MalyPokoj_parter", null },
                    { 6, null, 0, "Mateusz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lazienka_parter", null },
                    { 7, null, 0, "Mateusz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sypialnia_parter", null },
                    { 8, null, 0, "Mateusz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lazienka_pietro", null },
                    { 9, null, 0, "Mateusz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Korytarz_pietro", null },
                    { 10, null, 0, "Mateusz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DuzyPokoj_pietro", null },
                    { 11, null, 0, "Mateusz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sypialnia_pietro", null },
                    { 12, null, 0, "Mateusz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PokojMateusza_pietro", null },
                    { 13, null, 0, "Mateusz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Strych", null },
                    { 14, null, 0, "Mateusz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piwnica", null }
                });

            migrationBuilder.InsertData(
                table: "Boxes",
                columns: new[] { "ID", "BoxName", "CreatedBy", "DHTId", "DateCreated", "DateModified", "LightSensorID", "MotionSensorId", "RoomId" },
                values: new object[] { 1, "box_1", "Mateusz", 0, new DateTime(2021, 8, 15, 13, 39, 13, 491, DateTimeKind.Local).AddTicks(4557), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, 1 });

            migrationBuilder.InsertData(
                table: "Boxes",
                columns: new[] { "ID", "BoxName", "CreatedBy", "DHTId", "DateCreated", "DateModified", "LightSensorID", "MotionSensorId", "RoomId" },
                values: new object[] { 2, "box_2", "Mateusz", 0, new DateTime(2021, 8, 15, 13, 39, 13, 494, DateTimeKind.Local).AddTicks(71), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_RoomId",
                table: "Boxes",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_DHTSensors_BoxID",
                table: "DHTSensors",
                column: "BoxID");

            migrationBuilder.CreateIndex(
                name: "IX_LightSensors_BoxID",
                table: "LightSensors",
                column: "BoxID");

            migrationBuilder.CreateIndex(
                name: "IX_MotionSensors_BoxID",
                table: "MotionSensors",
                column: "BoxID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bulbs");

            migrationBuilder.DropTable(
                name: "DHTSensors");

            migrationBuilder.DropTable(
                name: "LightSensors");

            migrationBuilder.DropTable(
                name: "MotionSensors");

            migrationBuilder.DropTable(
                name: "Boxes");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
