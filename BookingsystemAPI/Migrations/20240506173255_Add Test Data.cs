using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingsystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "AppointmentId", "AppointmentEnd", "AppointmentStart", "CompanyId", "CustomerId" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 8, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 3, new DateTime(2024, 8, 21, 6, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 20, 7, 15, 0, 0, DateTimeKind.Unspecified), 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "EmailAddress", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 2, "tobias@johansson.se", "Tobias", "Johansson", "1234567890" },
                    { 3, "markus@johansson.se", "Markus", "Johansson", "1234567890" }
                });

            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "AppointmentId", "AppointmentEnd", "AppointmentStart", "CompanyId", "CustomerId" },
                values: new object[,]
                {
                    { 4, new DateTime(2024, 5, 19, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 19, 15, 30, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 5, new DateTime(2024, 6, 1, 11, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 1, 8, 20, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 6, new DateTime(2024, 7, 9, 15, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 9, 12, 50, 0, 0, DateTimeKind.Unspecified), 1, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "AppointmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "AppointmentId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "AppointmentId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "AppointmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "AppointmentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "CustomerId",
                keyValue: 3);
        }
    }
}
