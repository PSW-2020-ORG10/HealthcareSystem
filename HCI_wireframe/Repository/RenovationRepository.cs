/***********************************************************************
 * Module:  RenovationRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.RenovationRepository
 ***********************************************************************/

using Class_diagram.Model.Hospital;
using System;

namespace Class_diagram.Repository
{
   public class RenovationRepository : GenericFileRepository<Renovation>
   {
        public RenovationRepository(string filePath) : base(filePath)  { }

        public RenovationRepository() : base()   {  }

    }
}