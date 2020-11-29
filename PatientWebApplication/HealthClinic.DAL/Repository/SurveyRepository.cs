using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Patient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthClinic.CL.Repository
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly MyDbContext dbContext;
        public SurveyRepository()
        {
            this.dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
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
