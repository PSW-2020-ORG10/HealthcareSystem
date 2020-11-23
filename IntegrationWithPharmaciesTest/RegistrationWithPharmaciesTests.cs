using System;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using HealthClinic.CL.Model.Pharmacy;

namespace IntegrationWithPharmaciesTest
{
    public class RegistrationWithPharmaciesTests
    {
        [Fact]
        public static IRegistrationInPharmacyRepository Create_stub_repository()
        {
            var stubRepository = new Mock<IRegistrationInPharmacyRepository>();
            RegistrationInPharmacy registrationInPharmacy = new RegistrationInPharmacy(4,5,"apisa12345");

            var registrationsInPharmacies = new List<RegistrationInPharmacy>();
            registrationsInPharmacies.Add(registrationInPharmacy);
            stubRepository.Setup(m => m.GetAll()).Returns(registrationsInPharmacies);

            return stubRepository.Object;

        }
        [Fact]
        public void Find_registration()
        {
            RegistrationInPharmacyService service = new RegistrationInPharmacyService(Create_stub_repository());

            RegistrationInPharmacy foundRegistration = service.getPharmacyApiKey("apisa12345");

            Assert.NotNull(foundRegistration);
        }
        [Fact]
        public void Find_no_registration()
        {
            RegistrationInPharmacyService service = new RegistrationInPharmacyService(Create_stub_repository());

            RegistrationInPharmacy foundRegistration = service.getPharmacyApiKey("apisa99");

            foundRegistration.ShouldBeNull();
        }
    }
}
