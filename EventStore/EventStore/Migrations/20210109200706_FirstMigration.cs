using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventStore.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedbackSubmittedEvents",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    FeedbackID = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    PatientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackSubmittedEvents", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackSubmittedEvents");
        }
    }
}
