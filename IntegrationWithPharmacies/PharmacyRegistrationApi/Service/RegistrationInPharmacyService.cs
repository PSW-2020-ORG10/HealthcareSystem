﻿
using PharmacyRegistrationApi.Adapters;
using PharmacyRegistrationApi.DbContextModel;
using PharmacyRegistrationApi.Dtos;
using PharmacyRegistrationApi.Model;
using PharmacyRegistrationApi.Repository;
using System;
using System.Collections.Generic;

namespace PharmacyRegistrationApi.Service
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
            return IsApiKeyUnique(registration.PharmacyConnectionInfo.ApiKey) ? RegistrationInPharmacyRepository.Create(registration) : null;
        }
        public bool IsApiKeyUnique(String apiKey)
        {
            foreach(RegistrationInPharmacy registration in GetAll())
            {
                if (registration.PharmacyConnectionInfo.ApiKey.Equals(apiKey)) return false;
            }
            return true;
        }
        public List<RegistrationInPharmacy> GetAllForStub()
        {
            return IRegistrationRepository.GetAll();
        }

        public RegistrationInPharmacy GetPharmacyApiKey(String apiKey)
        {
            foreach (RegistrationInPharmacy registration in IRegistrationRepository.GetAll())
            {
                if (registration.PharmacyConnectionInfo.ApiKey.Equals(apiKey))  return registration; 
            }
            return null;
        }
        public RegistrationInPharmacy GetRegistrationByPharmacyName(String name)
        {
            foreach (RegistrationInPharmacy registration in RegistrationInPharmacyRepository.GetAll())
            {
                if (registration.PharmacyNameInfo.Name.Equals(name)) return registration;
            }
            return null;
        }
        public RegistrationInPharmacy CreateIRegistration(RegistrationInPharmacyDto dto)
        {
            foreach (RegistrationInPharmacy registrationIRepo in IRegistrationRepository.GetAll())
            {
                if (registrationIRepo.PharmacyConnectionInfo.ApiKey.Equals(RegistrationInPharmacyAdapter.RegistrationDtoToRegistration(dto).PharmacyConnectionInfo.ApiKey)) return null;
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
