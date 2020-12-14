using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class fifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicineDescription",
                table: "MedicineDescription");

            migrationBuilder.RenameTable(
                name: "MedicineDescription",
                newName: "MedicineDescriptions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicineDescriptions",
                table: "MedicineDescriptions",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicineDescriptions",
                table: "MedicineDescriptions");

            migrationBuilder.RenameTable(
                name: "MedicineDescriptions",
                newName: "MedicineDescription");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicineDescription",
                table: "MedicineDescription",
                column: "id");
        }
    }
}
