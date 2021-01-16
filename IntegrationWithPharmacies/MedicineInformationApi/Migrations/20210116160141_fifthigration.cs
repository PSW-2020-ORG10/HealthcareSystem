using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicineInformationApi.Migrations
{
    public partial class fifthigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicineInformations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineDescriptions",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MedicineInformationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineDescriptions", x => x.Name);
                    table.ForeignKey(
                        name: "FK_MedicineDescriptions_MedicineInformations_MedicineInformatio~",
                        column: x => x.MedicineInformationId,
                        principalTable: "MedicineInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MedicineInformations",
                columns: new[] { "Id", "Quantity" },
                values: new object[] { 1, 150 });

            migrationBuilder.InsertData(
                table: "MedicineDescriptions",
                columns: new[] { "Name", "Description", "MedicineInformationId" },
                values: new object[] { "Andol", "Against pain", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineDescriptions_MedicineInformationId",
                table: "MedicineDescriptions",
                column: "MedicineInformationId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineDescriptions");

            migrationBuilder.DropTable(
                name: "MedicineInformations");
        }
    }
}
