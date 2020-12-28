using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace IntegrationWithPharmaciesTest
{
    public class EPrescriptionTests
    {
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
            MedicineDescriptionService medicineDescriptionService = new MedicineDescriptionService(Create_stub_repository_medicines());

            String description = medicineDescriptionService.GetMedicineDescriptionFromStub("Paracetamol");
            Assert.NotEqual("", description);
        }

        [Fact]
        public void Finds_No_Medicine_Description()
        {
            MedicineDescriptionService medicineDescriptionService = new MedicineDescriptionService(Create_stub_repository_medicines());

            String description = medicineDescriptionService.GetMedicineDescriptionFromStub("Clyndamicin");
            Assert.Equal("", description);
        }

        [Fact]
        public void Creates_Medicine_Description()
        {
            MedicineDescriptionService medicineDescriptionService = new MedicineDescriptionService(Create_stub_repository_medicines());

            MedicineDescription description = medicineDescriptionService.createIMedicineDescription(new MedicineDescriptionDto("Andol", "Description", 1));
            Assert.NotNull(description);
        }
        [Fact]
        public void Creates_No_Medicine_Description()
        {
            MedicineDescriptionService medicineDescriptionService = new MedicineDescriptionService(Create_stub_repository_medicines());

            MedicineDescription description = medicineDescriptionService.createIMedicineDescription(new MedicineDescriptionDto("Paracetamol", "Description", 1));
            Assert.Null(description);
        }
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
        public static IMedicineDescriptionRepository Create_stub_repository_medicines()
        {
            var stubRepository = new Mock<IMedicineDescriptionRepository>();
            MedicineDescription medicine1 = new MedicineDescription(1,"Paracetamol", "Paracetamol is a medication used to treat pain and fever.", 2);
            MedicineDescription medicine2 = new MedicineDescription(2,"Ibuprofen","Ibuprofen is a medication used for treating pain, fever, and inflammation.", 2);
            var orders = new List<MedicineDescription>();
            orders.Add(medicine1);
            orders.Add(medicine2);
            stubRepository.Setup(m => m.GetAll()).Returns(orders);
            return stubRepository.Object;
        }
    }
}
