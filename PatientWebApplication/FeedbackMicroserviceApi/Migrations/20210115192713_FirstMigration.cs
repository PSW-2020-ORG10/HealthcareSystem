using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FeedbackMicroserviceApi.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    IsAnonymous = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Date", "IsAnonymous", "IsPublic", "IsPublished", "Message", "PatientId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, false, "First message", 1 },
                    { 2, new DateTime(2019, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, false, "Second message", 1 },
                    { 3, new DateTime(2020, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, false, "Third message", 1 },
                    { 4, new DateTime(2020, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, false, "Fourth message", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");
        }
    }
}
