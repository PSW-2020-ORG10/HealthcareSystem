using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 10,
                column: "Date",
                value: "11/11/2010");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 10,
                column: "Date",
                value: "11/13/2010");
        }
    }
}
