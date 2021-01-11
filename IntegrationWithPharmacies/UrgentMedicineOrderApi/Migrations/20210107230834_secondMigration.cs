using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UrgentMedicineOrderApi.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UrgentMedicineOrder",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Pharmacy = table.Column<string>(nullable: true),
                    DateOfOrder = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrgentMedicineOrder", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "UrgentMedicineOrder",
                columns: new[] { "id", "DateOfOrder", "Name", "Pharmacy", "Quantity" },
                values: new object[] { 1, "12/01/2020", "Andol", "Jankovic 3", 15 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UrgentMedicineOrder");
        }
    }
}
