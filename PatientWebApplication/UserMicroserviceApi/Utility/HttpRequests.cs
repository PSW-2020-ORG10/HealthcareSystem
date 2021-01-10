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
      private static readonly string appointmentServiceUrl = GetUrl();
        private static readonly HttpClient client = new HttpClient();

      public static string GetUrl()
      {
         if (Startup.IsNotProduction)
         {
            return "http://localhost:53212/";
         }
         return Startup.Configuration["AppointmentMicroServiceApi"];
      }

      public static async Task<List<MicroserviceAppointmentDto>> GetAllAppointments()
        {
            var responseString = await client.GetAsync($"{appointmentServiceUrl}api/doctorAppointment/getAllDto");
            return await responseString.Content.ReadAsAsync<List<MicroserviceAppointmentDto>>();
        }
    }
}
