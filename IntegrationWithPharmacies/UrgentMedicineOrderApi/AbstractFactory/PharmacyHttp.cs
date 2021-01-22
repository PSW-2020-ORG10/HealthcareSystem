using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UrgentMedicineOrderApi.Adapter;
using UrgentMedicineOrderApi.DbContextModel;
using UrgentMedicineOrderApi.Model;
using UrgentMedicineOrderApi.Service;

namespace UrgentMedicineOrderApi.AbstractFactory
{
    public class PharmacyHttp : IPharmacyHttp
    {
        private HttpRequests HttpRequests { get; }
        private UrgentOrderService UrgentOrderService { get; }
        private SmptServerService SmptServerService { get; }
        private MedicineAvailabilityTable MedicineAvailabilityTable { get; }
        private String Url { get; }
       

        public PharmacyHttp() { }
        public PharmacyHttp(String url, MyDbContext context)
        {
            HttpRequests = new HttpRequests();
            SmptServerService = new SmptServerService();
            MedicineAvailabilityTable = new MedicineAvailabilityTable();
            UrgentOrderService = new UrgentOrderService(context);
            Url = url;
         

        }
        public String CreateUrgentOrder(String medicine)
        {
            return FormUrgentOrderHttp(medicine);
        }
        private String FormUrgentOrderHttp(string medicine)
        {
            List<MedicineName> pharmaciesWithMedicine = CheckMedicineAvailability(medicine);
            if (pharmaciesWithMedicine == null) return null;
            HttpRequests.UpdateMedicineQuantity(medicine);
            return ForwardUrgentUrderHttp(medicine, pharmaciesWithMedicine);
        }

        private String ForwardUrgentUrderHttp(string medicine, List<MedicineName> pharmaciesWithMedicine)
        {
            UrgentMedicineOrder urgentMedicineOrder = UrgentOrderService.CreateUrgentOrder(medicine, pharmaciesWithMedicine);
            if (UrgentOrderService.SendOrderHttp(urgentMedicineOrder)) return CretaeUrgenMedicinetOrder(pharmaciesWithMedicine, urgentMedicineOrder);
            return null;
        }

        private String CretaeUrgenMedicinetOrder(List<MedicineName> pharmaciesWithMedicine, UrgentMedicineOrder urgentMedicineOrder)
        {
            UrgentOrderService.Create(UrgentMedicineOrderAdapter.UrgentMedicineOrderToUrgentMedicineOrderDto(urgentMedicineOrder));
            SmptServerService.SendEMailNotificationForUrgentOrdee(urgentMedicineOrder, pharmaciesWithMedicine[0].Name);
            return pharmaciesWithMedicine[0].Name;
        }
        public List<MedicineName> CheckMedicineAvailability(string medicine)
        {
            return MedicineAvailabilityTable.FormMedicineAvailability(HttpRequests.FormMedicineAvailabilityRequest(medicine));
        }

     
    }
}
