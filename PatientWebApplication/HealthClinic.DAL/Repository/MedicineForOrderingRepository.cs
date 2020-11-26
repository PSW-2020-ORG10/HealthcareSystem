using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthClinic.CL.Repository
{
    public class MedicineForOrderingRepository : IMedicineForOrderingRepository
    {
        private MyDbContext dbContext;
        public MedicineForOrderingRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public MedicineForOrdering Create(MedicineForOrdering medicine)
        {
            dbContext.MedicinesForOrdering.Add(medicine);
            dbContext.SaveChanges();
            return medicine;
        }

        public List<MedicineForOrdering> GetAll()
        {
            return dbContext.MedicinesForOrdering.ToList();
        }
    }
}
