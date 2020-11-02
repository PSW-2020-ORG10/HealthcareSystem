/***********************************************************************
 * Module:  EmergencyPhonesController.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Contoller.EmergencyPhonesController
 ***********************************************************************/
using Class_diagram.Model.Patient;
using Class_diagram.Service;
using HCI_wireframe.Contoller;
using System;
using System.Collections.Generic;
namespace Class_diagram.Contoller
{
    public class EmergencyPhonesController : IController<PhoneNumber>
    {
        public EmergencyPhonesService emergencyPhonesService;
        public EmergencyPhonesController()
        { 
            emergencyPhonesService = new EmergencyPhonesService(); 
        }

        public List<PhoneNumber> GetAll()
        {
            return emergencyPhonesService.GetAll();
        }

        public PhoneNumber GetByid(int id)
        {
            return emergencyPhonesService.GetByid(id);
        }

        public void New(PhoneNumber entity)
        {
            emergencyPhonesService.New(entity);
        }

        public void Remove(PhoneNumber entity)
        {
            emergencyPhonesService.Remove(entity);
        }

        public void Update(PhoneNumber entity)
        {
            emergencyPhonesService.Update(entity);
        }
    }
}