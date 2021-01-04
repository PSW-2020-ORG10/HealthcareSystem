/***********************************************************************
 * Module:  QuestionarieRepository.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Repository.QuestionarieRepository
 ***********************************************************************/

using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Repository
{
    public class QuestionarieRepository : GenericFileRepository<Question>
   {
      private readonly MyDbContext dbContext;
      public QuestionarieRepository(MyDbContext dbContext)
      {
         this.dbContext = dbContext;
      }
      public QuestionarieRepository(string filePath) : base(filePath) {  }

      public QuestionarieRepository() : base() {  }

    }
}