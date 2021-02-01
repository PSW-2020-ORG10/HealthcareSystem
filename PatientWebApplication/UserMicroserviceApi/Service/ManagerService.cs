/***********************************************************************
 * Module:  ManagerService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.ManagerService
 ***********************************************************************/

using System;
using System.Collections.Generic;
using UserMicroserviceApi.Model;
using UserMicroserviceApi.Repository;

namespace UserMicroserviceApi.Service
{
    public class ManagerService : AbstractUserService<ManagerUser>
    {
        public ManagerRepository managerRepository;
        string path = BingPathToAppDir(@"JsonFiles\manager.json");

        public ManagerService()
        {
            managerRepository = new ManagerRepository(path);
        }

        public override List<ManagerUser> GetAll()
        {
            return managerRepository.GetAll();
        }

        private bool CreateManagerIfDateIsValid(ManagerUser manager)
        {
            if (IsDataValid(manager.Email, manager.UniqueCitizensidentityNumber, manager) && IsCityValid(manager.City))
            {
                managerRepository.New(manager);
                return true;
            }
            return false;
        }


        public override bool New(ManagerUser manager)
        {
            return CreateManagerIfDateIsValid(manager);
        }

        private bool UpdateManagerIfDataIsValid(ManagerUser manager)
        {
            if (IsDataValid(manager.Email, manager.UniqueCitizensidentityNumber, manager) && IsCityValid(manager.City))
            {
                managerRepository.Update(manager);
                return true;
            }
            return false;
        }

        public override bool Update(ManagerUser manager)
        {
            return UpdateManagerIfDataIsValid(manager);
        }

        public override ManagerUser GetByid(int id)
        {
            return managerRepository.GetByid(id);
        }

        public override void Remove(ManagerUser manager)
        {
            managerRepository.Delete(manager.Id);
        }
    }
}