using AppointmentMicroserviceApi.Doctor;
using AppointmentMicroserviceApi.Patient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AppointmentMicroserviceApi.DbContextModel
{
    /// <summary>Class <c>MyDbContext</c> works with database as a part of <c>EntityFrameworkCore</c>.
    /// </summary>
    public class MyDbContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Referral> Referrals { get; set; }
        public DbSet<OperationReferral> OperationReferrals { get; set; }
        public DbSet<DoctorAppointment> DoctorAppointments { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Survey> Surveys { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Referral>().HasData(
                new Referral(1, "Aspirin", "25/02/2020", 3, "classify", "Patient had slight heart arrhythmia.", 1),
                new Referral(2, "Brufen", "11/05/2020", 1, "Appointment", "Patient had cold.", 2),
                new Referral(3, "Aspirin", "25/02/2020", 3, "classify", "Patient had slight heart arrhythmia.", 3),
                new Referral(4, "Brufen", "11/05/2020", 1, "Appointment", "Patient had cold.", 4),
                new Referral(5, "Aspirin", "25/02/2020", 3, "classify", "Patient had slight heart arrhythmia.", 5),
                new Referral(6, "Brufen", "11/05/2020", 1, "Appointment", "Patient had cold.", 6),
                new Referral(7, "Aspirin", "25/02/2020", 3, "classify", "Patient had slight heart arrhythmia.", 7),
                new Referral(8, "Brufen", "11/05/2020", 1, "Appointment", "Patient had cold.", 8),
                new Referral(9, "Aspirin", "25/02/2020", 3, "classify", "Patient had slight heart arrhythmia.", 9),
                new Referral(10, "Brufen", "11/05/2020", 1, "Appointment", "Patient had cold.", 10),
                new Referral(11, "Aspirin", "25/02/2020", 3, "classify", "Patient had slight heart arrhythmia.", 11),
                new Referral(12, "Brufen", "11/05/2020", 1, "Appointment", "Patient had cold.", 12)
           );

            modelBuilder.Entity<OperationReferral>().HasData(
                new OperationReferral(1, "Hemomycin", "15/09/2020", 1, "Operation", "Operation was successfull.", 1),
                new OperationReferral(2, "Amoxicillin", "18/10/2020", 3, "Operation", "Patient lost a lot of blood.", 2)
          );

            modelBuilder.Entity<Operation>().HasData(
                new Operation(1, 2, "23/12/2020", new TimeSpan(0, 14, 0, 0), new TimeSpan(0, 15, 0, 0, 0), 1, "room1"),
                new Operation(2, 1, "03/10/2020", new TimeSpan(0, 15, 0, 0), new TimeSpan(0, 15, 15, 0, 0), 2, "room1")
            );

            modelBuilder.Entity<DoctorAppointment>().HasData(
                new DoctorAppointment(1, new TimeSpan(0, 14, 15, 0, 0), "23/12/2020", 2, 1, new List<Referral>(), "1"),
                new DoctorAppointment(2, new TimeSpan(0, 14, 30, 0, 0), "23/12/2020", 2, 2, new List<Referral>(), "1"),
                new DoctorAppointment(3, new TimeSpan(0, 15, 0, 0, 0), "23/12/2020", 1, 2, new List<Referral>(), "1"),
                new DoctorAppointment(4, new TimeSpan(0, 15, 45, 0, 0), "23/12/2020", 1, 2, new List<Referral>(), "1"),
                new DoctorAppointment(5, new TimeSpan(0, 12, 0, 0, 0), "22/12/2020", 1, 1, new List<Referral>(), "1"),
                new DoctorAppointment(6, new TimeSpan(0, 12, 15, 0, 0), "22/12/2020", 2, 3, new List<Referral>(), "1"),
                new DoctorAppointment(7, new TimeSpan(), "07/02/2031", 1, 3, new List<Referral>(), "1"),
                new DoctorAppointment(8, new TimeSpan(), "07/12/2020", 1, 2, new List<Referral>(), "1"),
                new DoctorAppointment(9, new TimeSpan(), "05/12/2030", 1, 1, new List<Referral>(), "1"),
                new DoctorAppointment(10, new TimeSpan(), "11/11/2030", 1, 2, new List<Referral>(), "1"),
                new DoctorAppointment(11, new TimeSpan(), "14/03/2016", 2, 1, new List<Referral>(), "A2"),
                new DoctorAppointment(12, new TimeSpan(), "11/11/2010", 2, 2, new List<Referral>(), "B3")
            );

            modelBuilder.Entity<Question>().HasData(
                new Question(1, "Name", "Answer")
            );

            modelBuilder.Entity<Survey>().HasData(
                new Survey(1, 1, 3, 4, 5, 4, 5, 4, 5, 4, 5, 5, 5, 5, 4, 3, 3, 2, 2, 5),
                new Survey(2, 1, 4, 4, 5, 3, 1, 5, 5, 2, 2, 4, 2, 5, 3, 1, 3, 3, 3, 5)
            );


        }

    }
}
