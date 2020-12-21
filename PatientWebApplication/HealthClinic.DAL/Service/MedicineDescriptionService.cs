using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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
            MedicineDescription medicineDescription = GetAllForStub().SingleOrDefault(medicineDescriptionIt => (medicineDescriptionIt.Name.Equals(medicineName)));
            return (medicineDescription != null ? medicineDescription.Description : "");
        }
        public string GetMedicineDescriptionFromDatabase(String medicineName)
        {
            MedicineDescription medicineDescription = GetAll().SingleOrDefault(medicineDescriptionIt => (medicineDescriptionIt.Name.Equals(medicineName)));
            return (medicineDescription != null ? medicineDescription.Description : "");
        }

        public MedicineDescription createIMedicineDescription(MedicineDescriptionDto dto)
        {
            MedicineDescription medicineDescription = IMedicineDescriptionRepository.GetAll().SingleOrDefault(medicineDescriptionIt => CheckMedicineNameEquality(dto, medicineDescriptionIt));
            return (medicineDescription == null ? MedicineDescriptionAdapter.MedicineDescriptionDtoToMedicineDescription(dto) : null);
        }

        private static bool CheckMedicineNameEquality(MedicineDescriptionDto dto, MedicineDescription medicineDescription)
        {
            return medicineDescription.Name.Equals(MedicineDescriptionAdapter.MedicineDescriptionDtoToMedicineDescription(dto).Name);
        }
    }
}
