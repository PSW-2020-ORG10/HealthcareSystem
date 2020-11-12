/***********************************************************************
 * Module:  EmergencyPhonesService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.EmergencyPhonesService
 ***********************************************************************/
using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using HCI_wireframe;
using HCI_wireframe.Service;
using System;
using System.Collections.Generic;
using System.IO;
namespace Class_diagram.Service
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