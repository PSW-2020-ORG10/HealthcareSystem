using Class_diagram.Model.Patient;
using PatientWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Repositories
{
    public class FeedbackRepository
    {
        private readonly MyDbContext dbContext;
        public FeedbackRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Feedback Add(Feedback feedback)
        {
            dbContext.Feedbacks.Add(feedback);
            dbContext.SaveChanges();
            return feedback;
        }

        public PatientUser FindPatient() // Needs login
        {
            PatientUser patient = new PatientUser();
            patient = dbContext.Patients.SingleOrDefault(patient => patient.id == 1); // still no login, so patient set to created patient in database with id=1, this will be changed after
            return patient;
        }

        public List<Feedback> GetAll()
        {
            List<Feedback> result = new List<Feedback>();
            dbContext.Feedbacks.ToList().ForEach(feedback => result.Add(feedback));
            return result;
        }

        public Feedback Find(int id)
        {
            return dbContext.Feedbacks.SingleOrDefault(feedback => feedback.id == id);
        }

        public Feedback PublishFeedback(Feedback feedback)
        {
            feedback.IsPublished = true;
            dbContext.SaveChanges();
            return feedback;
        }
    }
}
