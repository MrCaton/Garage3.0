using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageMVC.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkedVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<int>(nullable: false),
                    LicenceNr = table.Column<string>(maxLength: 6, nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(maxLength: 15, nullable: true),
                    Model = table.Column<string>(maxLength: 50, nullable: true),
                    NrOfWheels = table.Column<int>(nullable: false),
                    ArrivalTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkedVehicle", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "ArrivalTime", "Brand", "Color", "LicenceNr", "Model", "NrOfWheels", "VehicleType" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 13, 9, 46, 3, 739, DateTimeKind.Local).AddTicks(3895), "Volkswagen", "Grey", "BIL111", "Golf", 4, 0 },
                    { 2, new DateTime(2020, 10, 13, 9, 46, 3, 747, DateTimeKind.Local).AddTicks(9852), "Ducati", "Red", "MOT111", "Retro", 2, 1 },
                    { 3, new DateTime(2020, 10, 12, 9, 46, 3, 747, DateTimeKind.Local).AddTicks(9978), "Boeing", "White", "AIR111", "777", 12, 3 },
                    { 4, new DateTime(2020, 10, 11, 9, 46, 3, 747, DateTimeKind.Local).AddTicks(9992), "Bertram", "White", "BOA111", "31 Flybridge Cruiser", 0, 4 },
                    { 5, new DateTime(2020, 10, 10, 9, 46, 3, 748, DateTimeKind.Local).AddTicks(2), "Mercedes Benz", "Red", "BUS111", "Citario", 4, 2 },
                    { 6, new DateTime(2020, 10, 9, 9, 46, 3, 748, DateTimeKind.Local).AddTicks(13), "Mercedes Benz", "Black", "BIL222", "C-Class", 4, 0 },
                    { 7, new DateTime(2020, 10, 8, 9, 46, 3, 748, DateTimeKind.Local).AddTicks(25), "BMW", "Green", "MOT222", "S 1000 RR", 2, 1 },
                    { 8, new DateTime(2020, 10, 7, 9, 46, 3, 748, DateTimeKind.Local).AddTicks(35), "SAAB", "Grey", "AIR222", "Gripen", 3, 3 },
                    { 9, new DateTime(2020, 10, 6, 9, 46, 3, 748, DateTimeKind.Local).AddTicks(43), "Sea Ray", "White", "BOA222", "SLX 400 OB", 0, 4 },
                    { 10, new DateTime(2020, 10, 5, 9, 46, 3, 748, DateTimeKind.Local).AddTicks(53), "Man", "Blue", "BUS222", "SR 240", 4, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkedVehicle");
        }
    }
}
