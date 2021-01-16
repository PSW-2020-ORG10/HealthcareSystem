using System;
using System.ComponentModel.DataAnnotations;

namespace PharmacyRegistrationApi.Model
{
    public class PharmacyConnectionInfo
    {
        [Key]
        public String ApiKey { get; set; }
        public String Email { get; set; }
        public int RegistrationInPharmacyId { get; set; }
        public PharmacyConnectionInfo() { }
        public PharmacyConnectionInfo(String apiKey, String email)
        {
            ApiKey = apiKey;
            Email = email;
        }
        public PharmacyConnectionInfo(String apiKey)
        {
            ApiKey = apiKey;
            Email = "";
        }
        public PharmacyConnectionInfo(String apiKey, String email, int registrationInPharmacyId)
        {
            ApiKey = apiKey;
            Email = email;
            RegistrationInPharmacyId = registrationInPharmacyId;
        }
    }
}
