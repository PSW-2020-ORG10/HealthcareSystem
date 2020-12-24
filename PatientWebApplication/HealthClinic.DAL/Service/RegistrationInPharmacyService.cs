using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Service
{
    public class RegistrationInPharmacyService
    {
        public RegistrationInPharmacyRepository RegistrationInPharmacyRepository { get; }
        private IRegistrationInPharmacyRepository IRegistrationRepository { get; set; }
        public RegistrationInPharmacyService() { }
    
        public RegistrationInPharmacyService(MyDbContext context)
        {
            RegistrationInPharmacyRepository = new RegistrationInPharmacyRepository(context);
        }
        public RegistrationInPharmacyService(IRegistrationInPharmacyRepository registrationRepository)
        {
            IRegistrationRepository = registrationRepository;
        }
        public List<RegistrationInPharmacy> GetAll()
        {
            return RegistrationInPharmacyRepository.GetAll();
        }
        public RegistrationInPharmacy Create(RegistrationInPharmacyDto dto)
        {
            RegistrationInPharmacy registration = RegistrationInPharmacyAdapter.RegistrationDtoToRegistration(dto);
            if (isApiKeyUnique(registration.ApiKey))  return RegistrationInPharmacyRepository.Create(registration); 
             return null;
        }
        public bool isApiKeyUnique(String apiKey)
        {
            foreach(RegistrationInPharmacy registration in GetAll())
            {
                if (registration.ApiKey.Equals(apiKey)) return false;
            }
            return true;
        }
        public List<RegistrationInPharmacy> GetAllForStub()
        {
            return IRegistrationRepository.GetAll();
        }

        public RegistrationInPharmacy getPharmacyApiKey(String apiKey)
        {
            foreach (RegistrationInPharmacy registration in IRegistrationRepository.GetAll())
            {
                if (registration.ApiKey.Equals(apiKey))  return registration; 
            }
            return null;
        }
        public RegistrationInPharmacy GetRegistrationByPharmacyName(String name)
        {
            foreach (RegistrationInPharmacy registration in RegistrationInPharmacyRepository.GetAll())
            {
                if (registration.Name.Equals(name)) return registration;
            }
            return null;
        }
        public RegistrationInPharmacy createIRegistration(RegistrationInPharmacyDto dto)
        {
            foreach (RegistrationInPharmacy registrationIRepo in IRegistrationRepository.GetAll())
            {
                if (registrationIRepo.ApiKey.Equals(RegistrationInPharmacyAdapter.RegistrationDtoToRegistration(dto).ApiKey)) return null;
            }
            return RegistrationInPharmacyAdapter.RegistrationDtoToRegistration(dto);
        }
        public Boolean Remove(String apiKey)
        {
            try{   
                RegistrationInPharmacyRepository.Remove(apiKey);
                return true;
            }
            catch{ return false; }
        }
    }
}
