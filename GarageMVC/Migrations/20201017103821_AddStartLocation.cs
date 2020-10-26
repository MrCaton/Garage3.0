using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageMVC.Migrations
{
    public partial class AddStartLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StartLocation",
                table: "ParkedVehicle",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartLocation",
                table: "ParkedVehicle");

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 13, 9, 46, 3, 739, DateTimeKind.Local).AddTicks(3895));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 13, 9, 46, 3, 747, DateTimeKind.Local).AddTicks(9852));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 12, 9, 46, 3, 747, DateTimeKind.Local).AddTicks(9978));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 11, 9, 46, 3, 747, DateTimeKind.Local).AddTicks(9992));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 10, 9, 46, 3, 748, DateTimeKind.Local).AddTicks(2));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 6,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 9, 9, 46, 3, 748, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 7,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 8, 9, 46, 3, 748, DateTimeKind.Local).AddTicks(25));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 8,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 7, 9, 46, 3, 748, DateTimeKind.Local).AddTicks(35));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 9,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 6, 9, 46, 3, 748, DateTimeKind.Local).AddTicks(43));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 10,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 5, 9, 46, 3, 748, DateTimeKind.Local).AddTicks(53));
        }
    }
}
