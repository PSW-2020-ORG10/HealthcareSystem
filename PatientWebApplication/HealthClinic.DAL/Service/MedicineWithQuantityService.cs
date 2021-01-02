using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinic.CL.Service
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

        public void UpdateMedicineQuantity(List<MedicineTenderOffer> medicineTenderOffers)
        {
            foreach(MedicineTenderOffer medicineTenderOffer in medicineTenderOffers)
            {
                CheckMedicineInDB(GetAll(), medicineTenderOffer);
            }
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
            UpdateOneMedicineQuantity(new MedicineWithQuantity(medicineParts[0], int.Parse(medicineParts[1]),""));
        }

        private void UpdateOneMedicineQuantity(MedicineWithQuantity medicineWithQuantity)
        {
            MedicineWithQuantity medicine = GetAll().SingleOrDefault(medicineName => medicineName.Name == medicineWithQuantity.Name);
            if (medicine != null) MedicineWithQuantityRepository.UpdateQuantity(medicine, medicineWithQuantity.Quantity);
            else { Create(MedicineWithQuantityAdapter.MedicineWithQuantityToMedicineWithQuantityDto(medicineWithQuantity)); }
        }

        public MedicineWithQuantity createIMedicineDescription(MedicineWithQuantityDto dto)
        {
            MedicineWithQuantity MedicineWithQuantity = IMedicineWithQuantityRepository.GetAll().SingleOrDefault(medicine => CheckMedicineNameEquality(dto, medicine));
            return (MedicineWithQuantity == null ? MedicineWithQuantityAdapter.MedicineWithQuantityDtoToMedicineWithQuantity(dto) : null);
        }

        private static bool CheckMedicineNameEquality(MedicineWithQuantityDto dto, MedicineWithQuantity MedicineWithQuantity)
        {
            return MedicineWithQuantity.Name.Equals(MedicineWithQuantityAdapter.MedicineWithQuantityDtoToMedicineWithQuantity(dto).Name);
        }

        private void CheckMedicineInDB(List<MedicineWithQuantity> medicineWithQuantities, MedicineTenderOffer medicineTenderOffer)
        {
            MedicineWithQuantity medicine = medicineWithQuantities.SingleOrDefault(medicineName => medicineName.Name == medicineTenderOffer.MedicineName);
            if (medicine != null)  UpdateMedicine(medicineTenderOffer, medicine); 
            else{ CreateNewMedicineWithQuantity(medicineTenderOffer);  }
        }

        public string GetMedicineDescriptionFromDatabase(string medicine)
        {
            MedicineWithQuantity medicineWithQuantity = GetAll().SingleOrDefault(medicineName => medicineName.Name.Equals(medicine));
            return medicineWithQuantity.Description;
        }

        private void CreateNewMedicineWithQuantity(MedicineTenderOffer medicineTenderOffer)
        {
            MedicineWithQuantityRepository.Create(new MedicineWithQuantity(medicineTenderOffer.MedicineName, medicineTenderOffer.Quantity,""));
        }

        public void CreateMedicineWithDescription(MedicineWithQuantityDto medicineWithQuantityDto)
        {
            MedicineWithQuantity medicineWithQuantity = GetAll().SingleOrDefault(medicineName => medicineName.Name.Equals(medicineWithQuantityDto.Name));
            if(medicineWithQuantity!=null) MedicineWithQuantityRepository.UpdateDescription(medicineWithQuantity, medicineWithQuantityDto.Description);
            else Create(medicineWithQuantityDto);
        }

        private void UpdateMedicine(MedicineTenderOffer medicineTenderOffer, MedicineWithQuantity medicine)
        {
            MedicineWithQuantityRepository.UpdateQuantity(medicine, medicineTenderOffer.Quantity);
        }
    }
}
