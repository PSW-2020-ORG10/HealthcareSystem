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
    public class PrescriptionsSimpleSearchTests
    {
        [Fact]
        public void Find_Prescriptions()
        {
            
            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> foundPrescriptions = service.SimpleSearchPrescriptions(new PrescriptionSearchDto("Medicine Name", "", "Comment", "", 1));

            foundPrescriptions.ShouldHaveSingleItem();
        }

        [Fact]
        public void Find_No_Matching_Prescriptions()
        {

            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> foundPrescriptions = service.SimpleSearchPrescriptions(new PrescriptionSearchDto("", "False", "", "", 1));

            foundPrescriptions.ShouldBeEmpty();
        }

        [Fact]
        public void Find_Prescriptions_With_Empty_Search()
        {
            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            List<Prescription> foundPrescriptions = service.SimpleSearchPrescriptions(new PrescriptionSearchDto("", "", "", "", 1));

            foundPrescriptions.ShouldNotBeEmpty();
        }


        private static IPrescriptionRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPrescriptionRepository>();

            var prescriptions = new List<Prescription>();

            List<Medicine> medicines = new List<Medicine>();
            Medicine medicine = new Medicine(1, "Medicine Name", 1, "Description", new List<ModelRoom>(), 1, true, 1);
            medicines.Add(medicine);

            Prescription prescription1 = new Prescription(1, 1, medicines, true, "Comment", 1);
            Prescription prescription2 = new Prescription(2, 1, new List<Medicine>(), true, "Some text", 1);

            prescriptions.Add(prescription1);
            prescriptions.Add(prescription2);

            stubRepository.Setup(m => m.GetPrescriptionsForPatient(1)).Returns(prescriptions);

            return stubRepository.Object;
        }
    }
}
