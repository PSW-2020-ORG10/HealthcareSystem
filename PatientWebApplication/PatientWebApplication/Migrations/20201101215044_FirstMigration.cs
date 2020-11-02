using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientWebApplication.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    IsAnonymous = table.Column<bool>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "id", "IsAnonymous", "IsPublic", "IsPublished", "Message", "PatientId" },
                values: new object[] { 1, true, true, false, "First message", 1 });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "id", "IsAnonymous", "IsPublic", "IsPublished", "Message", "PatientId" },
                values: new object[] { 2, false, false, false, "Second message", 2 });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "id", "IsAnonymous", "IsPublic", "IsPublished", "Message", "PatientId" },
                values: new object[] { 3, false, true, false, "Third message", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");
        }
    }
}
