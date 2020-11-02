﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientWebApplication.Models;

namespace PatientWebApplication.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20201102145206_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Class_diagram.Model.Patient.Feedback", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("PatientId");

                    b.ToTable("Feedbacks");

                    b.HasData(
                        new
                        {
                            id = 1,
                            IsAnonymous = true,
                            IsPublic = true,
                            IsPublished = false,
                            Message = "First message",
                            PatientId = 1
                        },
                        new
                        {
                            id = 2,
                            IsAnonymous = false,
                            IsPublic = false,
                            IsPublished = false,
                            Message = "Second message",
                            PatientId = 1
                        },
                        new
                        {
                            id = 3,
                            IsAnonymous = false,
                            IsPublic = true,
                            IsPublished = false,
                            Message = "Third message",
                            PatientId = 1
                        });
                });

            modelBuilder.Entity("Class_diagram.Model.Patient.PatientUserWeb", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("allergie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("guest")
                        .HasColumnType("bit");

                    b.Property<bool>("isRegisteredBySecretary")
                        .HasColumnType("bit");

                    b.Property<string>("medicalIdNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("secondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("uniqueCitizensidentityNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            id = 1,
                            allergie = "Alergija",
                            city = "Grad",
                            dateOfBirth = "2/2/2020",
                            email = "email",
                            firstName = "Pera",
                            guest = false,
                            isRegisteredBySecretary = false,
                            medicalIdNumber = "1234",
                            password = "pass",
                            phoneNumber = "123",
                            secondName = "Peric",
                            uniqueCitizensidentityNumber = "1234"
                        });
                });

            modelBuilder.Entity("Class_diagram.Model.Patient.Feedback", b =>
                {
                    b.HasOne("Class_diagram.Model.Patient.PatientUserWeb", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
