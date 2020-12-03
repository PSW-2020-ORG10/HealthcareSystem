/***********************************************************************
 * Module:  DoctorRepository.cs
 * Author:  Luna
 * Purpose: Definition of the Class Repository.DoctorRepository
 ***********************************************************************/

using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Doctor;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinic.CL.Repository
{
    public class DoctorRepository
   {
        private readonly MyDbContext dbContext;
        public DoctorRepository()
        {
            this.dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
        }

        public List<DoctorUser> GetAll()
        {
            return dbContext.Doctors.ToList();
        }

        public DoctorUser New(DoctorUser doctor)
        {
            dbContext.Doctors.Add(doctor);
            dbContext.SaveChanges();
            return doctor;
        }

        public DoctorUser Update(DoctorUser doctor)
        {
            dbContext.Doctors.Update(doctor);
            dbContext.SaveChanges();
            return doctor;
        }

        public DoctorUser GetByid(int id)
        {
            return dbContext.Doctors.SingleOrDefault(d => d.id == id);
        }

        public void Delete(int id)
        {
            dbContext.Doctors.Remove(dbContext.Doctors.SingleOrDefault(d => d.id == id));
            dbContext.SaveChanges();
        }
    }
}