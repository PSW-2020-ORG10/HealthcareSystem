/***********************************************************************
 * Module:  RenovationRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.RenovationRepository
 ***********************************************************************/

using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Hospital;

namespace HealthClinic.CL.Repository
{
    public class RenovationRepository : GenericFileRepository<Renovation>
    {
      private readonly MyDbContext dbContext;
      public RenovationRepository(MyDbContext dbContext)
      {
         this.dbContext = dbContext;
      }
      public RenovationRepository(string filePath) : base(filePath)  { }

        public RenovationRepository() : base()   {  }

    }
}