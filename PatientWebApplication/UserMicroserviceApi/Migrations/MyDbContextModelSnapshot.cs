﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserMicroserviceApi.DbContextModel;

namespace UserMicroserviceApi.Migrations
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

            modelBuilder.Entity("UserMicroserviceApi.Model.DoctorNotification", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("DoctorUserId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("DoctorUserId");

                    b.ToTable("DoctorNotifications");

                    b.HasData(
                        new
                        {
                            id = 3,
                            Data = "3. string",
                            DoctorUserId = 1
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.EmployeeUser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("city")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("dateOfBirth")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("firstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("salary")
                        .HasColumnType("double");

                    b.Property<string>("secondName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("uniqueCitizensidentityNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("EmployeeUser");

                    b.HasDiscriminator<string>("Discriminator").HasValue("EmployeeUser");
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.ManagerNotification", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ManagerUserId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ManagerUserId");

                    b.ToTable("ManagerNotification");
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.Message", b =>
                {
                    b.Property<int>("id")
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

                    b.HasKey("id");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            id = 1,
                            DateAction = "02/02/2020",
                            DateStamp = "03/12/2020",
                            IsRemoved = false,
                            PharmacyName = "Apoteka Jankovic",
                            Text = "Introducing our new commercial for your old family friend: Defrinol Forte!",
                            TimeStamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            id = 2,
                            DateAction = "02/02/2020",
                            DateStamp = "03/12/2020",
                            IsRemoved = false,
                            PharmacyName = "Apoteka Jankovic",
                            Text = "The bag saves lives, if there is an Andol in it!",
                            TimeStamp = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            id = 3,
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
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PatientUserId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("PatientUserId");

                    b.ToTable("PatientNotifications");

                    b.HasData(
                        new
                        {
                            id = 3,
                            Data = "3. string",
                            PatientUserId = 1
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.PatientUser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("allergie")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("bornIn")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("city")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("dateOfBirth")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("exLastname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("file")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("firstName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("gender")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("guest")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isBlocked")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isMarried")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isRegisteredBySecretary")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("isVerified")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("medicalIdNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("parentName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("secondName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("uniqueCitizensidentityNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            id = 1,
                            allergie = "Alergija",
                            bornIn = "Grad2",
                            city = "Grad",
                            dateOfBirth = "02/02/1990",
                            email = "patient1@gmail.com",
                            exLastname = "",
                            firstName = "Pera",
                            gender = "Male",
                            guest = false,
                            isBlocked = false,
                            isMarried = false,
                            isRegisteredBySecretary = false,
                            isVerified = false,
                            medicalIdNumber = "212313",
                            parentName = "Roditelj",
                            password = "12345",
                            phoneNumber = "123",
                            secondName = "Peric",
                            uniqueCitizensidentityNumber = "1234"
                        },
                        new
                        {
                            id = 2,
                            allergie = "Alergija",
                            bornIn = "Grad2",
                            city = "Grad",
                            dateOfBirth = "21/07/1989",
                            email = "marko_markovic@gmail.com",
                            exLastname = "",
                            file = "images.jfif",
                            firstName = "Marko",
                            gender = "Male",
                            guest = false,
                            isBlocked = false,
                            isMarried = false,
                            isRegisteredBySecretary = false,
                            isVerified = false,
                            medicalIdNumber = "2112313",
                            parentName = "Roditelj",
                            password = "12345",
                            phoneNumber = "555333",
                            secondName = "Markovic",
                            uniqueCitizensidentityNumber = "123456789"
                        },
                        new
                        {
                            id = 3,
                            allergie = "Alergija",
                            bornIn = "Grad2",
                            city = "Grad",
                            dateOfBirth = "2/2/2020",
                            email = "patient2@gmail.com",
                            exLastname = "",
                            file = "download.jfif",
                            firstName = "Stefan",
                            gender = "Male",
                            guest = false,
                            isBlocked = false,
                            isMarried = false,
                            isRegisteredBySecretary = false,
                            isVerified = false,
                            medicalIdNumber = "212313",
                            parentName = "Roditelj",
                            password = "12345",
                            phoneNumber = "123",
                            secondName = "Lelic",
                            uniqueCitizensidentityNumber = "1234"
                        },
                        new
                        {
                            id = 4,
                            allergie = "Alergija",
                            bornIn = "Grad2",
                            city = "Grad",
                            dateOfBirth = "2/2/2020",
                            email = "patient2@gmail.com",
                            exLastname = "",
                            firstName = "Marko",
                            gender = "Female",
                            guest = false,
                            isBlocked = false,
                            isMarried = false,
                            isRegisteredBySecretary = false,
                            isVerified = false,
                            medicalIdNumber = "2112313",
                            parentName = "Roditelj",
                            password = "12345",
                            phoneNumber = "123",
                            secondName = "Lazarevic",
                            uniqueCitizensidentityNumber = "1234"
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.PhoneNumber", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("number")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("PhoneNumbers");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "Name",
                            number = 123
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.Schedule", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("date")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("isOnDuty")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("room")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("shiftId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("shiftId");

                    b.ToTable("Schedules");

                    b.HasData(
                        new
                        {
                            id = 1,
                            EmployeeId = 1,
                            date = "08/12/2020",
                            isOnDuty = true,
                            room = "Ordination 1",
                            shiftId = 3
                        },
                        new
                        {
                            id = 2,
                            EmployeeId = 1,
                            date = "09/12/2020",
                            isOnDuty = true,
                            room = "Ordination 1",
                            shiftId = 3
                        },
                        new
                        {
                            id = 3,
                            EmployeeId = 1,
                            date = "10/12/2020",
                            isOnDuty = true,
                            room = "Ordination 1",
                            shiftId = 3
                        },
                        new
                        {
                            id = 4,
                            EmployeeId = 1,
                            date = "11/12/2020",
                            isOnDuty = true,
                            room = "Ordination 1",
                            shiftId = 3
                        },
                        new
                        {
                            id = 5,
                            EmployeeId = 1,
                            date = "12/12/2020",
                            isOnDuty = true,
                            room = "Ordination 1",
                            shiftId = 3
                        },
                        new
                        {
                            id = 6,
                            EmployeeId = 1,
                            date = "13/12/2020",
                            isOnDuty = true,
                            room = "Ordination 1",
                            shiftId = 3
                        },
                        new
                        {
                            id = 7,
                            EmployeeId = 1,
                            date = "14/12/2020",
                            isOnDuty = true,
                            room = "Ordination 1",
                            shiftId = 3
                        },
                        new
                        {
                            id = 8,
                            EmployeeId = 1,
                            date = "15/12/2020",
                            isOnDuty = true,
                            room = "Ordination 1",
                            shiftId = 3
                        },
                        new
                        {
                            id = 9,
                            EmployeeId = 1,
                            date = "16/12/2020",
                            isOnDuty = true,
                            room = "Ordination 1",
                            shiftId = 3
                        },
                        new
                        {
                            id = 10,
                            EmployeeId = 1,
                            date = "17/12/2020",
                            isOnDuty = true,
                            room = "Ordination 1",
                            shiftId = 3
                        },
                        new
                        {
                            id = 11,
                            EmployeeId = 1,
                            date = "18/12/2020",
                            isOnDuty = true,
                            room = "Ordination 1",
                            shiftId = 3
                        },
                        new
                        {
                            id = 12,
                            EmployeeId = 1,
                            date = "19/12/2020",
                            isOnDuty = true,
                            room = "Ordination 1",
                            shiftId = 4
                        },
                        new
                        {
                            id = 13,
                            EmployeeId = 1,
                            date = "20/12/2020",
                            isOnDuty = true,
                            room = "Ordination 1",
                            shiftId = 3
                        },
                        new
                        {
                            id = 14,
                            EmployeeId = 1,
                            date = "21/12/2020",
                            isOnDuty = true,
                            room = "Ordination 1",
                            shiftId = 3
                        },
                        new
                        {
                            id = 15,
                            EmployeeId = 1,
                            date = "23/12/2020",
                            isOnDuty = true,
                            room = "Ordination 1",
                            shiftId = 3
                        },
                        new
                        {
                            id = 16,
                            EmployeeId = 2,
                            date = "23/12/2020",
                            isOnDuty = true,
                            room = "1",
                            shiftId = 1
                        },
                        new
                        {
                            id = 17,
                            EmployeeId = 1,
                            date = "22/12/2020",
                            isOnDuty = true,
                            room = "1",
                            shiftId = 2
                        },
                        new
                        {
                            id = 18,
                            EmployeeId = 3,
                            date = "22/12/2020",
                            isOnDuty = true,
                            room = "1",
                            shiftId = 1
                        },
                        new
                        {
                            id = 19,
                            EmployeeId = 4,
                            date = "23/12/2020",
                            isOnDuty = true,
                            room = "1",
                            shiftId = 1
                        },
                        new
                        {
                            id = 20,
                            EmployeeId = 1,
                            date = "12/01/2021",
                            isOnDuty = true,
                            room = "Ordination 1",
                            shiftId = 4
                        },
                        new
                        {
                            id = 21,
                            EmployeeId = 1,
                            date = "25/12/2020",
                            isOnDuty = true,
                            room = "1",
                            shiftId = 4
                        },
                        new
                        {
                            id = 22,
                            EmployeeId = 1,
                            date = "29/12/2020",
                            isOnDuty = true,
                            room = "1",
                            shiftId = 3
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.Shift", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("endTime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("startTime")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("id");

                    b.ToTable("Shifts");

                    b.HasData(
                        new
                        {
                            id = 1,
                            endTime = "16:00",
                            startTime = "14:00"
                        },
                        new
                        {
                            id = 2,
                            endTime = "12:30",
                            startTime = "12:00"
                        },
                        new
                        {
                            id = 3,
                            endTime = "19:00",
                            startTime = "08:00"
                        },
                        new
                        {
                            id = 4,
                            endTime = "23:00",
                            startTime = "08:00"
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.Administrator", b =>
                {
                    b.HasBaseType("UserMicroserviceApi.Model.EmployeeUser");

                    b.HasDiscriminator().HasValue("Administrator");

                    b.HasData(
                        new
                        {
                            id = 5,
                            city = "Grad",
                            dateOfBirth = "12/12/1985",
                            email = "admin1@gmail.com",
                            firstName = "Pera",
                            password = "password",
                            phoneNumber = "123",
                            salary = 133.0,
                            secondName = "Peric",
                            uniqueCitizensidentityNumber = "1234"
                        },
                        new
                        {
                            id = 6,
                            city = "Grad",
                            dateOfBirth = "12/12/1985",
                            email = "admin2@gmail.com",
                            firstName = "Ana",
                            password = "password",
                            phoneNumber = "123",
                            salary = 133.0,
                            secondName = "Stanic",
                            uniqueCitizensidentityNumber = "1234"
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.DoctorUser", b =>
                {
                    b.HasBaseType("UserMicroserviceApi.Model.EmployeeUser");

                    b.Property<bool>("isSpecialist")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ordination")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("speciality")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasDiscriminator().HasValue("DoctorUser");

                    b.HasData(
                        new
                        {
                            id = 1,
                            city = "Grad",
                            dateOfBirth = "02/02/1975",
                            email = "email",
                            firstName = "Konstantin",
                            password = "pass",
                            phoneNumber = "123",
                            salary = 200.0,
                            secondName = "Davidovic",
                            uniqueCitizensidentityNumber = "1234",
                            isSpecialist = false,
                            ordination = "Ordination 1",
                            speciality = "Cardiology"
                        },
                        new
                        {
                            id = 2,
                            city = "Grad",
                            dateOfBirth = "02/02/1982",
                            email = "email",
                            firstName = "Novak",
                            password = "pass",
                            phoneNumber = "123",
                            salary = 200.0,
                            secondName = "Maric",
                            uniqueCitizensidentityNumber = "12345",
                            isSpecialist = false,
                            ordination = "Ordination 2",
                            speciality = "Pulmonology"
                        },
                        new
                        {
                            id = 3,
                            city = "Grad",
                            dateOfBirth = "02/02/1988",
                            email = "email",
                            firstName = "Milica",
                            password = "pass",
                            phoneNumber = "123",
                            salary = 200.0,
                            secondName = "Tadic",
                            uniqueCitizensidentityNumber = "12346",
                            isSpecialist = false,
                            ordination = "Ordination 3",
                            speciality = "Cardiology"
                        },
                        new
                        {
                            id = 4,
                            city = "Grad",
                            dateOfBirth = "02/02/1988",
                            email = "email",
                            firstName = "Jovan",
                            password = "pass",
                            phoneNumber = "123",
                            salary = 200.0,
                            secondName = "Jovanovic",
                            uniqueCitizensidentityNumber = "12346",
                            isSpecialist = false,
                            ordination = "Ordination 4",
                            speciality = "Pulmonology"
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.ManagerUser", b =>
                {
                    b.HasBaseType("UserMicroserviceApi.Model.EmployeeUser");

                    b.HasDiscriminator().HasValue("ManagerUser");

                    b.HasData(
                        new
                        {
                            id = 17,
                            city = "Grad",
                            dateOfBirth = "22/04/1993",
                            email = "email",
                            firstName = "Manager Name",
                            password = "pass",
                            phoneNumber = "123",
                            salary = 200.0,
                            secondName = "Manager Surname",
                            uniqueCitizensidentityNumber = "1234"
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.SecretaryUser", b =>
                {
                    b.HasBaseType("UserMicroserviceApi.Model.EmployeeUser");

                    b.Property<string>("room")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasDiscriminator().HasValue("SecretaryUser");

                    b.HasData(
                        new
                        {
                            id = 162,
                            city = "Grad",
                            dateOfBirth = "12/12/2012",
                            email = "email",
                            firstName = "Secretary Name",
                            password = "pass",
                            phoneNumber = "123",
                            salary = 133.0,
                            secondName = "Secretary Surname",
                            uniqueCitizensidentityNumber = "1234",
                            room = "Room"
                        });
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.DoctorNotification", b =>
                {
                    b.HasOne("UserMicroserviceApi.Model.DoctorUser", "DoctorUser")
                        .WithMany("specialNotifications")
                        .HasForeignKey("DoctorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.ManagerNotification", b =>
                {
                    b.HasOne("UserMicroserviceApi.Model.ManagerUser", "ManagerUser")
                        .WithMany("specialNotifications")
                        .HasForeignKey("ManagerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserMicroserviceApi.Model.ModelNotification", b =>
                {
                    b.HasOne("UserMicroserviceApi.Model.PatientUser", "PatientUser")
                        .WithMany("notifications")
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

                    b.HasOne("UserMicroserviceApi.Model.Shift", "shift")
                        .WithMany()
                        .HasForeignKey("shiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
