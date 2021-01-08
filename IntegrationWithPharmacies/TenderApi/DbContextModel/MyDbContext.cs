using Microsoft.EntityFrameworkCore;
using System;
using TenderApi.Model;

namespace TenderApi.DbContextModel
{
    public class MyDbContext : DbContext
    {
        public DbSet<Tender> Tender { get; set; }
        public DbSet<MedicineForTendering> MedicineForTendering { get; set; }
        public DbSet<MedicineTenderOffer> MedicineTenderOffers { get; set; }
        public DbSet<PharmacyTenderOffer> PharmacyTenderOffers { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PharmacyTenderOffer>().HasData(
                  new PharmacyTenderOffer(1, "pharmacyApi", false, 1)
            );
            modelBuilder.Entity<Tender>().HasData(
                  new Tender(1, new DateTime(), false)
            );
            modelBuilder.Entity<MedicineForTendering>().HasData(
                 new MedicineForTendering(1, "Andol", 135, 1)
            );
            modelBuilder.Entity<MedicineTenderOffer>().HasData(
                 new MedicineTenderOffer(1, "Andol", 1, 1, 1, 1)
            );
        }
    }
}
