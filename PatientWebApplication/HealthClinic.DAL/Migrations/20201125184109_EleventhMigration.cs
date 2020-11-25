using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class EleventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DoctorAppointments",
                columns: new[] { "id", "date", "doctorUserId", "patientUserId", "roomid", "time" },
                values: new object[,]
                {
                    { 4, "04/02/2019", 1, 1, "1", new TimeSpan(0, 0, 0, 0, 0) },
                    { 5, "11/01/2016", 2, 1, "1", new TimeSpan(0, 0, 0, 0, 0) },
                    { 6, "09/01/2014", 3, 1, "1", new TimeSpan(0, 0, 0, 0, 0) },
                    { 7, "07/02/2011", 3, 1, "1", new TimeSpan(0, 0, 0, 0, 0) },
                    { 8, "01/03/2020", 2, 1, "1", new TimeSpan(0, 0, 0, 0, 0) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 8);
        }
    }
}
