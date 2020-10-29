/***********************************************************************
 * Module:  QuestionarieRepository.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Repository.QuestionarieRepository
 ***********************************************************************/

using Class_diagram.Model.Patient;
using System;

namespace Class_diagram.Repository
{
   public class QuestionarieRepository : GenericFileRepository<Question>
   {
        public QuestionarieRepository(string filePath) : base(filePath) {  }

        public QuestionarieRepository() : base() {  }

    }
}