/***********************************************************************
 * Module:  User.cs
 * Author:  Luna
 * Purpose: Definition of the Class Model.Employee.User
 ***********************************************************************/

using Class_diagram.Model.Patient;
using System;

namespace Class_diagram.Model.Employee
{
    public class User : Entity
   {
        public String FirstName { get; set; }
        public String SecondName { get; set; }
        public String UniqueCitizensIdentityNumber { get; set; }
        public String DateOfBirth { get; set; }
        public String PhoneNumber { get; set; }
       

        public User(int id, string name, string secondname, string ucin, string date, string phone) : base(id)
        {
            this.FirstName = name;
            this.SecondName = secondname;
            this.UniqueCitizensIdentityNumber = ucin;
            this.DateOfBirth = date;
            this.PhoneNumber = phone;
        }

       
      public User() : base()
        {

        }

    }
}