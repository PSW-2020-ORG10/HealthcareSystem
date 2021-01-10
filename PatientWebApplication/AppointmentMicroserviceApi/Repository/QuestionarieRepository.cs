/***********************************************************************
 * Module:  QuestionarieRepository.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Repository.QuestionarieRepository
 ***********************************************************************/

using AppointmentMicroserviceApi.DbContextModel;
using AppointmentMicroserviceApi.Patient;

namespace AppointmentMicroserviceApi.Repository
{
    public class QuestionarieRepository : GenericFileRepository<Question>
    {
        private readonly MyDbContext dbContext;
        public QuestionarieRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public QuestionarieRepository(string filePath) : base(filePath) { }

        public QuestionarieRepository() : base() { }

       

    }
}