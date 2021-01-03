using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppointmentMicroserviceApi.Dtos;
using HealthClinic.CL.Dtos;
using Newtonsoft.Json;

namespace AppointmentMicroserviceApi.Utility
{
    public class HttpRequests
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<MicroserviceDoctorDto> GetDoctorByIdAsync(int id)
        {
            var responseString = await client.GetAsync("http://localhost:54689/api/doctor/" + id);
            MicroserviceDoctorDto doc = await responseString.Content.ReadAsAsync<MicroserviceDoctorDto>();
            return doc;
        }

        public static async Task<List<MicroserviceDoctorDto>> GetAllAsync()
        {
            var responseString = await client.GetAsync("http://localhost:54689/api/doctor/");
            return await responseString.Content.ReadAsAsync<List<MicroserviceDoctorDto>>();
        }
        public static async Task<MicroserviceShiftDto> GetShiftForDoctorForSpecificDay(DoctorShiftSearchDto dto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            var responseString = await client.PostAsync("http://localhost:54689/api/employeesSchedule", stringContent);
            return await responseString.Content.ReadAsAsync<MicroserviceShiftDto>();
        }

    }
}
