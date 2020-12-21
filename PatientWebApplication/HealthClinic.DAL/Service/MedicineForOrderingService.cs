using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;
using System.Collections.Generic;

namespace HealthClinic.CL.Service
{
    public class MedicineForOrderingService
    {
        public MedicineForOrderingRepository MedicineForOrderingRepository { get; }
        public IMedicineForOrderingRepository ImedicineForOrderingRepository { get; }
        public MedicineForOrderingService() { }

        public MedicineForOrderingService(MyDbContext context)
        {
            MedicineForOrderingRepository = new MedicineForOrderingRepository(context);
        }
        public MedicineForOrderingService(IMedicineForOrderingRepository medicineRepository)
        {
            ImedicineForOrderingRepository = medicineRepository;
        }
        public List<MedicineForOrdering> GetAll()
        {
            return MedicineForOrderingRepository.GetAll();
        }
        public MedicineForOrdering Create(MedicineForOrderingDto dto)
        {
            return MedicineForOrderingRepository.Create(MedicineForOrderingAdapter.MedicineOrderDtoToMedicineOrder(dto));
        }

        public List<MedicineForOrdering> GetAllForStub()
        {
            return ImedicineForOrderingRepository.GetAll();
        }

        
    }
}
