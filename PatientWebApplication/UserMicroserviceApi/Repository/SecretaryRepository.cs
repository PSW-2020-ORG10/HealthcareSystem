/***********************************************************************
 * Module:  SecretaryRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.SecretaryRepository
 ***********************************************************************/

using UserMicroserviceApi.DbContextModel;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Repository
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