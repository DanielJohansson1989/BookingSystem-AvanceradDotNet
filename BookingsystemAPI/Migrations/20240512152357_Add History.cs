using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingsystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    HistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeType = table.Column<int>(type: "int", nullable: false),
                    ChangeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    OldValueAppointmentStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OldValueAppointmentEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OldValueCustomerId = table.Column<int>(type: "int", nullable: true),
                    OldValueCompanyId = table.Column<int>(type: "int", nullable: true),
                    NewValueAppointmentStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewValueAppointmentEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewValueCustomerId = table.Column<int>(type: "int", nullable: true),
                    NewValueCompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.HistoryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History");
        }
    }
}
