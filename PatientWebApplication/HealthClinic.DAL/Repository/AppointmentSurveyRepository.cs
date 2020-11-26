using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Patient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthClinic.CL.Repository
{
    public class AppointmentSurveyRepository
    {
        private readonly MyDbContext dbContext;
        /// <summary>This constructor injects the FeedbackRepository with provided <paramref name="dbContext"/>.</summary>
        /// <param name="dbContext"><c>context</c> is type of <c>DbContext</c>, and it's used for accessing MYSQL database.</param>
        public AppointmentSurveyRepository()
        {
            this.dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);

        }

        public List<DoctorAppointment> GetAll()
        {
            return dbContext.DoctorAppointments.ToList().FindAll(appointment => appointment.PatientUserId == 1);
        }
    }
}
