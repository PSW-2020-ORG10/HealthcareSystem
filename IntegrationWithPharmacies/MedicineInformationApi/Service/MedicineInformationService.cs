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
    public class MedicineInformationService : IMedicineInformationService
    {
        public MedicineInformationRepository MedicineWithQuantityRepository { get; }
        public IMedicineInformationRepository IMedicineWithQuantityRepository { get; }
        public MedicineInformationService() { }

        public MedicineInformationService(MyDbContext context)
        {
            MedicineWithQuantityRepository = new MedicineInformationRepository(context);
        }
        public MedicineInformationService(IMedicineInformationRepository mdicineWithQuantityRepository)
        {
            IMedicineWithQuantityRepository = mdicineWithQuantityRepository;
        }


        public List<MedicineInformation> GetAll()
        {
            return MedicineWithQuantityRepository.GetAll();
        }

        public MedicineInformation Create(MedicineInformationDto medicineWithQuantityDto)
        {
            return MedicineWithQuantityRepository.Create(MedicineInformationAdapter.MedicineWithQuantityDtoToMedicineWithQuantity(medicineWithQuantityDto));
        }

        public string GetMedicineDescriptionFromStub(string medicine)
        {
            MedicineInformation medicineWithQuantity = GetAllForStub().SingleOrDefault(medicine1 => medicine1.MedicineDescription.Name.Equals(medicine));
            return (medicineWithQuantity != null ? medicineWithQuantity.MedicineDescription.Description : "");
        }

        public List<MedicineInformation> GetAllForStub()
        {
            return IMedicineWithQuantityRepository.GetAll();
        }

        public void UpdateMedicineQuantityUrgentOrder(String medicine)
        {
            String[] medicineParts = medicine.Split('_');
            UpdateOneMedicineQuantity(new MedicineInformation(new MedicineDescription(medicineParts[0], ""), int.Parse(medicineParts[1])));
        }

        private void UpdateOneMedicineQuantity(MedicineInformation medicineWithQuantity)
        {
            MedicineInformation medicine = GetAll().SingleOrDefault(medicineName => medicineName.MedicineDescription.Name == medicineWithQuantity.MedicineDescription.Name);
            if (medicine != null) MedicineWithQuantityRepository.UpdateQuantity(medicine.Id, medicineWithQuantity.Quantity);
            else { Create(MedicineInformationAdapter.MedicineWithQuantityToMedicineWithQuantityDto(medicineWithQuantity)); }
        }

        public MedicineInformation CreateIMedicineDescription(MedicineInformationDto dto)
        {
            MedicineInformation medicineWithQuantity = IMedicineWithQuantityRepository.GetAll().SingleOrDefault(medicine => CheckMedicineNameEquality(dto, medicine));
            return (medicineWithQuantity == null ? MedicineInformationAdapter.MedicineWithQuantityDtoToMedicineWithQuantity(dto) : null);
        }

        private static bool CheckMedicineNameEquality(MedicineInformationDto dto, MedicineInformation MedicineWithQuantity)
        {
            return MedicineWithQuantity.MedicineDescription.Name.Equals(MedicineInformationAdapter.MedicineWithQuantityDtoToMedicineWithQuantity(dto).MedicineDescription.Name);
        }


        public string GetMedicineDescriptionFromDatabase(string medicine)
        {
            MedicineInformation medicineWithQuantity = GetAll().SingleOrDefault(medicineName => medicineName.MedicineDescription.Name.Equals(medicine));
            Console.WriteLine("ajkfhbkjsadnvjksdnvjkfnvjknfd kljv                " + medicineWithQuantity);
            return medicineWithQuantity == null || medicineWithQuantity.MedicineDescription.Description.Equals("") ? null : medicineWithQuantity.MedicineDescription.Description;
        }

        public void CreateMedicineWithDescription(MedicineInformationDto medicineWithQuantityDto)
        {
            MedicineInformation medicineWithQuantity = GetAll().SingleOrDefault(medicineName => medicineName.MedicineDescription.Name.Equals(medicineWithQuantityDto.MedicineDescription.Name));
            if (medicineWithQuantity != null) MedicineWithQuantityRepository.UpdateDescription(medicineWithQuantity, medicineWithQuantityDto.MedicineDescription.Description);
            else Create(medicineWithQuantityDto);
        }
        public void UpdateQuantity(int medicineId, int quantity)
        {
            MedicineWithQuantityRepository.UpdateQuantity(medicineId, quantity);
        }


    }
}
