using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventStore.Migrations
{
    public partial class AppointmentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentSchedulingEvents",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    Step = table.Column<int>(nullable: false),
                    Action = table.Column<string>(nullable: false),
                    EndPoint = table.Column<string>(nullable: false),
                    Attempt = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentSchedulingEvents", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentSchedulingEvents");
        }
    }
}
