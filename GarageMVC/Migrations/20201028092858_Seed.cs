using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageMVC.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "UserName" },
                values: new object[] { 3, "bill@gmail.com", "Billy", "Buch", "BBch" });

            migrationBuilder.InsertData(
                table: "VehicleType2s",
                columns: new[] { "Id", "Name", "Size" },
                values: new object[] { 6, "Motorcycle", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleType2s",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
