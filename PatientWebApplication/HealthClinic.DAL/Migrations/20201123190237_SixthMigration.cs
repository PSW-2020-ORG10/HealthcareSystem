using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class SixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    patientId = table.Column<int>(nullable: false),
                    doctorId = table.Column<int>(nullable: false),
                    doctorsProfessionalism = table.Column<int>(nullable: false),
                    doctorsPoliteness = table.Column<int>(nullable: false),
                    doctorsTechnicality = table.Column<int>(nullable: false),
                    doctorsSkill = table.Column<int>(nullable: false),
                    doctorsKnowledge = table.Column<int>(nullable: false),
                    doctorsWorkingPace = table.Column<int>(nullable: false),
                    medicalStaffsProfessionalism = table.Column<int>(nullable: false),
                    medicalStaffsPoliteness = table.Column<int>(nullable: false),
                    medicalStaffsTechnicality = table.Column<int>(nullable: false),
                    medicalStaffsSkill = table.Column<int>(nullable: false),
                    medicalStaffsKnowledge = table.Column<int>(nullable: false),
                    medicalStaffsWorkingPace = table.Column<int>(nullable: false),
                    hospitalEnvironment = table.Column<int>(nullable: false),
                    hospitalEquipment = table.Column<int>(nullable: false),
                    hospitalHygiene = table.Column<int>(nullable: false),
                    hospitalPrices = table.Column<int>(nullable: false),
                    hospitalWaitingTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.id);
                    table.ForeignKey(
                        name: "FK_Surveys_Doctors_doctorId",
                        column: x => x.doctorId,
                        principalTable: "Doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Surveys_Patients_patientId",
                        column: x => x.patientId,
                        principalTable: "Patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "firstName", "secondName" },
                values: new object[] { "Konstantin", "Davidovic" });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "id", "doctorId", "doctorsKnowledge", "doctorsPoliteness", "doctorsProfessionalism", "doctorsSkill", "doctorsTechnicality", "doctorsWorkingPace", "hospitalEnvironment", "hospitalEquipment", "hospitalHygiene", "hospitalPrices", "hospitalWaitingTime", "medicalStaffsKnowledge", "medicalStaffsPoliteness", "medicalStaffsProfessionalism", "medicalStaffsSkill", "medicalStaffsTechnicality", "medicalStaffsWorkingPace", "patientId" },
                values: new object[] { 1, 1, 4, 5, 4, 5, 4, 5, 3, 3, 2, 2, 5, 5, 5, 4, 5, 5, 4, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_doctorId",
                table: "Surveys",
                column: "doctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_patientId",
                table: "Surveys",
                column: "patientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "firstName", "secondName" },
                values: new object[] { "DoctorName", "DoctorSurname" });
        }
    }
}
