using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "Date", "Start", "end" },
                values: new object[] { "03/03/2020", new TimeSpan(0, 14, 0, 0, 0), new TimeSpan(0, 15, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "PatientUserId", "Start", "end" },
                values: new object[] { 1, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 15, 15, 0, 0) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "Date", "Start", "end" },
                values: new object[] { "20/02/2020", new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Operations",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "PatientUserId", "Start", "end" },
                values: new object[] { 2, new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 0, 0, 0, 0) });
        }
    }
}
