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
            MedicineWithQuantityService medicineWithQuantityService = new MedicineWithQuantityService(Create_stub_repository_medicines());

            String description = medicineWithQuantityService.GetMedicineDescriptionFromStub("Paracetamol");
            Assert.NotEqual("", description);
        }

        [Fact]
        public void Finds_No_Medicine_Description()
        {
            MedicineWithQuantityService medicineDescriptionService = new MedicineWithQuantityService(Create_stub_repository_medicines());

            String description = medicineDescriptionService.GetMedicineDescriptionFromStub("Clyndamicin");
            Assert.Equal("", description);
        }

        [Fact]
        public void Creates_Medicine_Description()
        {
            MedicineWithQuantityService medicineWithQuantityService = new MedicineWithQuantityService(Create_stub_repository_medicines());

            MedicineWithQuantity description = medicineWithQuantityService.createIMedicineDescription(new MedicineWithQuantityDto("Andol", 5,"Description"));
            Assert.NotNull(description);
        }
        [Fact]
        public void Creates_No_Medicine_Description()
        {
            MedicineWithQuantityService medicineWithQuantityService = new MedicineWithQuantityService(Create_stub_repository_medicines());

            MedicineWithQuantity description = medicineWithQuantityService.createIMedicineDescription(new MedicineWithQuantityDto("Paracetamol", 10,"Description"));
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
        public static IMedicineWithQuantityRepository Create_stub_repository_medicines()
        {
            var stubRepository = new Mock<IMedicineWithQuantityRepository>();
            MedicineWithQuantity medicine1 = new MedicineWithQuantity(1,"Paracetamol", 2,"Paracetamol is a medication used to treat pain and fever.");
            MedicineWithQuantity medicine2 = new MedicineWithQuantity(2,"Ibuprofen",5,"Ibuprofen is a medication used for treating pain, fever, and inflammation.");
            var medicines = new List<MedicineWithQuantity>();
            medicines.Add(medicine1);
            medicines.Add(medicine2);
            stubRepository.Setup(m => m.GetAll()).Returns(medicines);
            return stubRepository.Object;
        }
    }
}
