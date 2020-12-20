/***********************************************************************
 * Module:  RenovationRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.RenovationRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Hospital;

namespace HealthClinic.CL.Repository
{
    public class RenovationRepository : GenericFileRepository<Renovation>
   {
        public RenovationRepository(string filePath) : base(filePath)  { }

        public RenovationRepository() : base()   {  }

    }
}