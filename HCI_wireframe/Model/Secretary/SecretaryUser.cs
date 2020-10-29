/***********************************************************************
 * Module:  Secretary.cs
 * Author:  Luna
 * Purpose: Definition of the Class Secretary.Secretary
 ***********************************************************************/

using System;
using Class_diagram.Model.Hospital;
using Class_diagram.Model.Doctor;
using Class_diagram.Model.Patient;
using Class_diagram.Model.Employee;
using HCI_wireframe.Model.Employee;

namespace Class_diagram.Model.Secretary
{
    public class SecretaryUser : EmployeeUser
    {
        public String room { get; set; }

        public SecretaryUser(int id, string name, string secondname, string ucin, String date, string phone, String email, String pasword, String city,
            Double salary, String room) :
            base(id, name, secondname, ucin, date, phone, email, pasword, city, salary)
        {

            this.room = room;
        }

        public SecretaryUser() :
            base()
        {

        }

    }
}