using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Model.Pharmacy
{
    public class RegistrationInPharmacy : Entity
    {
        public int pharmacyId { get; set; }
        public String apiKey { get; set; }
        public String name { get; set; }
        public String town { get; set; }


        public RegistrationInPharmacy() : base() { }

        public RegistrationInPharmacy(int id, int idPharmacy, String apiKeyPharmacy,String phName, String phTown) : base(id)
        {
            pharmacyId = idPharmacy;
            apiKey = apiKeyPharmacy;
            name = phName;
            town = phTown;
        }
          public RegistrationInPharmacy(int idPharmacy, String apiKeyPharmacy,String phName, String phTown) 
        {
            pharmacyId = idPharmacy;
            apiKey = apiKeyPharmacy;
            name = phName;
            town = phTown;
        }
    }
}
