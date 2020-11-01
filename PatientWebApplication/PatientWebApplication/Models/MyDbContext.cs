using Class_diagram.Model.Patient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
       // public DbSet<PatientUser> Patients { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>().HasData(

            new Feedback(1, "First message", true, true, 1),
            new Feedback(2, "Second message", false, false, 2),
            new Feedback(3, "Third message", true, false, 3)


           );
        }

    }
}
