using AppointmentMicroserviceApi.Patient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MyDbContext = AppointmentMicroserviceApi.DbContextModel.MyDbContext;

namespace AppointmentMicroserviceApi.Repository
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly MyDbContext dbContext;
        public SurveyRepository()
        {
            dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
        }

        public SurveyRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }
    
        public Survey Add(Survey survey)
        {
            dbContext.Surveys.Add(survey);
            dbContext.SaveChanges();
            return survey;
        }

        public List<Survey> GetAll()
        {
            return dbContext.Surveys.ToList();
        }

        public List<Survey> GetAllSurveysForPatientId(int id)
        {
            return dbContext.Surveys.ToList().FindAll(survey => survey.patientId == id);
        }
    }
}
