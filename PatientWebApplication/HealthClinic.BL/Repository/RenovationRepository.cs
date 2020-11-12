/***********************************************************************
 * Module:  RenovationRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.RenovationRepository
 ***********************************************************************/

using HealthClinic.BL.Model.Hospital;
using System;

namespace HealthClinic.BL.Repository
{
    public class RenovationRepository : GenericFileRepository<Renovation>
   {
        public RenovationRepository(string filePath) : base(filePath)  { }

        public RenovationRepository() : base()   {  }

    }
}