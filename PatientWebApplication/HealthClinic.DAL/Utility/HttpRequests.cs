using HealthClinic.CL.Model.Doctor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using HealthClinic.CL.Model.Employee;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Dtos;
using Newtonsoft.Json;

namespace HealthClinic.CL.Utility
{
    public static class HttpRequests
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<DoctorUser> GetDoctorByIdAsync(int id)
        {
            var responseString = await client.GetAsync("http://localhost:60198/api/doctor/"+id);
            DoctorUser doc = await responseString.Content.ReadAsAsync<DoctorUser>();
            return doc;
        }

        public static async Task<List<DoctorUser>> GetAllAsync()
        {
            var responseString = await client.GetAsync("http://localhost:60198/api/doctor/");
            return await responseString.Content.ReadAsAsync<List<DoctorUser>>();
        }

        public static async Task<Boolean> DoesDoctorHaveAnAppointmentAtSpecificTime(int doctorId, TimeSpan time, string date)
        {
            var responseString = await client.GetAsync("http://localhost:60198/api/doctor/appointment/"+doctorId +"/"+ time + "/" + date);
            return await responseString.Content.ReadAsAsync<Boolean>();
        }

        public static async Task<Boolean> DoesDoctorHaveAnOperationAtSpecificTime(int doctorId, TimeSpan time, string date)
        {
            var responseString = await client.GetAsync("http://localhost:60198/api/doctor/operation/" + doctorId + "/" + time + "/" + date);
            return await responseString.Content.ReadAsAsync<Boolean>();
        }

        public static async Task<Shift> GetShiftForDoctorForSpecificDay(DoctorShiftSearchDto dto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var responseString = await client.PostAsync("http://localhost:60198/api/employeesSchedule", stringContent);
            return await responseString.Content.ReadAsAsync<Shift>();
        }

        public static async Task<PatientUser> GetOnePatient(int id)
        {
            var responseString = await client.GetAsync("http://localhost:60198/api/patient/findOne/" +id);
            return await responseString.Content.ReadAsAsync<PatientUser>();
        }
    }
}
