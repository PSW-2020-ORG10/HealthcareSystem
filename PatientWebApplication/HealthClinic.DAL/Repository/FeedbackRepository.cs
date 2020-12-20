using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Patient;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinic.CL.Repositories
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

        /// <summary> This method saves provided <paramref name="feedback"/> to database. </summary>
        /// <param name="feedback"><c>feedback</c> is feedback that needs to be saved into database.
        /// </param>
        /// <returns> Feedback saved into database. </returns>
        public Feedback Add(Feedback feedback)
        {
            dbContext.Feedbacks.Add(feedback);
            dbContext.SaveChanges();
            return feedback;
        }

        /// <summary> Not finished. Need login. </summary>
        /// <returns> Found patient if search was successful; otherwise, default Patient object. </returns>
        public PatientUser FindPatient() // Needs login
        {
            PatientUser patient = new PatientUser();
            patient = dbContext.Patients.SingleOrDefault(onePatient => onePatient.id == 1); // still no login, so patient set to created patient in database with id=1, this will be changed after
            return patient;
        }
        /// <summary> This is method gets all <c>Feedback</c>. </summary>
        /// <returns> List of all feedback from database. </returns>
        public List<Feedback> GetAll()
        {
             
            return dbContext.Feedbacks.ToList();
        }

        /// <summary> This method searches for list of <c>Feedback</c> where paramter <c>IsPublished</c> is true.  </summary>
        /// <returns> List of all published feedback from database.</returns>
        public List<Feedback> GetPublished()
        {           
            return dbContext.Feedbacks.ToList().FindAll(feedback => feedback.IsPublished); 
        }

        /// <summary> This method searches for feedback based on <paramref name="id"/>. </summary>
        /// <param name="id"><c>id</c> is <c>id</c> of a <c>Feedback</c> that needs to be found.
        /// </param>
        /// <returns> Found feedback if search was successful; otherwise, default Feedback object. </returns>
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
