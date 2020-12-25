/***********************************************************************
 * Module:  QuestionarieService.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Service.QuestionarieService
 ***********************************************************************/
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
namespace HealthClinic.CL.Service
{
    public class QuestionarieService : BingPath, IService<Question>
    {
        public Repository.QuestionarieRepository questionarieRepository;
        String path = bingPathToAppDir(@"JsonFiles\questionary.json");

        public QuestionarieService()
        {
            questionarieRepository = new QuestionarieRepository(path);
        }
       
        public List<Question> GetAll()
        {
           return questionarieRepository.GetAll();
        
        }

        public Question GetByid(int id)
        {
            return questionarieRepository.GetByid(id);
        }

        public void New(Question entity)
        {
            questionarieRepository.New(entity);
        }

        public void Remove(Question entity)
        {
            questionarieRepository.Delete(entity.id);
        }

        public void Update(Question entity)
        {
            questionarieRepository.Update(entity);
        }
    }
}