using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GarageMVC.Migrations
{
    public partial class TestNewStuffWithOldData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2020, 10, 18, 21, 21, 46, 896, DateTimeKind.Local).AddTicks(6681));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 18, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(2981), 1 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 17, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(3288), 2 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 16, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(3332), 5 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 15, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(3342), 8 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 14, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(3351), 10 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 13, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(3360), 11 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 12, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(3368), 12 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 11, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(3377), 15 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 10, 21, 21, 46, 905, DateTimeKind.Local).AddTicks(3386), 18 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 18, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5364), 0 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 17, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5405), 0 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 16, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5411), 0 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 15, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5415), 0 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 14, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5419), 0 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 13, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5424), 0 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 12, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5427), 0 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 11, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5431), 0 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ArrivalTime", "StartLocation" },
                values: new object[] { new DateTime(2020, 10, 10, 15, 56, 13, 648, DateTimeKind.Local).AddTicks(5436), 0 });
        }
    }
}
