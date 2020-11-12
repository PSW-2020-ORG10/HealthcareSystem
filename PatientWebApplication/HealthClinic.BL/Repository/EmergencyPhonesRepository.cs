/***********************************************************************
 * Module:  EmergencyPhonesRepository.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Repository.EmergencyPhonesRepository
 ***********************************************************************/

using HealthClinic.BL.Model.Patient;

namespace HealthClinic.BL.Repository
{
    public class EmergencyPhonesRepository : GenericFileRepository<PhoneNumber>
   {
        public EmergencyPhonesRepository(string filePath) : base(filePath)  { }

        public EmergencyPhonesRepository() : base()   { }

    }
}