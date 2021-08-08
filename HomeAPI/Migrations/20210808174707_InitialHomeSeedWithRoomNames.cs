using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeAPI.Migrations
{
    public partial class InitialHomeSeedWithRoomNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Home",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Klatka" },
                    { 2, "Korytarz_parter" },
                    { 3, "Kuchnia_parter" },
                    { 4, "DuzyPokoj_parter" },
                    { 5, "MalyPokoj_parter" },
                    { 6, "Lazienka_parter" },
                    { 7, "Sypialnia_parter" },
                    { 8, "Lazienka_pietro" },
                    { 9, "Korytarz_pietro" },
                    { 10, "DuzyPokoj_pietro" },
                    { 11, "Sypialnia_pietro" },
                    { 12, "PokojMateusza_pietro" },
                    { 13, "Strych" },
                    { 14, "Piwnica" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Home",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Home",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Home",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Home",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Home",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Home",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Home",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Home",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Home",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Home",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Home",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Home",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Home",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Home",
                keyColumn: "ID",
                keyValue: 14);
        }
    }
}
