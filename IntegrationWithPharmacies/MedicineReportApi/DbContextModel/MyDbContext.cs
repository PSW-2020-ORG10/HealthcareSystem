using MedicineReportApi.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace MedicineReportApi.DbContextModel
{
    /// <summary>Class <c>MyDbContext</c> works with database as a part of <c>EntityFrameworkCore</c>.
    /// </summary>
    public class MyDbContext : DbContext
    {
        public DbSet<Tender> Tender { get; set; }
        public DbSet<MedicineForTendering> MedicineForTendering { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tender>().HasData(
                new Tender(1, new DateTime(), false)
            );

            modelBuilder.Entity<MedicineForTendering>().HasData(
                  new MedicineForTendering(1, "Andol", 135,1)
            );
        }

    }
}
