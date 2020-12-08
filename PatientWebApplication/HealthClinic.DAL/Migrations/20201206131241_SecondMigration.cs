using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Surveys",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 8,
                column: "Date",
                value: "07/12/2020");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DoctorAppointments",
                keyColumn: "id",
                keyValue: 8,
                column: "Date",
                value: "06/12/2020");

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "id", "appointmentId", "doctorsKnowledge", "doctorsPoliteness", "doctorsProfessionalism", "doctorsSkill", "doctorsTechnicality", "doctorsWorkingPace", "hospitalEnvironment", "hospitalEquipment", "hospitalHygiene", "hospitalPrices", "hospitalWaitingTime", "medicalStaffsKnowledge", "medicalStaffsPoliteness", "medicalStaffsProfessionalism", "medicalStaffsSkill", "medicalStaffsTechnicality", "medicalStaffsWorkingPace", "patientId" },
                values: new object[,]
                {
                    { 3, 5, 4, 5, 4, 3, 1, 5, 1, 2, 2, 1, 5, 5, 2, 3, 1, 5, 4, 1 },
                    { 4, 6, 5, 5, 4, 5, 2, 1, 1, 3, 1, 3, 5, 2, 2, 3, 2, 4, 3, 1 },
                    { 5, 7, 4, 5, 4, 2, 4, 5, 1, 1, 2, 5, 1, 5, 2, 1, 3, 4, 2, 1 }
                });
        }
    }
}
