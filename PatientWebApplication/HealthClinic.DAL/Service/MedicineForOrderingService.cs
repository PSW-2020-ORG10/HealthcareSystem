using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Service
{
    public class MedicineForOrderingService
    {
        public MedicineForOrderingRepository medicineForOrderingRepository { get; }
        public MedicineForOrderingService() { }

        public MedicineForOrderingService(MyDbContext context)
        {
            medicineForOrderingRepository = new MedicineForOrderingRepository(context);
        }
        public List<MedicineForOrdering> GetAll()
        {
            return medicineForOrderingRepository.GetAll();
        }
        public MedicineForOrdering Create(MedicineForOrderingDto dto)
        {
            MedicineForOrdering medicine = MedicineForOrderingAdapter.MedicineOrderDtoToMedicineOrder(dto);
            return medicineForOrderingRepository.Create(medicine);
        }
    }
}
