using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientWebApplication.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Patients_PatientUserId",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "PatientNotifications");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_PatientUserId",
                table: "PatientNotifications",
                newName: "IX_PatientNotifications_PatientUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientNotifications",
                table: "PatientNotifications",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(nullable: true),
                    secondName = table.Column<string>(nullable: true),
                    uniqueCitizensidentityNumber = table.Column<string>(nullable: true),
                    dateOfBirth = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    salary = table.Column<double>(nullable: false),
                    city = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    isSpecialist = table.Column<bool>(nullable: false),
                    ordination = table.Column<string>(nullable: true),
                    speciality = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorNotifications",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    DoctorUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorNotifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_DoctorNotifications_Doctors_DoctorUserId",
                        column: x => x.DoctorUserId,
                        principalTable: "Doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "id", "city", "dateOfBirth", "email", "firstName", "isSpecialist", "ordination", "password", "phoneNumber", "salary", "secondName", "speciality", "uniqueCitizensidentityNumber" },
                values: new object[] { 1, "Grad", "2/2/2020", "email", "DoctorName", false, "Ordination 1", "pass", "123", 200.0, "DoctorSurname", "Specialty", "1234" });

            migrationBuilder.InsertData(
                table: "DoctorNotifications",
                columns: new[] { "id", "Data", "DoctorUserId" },
                values: new object[] { 3, "3. string", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorNotifications_DoctorUserId",
                table: "DoctorNotifications",
                column: "DoctorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientNotifications_Patients_PatientUserId",
                table: "PatientNotifications",
                column: "PatientUserId",
                principalTable: "Patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientNotifications_Patients_PatientUserId",
                table: "PatientNotifications");

            migrationBuilder.DropTable(
                name: "DoctorNotifications");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientNotifications",
                table: "PatientNotifications");

            migrationBuilder.RenameTable(
                name: "PatientNotifications",
                newName: "Notifications");

            migrationBuilder.RenameIndex(
                name: "IX_PatientNotifications_PatientUserId",
                table: "Notifications",
                newName: "IX_Notifications_PatientUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Patients_PatientUserId",
                table: "Notifications",
                column: "PatientUserId",
                principalTable: "Patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
