﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserMicroserviceApi.DbContextModel;

namespace UserMicroserviceApi.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20210123200130_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("UserMicroserviceApi.Model.DoctorNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("DoctorUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorUserId");

                    b.ToTable("DoctorNotifications");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Data = "3. string",
                            DoctorUserId = 1
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.EmployeeUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("Salary")
                        .HasColumnType("double");

                    b.Property<string>("SecondName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UniqueCitizensidentityNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("EmployeeUser");

                    b.HasDiscriminator<string>("Discriminator").HasValue("EmployeeUser");
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.ManagerNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ManagerUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManagerUserId");

                    b.ToTable("ManagerNotification");
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DateAction")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("DateStamp")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PharmacyName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Text")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateAction = "02/02/2020",
                            DateStamp = "03/12/2020",
                            IsRemoved = false,
                            PharmacyName = "Apoteka Jankovic",
                            Text = "Introducing our new commercial for your old family friend: Defrinol Forte!",
                            TimeStamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            DateAction = "02/02/2020",
                            DateStamp = "03/12/2020",
                            IsRemoved = false,
                            PharmacyName = "Apoteka Jankovic",
                            Text = "The bag saves lives, if there is an Andol in it!",
                            TimeStamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            DateAction = "02/02/2020",
                            DateStamp = "03/12/2020",
                            IsRemoved = false,
                            PharmacyName = "Apoteka Jankovic",
                            Text = "Protects the heart, protects the brain, Aspirin!",
                            TimeStamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.ModelNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PatientUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientUserId");

                    b.ToTable("PatientNotifications");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Data = "3. string",
                            PatientUserId = 1
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.PatientUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Allergie")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("BornIn")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("City")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ExLastname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("File")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Guest")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsMarried")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsRegisteredBySecretary")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("MedicalIdNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ParentName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SecondName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UniqueCitizensidentityNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Allergie = "Alergija",
                            BornIn = "Grad2",
                            City = "Grad",
                            DateOfBirth = "02/02/1990",
                            Email = "patient1@gmail.com",
                            ExLastname = "",
                            File = "download.jfif",
                            FirstName = "Pera",
                            Gender = "Male",
                            Guest = false,
                            IsBlocked = false,
                            IsMarried = false,
                            IsRegisteredBySecretary = false,
                            IsVerified = true,
                            MedicalIdNumber = "212313",
                            ParentName = "Roditelj",
                            Password = "12345",
                            PhoneNumber = "123",
                            SecondName = "Peric",
                            UniqueCitizensidentityNumber = "1234"
                        },
                        new
                        {
                            Id = 2,
                            Allergie = "Alergija",
                            BornIn = "Grad2",
                            City = "Grad",
                            DateOfBirth = "21/07/1989",
                            Email = "marko_markovic@gmail.com",
                            ExLastname = "",
                            File = "man.jfif",
                            FirstName = "Marko",
                            Gender = "Male",
                            Guest = false,
                            IsBlocked = false,
                            IsMarried = false,
                            IsRegisteredBySecretary = false,
                            IsVerified = true,
                            MedicalIdNumber = "2112313",
                            ParentName = "Roditelj",
                            Password = "12345",
                            PhoneNumber = "555333",
                            SecondName = "Markovic",
                            UniqueCitizensidentityNumber = "123456789"
                        },
                        new
                        {
                            Id = 3,
                            Allergie = "Alergija",
                            BornIn = "Grad2",
                            City = "Grad",
                            DateOfBirth = "2/2/2020",
                            Email = "patient2@gmail.com",
                            ExLastname = "",
                            File = "download.jfif",
                            FirstName = "Stefan",
                            Gender = "Male",
                            Guest = false,
                            IsBlocked = false,
                            IsMarried = false,
                            IsRegisteredBySecretary = false,
                            IsVerified = true,
                            MedicalIdNumber = "212313",
                            ParentName = "Roditelj",
                            Password = "12345",
                            PhoneNumber = "123",
                            SecondName = "Lelic",
                            UniqueCitizensidentityNumber = "1234"
                        },
                        new
                        {
                            Id = 4,
                            Allergie = "Alergija",
                            BornIn = "Grad2",
                            City = "Grad",
                            DateOfBirth = "2/2/2020",
                            Email = "patient2@gmail.com",
                            ExLastname = "",
                            File = "man.jfif",
                            FirstName = "Marko",
                            Gender = "Female",
                            Guest = false,
                            IsBlocked = false,
                            IsMarried = false,
                            IsRegisteredBySecretary = false,
                            IsVerified = false,
                            MedicalIdNumber = "2112313",
                            ParentName = "Roditelj",
                            Password = "12345",
                            PhoneNumber = "123",
                            SecondName = "Lazarevic",
                            UniqueCitizensidentityNumber = "1234"
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PhoneNumbers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Name",
                            Number = 123
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsOnDuty")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Room")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ShiftId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ShiftId");

                    b.ToTable("Schedules");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = "08/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 2,
                            Date = "09/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 3,
                            Date = "10/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 4,
                            Date = "11/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 5,
                            Date = "12/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 6,
                            Date = "13/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 7,
                            Date = "14/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 8,
                            Date = "15/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 9,
                            Date = "16/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 10,
                            Date = "17/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 11,
                            Date = "18/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 12,
                            Date = "19/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 4
                        },
                        new
                        {
                            Id = 13,
                            Date = "20/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 14,
                            Date = "21/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 15,
                            Date = "23/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 16,
                            Date = "23/12/2020",
                            EmployeeId = 2,
                            IsOnDuty = true,
                            Room = "1",
                            ShiftId = 1
                        },
                        new
                        {
                            Id = 17,
                            Date = "22/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "1",
                            ShiftId = 2
                        },
                        new
                        {
                            Id = 18,
                            Date = "22/12/2020",
                            EmployeeId = 3,
                            IsOnDuty = true,
                            Room = "1",
                            ShiftId = 1
                        },
                        new
                        {
                            Id = 19,
                            Date = "23/12/2020",
                            EmployeeId = 4,
                            IsOnDuty = true,
                            Room = "1",
                            ShiftId = 1
                        },
                        new
                        {
                            Id = 20,
                            Date = "12/01/2021",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 4
                        },
                        new
                        {
                            Id = 21,
                            Date = "25/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "1",
                            ShiftId = 4
                        },
                        new
                        {
                            Id = 22,
                            Date = "29/12/2020",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 23,
                            Date = "31/01/2021",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 24,
                            Date = "16/01/2021",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 25,
                            Date = "17/01/2021",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 26,
                            Date = "18/01/2021",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 27,
                            Date = "19/01/2021",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 4
                        },
                        new
                        {
                            Id = 28,
                            Date = "20/01/2021",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 29,
                            Date = "21/01/2021",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        },
                        new
                        {
                            Id = 30,
                            Date = "22/01/2021",
                            EmployeeId = 1,
                            IsOnDuty = true,
                            Room = "Ordination 1",
                            ShiftId = 3
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EndTime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("StartTime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Shifts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndTime = "16:00",
                            StartTime = "14:00"
                        },
                        new
                        {
                            Id = 2,
                            EndTime = "12:30",
                            StartTime = "12:00"
                        },
                        new
                        {
                            Id = 3,
                            EndTime = "19:00",
                            StartTime = "08:00"
                        },
                        new
                        {
                            Id = 4,
                            EndTime = "23:00",
                            StartTime = "08:00"
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.Administrator", b =>
                {
                    b.HasBaseType("UserMicroserviceApi.Model.EmployeeUser");

                    b.HasDiscriminator().HasValue("Administrator");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            City = "Grad",
                            DateOfBirth = "12/12/1985",
                            Email = "admin1@gmail.com",
                            FirstName = "Pera",
                            Password = "password",
                            PhoneNumber = "123",
                            Salary = 133.0,
                            SecondName = "Peric",
                            UniqueCitizensidentityNumber = "1234"
                        },
                        new
                        {
                            Id = 6,
                            City = "Grad",
                            DateOfBirth = "12/12/1985",
                            Email = "admin2@gmail.com",
                            FirstName = "Ana",
                            Password = "password",
                            PhoneNumber = "123",
                            Salary = 133.0,
                            SecondName = "Stanic",
                            UniqueCitizensidentityNumber = "1234"
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.DoctorUser", b =>
                {
                    b.HasBaseType("UserMicroserviceApi.Model.EmployeeUser");

                    b.Property<bool>("IsSpecialist")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Ordination")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Speciality")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasDiscriminator().HasValue("DoctorUser");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Grad",
                            DateOfBirth = "02/02/1975",
                            Email = "email",
                            FirstName = "Konstantin",
                            Password = "pass",
                            PhoneNumber = "123",
                            Salary = 200.0,
                            SecondName = "Davidovic",
                            UniqueCitizensidentityNumber = "1234",
                            IsSpecialist = false,
                            Ordination = "Ordination 1",
                            Speciality = "Cardiology"
                        },
                        new
                        {
                            Id = 2,
                            City = "Grad",
                            DateOfBirth = "02/02/1982",
                            Email = "email",
                            FirstName = "Novak",
                            Password = "pass",
                            PhoneNumber = "123",
                            Salary = 200.0,
                            SecondName = "Maric",
                            UniqueCitizensidentityNumber = "12345",
                            IsSpecialist = false,
                            Ordination = "Ordination 2",
                            Speciality = "Pulmonology"
                        },
                        new
                        {
                            Id = 3,
                            City = "Grad",
                            DateOfBirth = "02/02/1988",
                            Email = "email",
                            FirstName = "Milica",
                            Password = "pass",
                            PhoneNumber = "123",
                            Salary = 200.0,
                            SecondName = "Tadic",
                            UniqueCitizensidentityNumber = "12346",
                            IsSpecialist = false,
                            Ordination = "Ordination 3",
                            Speciality = "Cardiology"
                        },
                        new
                        {
                            Id = 4,
                            City = "Grad",
                            DateOfBirth = "02/02/1988",
                            Email = "email",
                            FirstName = "Jovan",
                            Password = "pass",
                            PhoneNumber = "123",
                            Salary = 200.0,
                            SecondName = "Jovanovic",
                            UniqueCitizensidentityNumber = "12346",
                            IsSpecialist = false,
                            Ordination = "Ordination 4",
                            Speciality = "Pulmonology"
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.ManagerUser", b =>
                {
                    b.HasBaseType("UserMicroserviceApi.Model.EmployeeUser");

                    b.HasDiscriminator().HasValue("ManagerUser");

                    b.HasData(
                        new
                        {
                            Id = 17,
                            City = "Grad",
                            DateOfBirth = "22/04/1993",
                            Email = "email",
                            FirstName = "Manager Name",
                            Password = "pass",
                            PhoneNumber = "123",
                            Salary = 200.0,
                            SecondName = "Manager Surname",
                            UniqueCitizensidentityNumber = "1234"
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.SecretaryUser", b =>
                {
                    b.HasBaseType("UserMicroserviceApi.Model.EmployeeUser");

                    b.Property<string>("Room")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasDiscriminator().HasValue("SecretaryUser");

                    b.HasData(
                        new
                        {
                            Id = 162,
                            City = "Grad",
                            DateOfBirth = "12/12/2012",
                            Email = "email",
                            FirstName = "Secretary Name",
                            Password = "pass",
                            PhoneNumber = "123",
                            Salary = 133.0,
                            SecondName = "Secretary Surname",
                            UniqueCitizensidentityNumber = "1234",
                            Room = "Room"
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.DoctorNotification", b =>
                {
                    b.HasOne("UserMicroserviceApi.Model.DoctorUser", "DoctorUser")
                        .WithMany("SpecialNotifications")
                        .HasForeignKey("DoctorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.ManagerNotification", b =>
                {
                    b.HasOne("UserMicroserviceApi.Model.ManagerUser", "ManagerUser")
                        .WithMany("SpecialNotifications")
                        .HasForeignKey("ManagerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.ModelNotification", b =>
                {
                    b.HasOne("UserMicroserviceApi.Model.PatientUser", "PatientUser")
                        .WithMany("Notifications")
                        .HasForeignKey("PatientUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.Schedule", b =>
                {
                    b.HasOne("UserMicroserviceApi.Model.EmployeeUser", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserMicroserviceApi.Model.Shift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
