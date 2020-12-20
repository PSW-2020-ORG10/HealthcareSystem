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
        /*private readonly HttpClient _client;
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
            var stringContent = new StringContent(JsonConvert.SerializeObject(new AvailableAppointmentsSearchDto("03/03/2021", 3, 3)), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("http://localhost:60198/api/doctorappointment/availableappointments", stringContent);
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
            var appointments = await response.Content.ReadAsAsync<List<DoctorAppointment>>();
            appointments.ShouldBeEmpty();
        }

        [Fact]
        public async Task Find_Available_Appointments()
        {
            _context.Doctors.Add(new DoctorUser(1, "TestDoctorName1", "TestDoctorNameSurname1", "1234", "02/02/2020", "123", "email", "pass", "Grad", 200.0, false, "Cardiology", new List<DoctorNotification>(), "Ordination 1"));
            _context.Patients.Add(new PatientUser(1, "PatientName1", "PatientSurname1", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null));
            _context.Shifts.Add(new Shift(1, "14:00", "16:00"));
            _context.Schedules.Add(new Schedule(1, 1, "03/03/2021", true, 1, "1"));
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
            var stringContent = new StringContent(JsonConvert.SerializeObject(new DoctorAppointment(0, new TimeSpan(15, 30, 0), "03/03/2021", 1, 1, new List<Referral>(), "Ordination 1")), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("http://localhost:60198/api/doctorappointment", stringContent);
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Try_To_Schedule_Unvalid_Appointment()
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(new DoctorAppointment(0, new TimeSpan(15, 30, 0), "23/12/2020", 2, 2, new List<Referral>(), "Ordination 1")), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("http://localhost:60198/api/doctorappointment", stringContent);
            response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }*/
    }
}
