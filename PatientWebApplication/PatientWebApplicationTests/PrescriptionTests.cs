using Moq;
using SearchMicroserviceApi.Model;
using SearchMicroserviceApi.Repository;
using SearchMicroserviceApi.Service;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PatientWebApplicationTests
{
    public class PrescriptionTests
    {
        [Fact]
        public void Find_Prescription_By_AppointmentId()
        {
            PrescriptionService service = new PrescriptionService(CreateStubRepository());

            Prescription foundPrescriptions = service.GetPrescriptionsForAppointment(1);

            foundPrescriptions.ShouldNotBeNull();
        }

        private static IPrescriptionRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPrescriptionRepository>();

            var prescriptions = new List<Prescription>();

            List<PrescribedMedicine> medicines = new List<PrescribedMedicine>();
            medicines.Add(new PrescribedMedicine(1, 1, new Medicine(1, "Medicine Name", 1, "Comment", new List<ModelRoom>()), 1, "How to use", 1));

            Prescription prescription1 = new Prescription(1, 1, medicines, true, "Comment", 1, 1);

            prescriptions.Add(prescription1);

            stubRepository.Setup(m => m.GetPrescriptionsForAppointment(1)).Returns(prescription1);

            return stubRepository.Object;
        }
    }
}
