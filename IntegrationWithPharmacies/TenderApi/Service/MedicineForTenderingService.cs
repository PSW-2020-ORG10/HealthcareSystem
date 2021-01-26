using System;
using System.Collections.Generic;
using TenderApi.Adapter;
using TenderApi.DbContextModel;
using TenderApi.Dto;
using TenderApi.Model;
using TenderApi.Repository;

namespace TenderApi.Service
{
    public class MedicineForTenderingService
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
                Create(MedicineForTenderingAdapter.MedicineForebderingToMedicineForTenderingDto(new MedicineForTendering(medicineQuantity.MedicineName, medicineQuantity.RequiredQuantity, TenderService.GetNextTenderId())));
            }
        }
    }
}
