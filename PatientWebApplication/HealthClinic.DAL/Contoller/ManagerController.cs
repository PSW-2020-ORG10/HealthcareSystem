/***********************************************************************
 * Module:  ManagerController.cs
 * Author:  Luna
 * Purpose: Definition of the Class Contoller.ManagerController
 ***********************************************************************/

using HealthClinic.CL.Model.Manager;
using HealthClinic.CL.Service;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Contoller
{
    public class ManagerController : IUserController<ManagerUser>
    {
        public ManagerService managerService;

        public ManagerController()
        {
            managerService = new ManagerService();
        }

        public Boolean Update(ManagerUser manager)
        {
           return managerService.Update(manager);
        }

        public  List<ManagerUser> GetAll()
        {
            return managerService.GetAll();
        }

        public Boolean New(ManagerUser manager)
        {
           return managerService.New(manager);
        }

        public ManagerUser GetByid(int id)
        {
            return managerService.GetByid(id);
        }

        public void Remove(ManagerUser manager)
        {
            managerService.Remove(manager);
        }
    }
}