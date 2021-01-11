using PharmacyRegistrationApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace PharmacyRegistrationApi.DbContextModel
{
    /// <summary>Class <c>MyDbContext</c> works with database as a part of <c>EntityFrameworkCore</c>.
    /// </summary>
    public class MyDbContext : DbContext
    {
        
        public DbSet<RegistrationInPharmacy> Registrations { get; set; }
        
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RegistrationInPharmacy>().HasData(
                new RegistrationInPharmacy(1, 1, "api1","Jankovic 1","Novi Sad")
            );

            

        }

    }
}
