using System;

namespace MedicineReportApi.Model
{
    public class RegistrationInPharmacy : Entity
    {
        public int PharmacyId { get; set; }
        public String ApiKey { get; set; }
        public String Name { get; set; }
        public String Town { get; set; }

        public RegistrationInPharmacy() : base() { }

        public RegistrationInPharmacy(int id, int idPharmacy, String apiKeyPharmacy, String pharmacyName, String pharmacyTown) : base(id)
        {
            PharmacyId = idPharmacy;
            ApiKey = apiKeyPharmacy;
            Name = pharmacyName;
            Town = pharmacyTown;
        }
        public RegistrationInPharmacy(int idPharmacy, String apiKeyPharmacy, String pharmacyName, String pharmacyTown)
        {
            PharmacyId = idPharmacy;
            ApiKey = apiKeyPharmacy;
            Name = pharmacyName;
            Town = pharmacyTown;
        }
    }
}
