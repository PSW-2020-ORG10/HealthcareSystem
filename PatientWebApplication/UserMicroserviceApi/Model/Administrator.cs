using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroserviceApi.Model
{
    public class Administrator : EmployeeUser
    {
        public Administrator(int id, string name, string secondname, string ucin, string date, string phone, string email, string pasword, string city,double salary) :
        base(id, name, secondname, ucin, date, phone, email, pasword, city, salary)
        {
        }

        public Administrator() : base() { }
    }
}
