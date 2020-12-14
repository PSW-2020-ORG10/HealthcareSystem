using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using IntegrationWithPharmacies.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationWithPharmaciesTest
{
    public class EPrescriptionTests
    {
        [Fact]
        public static IEPrescriptionRepository Create_stub_repository()
        {
            var stubRepository = new Mock<IEPrescriptionRepository>();
            EPrescription prescription = new EPrescription("Jankovic", "Pera", "Peric", "12356489", "Paracetamol", 3, "3 times per week");
            EPrescription prescription2 = new EPrescription("Benu", "Zika", "Milic", "11111111", "Brufen", 5, "5 times per week");

            var prescriptions = new List<EPrescription>();
            prescriptions.Add(prescription);
            prescriptions.Add(prescription2);
            stubRepository.Setup(m => m.GetAll()).Returns(prescriptions);

            return stubRepository.Object;
        }
        [Fact]
        public void Generates_EPrescription()
        {
            EPrescriptionService ePrescriptionService = new EPrescriptionService(Create_stub_repository());

            String textPresctioption = ePrescriptionService.GeneratePrescriptionForPatient("12356489");
            Assert.NotEqual("", textPresctioption);
        }

        [Fact]
        public void Generates_No_EPrescription()
        {
            EPrescriptionService ePrescriptionService = new EPrescriptionService(Create_stub_repository());

            String textPresctioption = ePrescriptionService.GeneratePrescriptionForPatient("99999999");
            Assert.Equal("", textPresctioption);
        }
        [Fact]
        public void Finds_Medicine_Description()
        {
            MedicineForOrderingService medicineForOrderingService = new MedicineForOrderingService(Create_stub_repository_medicine_orders());

            String description = medicineForOrderingService.GetMedicineDescription("Paracetamol");
            Assert.NotEqual("", description);
        }

        [Fact]
        public void Finds_No_Medicine_Description()
        {
            MedicineForOrderingService medicineForOrderingService = new MedicineForOrderingService(Create_stub_repository_medicine_orders());

            String description = medicineForOrderingService.GetMedicineDescription("Clyndamicin");
            Assert.Equal("", description);
        }

        public static IMedicineForOrderingRepository Create_stub_repository_medicine_orders()
        {
            var stubRepository = new Mock<IMedicineForOrderingRepository>();
            MedicineForOrdering medicine1 = new MedicineForOrdering(2, "Paracetamol", 100, "Paracetamol is a medication used to treat pain and fever.", 2);
            MedicineForOrdering medicine2 = new MedicineForOrdering(3, "Ibuprofen", 80, "Ibuprofen is a medication used for treating pain, fever, and inflammation.", 2);
            var orders = new List<MedicineForOrdering>();
            orders.Add(medicine1);
            orders.Add(medicine2);
            stubRepository.Setup(m => m.GetAll()).Returns(orders);
            return stubRepository.Object;
        }
    }
}
