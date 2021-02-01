﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PharmacyRegistrationApi.DbContextModel;

namespace PharmacyRegistrationApi.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PharmacyRegistrationApi.Model.PharmacyConnectionInfo", b =>
                {
                    b.Property<string>("ApiKey")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("RegistrationInPharmacyId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ApiKey");

                    b.HasIndex("RegistrationInPharmacyId")
                        .IsUnique();

                    b.ToTable("RegistrationsInfo");

                    b.HasData(
                        new
                        {
                            ApiKey = "65ftvyubuef74f8H",
                            Email = "jankovic1@gmail.com",
                            RegistrationInPharmacyId = 1,
                            Url = "http://localhost:8086"
                        },
                        new
                        {
                            ApiKey = "65ftvyubuef74f8G",
                            Email = "benu1@gmail.com",
                            RegistrationInPharmacyId = 2,
                            Url = "http://localhost:8082"
                        });
                });

            modelBuilder.Entity("PharmacyRegistrationApi.Model.PharmacyNameInfo", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<int>("RegistrationInPharmacyId")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.HasIndex("RegistrationInPharmacyId")
                        .IsUnique();

                    b.ToTable("PharmacyNameInfos");

                    b.HasData(
                        new
                        {
                            Name = "Jankovic 1",
                            RegistrationInPharmacyId = 1
                        },
                        new
                        {
                            Name = "Benu 1",
                            RegistrationInPharmacyId = 2
                        });
                });

            modelBuilder.Entity("PharmacyRegistrationApi.Model.RegistrationInPharmacy", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PharmacyId")
                        .HasColumnType("int");

                    b.Property<string>("Town")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Registrations");

                    b.HasData(
                        new
                        {
                            id = 1,
                            PharmacyId = 1,
                            Town = "Novi Sad"
                        },
                        new
                        {
                            id = 2,
                            PharmacyId = 2,
                            Town = "Novi Sad"
                        });
                });

            modelBuilder.Entity("PharmacyRegistrationApi.Model.PharmacyConnectionInfo", b =>
                {
                    b.HasOne("PharmacyRegistrationApi.Model.RegistrationInPharmacy", null)
                        .WithOne("PharmacyConnectionInfo")
                        .HasForeignKey("PharmacyRegistrationApi.Model.PharmacyConnectionInfo", "RegistrationInPharmacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PharmacyRegistrationApi.Model.PharmacyNameInfo", b =>
                {
                    b.HasOne("PharmacyRegistrationApi.Model.RegistrationInPharmacy", null)
                        .WithOne("PharmacyNameInfo")
                        .HasForeignKey("PharmacyRegistrationApi.Model.PharmacyNameInfo", "RegistrationInPharmacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
