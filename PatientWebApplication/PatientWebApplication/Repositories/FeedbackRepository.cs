using Class_diagram.Model.Patient;
using PatientWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Repositories
{
    /// <summary>Class <c>FeedbackRepository</c> handles database data access.
    /// </summary>
    public class FeedbackRepository
    {
        /// <summary>Instance variable <c>dbContext</c> represents the object that works with MYSQL database data.  </summary>
        private readonly MyDbContext dbContext;
        /// <summary>This constructor injects the FeedbackRepository with provided <paramref name="dbContext"/>.</summary>
        /// <param name="dbContext"><c>context</c> is type of <c>DbContext</c>, and it's used for accessing MYSQL database.</param>
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
        /// <summary> This is method for getting all feedback. </summary>
        /// <returns> List of all feedback representing all feedback in database. </returns>
        public List<Feedback> GetAll()
        {
            List<Feedback> result = new List<Feedback>();
            dbContext.Feedbacks.ToList().ForEach(feedback => result.Add(feedback));
            return result;
        }

        /// <summary> This method searches for feedback based on <paramref name="id"/>. </summary>
        /// <param name="id"><c>id</c> is <c>id</c> of a <c>Feedback</c> that needs to be found.
        /// </param>
        /// <returns> Found feedback if search was successfully; otherwise, default Feedback object. </returns>
        public Feedback Find(int id)
        {
            return dbContext.Feedbacks.SingleOrDefault(feedback => feedback.id == id);
        }

        /// <summary> This method changes property <c>IsPublished</c> of given <paramref name="feedback"/> and saves it into database. </summary>
        /// <param name="feedback"><c>feedback</c> is feedback that needs to be published.
        /// </param>
        /// <returns> Feedback saved into database. </returns>
        public Feedback PublishFeedback(Feedback feedback)
        {
            feedback.IsPublished = true;
            dbContext.SaveChanges();
            return feedback;
        }

    }
}
