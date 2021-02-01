using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyRegistrationApi.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PharmacyId = table.Column<int>(nullable: false),
                    Town = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyNameInfos",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    RegistrationInPharmacyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyNameInfos", x => x.Name);
                    table.ForeignKey(
                        name: "FK_PharmacyNameInfos_Registrations_RegistrationInPharmacyId",
                        column: x => x.RegistrationInPharmacyId,
                        principalTable: "Registrations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationsInfo",
                columns: table => new
                {
                    ApiKey = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    RegistrationInPharmacyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationsInfo", x => x.ApiKey);
                    table.ForeignKey(
                        name: "FK_RegistrationsInfo_Registrations_RegistrationInPharmacyId",
                        column: x => x.RegistrationInPharmacyId,
                        principalTable: "Registrations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "id", "PharmacyId", "Town" },
                values: new object[] { 1, 1, "Novi Sad" });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "id", "PharmacyId", "Town" },
                values: new object[] { 2, 2, "Novi Sad" });

            migrationBuilder.InsertData(
                table: "PharmacyNameInfos",
                columns: new[] { "Name", "RegistrationInPharmacyId" },
                values: new object[,]
                {
                    { "Jankovic 1", 1 },
                    { "Benu 1", 2 }
                });

            migrationBuilder.InsertData(
                table: "RegistrationsInfo",
                columns: new[] { "ApiKey", "Email", "RegistrationInPharmacyId", "Url" },
                values: new object[,]
                {
                    { "65ftvyubuef74f8H", "jankovic1@gmail.com", 1, "http://localhost:8086" },
                    { "65ftvyubuef74f8G", "benu1@gmail.com", 2, "http://localhost:8082" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PharmacyNameInfos_RegistrationInPharmacyId",
                table: "PharmacyNameInfos",
                column: "RegistrationInPharmacyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrationsInfo_RegistrationInPharmacyId",
                table: "RegistrationsInfo",
                column: "RegistrationInPharmacyId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PharmacyNameInfos");

            migrationBuilder.DropTable(
                name: "RegistrationsInfo");

            migrationBuilder.DropTable(
                name: "Registrations");
        }
    }
}
