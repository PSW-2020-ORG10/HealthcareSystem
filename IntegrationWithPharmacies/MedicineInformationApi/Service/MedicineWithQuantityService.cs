using MedicineInformationApi.Adapter;
using MedicineInformationApi.DbContextModel;
using MedicineInformationApi.Dto;
using MedicineInformationApi.Model;
using MedicineInformationApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicineInformationApi.Service
{
    public class MedicineWithQuantityService : IMedicineWithQuantityService
    {
        public MedicineWithQuantityRepository MedicineWithQuantityRepository { get; }
        public IMedicineWithQuantityRepository IMedicineWithQuantityRepository { get; }
        public MedicineWithQuantityService() { }

        public MedicineWithQuantityService(MyDbContext context)
        {
            MedicineWithQuantityRepository = new MedicineWithQuantityRepository(context);
        }
        public MedicineWithQuantityService(IMedicineWithQuantityRepository mdicineWithQuantityRepository)
        {
            IMedicineWithQuantityRepository = mdicineWithQuantityRepository;
        }


        public List<MedicineWithQuantity> GetAll()
        {
            return MedicineWithQuantityRepository.GetAll();
        }

        public MedicineWithQuantity Create(MedicineWithQuantityDto medicineWithQuantityDto)
        {
            return MedicineWithQuantityRepository.Create(MedicineWithQuantityAdapter.MedicineWithQuantityDtoToMedicineWithQuantity(medicineWithQuantityDto));
        }

        public string GetMedicineDescriptionFromStub(string medicine)
        {
            MedicineWithQuantity medicineWithQuantity = GetAllForStub().SingleOrDefault(medicine1 => medicine1.Name.Equals(medicine));
            return (medicineWithQuantity != null ? medicineWithQuantity.Description : "");
        }

        public List<MedicineWithQuantity> GetAllForStub()
        {
            return IMedicineWithQuantityRepository.GetAll();
        }

        public void UpdateMedicineQuantityUrgentOrder(String medicine)
        {
            String[] medicineParts = medicine.Split('_');
            UpdateOneMedicineQuantity(new MedicineWithQuantity(medicineParts[0], int.Parse(medicineParts[1]), ""));
        }

        private void UpdateOneMedicineQuantity(MedicineWithQuantity medicineWithQuantity)
        {
            MedicineWithQuantity medicine = GetAll().SingleOrDefault(medicineName => medicineName.Name == medicineWithQuantity.Name);
            if (medicine != null) MedicineWithQuantityRepository.UpdateQuantity(medicine.Id, medicineWithQuantity.Quantity);
            else { Create(MedicineWithQuantityAdapter.MedicineWithQuantityToMedicineWithQuantityDto(medicineWithQuantity)); }
        }

        public MedicineWithQuantity CreateIMedicineDescription(MedicineWithQuantityDto dto)
        {
            MedicineWithQuantity medicineWithQuantity = IMedicineWithQuantityRepository.GetAll().SingleOrDefault(medicine => CheckMedicineNameEquality(dto, medicine));
            return (medicineWithQuantity == null ? MedicineWithQuantityAdapter.MedicineWithQuantityDtoToMedicineWithQuantity(dto) : null);
        }

        private static bool CheckMedicineNameEquality(MedicineWithQuantityDto dto, MedicineWithQuantity MedicineWithQuantity)
        {
            return MedicineWithQuantity.Name.Equals(MedicineWithQuantityAdapter.MedicineWithQuantityDtoToMedicineWithQuantity(dto).Name);
        }


        public string GetMedicineDescriptionFromDatabase(string medicine)
        {
            MedicineWithQuantity medicineWithQuantity = GetAll().SingleOrDefault(medicineName => medicineName.Name.Equals(medicine));
            Console.WriteLine("ajkfhbkjsadnvjksdnvjkfnvjknfd kljv                " + medicineWithQuantity);
            return medicineWithQuantity == null || medicineWithQuantity.Description.Equals("") ? null : medicineWithQuantity.Description;
        }

        public void CreateMedicineWithDescription(MedicineWithQuantityDto medicineWithQuantityDto)
        {
            MedicineWithQuantity medicineWithQuantity = GetAll().SingleOrDefault(medicineName => medicineName.Name.Equals(medicineWithQuantityDto.Name));
            if (medicineWithQuantity != null) MedicineWithQuantityRepository.UpdateDescription(medicineWithQuantity, medicineWithQuantityDto.Description);
            else Create(medicineWithQuantityDto);
        }
        public void UpdateQuantity(int medicineId, int quantity)
        {
            MedicineWithQuantityRepository.UpdateQuantity(medicineId, quantity);
        }


    }
}
