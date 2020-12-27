/***********************************************************************
 * Module:  ManagerService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.ManagerService
 ***********************************************************************/

using HealthClinic.CL.Model.Manager;
using System;
using System.Collections.Generic;
using UserMicroserviceApi.Repository;

namespace UserMicroserviceApi.Service
{
    public class ManagerService : AbstractUserService<ManagerUser>
    {
        public ManagerRepository managerRepository;


        string path = bingPathToAppDir(@"JsonFiles\manager.json");

        public ManagerService()
        {
            managerRepository = new ManagerRepository(path);
        }

        public override List<ManagerUser> GetAll()
        {
            return managerRepository.GetAll();
        }

        private bool createManagerIfDateIsValid(ManagerUser manager)
        {
            if (isDataValid(manager.email, manager.uniqueCitizensidentityNumber, manager) && isCityValid(manager.city))
            {
                managerRepository.New(manager);
                return true;
            }
            return false;
        }


        public override bool New(ManagerUser manager)
        {
            return createManagerIfDateIsValid(manager);
        }

        private bool updateManagerIfDataIsValid(ManagerUser manager)
        {
            if (isDataValid(manager.email, manager.uniqueCitizensidentityNumber, manager) && isCityValid(manager.city))
            {
                managerRepository.Update(manager);
                return true;
            }
            return false;
        }

        public override bool Update(ManagerUser manager)
        {
            return updateManagerIfDataIsValid(manager);
        }

        public override ManagerUser GetByid(int id)
        {
            return managerRepository.GetByid(id);
        }

        public override void Remove(ManagerUser manager)
        {
            managerRepository.Delete(manager.id);
        }
    }
}