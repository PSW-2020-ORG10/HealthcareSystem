using System;
using System.Collections.Generic;
using System.Text;
using HealthClinic.CL.Model.Pharmacy;

namespace HealthClinic.CL.Repository
{
    public interface IRegistrationInPharmacyRepository
    {
        RegistrationInPharmacy Create(RegistrationInPharmacy registration);

        List<RegistrationInPharmacy> GetAll();

        RegistrationInPharmacy getPharmacyApiKey(String apiKey);
       
    }

}

