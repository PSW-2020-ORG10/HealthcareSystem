/***********************************************************************
 * Module:  ManagerService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.ManagerService
 ***********************************************************************/

using Class_diagram.Model.Employee;
using Class_diagram.Model.Manager;
using Class_diagram.Repository;
using HCI_wireframe.Model.Employee;
using HCI_wireframe.Service;
using System;
using System.Collections.Generic;
using System.IO;

namespace Class_diagram.Service
{
   public class ManagerService : AbstractUserService<ManagerUser>
    {
        public ManagerRepository managerRepository;
        String path = bingPathToAppDir(@"JsonFiles\manager.json");

        public ManagerService()
        {
            managerRepository = new ManagerRepository(path);
        }


     
      

        public override List<ManagerUser> GetAll()
        {
            return managerRepository.GetAll();
        }

        public override Boolean New(ManagerUser manager)
        {
            if (isDataValid(manager.Email,manager.UniqueCitizensIdentityNumber,manager) && isCityValid(manager.city))
            {
                managerRepository.New(manager);
                return true;
            }
            return false;
            
        }

        public override bool Update(ManagerUser manager)
        {
            if (isDataValid(manager.Email, manager.UniqueCitizensIdentityNumber,manager) && isCityValid(manager.city))
            {
                managerRepository.Update(manager);
                return true;
            }
            return false;
        }

        public override ManagerUser GetByID(int ID)
        {
            return managerRepository.GetByID(ID);
        }

        public override void Remove(ManagerUser manager)
        {
            managerRepository.Delete(manager.ID);
        }
    }
}