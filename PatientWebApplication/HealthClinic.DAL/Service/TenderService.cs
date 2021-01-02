using System.Collections.Generic;
using System.Linq;
using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;

namespace HealthClinic.CL.Service
{
    public class TenderService: ITenderService
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
        public int getNextTenderId()
        {
            return GetAll().Max(tender => tender.id);
        }
        public void CloseTender(TenderOrder tender)
        {
            TenderRepository.CloseTender(GetAll().SingleOrDefault(tenderId => tenderId.id == tender.Id));
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
                tenderOrders.Add(new TenderOrder(new List<MedicineTenderOffer>(), tender.ActiveUntil.ToString("dd/MM/yyyy"), tender.id, 0, ""));
            }
            return tenderOrders;
        }

        public TenderOrder GetTenderById(int id)
        {
            return GetAllActiveTenders().SingleOrDefault(tender => tender.Id == id);
        }
    }
}
