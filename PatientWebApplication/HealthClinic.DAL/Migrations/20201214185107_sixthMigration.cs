using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class sixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineDescriptions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicineDescriptions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    MedicineDescriptionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineDescriptions", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "MedicineDescriptions",
                columns: new[] { "id", "Description", "MedicineDescriptionId", "Name" },
                values: new object[] { 1, "Analgin[metamizole] is a painkiller, spasm reliever and fever reliever", 1, "Analgin" });
        }
    }
}
