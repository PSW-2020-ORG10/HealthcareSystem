/***********************************************************************
 * Module:  SecretaryRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.SecretaryRepository
 ***********************************************************************/

using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Secretary;

namespace HealthClinic.CL.Repository
{
    public class SecretaryRepository : GenericFileRepository<SecretaryUser>
    {
      private readonly MyDbContext dbContext;
      public SecretaryRepository(MyDbContext dbContext)
      {
         this.dbContext = dbContext;
      }

      public SecretaryRepository(string filePath) : base(filePath) { }

        public SecretaryRepository() : base() { }

    }
}