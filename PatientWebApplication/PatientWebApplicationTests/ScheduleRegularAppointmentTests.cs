using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Employee;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PatientWebApplicationTests
{
    public class ScheduleRegularAppointmentTests
    {
        [Fact]
        public void Find_Available_Appointments()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateAppointmentStubRepository(), CreateScheduleStubRepository(), new DoctorService(CreateOperationStubRepository(), CreateAppointmentStubRepository(), CreateScheduleStubRepository(), CreateDoctorStubRepository()), CreatePatientStubRepository(), new OperationService(CreateOperationStubRepository()));

            List<DoctorAppointment> appointments = service.GetAllAvailableAppointmentsForDate("03/03/2020", 2, 2);

            appointments.ShouldNotBeEmpty();
        }

        [Fact]
        public void Find_No_Available_Appointments()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateAppointmentStubRepository(), CreateScheduleStubRepository(), new DoctorService(CreateOperationStubRepository(), CreateAppointmentStubRepository(), CreateScheduleStubRepository(), CreateDoctorStubRepository()), CreatePatientStubRepository(), new OperationService(CreateOperationStubRepository()));

            List<DoctorAppointment> appointments = service.GetAllAvailableAppointmentsForDate("02/02/2020", 1, 2);

            appointments.ShouldBeEmpty();
        }

        [Fact]
        public void Find_Available_Doctors()
        {
            DoctorService service = new DoctorService(CreateOperationStubRepository(), CreateAppointmentStubRepository(), CreateScheduleStubRepository(), CreateDoctorStubRepository());

            List<DoctorUser> appointments = service.GetAvailableDoctors("Cardiology", "02/02/2020", 2);

            appointments.ShouldNotBeEmpty();
        }

        [Fact]
        public void Find_No_Available_Doctors()
        {
            DoctorService service = new DoctorService(CreateOperationStubRepository(), CreateAppointmentStubRepository(), CreateScheduleStubRepository(), CreateDoctorStubRepository());

            List<DoctorUser> appointments = service.GetAvailableDoctors("Pulmonology", "02/02/2020", 2);

            appointments.ShouldBeEmpty();
        }

        private static IAppointmentRepository CreateAppointmentStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();

            var patientAppointments = new List<DoctorAppointment>();
            var doctorAppointments1 = new List<DoctorAppointment>();
            var doctorAppointments2 = new List<DoctorAppointment>();
            var doctorAppointments3 = new List<DoctorAppointment>();

            Referral referral1 = new Referral(1, "Medicine", "Take medicine until", 3, "classify", "comment", 1);
            Referral referral2 = new Referral(2, "Medicine2", "Take medicine until", 3, "Appointment", "comment", 1);
            var referrals = new List<Referral>();
            referrals.Add(referral1);
            referrals.Add(referral1);

            DoctorAppointment appointment1 = new DoctorAppointment(1, new TimeSpan(0, 14, 15, 0, 0), "03/03/2020", new PatientUser(), new DoctorUser(1, "TestDoctorName1", "TestDoctorNameSurname1", "1234", "02/02/2020", "123", "email", "pass", "Grad",
             200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 2"), new List<Referral>(), "1");
            DoctorAppointment appointment2 = new DoctorAppointment(2, new TimeSpan(0, 14, 30, 0, 0), "03/03/2020", new PatientUser(), new DoctorUser(2, "TestDoctorName2", "TestDoctorNameSurname2", "1234", "02/02/2020", "123", "email", "pass", "Grad",
             200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 2"), new List<Referral>(), "1");
            DoctorAppointment appointment3 = new DoctorAppointment(3, new TimeSpan(0, 15, 0, 0, 0), "03/03/2020", new PatientUser(), new DoctorUser(2, "TestDoctorName2", "TestDoctorNameSurname2", "1234", "02/02/2020", "123", "email", "pass", "Grad",
             200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 2"), new List<Referral>(), "1");
            DoctorAppointment appointment4 = new DoctorAppointment(4, new TimeSpan(0, 15, 45, 0, 0), "03/03/2020", new PatientUser(), new DoctorUser(2, "TestDoctorName2", "TestDoctorNameSurname2", "1234", "02/02/2020", "123", "email", "pass", "Grad",
             200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 2"), new List<Referral>(), "1");
            DoctorAppointment appointment5 = new DoctorAppointment(5, new TimeSpan(0, 12, 0, 0, 0), "02/02/2020", new PatientUser(), new DoctorUser(1, "TestDoctorName1", "TestDoctorNameSurname1", "1234", "02/02/2020", "123", "email", "pass", "Grad",
             200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 2"), new List<Referral>(), "1");
            DoctorAppointment appointment6 = new DoctorAppointment(6, new TimeSpan(0, 12, 15, 0, 0), "02/02/2020", new PatientUser(), new DoctorUser(3, "TestDoctorName3", "TestDoctorNameSurname3", "1234", "02/02/2020", "123", "email", "pass", "Grad",
             200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 2"), new List<Referral>(), "1");

            patientAppointments.Add(appointment1);
            doctorAppointments1.Add(appointment1);
            patientAppointments.Add(appointment2);
            doctorAppointments2.Add(appointment2);
            doctorAppointments2.Add(appointment3);
            doctorAppointments2.Add(appointment4);
            doctorAppointments1.Add(appointment5);
            doctorAppointments3.Add(appointment6);
            patientAppointments.Add(appointment6);

            stubRepository.Setup(m => m.GetAppointmentsForPatient(2)).Returns(patientAppointments);
            stubRepository.Setup(m => m.GetAppointmentsForDoctor(1)).Returns(doctorAppointments1);
            stubRepository.Setup(m => m.GetAppointmentsForDoctor(2)).Returns(doctorAppointments2);
            stubRepository.Setup(m => m.GetAppointmentsForDoctor(3)).Returns(doctorAppointments3);

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

        private static IEmployeesScheduleRepository CreateScheduleStubRepository()
        {
            var stubRepository = new Mock<IEmployeesScheduleRepository>();
            List<Schedule> schedules = new List<Schedule>();
            Schedule schedule1 = new Schedule(2, "2", "03/03/2020", true, "EmployeeName1", "EmployeeSurname1", new Shift(1, "14:00", "16:00"), "1");
            Schedule schedule2 = new Schedule(1, "1", "02/02/2020", true, "EmployeeName2", "EmployeeSurname2", new Shift(2, "12:00", "12:30"), "1");
            Schedule schedule3 = new Schedule(3, "3", "02/02/2020", true, "EmployeeName2", "EmployeeSurname2", new Shift(1, "14:00", "16:00"), "1");

            schedules.Add(schedule1);
            schedules.Add(schedule2);
            schedules.Add(schedule3);

            stubRepository.Setup(m => m.GetAll()).Returns(schedules);

            return stubRepository.Object;
        }

        private static IDoctorRepository CreateDoctorStubRepository()
        {
            var stubRepository = new Mock<IDoctorRepository>();
            List<DoctorUser> doctors = new List<DoctorUser>();
            DoctorUser doctor1 = new DoctorUser(1, "TestDoctorName1", "TestDoctorNameSurname1", "1234", "02/02/2020", "123", "email", "pass", "Grad", 200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 2");
            DoctorUser doctor2 = new DoctorUser(2, "TestDoctorName2", "TestDoctorNameSurname2", "1234", "02/02/2020", "123", "email", "pass", "Grad", 200.0, false, "Pulmonology", new List<DoctorNotification>(), "Ordination 2");
            DoctorUser doctor3 = new DoctorUser(3, "TestDoctorName3", "TestDoctorNameSurname3", "1234", "02/02/2020", "123", "email", "pass", "Grad", 200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 2");

            doctors.Add(doctor1);
            doctors.Add(doctor2);
            doctors.Add(doctor3);

            stubRepository.Setup(m => m.GetAll()).Returns(doctors);
            stubRepository.Setup(m => m.GetByid(1)).Returns(doctor1);
            stubRepository.Setup(m => m.GetByid(2)).Returns(doctor2);
            stubRepository.Setup(m => m.GetByid(3)).Returns(doctor3);

            return stubRepository.Object;
        }

        private static IPatientsRepository CreatePatientStubRepository()
        {
            var stubRepository = new Mock<IPatientsRepository>();
            List<PatientUser> patients = new List<PatientUser>();
            PatientUser patient = new PatientUser(2, "PatientName2", "PatientSurname2", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);

            stubRepository.Setup(m => m.Find(patient.id)).Returns(patient);

            return stubRepository.Object;
        }
    }
}
