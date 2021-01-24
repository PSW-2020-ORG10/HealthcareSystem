using MedicineInformationApi.DbContextModel;
using MedicineInformationApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicineInformationApi.Repository
{
    public class MedicineWithQuantityRepository : IMedicineWithQuantityRepository
    {
        private MyDbContext DbContext;

        public MedicineWithQuantityRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public MedicineWithQuantity Create(MedicineWithQuantity medicineWithQuantity)
        {
            DbContext.MedicineWithQuantity.Add(medicineWithQuantity);
            DbContext.SaveChanges();
            return medicineWithQuantity;
        }

        public List<MedicineWithQuantity> GetAll()
        {
            return DbContext.MedicineWithQuantity.ToList();
        }

        public void UpdateQuantity(int medicineId, int quantity)
        {
            MedicineWithQuantity medicineWithQuantity = GetAll().SingleOrDefault(medicine => medicine.Id == medicineId);
            medicineWithQuantity.Quantity += quantity;
            DbContext.SaveChanges();
        }
        public void UpdateDescription(MedicineWithQuantity medicine, String description)
        {
            medicine.Description = description;
            DbContext.SaveChanges();
        }
    }
}
