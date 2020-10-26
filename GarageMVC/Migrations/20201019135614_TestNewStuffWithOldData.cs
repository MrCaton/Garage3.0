using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageMVC.Migrations
{
    public partial class TestNewStuffWithOldData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 18, 15, 56, 13, 645, DateTimeKind.Local).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 18, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 17, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5405));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 16, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 15, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5415));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 6,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 14, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5419));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 7,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 13, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5424));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 8,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 12, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5427));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 9,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 11, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5431));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 10,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 10, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5436));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 16, 12, 38, 21, 172, DateTimeKind.Local).AddTicks(3572));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 16, 12, 38, 21, 175, DateTimeKind.Local).AddTicks(112));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 15, 12, 38, 21, 175, DateTimeKind.Local).AddTicks(165));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 14, 12, 38, 21, 175, DateTimeKind.Local).AddTicks(173));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 13, 12, 38, 21, 175, DateTimeKind.Local).AddTicks(177));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 6,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 12, 12, 38, 21, 175, DateTimeKind.Local).AddTicks(182));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 7,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 11, 12, 38, 21, 175, DateTimeKind.Local).AddTicks(186));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 8,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 10, 12, 38, 21, 175, DateTimeKind.Local).AddTicks(191));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 9,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 9, 12, 38, 21, 175, DateTimeKind.Local).AddTicks(195));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 10,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 8, 12, 38, 21, 175, DateTimeKind.Local).AddTicks(200));
        }
    }
}
