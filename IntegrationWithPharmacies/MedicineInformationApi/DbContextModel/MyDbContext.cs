using MedicineInformationApi.Model;
using Microsoft.EntityFrameworkCore;

namespace MedicineInformationApi.DbContextModel
{
    public class MyDbContext : DbContext
    {
        public DbSet<MedicineWithQuantity> MedicineWithQuantity { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicineWithQuantity>().HasData(
                new MedicineWithQuantity(1, "Andol", 150, "Against pain")
            );
        }
    }
}
