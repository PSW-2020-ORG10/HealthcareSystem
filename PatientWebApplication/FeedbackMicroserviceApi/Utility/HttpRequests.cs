using FeedbackMicroserviceApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FeedbackMicroserviceApi.Utility
{
    public static class HttpRequests
    {
         private static readonly string usersServiceUrl = Startup.Configuration["UserMicroServiceApi"];
         private static readonly HttpClient client = new HttpClient();

        public static async Task<MicroservicePatientDto> GetOnePatient(int id)
        {
            var responseString = await client.GetAsync($"{usersServiceUrl}api/patientUser/findDto/" + id);
            return await responseString.Content.ReadAsAsync<MicroservicePatientDto>();
        }
    }
}
