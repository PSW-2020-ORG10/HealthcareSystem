
using MedicineInformationApi.Dto;
using MedicineInformationApi.Model;
using MedicineInformationApi.Repository;
using MedicineInformationApi.Service;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace IntegrationWithPharmaciesTest
{
    public class EPrescriptionTests
    {
        [Fact]
        public void Finds_Medicine_Description()
        {
            MedicineInformationService medicineWithQuantityService = new MedicineInformationService(Create_stub_repository_medicines());

            String description = medicineWithQuantityService.GetMedicineDescriptionFromStub("Paracetamol");
            Assert.NotEqual("", description);
        }

        [Fact]
        public void Finds_No_Medicine_Description()
        {
            MedicineInformationService medicineDescriptionService = new MedicineInformationService(Create_stub_repository_medicines());

            String description = medicineDescriptionService.GetMedicineDescriptionFromStub("Clyndamicin");
            Assert.Equal("", description);
        }

        [Fact]
        public void Creates_Medicine_Description()
        {
            MedicineInformationService medicineWithQuantityService = new MedicineInformationService(Create_stub_repository_medicines());

            MedicineInformation description = medicineWithQuantityService.CreateIMedicineDescription(new MedicineInformationDto(new MedicineDescription("Andol","Description"),5));
            Assert.NotNull(description);
        }
        [Fact]
        public void Creates_No_Medicine_Description()
        {
            MedicineInformationService medicineWithQuantityService = new MedicineInformationService(Create_stub_repository_medicines());

            MedicineInformation description = medicineWithQuantityService.CreateIMedicineDescription(new MedicineInformationDto(new MedicineDescription("Paracetamol","Description"),10));
            Assert.Null(description);
        }
      
        public static IMedicineInformationRepository Create_stub_repository_medicines()
        {
            var stubRepository = new Mock<IMedicineInformationRepository>();
            MedicineInformation medicine1 = new MedicineInformation(1, new MedicineDescription("Paracetamol", "Paracetamol is a medication used to treat pain and fever."),2);
            MedicineInformation medicine2 = new MedicineInformation(2, new MedicineDescription("Ibuprofen","Ibuprofen is a medication used for treating pain, fever, and inflammation."),5);
            var medicines = new List<MedicineInformation>();
            medicines.Add(medicine1);
            medicines.Add(medicine2);
            stubRepository.Setup(m => m.GetAll()).Returns(medicines);
            return stubRepository.Object;
        }
    }
}
