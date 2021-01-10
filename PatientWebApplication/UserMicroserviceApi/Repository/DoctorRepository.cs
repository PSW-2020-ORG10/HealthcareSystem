/***********************************************************************
 * Module:  DoctorRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.DoctorRepository
 ***********************************************************************/

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UserMicroserviceApi.DbContextModel;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly MyDbContext dbContext;
        public DoctorRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DoctorRepository()
        {
            dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
        }

        public void New(DoctorUser doctor)
        {
            dbContext.Doctors.Add(doctor);
            dbContext.SaveChanges();
        }

        public void Update(DoctorUser doctor)
        {
            dbContext.Doctors.Update(doctor);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            dbContext.Doctors.Remove(GetByid(id));
            dbContext.SaveChanges();
        }

        public List<DoctorUser> GetAll()
        {
            return dbContext.Doctors.ToList();
        }

        public DoctorUser GetByid(int id)
        {
            return dbContext.Doctors.SingleOrDefault(doctor => doctor.Id == id);
        }

    }
}