using PharmacyRegistrationApi.Model;
using System;
using System.Collections.Generic;

namespace PharmacyRegistrationApi.Repository
{
    public interface IRegistrationInPharmacyRepository
    {
        RegistrationInPharmacy Create(RegistrationInPharmacy registration);

        List<RegistrationInPharmacy> GetAll();

        RegistrationInPharmacy GetPharmacyApiKey(String apiKey);
       
    }

}

