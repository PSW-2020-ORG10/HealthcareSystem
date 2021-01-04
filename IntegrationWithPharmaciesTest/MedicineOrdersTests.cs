using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using IntegrationWithPharmacies.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace IntegrationWithPharmaciesTest
{
   public class MedicineOrdersTests
    {
        [Fact]
        public void Creates_Urgent_Order()
        {
            UrgentOrderService urgentMedicineOrderService = new UrgentOrderService(Create_stub_repository_urgent_orders());
            UrgentMedicineOrder order = urgentMedicineOrderService.createIUrgentMedicineOrder(new UrgentMedicineOrderDto("Andol", 1,"api1","12/12/2020"));
            Assert.NotNull(order);
        }
        [Fact]
        public void Creates_Tender()
        {
            TenderService tenderService = new TenderService(Create_stub_repository_tenders());
            Tender tender = tenderService.createITender(new TenderDto(new DateTime(),false));
            Assert.NotNull(tender);
        }

        [Fact]
        public void Creates_Medicines_For_Tender()
        {
            MedicineForTenderingService medicineForTenderingService = new MedicineForTenderingService(Create_stub_repository_Tenders_Medicine());
            MedicineForTendering medicine = medicineForTenderingService.CreateIMedicineForTendering(new MedicineForTenderingDto("Andol", 5, 1));
            Assert.NotNull(medicine);
        }

        public static IUrgentMedicineOrderRepository Create_stub_repository_urgent_orders()
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
        public static ITenderRepository Create_stub_repository_tenders()
        {
            var stubRepository = new Mock<ITenderRepository>();
            Tender tender = new Tender(1, new DateTime(), false);
            var tenders = new List<Tender>();
            tenders.Add(tender);
            stubRepository.Setup(m => m.GetAll()).Returns(tenders);
            return stubRepository.Object;
        }
        public static IMedicineForTenderingRepository Create_stub_repository_Tenders_Medicine()
        {
            var stubRepository = new Mock<IMedicineForTenderingRepository>();
            MedicineForTendering medicineForTendering = new MedicineForTendering(1,"Brufen",5,1);
            var medicinesForTendering = new List<MedicineForTendering>();
            medicinesForTendering.Add(medicineForTendering);
            stubRepository.Setup(m => m.GetAll()).Returns(medicinesForTendering);
            return stubRepository.Object;
        }
    }
}
