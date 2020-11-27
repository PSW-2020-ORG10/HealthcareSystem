using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 1,
                column: "PatientUserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "Date", "PatientUserId" },
                values: new object[] { "07/01/2020", 2 });

            migrationBuilder.InsertData(
                table: "DoctorAppointments",
                columns: new[] { "id", "Date", "DoctorUserId", "PatientUserId", "RoomId", "Start" },
                values: new object[,]
                {
                    { 9, "14/03/2016", 1, 1, "1", new TimeSpan(0, 0, 0, 0, 0) },
                    { 10, "11/13/2010", 2, 1, "1", new TimeSpan(0, 0, 0, 0, 0) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 1,
                column: "PatientUserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "Date", "PatientUserId" },
                values: new object[] { "20/11/2017", 1 });
        }
    }
}
