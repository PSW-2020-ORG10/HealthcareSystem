using System;


namespace HealthClinic.CL.Dtos
{
    public class RegistrationInPharmacyDto
    {
        public int PharmacyId { get; set; }
        public String ApiKey { get; set; }
        public String Name { get; set; }
        public String Town { get; set; }

        public RegistrationInPharmacyDto() { }

        public RegistrationInPharmacyDto(int idPharmacy, String apiKeyPharmacy, String pharmacyName, String pharmacyTown)
        {
            PharmacyId = idPharmacy;
            ApiKey = apiKeyPharmacy;
            Name = pharmacyName;
            Town = pharmacyTown;
        }
    }
}
