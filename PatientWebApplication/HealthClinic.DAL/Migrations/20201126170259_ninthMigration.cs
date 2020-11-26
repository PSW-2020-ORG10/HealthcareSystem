using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class ninthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MedicinesForOrdering",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    orderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinesForOrdering", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "MedicinesForOrdering",
                columns: new[] { "id", "description", "name", "orderId", "quantity" },
                values: new object[] { 100, "Medicine description", "Medicine name", 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicinesForOrdering");

            migrationBuilder.AddColumn<string>(
                name: "MedicineForOrdering_description",
                table: "Equipment",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "orderId",
                table: "Equipment",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "id", "Discriminator", "name", "quantity", "MedicineForOrdering_description", "orderId" },
                values: new object[] { 100, "MedicineForOrdering", "Medicine name", 1, "Medicine description", 1 });
        }
    }
}
