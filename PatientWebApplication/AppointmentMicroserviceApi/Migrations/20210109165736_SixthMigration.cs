using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentMicroserviceApi.Migrations
{
    public partial class SixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 3,
                column: "CancelDateString",
                value: "09/01/2021");

            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 4,
                column: "CancelDateString",
                value: "09/01/2021");

            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 5,
                column: "CancelDateString",
                value: "09/01/2021");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 3,
                column: "CancelDateString",
                value: null);

            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 4,
                column: "CancelDateString",
                value: null);

            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 5,
                column: "CancelDateString",
                value: null);
        }
    }
}
