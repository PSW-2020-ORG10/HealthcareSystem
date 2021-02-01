using System.Collections.Generic;
using Moq;
using PharmacyRegistrationApi.Dtos;
using PharmacyRegistrationApi.Model;
using PharmacyRegistrationApi.Repository;
using PharmacyRegistrationApi.Service;
using Shouldly;
using Xunit;

namespace IntegrationWithPharmaciesTest
{
    public class RegistrationWithPharmaciesTests
    {
        [Fact]
        public static IRegistrationInPharmacyRepository Create_stub_repository()
        {
            var stubRepository = new Mock<IRegistrationInPharmacyRepository>();
            RegistrationInPharmacy registrationInPharmacy = new RegistrationInPharmacy(4,5,"Novi Sad", new PharmacyConnectionInfo("apisa12345", "email@gmail.com",""), new PharmacyNameInfo("Jankovic 2"));

            var registrationsInPharmacies = new List<RegistrationInPharmacy>();
            registrationsInPharmacies.Add(registrationInPharmacy);
            stubRepository.Setup(m => m.GetAll()).Returns(registrationsInPharmacies);

            return stubRepository.Object;

        }
        [Fact]
        public void Find_registration()
        {
            RegistrationInPharmacyService service = new RegistrationInPharmacyService(Create_stub_repository());

            RegistrationInPharmacy foundRegistration = service.GetPharmacyApiKey("apisa12345");

            Assert.NotNull(foundRegistration);
        }
        [Fact]
        public void Find_no_registration()
        {
            RegistrationInPharmacyService service = new RegistrationInPharmacyService(Create_stub_repository());

            RegistrationInPharmacy foundRegistration = service.GetPharmacyApiKey("apisa99");

            foundRegistration.ShouldBeNull();
        }
        [Fact]
        public void Creates_registration()
        {
            RegistrationInPharmacyService service = new RegistrationInPharmacyService(Create_stub_repository());

            RegistrationInPharmacy registrationInPharmacy = service.CreateIRegistration(new RegistrationInPharmacyDto(3,"Bg", new PharmacyConnectionInfo("fffffff", "email@gmail.com",""), new PharmacyNameInfo("Jankovic")));

            registrationInPharmacy.ShouldNotBeNull();
        }
        [Fact]
        public void Creates_no_registration()
        {
            RegistrationInPharmacyService service = new RegistrationInPharmacyService(Create_stub_repository());

            RegistrationInPharmacy registrationInPharmacy = service.CreateIRegistration(new RegistrationInPharmacyDto(33,"NS", new PharmacyConnectionInfo("apisa12345", "email@gmail.com",""), new PharmacyNameInfo("Jankovic")));

            registrationInPharmacy.ShouldBeNull();
        }
    }
}
