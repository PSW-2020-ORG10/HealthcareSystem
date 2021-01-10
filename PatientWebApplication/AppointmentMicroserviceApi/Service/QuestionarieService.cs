/***********************************************************************
 * Module:  QuestionarieService.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Service.QuestionarieService
 ***********************************************************************/
using AppointmentMicroserviceApi.Patient;
using AppointmentMicroserviceApi.Repository;
using System.Collections.Generic;

namespace AppointmentMicroserviceApi.Service
{
    public class QuestionarieService : IService<Question>
    {
        public QuestionarieRepository questionarieRepository;

        public QuestionarieService()
        {
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
            questionarieRepository.Delete(entity.Id);
        }

        public void Update(Question entity)
        {
            questionarieRepository.Update(entity);
        }
    }
}