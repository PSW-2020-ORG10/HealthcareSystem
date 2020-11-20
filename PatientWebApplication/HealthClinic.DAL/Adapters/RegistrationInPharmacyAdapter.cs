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
            RegistrationInPharmacy registration = new RegistrationInPharmacy(1, dto.pharmacyId, dto.apiKey);
            return registration;
        }

        public static RegistrationInPharmacyDto RegistrationToRegistrationDto(RegistrationInPharmacy registration)
        {
            RegistrationInPharmacyDto dto = new RegistrationInPharmacyDto(registration.pharmacyId, registration.apiKey);
            return dto;
        }
    }
}
