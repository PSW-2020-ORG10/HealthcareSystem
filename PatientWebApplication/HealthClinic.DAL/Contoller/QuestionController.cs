/***********************************************************************
 * Module:  QuestionController.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Contoller.QuestionController
 ***********************************************************************/
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Service;
using System.Collections.Generic;
namespace HealthClinic.CL.Contoller
{
    public class QuestionController : IController<Question>
    {
        public QuestionarieService questionarieService;

        public QuestionController()
        {
            questionarieService = new QuestionarieService();
        }
       
        public List<Question> GetAll()
        {
            return questionarieService.GetAll();
        }

        public Question GetByid(int id)
        {
            return questionarieService.GetByid(id);
        }

        public void New(Question entity)
        {
            questionarieService.New(entity);
        }

        public void Remove(Question entity)
        {
            questionarieService.Remove(entity);
        }

        public void Update(Question entity)
        {
            questionarieService.Update(entity);
        }
    }
}