using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentMicroserviceApi.Migrations
{
    public partial class SeventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "CancelDateString", "IsCanceled" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "CancelDateString", "IsCanceled" },
                values: new object[] { null, false });

            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "CancelDateString", "IsCanceled" },
                values: new object[] { null, false });

            migrationBuilder.InsertData(
                table: "DoctorAppointments",
                columns: new[] { "id", "CancelDateString", "Date", "DoctorUserId", "IsCanceled", "PatientUserId", "RoomId", "Start" },
                values: new object[,]
                {
                    { 13, "09/01/2021", "23/12/2020", 2, true, 3, "1", new TimeSpan(0, 15, 0, 0, 0) },
                    { 14, "09/01/2021", "23/12/2020", 2, true, 3, "1", new TimeSpan(0, 15, 45, 0, 0) },
                    { 15, "09/01/2021", "22/12/2020", 1, true, 3, "1", new TimeSpan(0, 12, 0, 0, 0) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "CancelDateString", "IsCanceled" },
                values: new object[] { "09/01/2021", true });

            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "CancelDateString", "IsCanceled" },
                values: new object[] { "09/01/2021", true });

            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "CancelDateString", "IsCanceled" },
                values: new object[] { "09/01/2021", true });
        }
    }
}
