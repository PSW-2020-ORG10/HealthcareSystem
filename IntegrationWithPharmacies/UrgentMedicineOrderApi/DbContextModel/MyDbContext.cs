using Microsoft.EntityFrameworkCore;
using UrgentMedicineOrderApi.Model;

namespace UrgentMedicineOrderApi.DbContextModel
{
    /// <summary>Class <c>MyDbContext</c> works with database as a part of <c>EntityFrameworkCore</c>.
    /// </summary>
    public class MyDbContext : DbContext
    {
        public DbSet<MedicineWithQuantity> MedicineWithQuantity { get; set; }
        public DbSet<UrgentMedicineOrder> UrgentMedicineOrder { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicineWithQuantity>().HasData(
                new MedicineWithQuantity(1,"Andol",150, "Against pain" )
            );

            modelBuilder.Entity<UrgentMedicineOrder>().HasData(
                new UrgentMedicineOrder(1, "Andol", 15, "Jankovic 3","12/01/2020")
            );

           
        }

    }
}
