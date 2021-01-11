using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentMicroserviceApi.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 3,
                column: "IsCanceled",
                value: true);

            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 4,
                column: "IsCanceled",
                value: true);

            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 5,
                column: "IsCanceled",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 3,
                column: "IsCanceled",
                value: false);

            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 4,
                column: "IsCanceled",
                value: false);

            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 5,
                column: "IsCanceled",
                value: false);
        }
    }
}
