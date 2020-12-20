/***********************************************************************
 * Module:  ManagerRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.ManagerRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Manager;

namespace HealthClinic.CL.Repository
{
    public class ManagerRepository : GenericFileRepository<ManagerUser>
   {
        public ManagerRepository() : base(){ }

        public ManagerRepository(string filePath) : base(filePath)  { }

   }
}