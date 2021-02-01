﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppointmentMicroserviceApi.Dtos;
using Newtonsoft.Json;

namespace AppointmentMicroserviceApi.Utility
{
    public class HttpRequests
    {
        private static readonly string usersServiceUrl = Startup.Configuration["UserMicroServiceApi"];
        private static readonly HttpClient client = new HttpClient();

        public static async Task<MicroserviceDoctorDto> GetDoctorByIdAsync(int id)
        {
         var responseString = await client.GetAsync($"{usersServiceUrl}api/doctor/{id}");
            MicroserviceDoctorDto doc = await responseString.Content.ReadAsAsync<MicroserviceDoctorDto>();
            return doc;
        }

        public static async Task<List<MicroserviceDoctorDto>> GetAllAsync()
        {
         var responseString = await client.GetAsync($"{usersServiceUrl}api/doctor/");
            return await responseString.Content.ReadAsAsync<List<MicroserviceDoctorDto>>();
        }
        public static async Task<MicroserviceShiftDto> GetShiftForDoctorForSpecificDay(DoctorShiftSearchDto dto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var responseString = await client.PostAsync($"{usersServiceUrl}api/employeesSchedule", stringContent);
            return await responseString.Content.ReadAsAsync<MicroserviceShiftDto>();
        }

        public static async Task<Boolean> DoesDoctorHaveAnAppointmentAtSpecificTime(int doctorId, TimeSpan time, string date)
        {
            var responseString = await client.GetAsync($"{usersServiceUrl}api/doctor/appointment/{doctorId}/{time}/{date}");
            return await responseString.Content.ReadAsAsync<Boolean>();
        }

        public static async Task<Boolean> DoesDoctorHaveAnOperationAtSpecificTime(int doctorId, TimeSpan time, string date)
        {
            var responseString = await client.GetAsync($"{usersServiceUrl}api/doctor/operation/{doctorId}/{time}/{date}");
            return await responseString.Content.ReadAsAsync<Boolean>();
        }

        public static async Task<MicroservicePatientUserDto> GetPatientByIdAsync(int id)
        {
            var responseString = await client.GetAsync($"{usersServiceUrl}api/patientUser/getOneEventDto/{id}");
            MicroservicePatientUserDto patient = await responseString.Content.ReadAsAsync<MicroservicePatientUserDto>();
            return patient;
        }
    }
}
