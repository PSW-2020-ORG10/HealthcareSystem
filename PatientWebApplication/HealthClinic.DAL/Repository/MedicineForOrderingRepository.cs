using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinic.CL.Repository
{
    public class MedicineForOrderingRepository : IMedicineForOrderingRepository
    {
        private MyDbContext DbContext;
        public MedicineForOrderingRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public MedicineForOrdering Create(MedicineForOrdering medicine)
        {
            DbContext.MedicinesForOrdering.Add(medicine);
            DbContext.SaveChanges();
            return medicine;
        }

        public List<MedicineForOrdering> GetAll()
        {
            return DbContext.MedicinesForOrdering.ToList();
        }
    }
}
