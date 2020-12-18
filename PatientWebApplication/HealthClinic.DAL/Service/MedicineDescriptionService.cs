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
        public IMedicineDescriptionRepository IMedicineDescriptionRepository { get; }
        public MedicineDescriptionService() { }

        public MedicineDescriptionService(MyDbContext context)
        {
            MedicineDescriptionRepository = new MedicineDescriptionRepository(context);
        }
      
        public MedicineDescription Create(MedicineDescriptionDto dto)
        {
            return MedicineDescriptionRepository.Create(MedicineDescriptionAdapter.MedicineDescriptionDtoToMedicineDescription(dto));
        }
        public MedicineDescriptionService(IMedicineDescriptionRepository medicineRepository)
        {
            IMedicineDescriptionRepository = medicineRepository;
        }

        public List<MedicineDescription> GetAll()
        {
            return MedicineDescriptionRepository.GetAll();
        }
        public List<MedicineDescription> GetAllForStub()
        {
            return IMedicineDescriptionRepository.GetAll();
        }
        public string GetMedicineDescriptionFromStub(string medicineName)
        {
            foreach (MedicineDescription medicine in GetAllForStub())
            {
                if (medicine.Name.Equals(medicineName))
                {
                    return medicine.Description;
                }
            }
            return "";
        }
        public String GetMedicineDescriptionFromDatabase(String medicine)
        {
            foreach (MedicineDescription medicineDescription in GetAll())
            {
                if (medicineDescription.Name.ToString().Equals(medicine))
                {
                    return medicineDescription.Description.ToString();
                }
            }
            return "";
        }

        public MedicineDescription createIMedicineDescription(MedicineDescriptionDto dto)
        {
            foreach (MedicineDescription medicine in IMedicineDescriptionRepository.GetAll())
            {
                if (medicine.Name.Equals(MedicineDescriptionAdapter.MedicineDescriptionDtoToMedicineDescription(dto).Name)) return null;
            }
            return MedicineDescriptionAdapter.MedicineDescriptionDtoToMedicineDescription(dto);
        }

    }
}
