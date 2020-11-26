using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class eightMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MedicineForOrdering_description",
                table: "Equipment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "orderId",
                table: "Equipment",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "id", "Discriminator", "name", "quantity", "MedicineForOrdering_description", "orderId" },
                values: new object[] { 100, "MedicineForOrdering", "Medicine name", 1, "Medicine description", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "id",
                keyValue: 100);

            migrationBuilder.DropColumn(
                name: "MedicineForOrdering_description",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "Equipment");
        }
    }
}
