/***********************************************************************
 * Module:  RenovationController.cs
 * Author:  Luna
 * Purpose: Definition of the Class Contoller.RenovationController
 ***********************************************************************/

using Class_diagram.Model.Hospital;
using Class_diagram.Service;
using HCI_wireframe.Contoller;
using System;
using System.Collections.Generic;

namespace Class_diagram.Contoller
{
   public class RenovationController : IController<Renovation>
    {
        public RenovationService renovationService;

        public RenovationController()
        {
            renovationService = new RenovationService();
        }

        public void Update(Renovation renovation)
        {
            renovationService.Update(renovation);
        }
      
         public void Remove(Renovation renovation)
         {
            renovationService.Remove(renovation);
         }
      
        public List<Renovation> GetAll()
        {
          return renovationService.GetAll();

        }
        public void New(Renovation renovation)
        {
            renovationService.New(renovation);
        }

        public Renovation GetByid(int id)
        {
            return renovationService.GetByid(id);
        }
    }
}