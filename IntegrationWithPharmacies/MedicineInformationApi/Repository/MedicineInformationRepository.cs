using MedicineInformationApi.DbContextModel;
using MedicineInformationApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicineInformationApi.Repository
{
    public class MedicineInformationRepository : IMedicineInformationRepository
    {
        private MyDbContext DbContext;

        public MedicineInformationRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public MedicineInformation Create(MedicineInformation medicineWithQuantity)
        {
            DbContext.MedicineInformations.Add(medicineWithQuantity);
            DbContext.SaveChanges();
            return medicineWithQuantity;
        }

        public List<MedicineInformation> GetAll()
        {
            return DbContext.MedicineInformations.ToList();
        }

        public void UpdateQuantity(int medicineId, int quantity)
        {
            MedicineInformation medicineWithQuantity = GetAll().SingleOrDefault(medicine => medicine.Id == medicineId);
            medicineWithQuantity.Quantity += quantity;
            DbContext.SaveChanges();
        }
        public void UpdateDescription(MedicineInformation medicine, String description)
        {
            medicine.MedicineDescription.Description = description;
            DbContext.SaveChanges();
        }
    }
}
