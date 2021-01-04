/***********************************************************************
 * Module:  EmergencyPhonesRepository.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Repository.EmergencyPhonesRepository
 ***********************************************************************/

using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Repository
{
    public class EmergencyPhonesRepository : GenericFileRepository<PhoneNumber>
   {
      private readonly MyDbContext dbContext;
      public EmergencyPhonesRepository(MyDbContext context)
      {
         this.dbContext = context;
      }
      public EmergencyPhonesRepository(string filePath) : base(filePath)  { }

        public EmergencyPhonesRepository() : base()   { }

    }
}