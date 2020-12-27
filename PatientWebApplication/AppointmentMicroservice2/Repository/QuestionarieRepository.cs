/***********************************************************************
 * Module:  QuestionarieRepository.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Repository.QuestionarieRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;

namespace AppointmentMicroservice.Repository
{
    public class QuestionarieRepository : GenericFileRepository<Question>
    {
        public QuestionarieRepository(string filePath) : base(filePath) { }

        public QuestionarieRepository() : base() { }

    }
}