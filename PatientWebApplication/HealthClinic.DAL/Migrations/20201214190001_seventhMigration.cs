using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class seventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicineDescriptions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MedicineDescriptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineDescriptions", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "MedicineDescriptions",
                columns: new[] { "id", "Description", "MedicineDescriptionId", "Name" },
                values: new object[] { 1, "Analgin has anti - inflammatory, analgesic, antifebrile action.", 1, "Analgin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineDescriptions");
        }
    }
}
