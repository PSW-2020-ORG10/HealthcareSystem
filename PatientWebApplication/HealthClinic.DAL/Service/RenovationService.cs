/***********************************************************************
 * Module:  RenovationService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.RenovationService
 ***********************************************************************/


using HealthClinic.CL.Model.Hospital;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Service
{
    public class RenovationService : BingPath, IService<Renovation>
    {
        public RenovationRepository renovationRepository;
        String b = bingPathToAppDir(@"JsonFiles\renovation.json");

        public RenovationService()
        {
            renovationRepository = new RenovationRepository(b);
        }

        public void Update(Renovation renovation)
        {
            renovationRepository.Update(renovation);
        }
      
        public void Remove(Renovation renovation)
        {
            renovationRepository.Delete(renovation.id);
        }
      
        public List<Renovation> GetAll()
        {
            return renovationRepository.GetAll();

        }
        public void New(Renovation renovation)
        {
            renovationRepository.New(renovation);
        }

        public Renovation GetByid(int id)
        {
            return  renovationRepository.GetByid(id);
        }
    }
}