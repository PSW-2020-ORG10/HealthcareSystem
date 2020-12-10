using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Employee;
using HealthClinic.CL.Model.Patient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using PatientWebApplication;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PatientWebApplicationIntegrationTests
{
    public class ScheduleRegularAppointmentsTests
    {
        private readonly HttpClient _client;
        private readonly MyDbContext _context;

        public ScheduleRegularAppointmentsTests()
        {
            var builder = new WebHostBuilder()
               .UseEnvironment("Testing")
               .UseStartup<Startup>();

            var server = new TestServer(builder);
            _context = server.Host.Services.GetService(typeof(MyDbContext)) as MyDbContext;
            _client = server.CreateClient();
        }

        [Fact]
        public async Task Find_No_Available_Appointments()
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(new AvailableAppointmentsSearchDto("03/03/2021", 2, 2)), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("http://localhost:60198/api/doctorappointment/availableappointments", stringContent);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            var appointments = await response.Content.ReadAsAsync<List<DoctorAppointment>>();
            appointments.ShouldBeEmpty();
        }

        [Fact]
        public async Task Find_Available_Appointments()
        {
            var doctor1 = new DoctorUser(1, "TestDoctorName1", "TestDoctorNameSurname1", "1234", "02/02/2020", "123", "email", "pass", "Grad", 200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 1");
            var patient1 = new PatientUser(1, "PatientName1", "PatientSurname1", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);
            var shift1 = new Shift(1, "14:00", "16:00");
            var schedule1 = new Schedule(1, "1", "03/03/2021", true, "EmployeeName1", "EmployeeSurname1", 1, "1");
            _context.Doctors.Add(doctor1);
            _context.Patients.Add(patient1);
            _context.Shifts.Add(shift1);
            _context.Schedules.Add(schedule1);
            _context.SaveChanges();

            var stringContent = new StringContent(JsonConvert.SerializeObject(new AvailableAppointmentsSearchDto("03/03/2021", 1, 1)), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("http://localhost:60198/api/doctorappointment/availableappointments", stringContent);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            var appointments = await response.Content.ReadAsAsync<List<DoctorAppointment>>();
            appointments.ShouldNotBeEmpty();
        }

        [Fact]
        public async Task Schedule_Appointment()
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(new DoctorAppointment(0, new TimeSpan(15,30,0), "03/03/2021", 1, 1, new List<Referral>(), "Ordination 1")), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("http://localhost:60198/api/doctorappointment", stringContent);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Try_To_Schedule_Unvalid_Appointment()
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(new DoctorAppointment(0, new TimeSpan(15, 30, 0), "23/12/2020", 2, 2, new List<Referral>(), "Ordination 1")), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("http://localhost:60198/api/doctorappointment", stringContent);

            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        public void SetupDbContext(MyDbContext context)
        {
            if(context.Doctors.Local.Count != 0)
            {
                return;
            }
            DoctorUser doctor1 = new DoctorUser(1, "TestDoctorName1", "TestDoctorNameSurname1", "1234", "02/02/2020", "123", "email", "pass", "Grad", 200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 1");
            DoctorUser doctor2 = new DoctorUser(2, "TestDoctorName2", "TestDoctorNameSurname2", "1234", "02/02/2020", "123", "email", "pass", "Grad", 200.0, false, "Pulmonology", new List<DoctorNotification>(), "Ordination 2");
            DoctorUser doctor3 = new DoctorUser(3, "TestDoctorName3", "TestDoctorNameSurname3", "1234", "02/02/2020", "123", "email", "pass", "Grad", 200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 3");

            context.Doctors.Add(doctor1);
            context.Doctors.Add(doctor2);
            context.Doctors.Add(doctor3);

            PatientUser patient1 = new PatientUser(1, "PatientName1", "PatientSurname1", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);
            PatientUser patient2 = new PatientUser(2, "PatientName2", "PatientSurname2", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);
            context.Patients.Add(patient1);
            context.Patients.Add(patient2);

            Schedule schedule1 = new Schedule(2, "2", "03/03/2021", true, "EmployeeName1", "EmployeeSurname1", 1, "1");
            Schedule schedule2 = new Schedule(1, "1", "02/02/2021", true, "EmployeeName2", "EmployeeSurname2", 2, "1");
            Schedule schedule3 = new Schedule(3, "3", "02/02/2021", true, "EmployeeName2", "EmployeeSurname2", 3, "1");

            context.Schedules.Add(schedule1);
            context.Schedules.Add(schedule2);
            context.Schedules.Add(schedule3);

            Shift shift1 = new Shift(1, "14:00", "16:00");
            Shift shift2 = new Shift(2, "12:00", "12:30");
            Shift shift3 = new Shift(3, "14:00", "16:00");

            context.Shifts.Add(shift1);
            context.Shifts.Add(shift2);
            context.Shifts.Add(shift3);

            Referral referral1 = new Referral(1, "Medicine", "Take medicine until", 3, "classify", "comment", 1);
            Referral referral2 = new Referral(2, "Medicine2", "Take medicine until", 3, "Appointment", "comment", 1);

            context.Referrals.Add(referral1);
            context.Referrals.Add(referral2);

            DoctorAppointment appointment1 = new DoctorAppointment(1, new TimeSpan(0, 14, 15, 0, 0), "03/03/2021", 1, 1, new List<Referral>(), "1");
            DoctorAppointment appointment2 = new DoctorAppointment(2, new TimeSpan(0, 14, 30, 0, 0), "03/03/2021", 1, 2, new List<Referral>(), "1");
            DoctorAppointment appointment3 = new DoctorAppointment(3, new TimeSpan(0, 15, 0, 0, 0), "03/03/2021", 1, 2, new List<Referral>(), "1");
            DoctorAppointment appointment4 = new DoctorAppointment(4, new TimeSpan(0, 15, 45, 0, 0), "03/03/2021", 1,2, new List<Referral>(), "1");
            DoctorAppointment appointment5 = new DoctorAppointment(5, new TimeSpan(0, 12, 0, 0, 0), "02/02/2021", 1, 1, new List<Referral>(), "1");
            DoctorAppointment appointment6 = new DoctorAppointment(6, new TimeSpan(0, 14, 15, 0, 0), "02/02/2021", 1,3, new List<Referral>(), "1");

            context.DoctorAppointments.Add(appointment1);
            context.DoctorAppointments.Add(appointment2);
            context.DoctorAppointments.Add(appointment3);
            context.DoctorAppointments.Add(appointment4);
            context.DoctorAppointments.Add(appointment5);
            context.DoctorAppointments.Add(appointment6);

            OperationReferral operationReferral1 = new OperationReferral(1, "Medicine", "Take medicine until", 3, "classify", "comment", 1);
            OperationReferral operationReferral2 = new OperationReferral(2, "Medicine2", "Take medicine until", 3, "Appointment", "comment", 2);

            context.OperationReferrals.Add(operationReferral1);
            context.OperationReferrals.Add(operationReferral2);

            Operation operation1 = new Operation(1, 2, "03/03/2021", new TimeSpan(0, 14, 0, 0), new TimeSpan(0, 15, 0, 0, 0), 1, "room1");
            Operation operation2 = new Operation(2, 1, "03/03/2021", new TimeSpan(0, 15, 0, 0), new TimeSpan(0, 15, 15, 0, 0), 2, "room1");

            context.Operations.Add(operation1);
            context.Operations.Add(operation2);

            context.SaveChanges();
        }
    }
}
