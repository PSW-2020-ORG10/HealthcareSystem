/***********************************************************************
 * Module:  Question.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Patient.Question
 ***********************************************************************/
using AppointmentMicroserviceApi.Model;
using System;
namespace AppointmentMicroserviceApi.Patient
{
    public class Question : Entity
    {
        public String Name { get; set; }
        public String Answer { get; set; }
        public Question(int id, String name, String answer) : base(id)
        {
            Name = name;
            Answer = answer;
        }
        public Question() : base() { }
    }
}