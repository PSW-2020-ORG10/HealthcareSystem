/***********************************************************************
 * Module:  OperationRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.OperationRepository
 ***********************************************************************/

using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Doctor;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinic.CL.Repository
{
    public class OperationRepository : IOperationRepository
    {
        private readonly MyDbContext dbContext;
        public OperationRepository()
        {
            this.dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
        }

        public void New(Operation operation)
        {
            dbContext.Operations.Add(operation);
            dbContext.SaveChanges();
        }

        public void Update(Operation operation)
        {
            dbContext.Operations.Update(operation);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            dbContext.Operations.Remove(GetByid(id));
            dbContext.SaveChanges();
        }

        public List<Operation> GetAll()
        {
            return dbContext.Operations.ToList();
        }

        public Operation GetByid(int id)
        {
            return dbContext.Operations.SingleOrDefault(operation => operation.id == id);
        }

        public List<Operation> GetOperationsForPatient(int idPatient)
        {
            return dbContext.Operations.ToList().FindAll(operation => operation.PatientUserId == idPatient);
        }

        public List<Operation> GetOperationsForDoctor(int idDoctor)
        {
            return dbContext.Operations.ToList().FindAll(operation => operation.DoctorUserId == idDoctor);
        }
    }
}