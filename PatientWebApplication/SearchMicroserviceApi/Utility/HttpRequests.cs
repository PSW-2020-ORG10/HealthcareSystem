using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SearchMicroserviceApi.Dtos;

namespace SearchMicroserviceApi.Utility
{
    public class HttpRequests
    {
         private static readonly string usersServiceUrl = Startup.Configuration["UserMicroServiceApi"];
         private static readonly string appointmentServiceUrl = Startup.Configuration["AppointmentMicroServiceApi"];
         private static readonly HttpClient client = new HttpClient();

        public static async Task<MicroserviceDoctorDto> GetDoctorByIdAsync(int id)
        {
            var responseString = await client.GetAsync($"{usersServiceUrl}api/doctor/" + id);
            MicroserviceDoctorDto doc = await responseString.Content.ReadAsAsync<MicroserviceDoctorDto>();
            return doc;
        }

        public static async Task<List<MicroserviceDoctorDto>> GetAllAsync()
        {
            var responseString = await client.GetAsync($"{usersServiceUrl}api/doctor/");
            return await responseString.Content.ReadAsAsync<List<MicroserviceDoctorDto>>();
        }

        public static async Task<List<MicroserviceSearchAppointmentDto>> GetAppointmentsForPatientDto(int patientId)
        {
            var responseString = await client.GetAsync($"{appointmentServiceUrl}api/doctorAppointment/appointmentsForPatientDto/" + patientId);
            return await responseString.Content.ReadAsAsync<List<MicroserviceSearchAppointmentDto>>();
        }

        public static async Task<List<AppointmentDto>> GetAppointmentsForPatientDtoSimple(int patientId)
        {
            var responseString = await client.GetAsync($"{appointmentServiceUrl}api/doctorAppointment/appointmentsForPatientDtoSimple/" + patientId);
            return await responseString.Content.ReadAsAsync<List<AppointmentDto>>();
        }

    }
}
