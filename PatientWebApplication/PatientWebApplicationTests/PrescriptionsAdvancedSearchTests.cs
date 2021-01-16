using Moq;
using SearchMicroserviceApi.Dtos;
using SearchMicroserviceApi.Model;
using SearchMicroserviceApi.Repository;
using SearchMicroserviceApi.Service;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace PatientWebApplicationTests
{
    public class PrescriptionsAdvancedSearchTests
    {
        [Fact]
        public void Find_Prescriptions()
        {

            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> foundPrescriptions = service.AdvancedSearchPrescriptions(new PrescriptionAdvancedSearchDto("medicines", "Medicine Name", new string[] { }, new string[] { }, new string[] { }, 1));

            foundPrescriptions.ShouldHaveSingleItem();
        }

        [Fact]
        public void Find_Prescriptions_OR()
        {

            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> foundPrescriptions = service.AdvancedSearchPrescriptions(new PrescriptionAdvancedSearchDto("medicines", "Medicine Name", new string[1] { "comment" }, new string[1] { "Comment" }, new string[1] { "or" }, 1));

            foundPrescriptions.ShouldHaveSingleItem();
        }

        [Fact]
        public void Find_No_Prescriptions_AND()
        {

            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> foundPrescriptions = service.AdvancedSearchPrescriptions(new PrescriptionAdvancedSearchDto("medicines", "Medicine Name", new string[1] { "comment" }, new string[1] { "Comment23" }, new string[1] { "and" }, 1));

            foundPrescriptions.ShouldBeEmpty();
        }

        [Fact]
        public void Find_No_Matching_Prescriptions()
        {

            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> foundPrescriptions = service.AdvancedSearchPrescriptions(new PrescriptionAdvancedSearchDto("medicines", "Medicine Name23", new string[] { }, new string[] { }, new string[] { }, 1));

            foundPrescriptions.ShouldBeEmpty();
        }

        [Fact]
        public void Find_Prescriptions_With_Empty_Search()
        {
            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> foundPrescriptions = service.AdvancedSearchPrescriptions(new PrescriptionAdvancedSearchDto("", "", new string[] { }, new string[] { }, new string[] { }, 1));

            foundPrescriptions.ShouldNotBeEmpty();
        }


        private static IPrescriptionRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPrescriptionRepository>();

            var prescriptions = new List<Prescription>();

            List<PrescribedMedicine> medicines = new List<PrescribedMedicine>();
            medicines.Add(new PrescribedMedicine(1, 1, 1, "How to use", 1));

            Prescription prescription1 = new Prescription(1, 1, medicines, true, "Comment", 1, 1);
            Prescription prescription2 = new Prescription(2, 1, new List<PrescribedMedicine>(), true, "Some text", 1, 1);

            prescriptions.Add(prescription1);
            prescriptions.Add(prescription2);

            stubRepository.Setup(m => m.GetPrescriptionsForPatient(1)).Returns(prescriptions);

            return stubRepository.Object;
        }
    }
}
