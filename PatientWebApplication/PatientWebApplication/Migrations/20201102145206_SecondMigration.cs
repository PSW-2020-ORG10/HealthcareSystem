using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientWebApplication.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(nullable: true),
                    secondName = table.Column<string>(nullable: true),
                    uniqueCitizensidentityNumber = table.Column<string>(nullable: true),
                    dateOfBirth = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    medicalIdNumber = table.Column<string>(nullable: true),
                    allergie = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    guest = table.Column<bool>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    isRegisteredBySecretary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "id", "allergie", "city", "dateOfBirth", "email", "firstName", "guest", "isRegisteredBySecretary", "medicalIdNumber", "password", "phoneNumber", "secondName", "uniqueCitizensidentityNumber" },
                values: new object[] { 1, "Alergija", "Grad", "2/2/2020", "email", "Pera", false, false, "1234", "pass", "123", "Peric", "1234" });

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 2,
                column: "PatientId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 3,
                column: "PatientId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_PatientId",
                table: "Feedbacks",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Patients_PatientId",
                table: "Feedbacks",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Patients_PatientId",
                table: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_PatientId",
                table: "Feedbacks");

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 2,
                column: "PatientId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 3,
                column: "PatientId",
                value: 3);
        }
    }
}
