using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMicroserviceApi.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 1,
                column: "Text",
                value: "Brufen");

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "id", "DateAction", "DateStamp", "IsRemoved", "PharmacyName", "Text", "TimeStamp" },
                values: new object[] { 3, "02/02/2020", "03/12/2020", false, "Apoteka Jankovic", "Defrinol", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "id", "DateAction", "DateStamp", "IsRemoved", "PharmacyName", "Text", "TimeStamp" },
                values: new object[] { 2, "02/02/2020", "03/12/2020", false, "Apoteka Jankovic", "Aspirin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 1,
                column: "Text",
                value: "Message");
        }
    }
}
