using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAppointments_Doctors_DoctorUserId",
                table: "DoctorAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAppointments_Patients_PatientUserId",
                table: "DoctorAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Referrals_DoctorAppointments_AppointmentId",
                table: "Referrals");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_DoctorAppointments_appointmentId",
                table: "Surveys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorAppointments",
                table: "DoctorAppointments");

            migrationBuilder.RenameTable(
                name: "DoctorAppointments",
                newName: "DoctorAppointment");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorAppointments_PatientUserId",
                table: "DoctorAppointment",
                newName: "IX_DoctorAppointment_PatientUserId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorAppointments_DoctorUserId",
                table: "DoctorAppointment",
                newName: "IX_DoctorAppointment_DoctorUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorAppointment",
                table: "DoctorAppointment",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAppointment_Doctors_DoctorUserId",
                table: "DoctorAppointment",
                column: "DoctorUserId",
                principalTable: "Doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAppointment_Patients_PatientUserId",
                table: "DoctorAppointment",
                column: "PatientUserId",
                principalTable: "Patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Referrals_DoctorAppointment_AppointmentId",
                table: "Referrals",
                column: "AppointmentId",
                principalTable: "DoctorAppointment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_DoctorAppointment_appointmentId",
                table: "Surveys",
                column: "appointmentId",
                principalTable: "DoctorAppointment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAppointment_Doctors_DoctorUserId",
                table: "DoctorAppointment");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorAppointment_Patients_PatientUserId",
                table: "DoctorAppointment");

            migrationBuilder.DropForeignKey(
                name: "FK_Referrals_DoctorAppointment_AppointmentId",
                table: "Referrals");

            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_DoctorAppointment_appointmentId",
                table: "Surveys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DoctorAppointment",
                table: "DoctorAppointment");

            migrationBuilder.RenameTable(
                name: "DoctorAppointment",
                newName: "DoctorAppointments");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorAppointment_PatientUserId",
                table: "DoctorAppointments",
                newName: "IX_DoctorAppointments_PatientUserId");

            migrationBuilder.RenameIndex(
                name: "IX_DoctorAppointment_DoctorUserId",
                table: "DoctorAppointments",
                newName: "IX_DoctorAppointments_DoctorUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DoctorAppointments",
                table: "DoctorAppointments",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAppointments_Doctors_DoctorUserId",
                table: "DoctorAppointments",
                column: "DoctorUserId",
                principalTable: "Doctors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorAppointments_Patients_PatientUserId",
                table: "DoctorAppointments",
                column: "PatientUserId",
                principalTable: "Patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Referrals_DoctorAppointments_AppointmentId",
                table: "Referrals",
                column: "AppointmentId",
                principalTable: "DoctorAppointments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_DoctorAppointments_appointmentId",
                table: "Surveys",
                column: "appointmentId",
                principalTable: "DoctorAppointments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
