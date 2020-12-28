using HealthClinic.CL.Model.Doctor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HealthClinic.CL.Model.Employee;
using HealthClinic.CL.Model.Patient;
using Newtonsoft.Json;
using HealthClinic.CL.Dtos;

namespace HealthClinic.CL.Utility
{
    public static class HttpRequests
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<DoctorUser> GetDoctorByIdAsync(int id)
        {
            var responseString = await client.GetAsync("http://localhost:54689/api/doctor/" + id);
            DoctorUser doc = await responseString.Content.ReadAsAsync<DoctorUser>();
            return doc;
        }

        public static async Task<List<DoctorUser>> GetAllAsync()
        {
            var responseString = await client.GetAsync("http://localhost:54689/api/doctor/");
            return await responseString.Content.ReadAsAsync<List<DoctorUser>>();
        }

        public static async Task<Boolean> DoesDoctorHaveAnAppointmentAtSpecificTime(int doctorId, TimeSpan time, string date)
        {
            var responseString = await client.GetAsync("http://localhost:54689/api/doctor/appointment/" + doctorId +"/"+ time + "/" + date);
            return await responseString.Content.ReadAsAsync<Boolean>();
        }

        public static async Task<Boolean> DoesDoctorHaveAnOperationAtSpecificTime(int doctorId, TimeSpan time, string date)
        {
            var responseString = await client.GetAsync("http://localhost:54689/api/doctor/operation/" + doctorId + "/" + time + "/" + date);
            return await responseString.Content.ReadAsAsync<Boolean>();
        }

        public static async Task<Shift> GetShiftForDoctorForSpecificDay(DoctorShiftSearchDto dto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var responseString = await client.PostAsync("http://localhost:54689/api/employeesSchedule", stringContent);
            return await responseString.Content.ReadAsAsync<Shift>();
        }

        public static async Task<PatientUser> GetOnePatient(int id)
        {
            var responseString = await client.GetAsync("http://localhost:54689/api/patientUser/find/" + id);
            return await responseString.Content.ReadAsAsync<PatientUser>();
        }

        public static async Task<List<DoctorAppointment>> GetAvailableAppointments(AvailableAppointmentsSearchDto dto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var responseString = await client.PostAsync("http://localhost:54689/api/doctorAppointment/availableappointments", stringContent);
            return await responseString.Content.ReadAsAsync<List<DoctorAppointment>>();
        }

        public static async Task<List<DoctorAppointment>> GetAllAppointments()
        {
            var responseString = await client.GetAsync("http://localhost:54689/api/doctorAppointment/getAll");
            return await responseString.Content.ReadAsAsync<List<DoctorAppointment>>();
        }

        public static async Task<List<DoctorAppointment>> GetAppointmentsForDoctor(int doctorId)
        {
            var responseString = await client.GetAsync("http://localhost:54689/api/doctorAppointment/appointmentsForDoctor/" + doctorId);
            return await responseString.Content.ReadAsAsync<List<DoctorAppointment>>();
        }

        public static async Task<List<Operation>> GetAllOperations()
        {
            var responseString = await client.GetAsync("http://localhost:54689/api/operation/getAll");
            return await responseString.Content.ReadAsAsync<List<Operation>>();
        }

        public static async Task<List<Operation>> GetOperationsForDoctor(int doctorId)
        {
            var responseString = await client.GetAsync("http://localhost:54689/api/operation/operationsForDoctor/" + doctorId);
            return await responseString.Content.ReadAsAsync<List<Operation>>();
        }

        public static async Task<List<DoctorAppointment>> GetAppointmentsForPatient(int patientId)
        {
            var responseString = await client.GetAsync("http://localhost:54689/api/doctorAppointment/appointmentsForPatient/" + patientId);
            return await responseString.Content.ReadAsAsync<List<DoctorAppointment>>();
        }
    }
}
