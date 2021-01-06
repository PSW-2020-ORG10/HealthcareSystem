using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UserMicroserviceApi.Dtos;

namespace UserMicroserviceApi.Utility
{
    public class HttpRequests
    {
        private static readonly HttpClient client = new HttpClient();
        public static async Task<List<MicroserviceAppointmentDto>> GetAllAppointments()
        {
            var responseString = await client.GetAsync("http://localhost:54689/api/doctorAppointment/getAllDto");
            return await responseString.Content.ReadAsAsync<List<MicroserviceAppointmentDto>>();
        }
    }
}
