using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Doctor;
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
    public class AppointmentsAdvancedSearchTests
    {
        [Fact]
        public void Find_Appointments()
        {

            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepository());

            List<DoctorAppointment> foundAppointments = service.AdvancedSearchAppointments(new AppointmentAdvancedSearchDto("date", "22/04/2020", new string[] { }, new string[] { }, new string[] { }));

            foundAppointments.ShouldHaveSingleItem();
        }

        [Fact]
        public void Find_Appointments_OR()
        {

            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepository());

            List<DoctorAppointment> foundAppointments = service.AdvancedSearchAppointments(new AppointmentAdvancedSearchDto("date", "22/04/2020", new string[1] { "date" }, new string[1] { "Date" }, new string[1] { "or" }));

            foundAppointments.ShouldHaveSingleItem();
        }

        [Fact]
        public void Find_No_Appointments_AND()
        {

            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepository());

            List<DoctorAppointment> foundAppointments = service.AdvancedSearchAppointments(new AppointmentAdvancedSearchDto("date", "22/04/2020", new string[1] { "date" }, new string[1] { "Date12" }, new string[1] { "and" }));

            foundAppointments.ShouldBeEmpty();
        }

        [Fact]
        public void Find_No_Matching_Appointments()
        {

            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepository());

            List<DoctorAppointment> foundAppointments = service.AdvancedSearchAppointments(new AppointmentAdvancedSearchDto("date", "23/04/2020", new string[] { }, new string[] { }, new string[] { }));

            foundAppointments.ShouldBeEmpty();
        }
        [Fact]
        public void Find_Appointments_With_Empty_Search()
        {

            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepository());

            List<DoctorAppointment> foundAppointments = service.AdvancedSearchAppointments(new AppointmentAdvancedSearchDto("", "", new string[] { }, new string[] { }, new string[] { }));

            foundAppointments.ShouldNotBeEmpty();
        }


        private static IAppointmentRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();

            var appointments = new List<DoctorAppointment>();

            DoctorAppointment doctorAppointment1 = new DoctorAppointment(1, new TimeSpan(), "22/04/2020", 2, 1, new List<Referral>(), "1");
            DoctorAppointment doctorAppointment2 = new DoctorAppointment(2, new TimeSpan(), "07/01/2020", 2, 2, new List<Referral>(), "1");

            appointments.Add(doctorAppointment1);
            appointments.Add(doctorAppointment2);

            stubRepository.Setup(m => m.GetAppointmentsForPatient(2)).Returns(appointments);

            return stubRepository.Object;
        }
    }
}
