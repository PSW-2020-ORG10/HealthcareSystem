/***********************************************************************
 * Module:  Question.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Patient.Question
 ***********************************************************************/
using System;
using System.Collections.Generic;
namespace Class_diagram.Model.Patient
{
    public class Question : Entity
    {
        public String name { get; set; }
        public String answer { get; set; }
        public Question(int id, String name, String answer) : base(id)
        {
            this.name = name;
            this.answer = answer;
        }
        public Question() : base() { }
    }
}