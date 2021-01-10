
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

            MedicineWithQuantity description = medicineWithQuantityService.CreateIMedicineDescription(new MedicineWithQuantityDto("Andol", 5,"Description"));
            Assert.NotNull(description);
        }
        [Fact]
        public void Creates_No_Medicine_Description()
        {
            MedicineWithQuantityService medicineWithQuantityService = new MedicineWithQuantityService(Create_stub_repository_medicines());

            MedicineWithQuantity description = medicineWithQuantityService.CreateIMedicineDescription(new MedicineWithQuantityDto("Paracetamol", 10,"Description"));
            Assert.Null(description);
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
