/***********************************************************************
 * Module:  ManagerRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.ManagerRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Manager;
using HealthClinic.CL.Repository;

namespace UserMicroserviceApi.Repository
{
    public class ManagerRepository : GenericFileRepository<ManagerUser>
    {
        public ManagerRepository() : base() { }

        public ManagerRepository(string filePath) : base(filePath) { }

    }
}