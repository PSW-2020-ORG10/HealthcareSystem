﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TenderApi.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicineForTendering",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    TenderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineForTendering", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineTenderOffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MedicineName = table.Column<string>(nullable: true),
                    RequiredQuantity = table.Column<int>(nullable: false),
                    AvailableQuantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    PharmacyTenderOfferId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTenderOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PharmacyTenderOffers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PharmacyName = table.Column<string>(nullable: true),
                    IsWinner = table.Column<bool>(nullable: false),
                    TenderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyTenderOffers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tender",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    Closed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tender", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MedicineForTendering",
                columns: new[] { "Id", "Name", "Quantity", "TenderId" },
                values: new object[] { 1, "Andol", 135, 1 });

            migrationBuilder.InsertData(
                table: "MedicineTenderOffers",
                columns: new[] { "Id", "AvailableQuantity", "MedicineName", "PharmacyTenderOfferId", "Price", "RequiredQuantity" },
                values: new object[] { 1, 1, "Andol", 1, 1.0, 1 });

            migrationBuilder.InsertData(
                table: "PharmacyTenderOffers",
                columns: new[] { "Id", "IsWinner", "PharmacyName", "TenderId" },
                values: new object[] { 1, false, "pharmacy Jankovic", 1 });

            migrationBuilder.InsertData(
                table: "Tender",
                columns: new[] { "Id", "Closed", "ExpirationDate" },
                values: new object[] { 1, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineForTendering");

            migrationBuilder.DropTable(
                name: "MedicineTenderOffers");

            migrationBuilder.DropTable(
                name: "PharmacyTenderOffers");

            migrationBuilder.DropTable(
                name: "Tender");
        }
    }
}
