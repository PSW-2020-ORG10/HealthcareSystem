/***********************************************************************
 * Module:  ManagerRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.ManagerRepository
 ***********************************************************************/

using UserMicroserviceApi.DbContextModel;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Repository
{
    public class ManagerRepository : GenericFileRepository<ManagerUser>
    {
        private readonly MyDbContext dbContext;

        public ManagerRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ManagerRepository() : base() { }

        public ManagerRepository(string filePath) : base(filePath) { }

    }
}