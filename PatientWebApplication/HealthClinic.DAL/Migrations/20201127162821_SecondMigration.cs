using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DoctorAppointments",
                columns: new[] { "id", "Date", "DoctorUserId", "PatientUserId", "RoomId", "Start" },
                values: new object[] { 3, "14/06/2020", 1, 2, "A2", new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "DoctorAppointments",
                columns: new[] { "id", "Date", "DoctorUserId", "PatientUserId", "RoomId", "Start" },
                values: new object[] { 4, "31/03/2020", 2, 2, "B3", new TimeSpan(0, 0, 0, 0, 0) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
