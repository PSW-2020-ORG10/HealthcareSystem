﻿using FeedbackMicroserviceApi.DbContextModel;
using FeedbackMicroserviceApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace FeedbackMicroserviceApi.Repository
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
            return dbContext.Feedbacks.SingleOrDefault(feedback => feedback.Id == id);
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
