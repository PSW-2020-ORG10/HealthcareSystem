/***********************************************************************
 * Module:  ManagerRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.ManagerRepository
 ***********************************************************************/

using Class_diagram.Model.Manager;
using System;

namespace Class_diagram.Repository
{
   public class ManagerRepository : GenericFileRepository<ManagerUser>
   {
        public ManagerRepository() : base(){ }

        public ManagerRepository(string filePath) : base(filePath)  { }

   }
}