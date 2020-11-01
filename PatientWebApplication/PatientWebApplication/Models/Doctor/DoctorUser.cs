using System;
using System.Collections.Generic;
using HCI_wireframe.Model.Employee;

namespace HCI_wireframe.Model.Doctor
{
    public class DoctorUser : EmployeeUser
    {


        public Boolean Specialist { get; set; }
       
        public List<String> specialNotifications { get; set; }
        public String ordination { get; set; }

        public String speciality;
        public DoctorUser(int id, string name, string secondname, string ucin, string date, string phone, string email, string pasword, String city,
             Double salary, Boolean specialist, String speciality,  List<String> spec, String ord) :
             base(id, name, secondname, ucin, date, phone, email, pasword, city, salary)
        {
            this.Specialist = specialist;
            this.speciality = speciality;
          
            this.specialNotifications = spec;
            this.ordination = ord;

        }

        public DoctorUser(int id, string name, string secondname, string ucin, string date, string phone, string email, string pasword) :
            base(id, name, secondname, ucin, date, phone, email, pasword)
        {

        }



        public DoctorUser() :
         base()
        {

        }



    }
}