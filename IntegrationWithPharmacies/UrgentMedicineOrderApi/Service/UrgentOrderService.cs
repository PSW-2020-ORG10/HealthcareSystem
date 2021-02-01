﻿using System;
using System.Collections.Generic;
using UrgentMedicineOrderApi.Repository;
using UrgentMedicineOrderApi.DbContextModel;
using UrgentMedicineOrderApi.Model;
using UrgentMedicineOrderApi.Dto;
using UrgentMedicineOrderApi.Adapter;
using UrgentMedicineOrderApi.AbstractFactory;
using Castle.Core.Internal;

namespace UrgentMedicineOrderApi.Service
{
    public class UrgentOrderService
    {
        private HttpRequests HttpRequests { get; }
        private MedicineAvailabilityTable MedicineAvailabilityTable { get; }
        public UrgentMedicineOrderRepository UrgentMedicineOrderRepository { get; }
        public IUrgentMedicineOrderRepository IUrgentMedicineOrderRepository { get; }
        public PharmacyFactoryGrpcAndSftp PharmacyFactoryGrpcAndSftp { get; }
        public PharmacyFactoryHttp PharmacyFactoryHttp { get; }
        public MyDbContext Context { get; }

        public UrgentOrderService(MyDbContext context)
        {
            HttpRequests = new HttpRequests();
            MedicineAvailabilityTable = new MedicineAvailabilityTable();
            UrgentMedicineOrderRepository = new UrgentMedicineOrderRepository(context);
            PharmacyFactoryGrpcAndSftp = new PharmacyFactoryGrpcAndSftp();
            PharmacyFactoryHttp = new PharmacyFactoryHttp();
            Context = context;
        }

        public UrgentOrderService(IUrgentMedicineOrderRepository urgentMedicineOrderRepository)
        {
            IUrgentMedicineOrderRepository = urgentMedicineOrderRepository;
        }
        public UrgentMedicineOrder Create(UrgentMedicineOrderDto dto)
        {
            return UrgentMedicineOrderRepository.Create(UrgentMedicineOrderAdapter.UrgentMedicineOrderDtoUrgentMedicineOrder(dto));
        }
        public String FormUrgentOrder(string medicine)
        {
            List<String> pharmacies = new List<String>();

            foreach(RegistrationInPharmacy registrationInPharmacy in HttpRequests.GetRegistrationsInPharmaciesAll())
            {
                DefineTyepOfApiKey(medicine, pharmacies, registrationInPharmacy);
            }
            return (pharmacies.Count != 0) ? pharmacies[0] : null;
        }

        private void DefineTyepOfApiKey(String medicine, List<string> pharmacies, RegistrationInPharmacy registrationInPharmacy)
        {
            if (registrationInPharmacy.PharmacyConnectionInfo.ApiKey.Substring(registrationInPharmacy.PharmacyConnectionInfo.ApiKey.Length - 1).Equals("H"))
            {
                UrgentOrderForHttps(medicine, pharmacies, registrationInPharmacy);
            }
            else UrgentOrderForSftpGrpc(medicine, pharmacies);
            
        }

        private void UrgentOrderForSftpGrpc(String medicine, List<string> pharmacies)
        {
            IPharmacy ipharmacy = PharmacyFactoryGrpcAndSftp.GetIPharmacy(Context);
            if (!ipharmacy.CreateUrgentOrder(medicine).IsNullOrEmpty()) { pharmacies.Add(ipharmacy.CreateUrgentOrder(medicine)); }
        }

        private void UrgentOrderForHttps(string medicine, List<string> pharmacies, RegistrationInPharmacy registrationInPharmacy)
        {
            IPharmacy ipharmacy = PharmacyFactoryHttp.GetIPharmacy(Context);

            if (!ipharmacy.CreateUrgentOrder(medicine).IsNullOrEmpty()) { pharmacies.Add(ipharmacy.CreateUrgentOrder(medicine)); }
        }

        public List<UrgentMedicineOrder> GetAll()
        {
            return UrgentMedicineOrderRepository.GetAll();
        }
        public List<UrgentMedicineOrder> GetAllForStub()
        {
            return IUrgentMedicineOrderRepository.GetAll();
        }
        public UrgentMedicineOrder createIUrgentMedicineOrder(UrgentMedicineOrderDto dto)
        {
            return UrgentMedicineOrderAdapter.UrgentMedicineOrderDtoUrgentMedicineOrder(dto);
        }
        public Boolean SendOrderHttp(UrgentMedicineOrder order)
        {
            try
            {
                HttpRequests.SendUrgentOrder(CreateOrder(order));
                return true;
            }
            catch (Exception e) { return false; }
        }
        public Boolean SendOrderGrpc(UrgentMedicineOrder order)
        {
            try
            {
                _= new ClientScheduledService().SendMessage(CreateOrder(order)).Result;
                return true;
            }
            catch (Exception e) { return false; }
        }
        public String CreateOrder(UrgentMedicineOrder order)
        {
            return order.Name + ":"+ order.Quantity.ToString()+":"+order.Pharmacy;

        }
        public static UrgentMedicineOrder CreateUrgentOrder(string medicine, List<MedicineName> pharmaciesWithMedicine)
        {
            String[] parts = medicine.Split("_");

            return new UrgentMedicineOrder(parts[0], int.Parse(parts[1]), pharmaciesWithMedicine[0].Api, DateTime.Now.ToString("dd/MM/yyyy"));
        }

        public List<MedicineName> CheckMedicineAvailability(string medicine)
        {
            return MedicineAvailabilityTable.FormMedicineAvailability(HttpRequests.FormMedicineAvailabilityRequest(medicine));
        }
        public List<MedicineName> CheckMedicineAvailability2(string medicine)
        {
            return MedicineAvailabilityTable.FormMedicineAvailability(HttpRequests.FormMedicineAvailabilityRequest2(medicine));
        }
    }
}
