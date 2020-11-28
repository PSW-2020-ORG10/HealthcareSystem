using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class LastMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DoctorAppointments",
                columns: new[] { "id", "Date", "DoctorUserId", "PatientUserId", "RoomId", "Start" },
                values: new object[] { 11, "14/03/2016", 1, 2, "A2", new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "DoctorAppointments",
                columns: new[] { "id", "Date", "DoctorUserId", "PatientUserId", "RoomId", "Start" },
                values: new object[] { 12, "11/11/2030", 2, 2, "B3", new TimeSpan(0, 0, 0, 0, 0) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 12);
        }
    }
}
