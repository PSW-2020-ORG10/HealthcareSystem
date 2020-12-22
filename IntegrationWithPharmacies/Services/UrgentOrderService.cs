using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using IntegrationWithPharmacies.Controllers;
using IntegrationWithPharmacies.FileProtocol;

namespace IntegrationWithPharmacies.Services
{
    public class UrgentOrderService
    {
        private HttpService HttpService { get; }
        public UrgentOrderService(MyDbContext context)
        {
            HttpService = new HttpService();
        }
        public Boolean SendOrderHttp(UrgentMedicineOrder order)
        {
            String medicineOrder = CreateOrder(order);
            try
            {
                HttpService.SendUrgentOrder(medicineOrder);
                return true;
            }
            catch (Exception e) { return false; }
        }
        public Boolean SendOrderGrpc(UrgentMedicineOrder order)
        {
            String medicineOrder = CreateOrder(order);
            try
            {
                //NE ZNAM KAKO DA POSALJEM  PREKO GRPC
                return true;
            }
            catch (Exception e) { return false; }
        }
        public String CreateOrder(UrgentMedicineOrder order)
        {
            return order.Name + ":"+ order.Quantity.ToString()+":"+order.Pharmacy;

        }
    }
}
