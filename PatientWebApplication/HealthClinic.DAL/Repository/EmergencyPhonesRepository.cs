/***********************************************************************
 * Module:  EmergencyPhonesRepository.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Repository.EmergencyPhonesRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Repository
{
    public class EmergencyPhonesRepository : GenericFileRepository<PhoneNumber>
   {
        public EmergencyPhonesRepository(string filePath) : base(filePath)  { }

        public EmergencyPhonesRepository() : base()   { }

    }
}