/***********************************************************************
 * Module:  RenovationService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.RenovationService
 ***********************************************************************/


using Class_diagram.Repository;
using HCI_wireframe.Service;
using HealthClinic.BL.Model.Hospital;
using System;
using System.Collections.Generic;
using System.IO;

namespace Class_diagram.Service
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