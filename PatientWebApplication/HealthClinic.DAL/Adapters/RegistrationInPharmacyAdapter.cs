using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Pharmacy;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Adapters
{
    public class RegistrationInPharmacyAdapter
    {
        public static RegistrationInPharmacy RegistrationDtoToRegistration(RegistrationInPharmacyDto dto)
        {
            return new RegistrationInPharmacy(12, dto.pharmacyId, dto.apiKey);
        }

        public static RegistrationInPharmacyDto RegistrationToRegistrationDto(RegistrationInPharmacy registration)
        {
           return new RegistrationInPharmacyDto(registration.pharmacyId, registration.apiKey);
        }
    }
}
