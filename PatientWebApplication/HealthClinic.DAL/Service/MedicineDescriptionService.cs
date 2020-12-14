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
    public class MedicineDescriptionService : IMedicineDescriptionService
    {
        public MedicineDescriptionRepository MedicineDescriptionRepository { get; }
        public MedicineDescriptionService() { }

        public MedicineDescriptionService(MyDbContext context)
        {
            MedicineDescriptionRepository = new MedicineDescriptionRepository(context);
        }
      
        public MedicineDescription Create(MedicineDescriptionDto dto)
        {
            return MedicineDescriptionRepository.Create(MedicineDescriptionAdapter.MedicineDescriptionDtoToMedicineDescription(dto));
        }

        public List<MedicineDescription> GetAll()
        {
            return MedicineDescriptionRepository.GetAll();
        }
    }
}
