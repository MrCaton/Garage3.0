using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageMVC.Migrations
{
    public partial class password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Member",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 26, 15, 22, 30, 962, DateTimeKind.Local).AddTicks(4870));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 26, 15, 22, 30, 965, DateTimeKind.Local).AddTicks(1750));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 25, 15, 22, 30, 965, DateTimeKind.Local).AddTicks(1797));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 24, 15, 22, 30, 965, DateTimeKind.Local).AddTicks(1802));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 23, 15, 22, 30, 965, DateTimeKind.Local).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 6,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 22, 15, 22, 30, 965, DateTimeKind.Local).AddTicks(1809));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 7,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 21, 15, 22, 30, 965, DateTimeKind.Local).AddTicks(1813));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 8,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 20, 15, 22, 30, 965, DateTimeKind.Local).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 9,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 19, 15, 22, 30, 965, DateTimeKind.Local).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 10,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 18, 15, 22, 30, 965, DateTimeKind.Local).AddTicks(1823));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Member");

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 25, 20, 32, 12, 797, DateTimeKind.Local).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 25, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4736));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 24, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4780));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 23, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4786));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 22, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4791));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 6,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 21, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 7,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 20, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4798));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 8,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 19, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4802));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 9,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 18, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4805));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 10,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 17, 20, 32, 12, 800, DateTimeKind.Local).AddTicks(4808));
        }
    }
}
