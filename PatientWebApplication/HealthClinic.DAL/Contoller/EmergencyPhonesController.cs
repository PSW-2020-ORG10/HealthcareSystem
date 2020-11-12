/***********************************************************************
 * Module:  EmergencyPhonesController.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Contoller.EmergencyPhonesController
 ***********************************************************************/
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Service;
using System.Collections.Generic;
namespace HealthClinic.CL.Contoller
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