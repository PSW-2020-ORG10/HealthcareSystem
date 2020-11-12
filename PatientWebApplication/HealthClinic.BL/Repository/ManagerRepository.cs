/***********************************************************************
 * Module:  ManagerRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.ManagerRepository
 ***********************************************************************/

using HealthClinic.BL.Model.Manager;
using System;

namespace HealthClinic.BL.Repository
{
    public class ManagerRepository : GenericFileRepository<ManagerUser>
   {
        public ManagerRepository() : base(){ }

        public ManagerRepository(string filePath) : base(filePath)  { }

   }
}