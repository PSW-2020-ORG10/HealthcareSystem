/***********************************************************************
 * Module:  OperationRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.OperationRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Doctor;
using System.Collections.Generic;

namespace HealthClinic.CL.Repository
{
    public interface IOperationRepository
    {
        void Delete(int id);
        List<Operation> GetAll();
        Operation GetByid(int id);
        List<Operation> GetOperationsForPatient(int idPatient);
        void New(Operation operation);
        void Update(Operation operation);
    }
}