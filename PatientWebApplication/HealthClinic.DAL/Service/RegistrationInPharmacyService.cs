using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Service
{
    public class RegistrationInPharmacyService
    {
        public RegistrationInPharmacyRepository RegistrationInPharmacyRepository { get; }
        public RegistrationInPharmacyService() { }

        public RegistrationInPharmacyService(MyDbContext context)
        {
            RegistrationInPharmacyRepository = new RegistrationInPharmacyRepository(context);
        }
        public List<RegistrationInPharmacy> GetAll()
        {
            return RegistrationInPharmacyRepository.GetAll();
        }
        public RegistrationInPharmacy Create(RegistrationInPharmacyDto dto)
        {
            RegistrationInPharmacy registration = RegistrationInPharmacyAdapter.RegistrationDtoToRegistration(dto);

            return RegistrationInPharmacyRepository.Create(registration);
        }

        public RegistrationInPharmacy getApiKey(int pharmacyId)
        {
            return RegistrationInPharmacyRepository.getApiKey(pharmacyId);
        }
        public RegistrationInPharmacy getPharmacyId(String apiKey)
        {
            return RegistrationInPharmacyRepository.getPharmacyId(apiKey);
        }

    }
}
