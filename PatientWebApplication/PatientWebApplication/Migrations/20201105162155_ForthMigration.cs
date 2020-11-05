using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientWebApplication.Migrations
{
    public partial class ForthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Referrals",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    medicine = table.Column<string>(nullable: true),
                    takeMedicineUntil = table.Column<string>(nullable: true),
                    quantityPerDay = table.Column<int>(nullable: false),
                    classify = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referrals", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientUserId = table.Column<int>(nullable: false),
                    date = table.Column<string>(nullable: true),
                    start = table.Column<TimeSpan>(nullable: false),
                    end = table.Column<TimeSpan>(nullable: false),
                    DoctorUserId = table.Column<int>(nullable: false),
                    idRoom = table.Column<string>(nullable: true),
                    OperationReferralId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Operations_Doctors_DoctorUserId",
                        column: x => x.DoctorUserId,
                        principalTable: "Doctors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operations_Referrals_OperationReferralId",
                        column: x => x.OperationReferralId,
                        principalTable: "Referrals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operations_Patients_PatientUserId",
                        column: x => x.PatientUserId,
                        principalTable: "Patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Referrals",
                columns: new[] { "id", "classify", "comment", "medicine", "quantityPerDay", "takeMedicineUntil" },
                values: new object[] { 1, "classify", "comment", "Medicine", 3, "Take medicine until" });

            migrationBuilder.InsertData(
                table: "Operations",
                columns: new[] { "id", "DoctorUserId", "OperationReferralId", "PatientUserId", "date", "end", "idRoom", "start" },
                values: new object[] { 1, 1, 1, 1, "2/2/2020", new TimeSpan(0, 0, 0, 0, 0), "room1", new TimeSpan(0, 0, 0, 0, 0) });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_DoctorUserId",
                table: "Operations",
                column: "DoctorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_OperationReferralId",
                table: "Operations",
                column: "OperationReferralId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_PatientUserId",
                table: "Operations",
                column: "PatientUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Referrals");
        }
    }
}
