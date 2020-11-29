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
           // var randomNumber = new Random();
          
            return new RegistrationInPharmacy(dto.pharmacyId, dto.apiKey,dto.name,dto.town);
        }

        public static RegistrationInPharmacyDto RegistrationToRegistrationDto(RegistrationInPharmacy registration)
        {
           return new RegistrationInPharmacyDto(registration.pharmacyId, registration.apiKey,registration.name,registration.town);
        }
    }
}
