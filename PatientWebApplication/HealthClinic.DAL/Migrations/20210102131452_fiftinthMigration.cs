using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthClinic.CL.Migrations
{
    public partial class fiftinthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorsOrders");

            migrationBuilder.DropTable(
                name: "MedicineDescriptions");

            migrationBuilder.DropTable(
                name: "MedicinesForOrdering");

            migrationBuilder.DropTable(
                name: "ManagersOrders");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MedicineWithQuantities",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MedicineWithQuantities",
                keyColumn: "id",
                keyValue: 1,
                column: "Description",
                value: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "MedicineWithQuantities");

            migrationBuilder.CreateTable(
                name: "ManagersOrders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsOrdered = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsUrgent = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagersOrders", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "MedicinesForOrdering",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicinesForOrdering", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorsOrders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateEnd = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsFinished = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsOrdered = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsUrgent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ManagersOrderid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsOrders", x => x.id);
                    table.ForeignKey(
                        name: "FK_DoctorsOrders_ManagersOrders_ManagersOrderid",
                        column: x => x.ManagersOrderid,
                        principalTable: "ManagersOrders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DoctorsOrders",
                columns: new[] { "id", "DateEnd", "DateStart", "IsFinished", "IsOrdered", "IsUrgent", "ManagersOrderid" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, false, null });

            migrationBuilder.InsertData(
                table: "ManagersOrders",
                columns: new[] { "id", "Date", "IsOrdered", "IsUrgent" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true });

            migrationBuilder.InsertData(
                table: "MedicineDescriptions",
                columns: new[] { "id", "Description", "MedicineDescriptionId", "Name" },
                values: new object[] { 1, "Analgin has anti - inflammatory, analgesic, antifebrile action.", 1, "Analgin" });

            migrationBuilder.InsertData(
                table: "MedicinesForOrdering",
                columns: new[] { "id", "Description", "Name", "OrderId", "Quantity" },
                values: new object[] { 1, "Medicine description", "Medicine name", 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorsOrders_ManagersOrderid",
                table: "DoctorsOrders",
                column: "ManagersOrderid");
        }
    }
}
