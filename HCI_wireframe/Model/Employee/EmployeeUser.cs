using Class_diagram.Model.Employee;
using Class_diagram.Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_wireframe.Model.Employee
{

   
     public class EmployeeUser : User
    {
        public Double salary { get; set; }
       
        public String city { get; set; }

        public String email { get; set; }
        public String password { get; set; }
        public EmployeeUser() : base() { }


        public EmployeeUser(int id, string name, string secondname, string ucin, string date, string phone, string email, string password, String city,
            Double salary) : base(id, name, secondname, ucin, date, phone)
        {
            this.email = email;
            this.password = password;
            this.city = city;
          
            this.salary = salary;
        }

        public EmployeeUser(int id, string name, string secondname, string ucin, string date, string phone, string email, string pasword) : base(id, name, secondname, ucin, date, phone)
        {
            this.email = email;
            this.password = pasword;
           
         
        }


       
    }
}
