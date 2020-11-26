using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace PatientWebApplicationTests
{
    public class AppointmentSimpleSearchTests
    {
        [Fact]
        public void Find_Appointment()
        {

            RegularAppointmentService service = new RegularAppointmentService(CreateAppointmentStubRepository());

            List<DoctorAppointment> foundAppointments = service.SimpleSearchAppointments(new AppointmentReportSearchDto("Per", "20/07/2020", "25/08/2020", "Appointment", 2));

            foundAppointments.ShouldHaveSingleItem();
        }

        [Fact]
        public void Find_No_Matching_Appointments()
        {

            RegularAppointmentService service = new RegularAppointmentService(CreateAppointmentStubRepository());

            List<DoctorAppointment> foundAppointments = service.SimpleSearchAppointments(new AppointmentReportSearchDto("", "", "", "Operation", 2));

            foundAppointments.ShouldBeEmpty();
        }

        [Fact]
        public void Find_Appointment_With_Empty_Start()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateAppointmentStubRepository());

            List<DoctorAppointment> foundAppointments = service.SimpleSearchAppointments(new AppointmentReportSearchDto("", "", "22/11/2020", "Appointment", 2));

            foundAppointments.ShouldNotBeEmpty();

        }

        [Fact]
        public void Find_Appointment_With_Empty_End()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateAppointmentStubRepository());

            List<DoctorAppointment> foundAppointments = service.SimpleSearchAppointments(new AppointmentReportSearchDto("", "22/01/2020", "", "Appointment", 2));

            foundAppointments.ShouldNotBeEmpty();

        }

        [Fact]
        public void Find_Operation()
        {

            OperationService service = new OperationService(CreateOperationStubRepository());

            List<Operation> foundOperations = service.SimpleSearchOperations(new AppointmentReportSearchDto("Per", "20/02/2020", "21/05/2020", "Operation", 2));

            foundOperations.ShouldHaveSingleItem();
        }

        [Fact]
        public void Find_No_Matching_Operations()
        {

            OperationService service = new OperationService(CreateOperationStubRepository());

            List<Operation> foundOperations = service.SimpleSearchOperations(new AppointmentReportSearchDto("", "", "", "Appointment", 2));

            foundOperations.ShouldBeEmpty();
        }

        [Fact]
        public void Find_Operation_With_Empty_Start()
        {
            OperationService service = new OperationService(CreateOperationStubRepository());

            List<Operation> foundOperations = service.SimpleSearchOperations(new AppointmentReportSearchDto("", "", "22/11/2020", "Operation", 2));

            foundOperations.ShouldNotBeEmpty();

        }

        [Fact]
        public void Find_Operation_With_Empty_End()
        {
            OperationService service = new OperationService(CreateOperationStubRepository());

            List<Operation> foundAppointments = service.SimpleSearchOperations(new AppointmentReportSearchDto("", "22/03/2020", "", "Operation", 2));

            foundAppointments.ShouldNotBeEmpty();

        }


        private static IAppointmentRepository CreateAppointmentStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();

            var appointments = new List<DoctorAppointment>();

            Referral referral1 = new Referral(1, "Medicine", "Take medicine until", 3, "classify", "comment", 1);
            Referral referral2 = new Referral(2, "Medicine2", "Take medicine until", 3, "Appointment", "comment", 1);
            var referrals = new List<Referral>();
            referrals.Add(referral1);
            referrals.Add(referral1);

            DoctorAppointment appointment1 = new DoctorAppointment(1, new TimeSpan(), "22/04/2020", new PatientUser(), new DoctorUser(1, "DoctorName", "DoctorSurname", "1234", "2/2/2020", "123", "email", "pass", "Grad",
             200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1"), new List<Referral>(), "1");
            DoctorAppointment appointment2 = new DoctorAppointment(2, new TimeSpan(), "22/08/2020", new PatientUser(), new DoctorUser(1, "Pera", "Jovanovic", "1234", "2/2/2020", "123", "email", "pass", "Grad",
             200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1"), new List<Referral>(), "1");

            appointments.Add(appointment1);
            appointments.Add(appointment2);

            stubRepository.Setup(m => m.GetAppointmentsForPatient(2)).Returns(appointments);

            return stubRepository.Object;
        }

        private static IOperationRepository CreateOperationStubRepository()
        {
            var stubRepository = new Mock<IOperationRepository>();

            var operations = new List<Operation>();

            Operation operation1 = new Operation(1, new PatientUser(), "20/02/2020", new TimeSpan(), new TimeSpan(), new DoctorUser(1, "DoctorName", "DoctorSurname", "1234", "2/2/2020", "123", "email", "pass", "Grad",
             200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1"), "room1", new OperationReferral(1, "Medicine", "Take medicine until", 3, "classify", "comment", 1));
            Operation operation2 = new Operation(1, new PatientUser(), "20/04/2020", new TimeSpan(), new TimeSpan(), new DoctorUser(1, "Pera", "Jovanovic", "1234", "2/2/2020", "123", "email", "pass", "Grad",
             200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1"), "room1", new OperationReferral(1, "Medicine", "Take medicine until", 3, "classify", "comment", 1));

            operations.Add(operation1);
            operations.Add(operation2);

            stubRepository.Setup(m => m.GetOperationsForPatient(2)).Returns(operations);

            return stubRepository.Object;
        }
    }
}
