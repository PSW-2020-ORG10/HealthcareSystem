using AppointmentMicroserviceApi.Doctor;
using AppointmentMicroserviceApi.Patient;
using AppointmentMicroserviceApi.Repository;
using AppointmentMicroserviceApi.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using UserMicroserviceApi.Model;
using UserMicroserviceApi.Repository;
using Xunit;

namespace PatientWebApplicationTests
{
    public class ScheduleRecommendedAppointmentTests
    {
        [Fact]
        public void Create_Appointment()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateAppointmentStubRepository(), new OperationService(CreateOperationStubRepository()));

            DateTime dt = DateTime.Now.AddDays(10);
            String date = dt.ToString("dd/MM/yyyy");
            DoctorAppointment appointment = service.CreateRecommended(new DoctorAppointment(8, new TimeSpan(0, 14, 0, 0, 0), date, 1,1, new List<Referral>(), "1"));

            appointment.ShouldNotBeNull();
        }

        private static IAppointmentRepository CreateAppointmentStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();

           DoctorAppointment appointment7 = new DoctorAppointment(7, new TimeSpan(0, 14, 0, 0, 0), "07/03/2020", 1, 1, new List<Referral>(), "1");

            stubRepository.Setup(m => m.New(It.IsAny<DoctorAppointment>())).Returns(appointment7);

            return stubRepository.Object;
        }

        private static IOperationRepository CreateOperationStubRepository()
        {
            var stubRepository = new Mock<IOperationRepository>();

            var patientOperations = new List<Operation>();
            var doctorOperations = new List<Operation>();

            OperationReferral referral1 = new OperationReferral(1, "Medicine", "Take medicine until", 3, "classify", "comment", 1);
            OperationReferral referral2 = new OperationReferral(2, "Medicine2", "Take medicine until", 3, "Appointment", "comment", 1);
            var referrals = new List<OperationReferral>();
            referrals.Add(referral1);
            referrals.Add(referral1);

            Operation operation1 = new Operation(1, 2, "03/03/2020", new TimeSpan(0, 14, 0, 0), new TimeSpan(0, 15, 0, 0, 0), 1, "room1");
            Operation operation2 = new Operation(2, 1, "03/10/2020", new TimeSpan(0, 15, 0, 0), new TimeSpan(0, 15, 15, 0, 0), 2, "room1");

            patientOperations.Add(operation1);
            doctorOperations.Add(operation2);

            stubRepository.Setup(m => m.GetOperationsForPatient(2)).Returns(patientOperations);
            stubRepository.Setup(m => m.GetOperationsForDoctor(2)).Returns(doctorOperations);
            stubRepository.Setup(m => m.GetOperationsForDoctor(1)).Returns(new List<Operation>());
            stubRepository.Setup(m => m.GetOperationsForDoctor(3)).Returns(new List<Operation>());

            return stubRepository.Object;
        }
    }
}
