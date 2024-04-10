using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThAmCo.Venues.Data.Migrations
{
    public partial class AddedYearAndMonthToAvailabilityDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 51.789999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 46.770000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 72.069999999999993 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 91.030000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 57.18 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 61.130000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 139.55000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 96.379999999999995 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 92.689999999999998 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 95.010000000000005 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 59.859999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 57.450000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 55.439999999999998 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 79.260000000000005 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 80.489999999999995 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 97.650000000000006 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 57.399999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 58.020000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 78.489999999999995 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 50.630000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 94.670000000000002 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 32.43 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 68.049999999999997 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 92.519999999999996 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 53.119999999999997 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 49.280000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 104.76000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 30.91 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 99.439999999999998 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 69.359999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 76.140000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 64.019999999999996 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 51.479999999999997 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 112.88 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 109.15000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 115.89 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 64.030000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 53.840000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 92.319999999999993 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 40.109999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 76.810000000000002 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 80.659999999999997 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 43.719999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 42.299999999999997 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 51.560000000000002 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 87.870000000000005 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 48.590000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 84.980000000000004 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 80.769999999999996 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 35.850000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 83.709999999999994 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 91.530000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 132.13 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 104.41 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 114.65000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 50.390000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 95.829999999999998 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 62.539999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 78.430000000000007 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 77.700000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 33.030000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 110.11 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 77.640000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 130.16999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 35.670000000000002 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 101.31999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 53.219999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 74.150000000000006 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 102.22 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 44.049999999999997 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 99.879999999999995 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 115.3 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 72.340000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 53.810000000000002 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 52.939999999999998 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 112.63 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK" });

            migrationBuilder.DeleteData(
                table: "Availabilities",
                keyColumns: new[] { "Date", "VenueCode" },
                keyValues: new object[] { new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR" });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 51.789999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 46.770000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 72.069999999999993 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 91.030000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 57.18 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 61.130000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 139.55000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 96.379999999999995 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 92.689999999999998 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 95.010000000000005 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 59.859999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 57.450000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 55.439999999999998 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 79.260000000000005 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 80.489999999999995 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 97.650000000000006 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 57.399999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 58.020000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 78.489999999999995 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 50.630000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 94.670000000000002 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 32.43 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 68.049999999999997 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 92.519999999999996 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 53.119999999999997 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 49.280000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 104.76000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 30.91 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 99.439999999999998 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 69.359999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 76.140000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 64.019999999999996 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 51.479999999999997 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 112.88 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 109.15000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 115.89 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 64.030000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 53.840000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 92.319999999999993 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 40.109999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 76.810000000000002 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 80.659999999999997 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 43.719999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 42.299999999999997 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 51.560000000000002 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 87.870000000000005 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 48.590000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 84.980000000000004 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 80.769999999999996 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 35.850000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 83.709999999999994 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 91.530000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 132.13 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 104.41 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 114.65000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 50.390000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 95.829999999999998 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 62.539999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 78.430000000000007 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 77.700000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 33.030000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 110.11 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 77.640000000000001 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 130.16999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 35.670000000000002 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 101.31999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 53.219999999999999 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 74.150000000000006 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 102.22 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 44.049999999999997 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 99.879999999999995 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 115.3 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CRKHL", 72.340000000000003 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 53.810000000000002 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "FDLCK", 52.939999999999998 });

            migrationBuilder.InsertData(
                table: "Availabilities",
                columns: new[] { "Date", "VenueCode", "CostPerHour" },
                values: new object[] { new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "TNDMR", 112.63 });
        }
    }
}
