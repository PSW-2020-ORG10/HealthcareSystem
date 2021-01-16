using Microsoft.EntityFrameworkCore.Migrations;

namespace SearchMicroserviceApi.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Prescriptions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 5,
                column: "AppointmentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 6,
                column: "AppointmentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "Id",
                keyValue: 7,
                column: "AppointmentId",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Prescriptions");
        }
    }
}
