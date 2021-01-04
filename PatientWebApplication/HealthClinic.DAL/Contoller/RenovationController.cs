/***********************************************************************
 * Module:  RenovationController.cs
 * Author:  Luna
 * Purpose: Definition of the Class Contoller.RenovationController
 ***********************************************************************/

using HealthClinic.CL.Model.Hospital;
using HealthClinic.CL.Service;
using System.Collections.Generic;

namespace HealthClinic.CL.Contoller
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