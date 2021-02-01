/***********************************************************************
 * Module:  OperationRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.OperationRepository
 ***********************************************************************/

using AppointmentMicroserviceApi.Doctor;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MyDbContext = AppointmentMicroserviceApi.DbContextModel.MyDbContext;

namespace AppointmentMicroserviceApi.Repository
{
    public class OperationRepository : IOperationRepository
    {
        private readonly MyDbContext dbContext;
        public OperationRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public OperationRepository()
        {
            dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
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
            return dbContext.Operations.SingleOrDefault(operation => operation.Id == id);
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