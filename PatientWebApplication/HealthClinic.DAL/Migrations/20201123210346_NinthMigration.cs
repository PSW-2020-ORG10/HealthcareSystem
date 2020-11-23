using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class NinthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DoctorAppointments",
                columns: new[] { "id", "date", "doctorUserId", "patientUserId", "roomid", "time" },
                values: new object[] { 2, "20/11/2017", 2, 1, "1", new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "DoctorAppointments",
                columns: new[] { "id", "date", "doctorUserId", "patientUserId", "roomid", "time" },
                values: new object[] { 3, "05/07/2019", 3, 1, "1", new TimeSpan(0, 0, 0, 0, 0) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
