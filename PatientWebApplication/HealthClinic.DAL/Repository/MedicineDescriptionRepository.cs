using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Repository
{
    public class MedicineDescriptionRepository : IMedicineDescriptionRepository
    {
        private MyDbContext DbContext;
        public MedicineDescriptionRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public MedicineDescription Create(MedicineDescription medicine)
        {
            DbContext.MedicineDescription.Add(medicine);
            DbContext.SaveChanges();
            return medicine;
        }

        public List<MedicineDescription> GetAll()
        {
            Console.WriteLine(DbContext.MedicineDescription.ToList().Count());
            return DbContext.MedicineDescription.ToList();
        }
    }
}
