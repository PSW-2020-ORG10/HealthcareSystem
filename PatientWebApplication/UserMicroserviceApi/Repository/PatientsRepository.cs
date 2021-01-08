using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UserMicroserviceApi.DbContextModel;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Repository
{
    public class PatientsRepository : IPatientsRepository
    {
        private readonly MyDbContext dbContext;
        public PatientsRepository(MyDbContext context)
        {
            dbContext = context;
        }

        public PatientsRepository()
        {
            dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
        }

        public PatientUser Add(PatientUser patient)
        {
            dbContext.Patients.Add(patient);
            dbContext.SaveChanges();
            return patient;
        }

        public PatientUser Validate(PatientUser patient)
        {
            patient.isVerified = true;
            dbContext.SaveChanges();
            return patient;
        }

        public List<PatientUser> GetAll()
        {
            return dbContext.Patients.ToList();
        }

        /// <summary> This method searches for patient based on <paramref name="id"/>. </summary>
        /// <param name="id"><c>id</c> is <c>id</c> of a <c>PatientUser/c> that needs to be found.
        /// </param>
        /// <returns> Found patient if search was successful; otherwise, default PatientUser object.</returns>
        public PatientUser FindOne(int id)
        {
            return dbContext.Patients.SingleOrDefault(patient => patient.id == id);
        }

        public PatientUser BlockPatient(PatientUser patient)
        {
            patient.isBlocked = true;
            dbContext.SaveChanges();
            return patient;
        }

        public PatientUser GetByLoginInfo(UserModel login)
        {
            return dbContext.Patients.SingleOrDefault(patient => patient.email.Equals(login.Email) && patient.password.Equals(login.Password) && patient.isBlocked == false && patient.isVerified == true);
        }

        public PatientUser GetByEmail(string email)
        {
            return dbContext.Patients.SingleOrDefault(patient => patient.email.Equals(email));
        }
    }

}

