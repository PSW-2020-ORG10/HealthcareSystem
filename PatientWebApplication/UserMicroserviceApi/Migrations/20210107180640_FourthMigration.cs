using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMicroserviceApi.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 1,
                column: "Text",
                value: "Introducing our new commercial for your old family friend: Defrinol Forte!");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 2,
                column: "Text",
                value: "The bag saves lives, if there is an Andol in it!");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 3,
                column: "Text",
                value: "Protects the heart, protects the brain, Aspirin!");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 1,
                column: "Text",
                value: "Predstavljamo Vam nasu novu reklamu za Vaseg starog porodicnog prijatelja: Defrinol Forte!");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 2,
                column: "Text",
                value: "Torba glavu cuva, ako je u njoj Andol!");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "id",
                keyValue: 3,
                column: "Text",
                value: "Stiti srce, cuva mozak, Aspirin!");
        }
    }
}
