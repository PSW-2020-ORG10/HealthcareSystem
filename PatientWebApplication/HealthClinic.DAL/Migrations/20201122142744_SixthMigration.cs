using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class SixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Prescriptions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoctorUserid",
                table: "Prescriptions",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "id",
                keyValue: 1,
                column: "DoctorId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "id",
                keyValue: 2,
                column: "DoctorId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_DoctorUserid",
                table: "Prescriptions",
                column: "DoctorUserid");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorUserid",
                table: "Prescriptions",
                column: "DoctorUserid",
                principalTable: "Doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Doctors_DoctorUserid",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_DoctorUserid",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "DoctorUserid",
                table: "Prescriptions");
        }
    }
}
