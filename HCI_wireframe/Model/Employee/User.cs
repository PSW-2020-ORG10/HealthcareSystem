/***********************************************************************
 * Module:  User.cs
 * Author:  Luna
 * Purpose: Definition of the Class Model.Employee.User
 ***********************************************************************/

using Class_diagram.Model.Patient;
using HCI_wireframe.Model.Employee;
using System;

namespace Class_diagram.Model.Employee
{
   public class User : Entity
   {
        public String firstName { get; set; }
        public String secondName { get; set; }
        public String uniqueCitizensidentityNumber { get; set; }
        public String dateOfBirth { get; set; }
        public String phoneNumber { get; set; }
       

        public User(int id, string firstName, string secondName, string uniqueCitizensidentityNumber, string dateOfBirth, string phoneNumber) : base(id)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.uniqueCitizensidentityNumber = uniqueCitizensidentityNumber;
            this.dateOfBirth = dateOfBirth;
            this.phoneNumber = phoneNumber;
        }

       
      public User() : base()
        {

        }

    }
}