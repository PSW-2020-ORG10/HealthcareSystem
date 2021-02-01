using System;
using System.ComponentModel.DataAnnotations;

namespace TenderApi.Model
{
    public class PharmacyConnectionInfo
    {
        [Key]
        public String ApiKey { get; set; }
        public String Email { get; set; }
        public String Url { get; set; }
        public int RegistrationInPharmacyId { get; set; }
        public PharmacyConnectionInfo() { }
        public PharmacyConnectionInfo(String apiKey, String email, String url)
        {
            ApiKey = apiKey;
            Email = email;
            Url = url;
        }
        public PharmacyConnectionInfo(String apiKey)
        {
            ApiKey = apiKey;
            Email = "";
        }
        public PharmacyConnectionInfo(String apiKey, String email, String url, int registrationInPharmacyId)
        {
            ApiKey = apiKey;
            Email = email;
            Url = url;
            RegistrationInPharmacyId = registrationInPharmacyId;
        }
    }
}
