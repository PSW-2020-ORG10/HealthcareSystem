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
            var randomNumber = new Random();
          
            return new RegistrationInPharmacy(randomNumber.Next(5, 1000), dto.pharmacyId, dto.apiKey);
        }

        public static RegistrationInPharmacyDto RegistrationToRegistrationDto(RegistrationInPharmacy registration)
        {
           return new RegistrationInPharmacyDto(registration.pharmacyId, registration.apiKey);
        }
    }
}
