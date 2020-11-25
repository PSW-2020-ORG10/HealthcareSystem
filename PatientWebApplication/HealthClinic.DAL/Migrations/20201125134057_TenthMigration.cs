using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class TenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Doctors_doctorId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_doctorId",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "doctorId",
                table: "Surveys");

            migrationBuilder.AddColumn<int>(
                name: "appointmentId",
                table: "Surveys",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "id",
                keyValue: 1,
                column: "appointmentId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_appointmentId",
                table: "Surveys",
                column: "appointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_DoctorAppointments_appointmentId",
                table: "Surveys",
                column: "appointmentId",
                principalTable: "DoctorAppointments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_DoctorAppointments_appointmentId",
                table: "Surveys");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_appointmentId",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "appointmentId",
                table: "Surveys");

            migrationBuilder.AddColumn<int>(
                name: "doctorId",
                table: "Surveys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "id",
                keyValue: 1,
                column: "doctorId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_doctorId",
                table: "Surveys",
                column: "doctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Doctors_doctorId",
                table: "Surveys",
                column: "doctorId",
                principalTable: "Doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
