/***********************************************************************
 * Module:  QuestionController.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Contoller.QuestionController
 ***********************************************************************/
using Class_diagram.Model.Patient;
using Class_diagram.Service;
using HCI_wireframe.Contoller;
using System;
using System.Collections.Generic;
namespace Class_diagram.Contoller
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