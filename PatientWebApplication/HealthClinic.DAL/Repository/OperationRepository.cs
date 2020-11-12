/***********************************************************************
 * Module:  OperationRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.OperationRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Doctor;

namespace HealthClinic.CL.Repository
{
    public class OperationRepository : GenericFileRepository<Operation>
   {
        public OperationRepository(string filePath) : base(filePath){ }

        public OperationRepository() : base() { }

    }
}