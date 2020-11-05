using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientWebApplication.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "id", "IsAnonymous", "IsPublic", "IsPublished", "Message", "PatientId" },
                values: new object[] { 4, false, true, false, "Fourth message", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Feedbacks",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
