/***********************************************************************
 * Module:  EmergencyPhonesService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.EmergencyPhonesService
 ***********************************************************************/
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
namespace HealthClinic.CL.Service
{
    public class EmergencyPhonesService : BingPath, IService<PhoneNumber>
    {
        public EmergencyPhonesRepository emergencyPhonesRepository;
        String path = bingPathToAppDir(@"JsonFiles\emergencyPhones.json");


        public EmergencyPhonesService()
        {
            emergencyPhonesRepository = new EmergencyPhonesRepository(path);
        }
      
        public List<PhoneNumber> GetAll()
        {
           return emergencyPhonesRepository.GetAll();
          
        }

        public PhoneNumber GetByid(int id)
        {
            return emergencyPhonesRepository.GetByid(id);
        }

        public void New(PhoneNumber entity)
        {
            emergencyPhonesRepository.New(entity);
        }

        public void Remove(PhoneNumber entity)
        {
            emergencyPhonesRepository.Delete(entity.id);
        }

        public void Update(PhoneNumber entity)
        {
            emergencyPhonesRepository.Update(entity);
        }
    }
}