using System;
using System.Collections.Generic;
using System.Text;
using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;

namespace HealthClinic.CL.Service
{
    public class MedicineForTenderingService : IMedicineForTenderingService
    {
        public MedicineForTenderingRepository MedicineForTenderingRepository { get; }
        public IMedicineForTenderingRepository IMedicineForTenderingRepository { get; }
        public MedicineForTenderingService() { }

        public MedicineForTenderingService(MyDbContext context)
        {
            MedicineForTenderingRepository = new MedicineForTenderingRepository(context);
        }

        public MedicineForTendering Create(MedicineForTenderingDto dto)
        {
            return MedicineForTenderingRepository.Create(MedicineForTenderingAdapter.MedicineForTenderingDtoToMedicineForTendering(dto));
        }
        public MedicineForTenderingService(IMedicineForTenderingRepository tenderRepository)
        {
            IMedicineForTenderingRepository = tenderRepository;
        }

        public List<MedicineForTendering> GetAll()
        {
            return MedicineForTenderingRepository.GetAll();
        }
       
    }
}
