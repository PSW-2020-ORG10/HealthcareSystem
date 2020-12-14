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
    public class MedicineDescriptionService
    {
        public MedicineDescriptionRepository MedicineDescriptionRepository { get; }
        public MedicineDescriptionService() { }

        public MedicineDescriptionService(MyDbContext context)
        {
            MedicineDescriptionRepository = new MedicineDescriptionRepository(context);
        }
        public List<MedicineDescription> GetAll()
        {
            return MedicineDescriptionRepository.GetAll();
        }
        public MedicineDescription Create(MedicineDescriptionDto dto)
        {
            return MedicineDescriptionRepository.Create(MedicineDescriptionAdapter.MedicineDescriptionDtoToMedicineDescription(dto));
        }
    }
}
