using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthClinic.CL.Repository
{
    public class MedicineDescriptionRepository : IMedicineDescriptionRepository
    {
        private MyDbContext DbContext;
        public MedicineDescriptionRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public MedicineDescriptionRepository() { }  
        public MedicineDescription Create(MedicineDescription medicine)
        {
            DbContext.MedicineDescriptions.Add(medicine);
            DbContext.SaveChanges();
            return medicine;
        }

        public List<MedicineDescription> GetAll()
        {
            return DbContext.MedicineDescriptions.ToList();
        }
    }
}
