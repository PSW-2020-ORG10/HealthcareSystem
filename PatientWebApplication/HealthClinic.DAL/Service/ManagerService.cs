/***********************************************************************
 * Module:  ManagerService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.ManagerService
 ***********************************************************************/

using HealthClinic.CL.Model.Manager;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Service
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

        private bool createManagerIfDateIsValid(ManagerUser manager)
        {
            if (isDataValid(manager.email, manager.uniqueCitizensidentityNumber, manager) && isCityValid(manager.city))
            {
                managerRepository.New(manager);
                return true;
            }
            return false;
        }
        

        public override Boolean New(ManagerUser manager)
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