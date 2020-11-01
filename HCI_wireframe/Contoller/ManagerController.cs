/***********************************************************************
 * Module:  ManagerController.cs
 * Author:  Luna
 * Purpose: Definition of the Class Contoller.ManagerController
 ***********************************************************************/

using Class_diagram.Model.Employee;
using Class_diagram.Model.Hospital;
using Class_diagram.Model.Manager;
using Class_diagram.Service;
using HCI_wireframe.Contoller;
using HCI_wireframe.Model.Employee;
using System;
using System.Collections.Generic;

namespace Class_diagram.Contoller
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