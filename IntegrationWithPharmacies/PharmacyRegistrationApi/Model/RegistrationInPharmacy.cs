using System;

namespace PharmacyRegistrationApi.Model
{
    public class RegistrationInPharmacy : Entity
    {
        public int PharmacyId { get; set; }
        public String ApiKey { get; set; }
        public String Name { get; set; }
        public String Town { get; set; }


        public RegistrationInPharmacy() : base() { }

        public RegistrationInPharmacy(int id, int pharmacyId, String apiKey, String name, String town) : base(id)
        {
            PharmacyId = pharmacyId;
            ApiKey = apiKey;
            Name = name;
            Town = town;
        }
        public RegistrationInPharmacy(int pharmacyId, String apiKey, String name, String town)
        {
            PharmacyId = pharmacyId;
            ApiKey = apiKey;
            Name = name;
            Town = town;
        }
    }
}
