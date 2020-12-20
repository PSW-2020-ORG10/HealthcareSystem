using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Patient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthClinic.CL.Repository
{
    /// <summary>Class <c>PrescriptionRepository</c> handles database data access.
    /// </summary>
    public class PrescriptionRepository : IPrescriptionRepository
    {
        /// <summary>Instance variable <c>dbContext</c> represents the object that works with MYSQL database data.  </summary>
        private readonly MyDbContext dbContext;

        /// <summary>This constructor injects the PrescriptionRepository with provided <paramref name="dbContext"/>.</summary>
         public PrescriptionRepository()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options;
            this.dbContext = new MyDbContext(options);
        }

        /// <summary> This is method gets all <c>Prescription</c>. </summary>
        /// <returns> List of all prescriptions from database. </returns>
        public List<Prescription> GetAll()
        {
            return dbContext.Prescriptions.ToList();
        }

        /// <summary> This method searches for list of <c>Prescription</c> of logged Patient.  </summary>
        /// /// <param name="idPatient"><c>idPatient</c> is <c>id</c> of a <c>PatientUser</c> that is logged.
        /// </param>
        /// <returns> List of all patient prescription from database.</returns>
        public List<Prescription> GetPrescriptionsForPatient(int idPatient)
        {
            return dbContext.Prescriptions.ToList().FindAll(prescription => prescription.patientsid == idPatient);
        }
    }
}
