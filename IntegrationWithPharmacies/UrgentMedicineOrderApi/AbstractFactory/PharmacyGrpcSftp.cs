using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UrgentMedicineOrderApi.Adapter;
using UrgentMedicineOrderApi.DbContextModel;
using UrgentMedicineOrderApi.Model;
using UrgentMedicineOrderApi.Service;

namespace UrgentMedicineOrderApi.AbstractFactory
{
    public class PharmacyGrpcSftp : IPharmacyHttp
    {
        public String Url; 
        private HttpRequests HttpRequests { get; }
        private UrgentOrderService UrgentOrderService { get; }
        private SmptServerService SmptServerService { get; }
        private MedicineAvailabilityTable MedicineAvailabilityTable { get; }
        public PharmacyGrpcSftp() { }
        public PharmacyGrpcSftp(string url, MyDbContext context)
        {
            Url = url;
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
            return ForwardUrgentUrderGrpc(medicine, pharmaciesWithMedicine);
        }

        private String ForwardUrgentUrderGrpc(string medicine, List<MedicineName> pharmaciesWithMedicine)
        {
            UrgentMedicineOrder urgentMedicineOrder = UrgentOrderService.CreateUrgentOrder(medicine, pharmaciesWithMedicine);
            if (UrgentOrderService.SendOrderGrpc(urgentMedicineOrder)) return CretaeUrgenMedicinetOrder(pharmaciesWithMedicine, urgentMedicineOrder);
            return null;
        }
        private String CretaeUrgenMedicinetOrder(List<MedicineName> pharmaciesWithMedicine, UrgentMedicineOrder urgentMedicineOrder)
        {
            UrgentOrderService.Create(UrgentMedicineOrderAdapter.UrgentMedicineOrderToUrgentMedicineOrderDto(urgentMedicineOrder));
            SmptServerService.SendEMailNotificationForUrgentOrdee(urgentMedicineOrder, pharmaciesWithMedicine[0].Name);
            return pharmaciesWithMedicine[0].Name;
        }
    }
}
