using System.Collections.Generic;
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
        public TenderService TenderService { get; }
        public MedicineForTenderingService() { }

        public MedicineForTenderingService(MyDbContext context)
        {
            MedicineForTenderingRepository = new MedicineForTenderingRepository(context);
            TenderService = new TenderService(context);
        }

        public MedicineForTendering Create(MedicineForTenderingDto dto)
        {
            return MedicineForTenderingRepository.Create(MedicineForTenderingAdapter.MedicineForTenderingDtoToMedicineForTendering(dto));
        }
        public MedicineForTenderingService(IMedicineForTenderingRepository medicineForTenderingRepository)
        {
            IMedicineForTenderingRepository = medicineForTenderingRepository;
        }

        public List<MedicineForTendering> GetAll()
        {
            return MedicineForTenderingRepository.GetAll();
        }
        public MedicineForTendering CreateIMedicineForTendering(MedicineForTenderingDto dto)
        {
            return MedicineForTenderingAdapter.MedicineForTenderingDtoToMedicineForTendering(dto);
        }

        public List<MedicineForTendering> GetAllForStub()
        {
           return IMedicineForTenderingRepository.GetAll();
          
        }
        public void CreateAllMedicineForTendering(TenderOrder tender)
        {
            foreach (MedicineTenderOffer medicineQuantity in tender.MedicinesWithQuantity)
            {
                Create(MedicineForTenderingAdapter.MedicineForebderingToMedicineForTenderingDto(new MedicineForTendering(medicineQuantity.MedicineName, medicineQuantity.Quantity, TenderService.getNextTenderId())));
            }
        }
      
    }
}
