﻿using System;
using System.Collections.Generic;
using UrgentMedicineOrderApi.Adapter;
using UrgentMedicineOrderApi.DbContextModel;
using UrgentMedicineOrderApi.Model;
using UrgentMedicineOrderApi.Service;

namespace UrgentMedicineOrderApi.AbstractFactory
{
    public class PharmacyGrpcSftp : IPharmacyGrpcSftp
    {
        private HttpRequests HttpRequests { get; }
        private UrgentOrderService UrgentOrderService { get; }
        private SmptServerService SmptServerService { get; }
        private MedicineAvailabilityTable MedicineAvailabilityTable { get; }
        public PharmacyGrpcSftp() { }
        public PharmacyGrpcSftp(MyDbContext context)
        {
            HttpRequests = new HttpRequests();
            SmptServerService = new SmptServerService();
            MedicineAvailabilityTable = new MedicineAvailabilityTable();
            UrgentOrderService = new UrgentOrderService(context);
        }

        public String CreateUrgentOrder(String medicine)
        {
            return FormUrgentOrderGrpc(medicine);
        }

        public String FormUrgentOrderGrpc(String medicine)
        {
            List<MedicineName> pharmaciesWithMedicine = UrgentOrderService.CheckMedicineAvailability2(medicine);
            if (pharmaciesWithMedicine == null) return null;
            HttpRequests.UpdateMedicineQuantity(medicine);
            return ForwardUrgentOrderGrpc(medicine, pharmaciesWithMedicine);
        }

        public String ForwardUrgentOrderGrpc(string medicine, List<MedicineName> pharmaciesWithMedicine)
        {
            UrgentMedicineOrder urgentMedicineOrder = UrgentOrderService.CreateUrgentOrder(medicine, pharmaciesWithMedicine);
            return UrgentOrderService.SendOrderGrpc(urgentMedicineOrder) ? CreateUrgenMedicineOrder(pharmaciesWithMedicine, urgentMedicineOrder) : null;
        }
        private String CreateUrgenMedicineOrder(List<MedicineName> pharmaciesWithMedicine, UrgentMedicineOrder urgentMedicineOrder)
        {
            UrgentOrderService.Create(UrgentMedicineOrderAdapter.UrgentMedicineOrderToUrgentMedicineOrderDto(urgentMedicineOrder));
            SmptServerService.SendEMailNotificationForUrgentOrder(urgentMedicineOrder, pharmaciesWithMedicine[0].Name);
            return pharmaciesWithMedicine[0].Name;
        }

    }
}
