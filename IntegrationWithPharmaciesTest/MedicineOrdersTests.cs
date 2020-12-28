using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;
using IntegrationWithPharmacies.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace IntegrationWithPharmaciesTest
{
   public class MedicineOrdersTests
    {
        [Fact]
        public void Creates_Urgent_Order()
        {
            UrgentOrderService urgentMedicineOrderService = new UrgentOrderService(Create_stub_repository_urgen_orders());

            UrgentMedicineOrder order = urgentMedicineOrderService.createIUrgentMedicineOrder(new UrgentMedicineOrderDto("Andol", 1,"api1","12/12/2020"));
            Assert.NotNull(order);
        }

        public static IUrgentMedicineOrderRepository Create_stub_repository_urgen_orders()
        {
            var stubRepository = new Mock<IUrgentMedicineOrderRepository>();
            UrgentMedicineOrder order1 = new UrgentMedicineOrder(1, "Paracetamol", 2, "api3","12/12/2020");
            UrgentMedicineOrder order2 = new UrgentMedicineOrder(2, "Ibuprofen", 3,"api2","12/12/2020");
            var orders = new List<UrgentMedicineOrder>();
            orders.Add(order1);
            orders.Add(order2);
            stubRepository.Setup(m => m.GetAll()).Returns(orders);
            return stubRepository.Object;
        }
    }
}
