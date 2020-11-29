using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class RegistrationInPharmacyDto
    {

        public int pharmacyId { get; set; }
        public String apiKey { get; set; }
        public String name { get; set; }
        public String town { get; set; }
        public RegistrationInPharmacyDto() { }
        public RegistrationInPharmacyDto(int idPharmacy, String apiKeyPharmacy,String phName, String phTown)
        {
            pharmacyId = idPharmacy;
            apiKey = apiKeyPharmacy;
            name = phName;
            town = phTown;
        }
    }
}
