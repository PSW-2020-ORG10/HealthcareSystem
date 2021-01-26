using System.Collections.Generic;
using System.Linq;
using TenderApi.Adapter;
using TenderApi.DbContextModel;
using TenderApi.Dto;
using TenderApi.Model;
using TenderApi.Repository;

namespace TenderApi.Service
{
    public class TenderService
    {
        public TenderRepository TenderRepository { get; }
        public ITenderRepository ITenderRepository { get; }
        public MedicineForTenderingRepository MedicineForTenderingRepository { get; }
        public TenderService() { }

        public TenderService(MyDbContext context)
        {
            TenderRepository = new TenderRepository(context);
            MedicineForTenderingRepository = new MedicineForTenderingRepository(context);
        }
        public TenderService(ITenderRepository tenderRepository)
        {
            ITenderRepository = tenderRepository;
        }
        public Tender Create(TenderDto dto)
        {
            return TenderRepository.Create(TenderAdapter.TenderDtoToTender(dto));
        }

        public List<Tender> GetAll()
        {
            return TenderRepository.GetAll();
        }
        public Tender createITender(TenderDto dto)
        {
            return TenderAdapter.TenderDtoToTender(dto);
        }

        public List<Tender> GetAllForStub()
        {
            return ITenderRepository.GetAll();
        }
        public int GetNextTenderId()
        {
            return GetAll().Max(tender => tender.Id);
        }
        public void CloseTender(TenderOrder tender)
        {
            TenderRepository.CloseTender(GetAll().SingleOrDefault(tenderId => tenderId.Id == tender.Id));
        }
        public List<TenderOrder> GetAllActiveTenders()
        {
            List<TenderOrder> tenderOrders = FormTenderOrders();
            foreach (MedicineForTendering medicineForTendering in MedicineForTenderingRepository.GetAll())
            {
                FormOneMedicineInTender(tenderOrders, medicineForTendering);
            }
            return tenderOrders;
        }

        private void FormOneMedicineInTender(List<TenderOrder> tenderOrders, MedicineForTendering medicineForTendering)
        {
            foreach (TenderOrder tenderOrder in tenderOrders)
            {
                if (medicineForTendering.TenderId == tenderOrder.Id) tenderOrder.MedicinesWithQuantity.Add(new MedicineTenderOffer(medicineForTendering.Name, medicineForTendering.Quantity));
            }
        }

        private List<TenderOrder> FormTenderOrders()
        {
            List<TenderOrder> tenderOrders = new List<TenderOrder>();
            foreach (Tender tender in GetAll().Where(tender => tender.Closed == false).ToList())
            {
                tenderOrders.Add(new TenderOrder(new List<MedicineTenderOffer>(), tender.ExpirationDate.ToString("dd/MM/yyyy"), tender.Id, 0, ""));
            }
            return tenderOrders;
        }

        public TenderOrder GetTenderById(int id)
        {
            return GetAllActiveTenders().SingleOrDefault(tender => tender.Id == id);
        }
    }
}
