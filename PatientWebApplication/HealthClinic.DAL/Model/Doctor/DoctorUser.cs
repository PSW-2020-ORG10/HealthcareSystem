using System.Collections.Generic;
using HealthClinic.CL.Model.Employee;

namespace HealthClinic.CL.Model.Doctor
{
    public class DoctorUser : EmployeeUser
    {
        public bool isSpecialist { get; set; }

        public virtual List<DoctorNotification> specialNotifications { get; set; }
        public string ordination { get; set; }

        public string speciality { get; set; }
        public DoctorUser(int id, string name, string secondname, string ucin, string date, string phone, string email, string pasword, string city,
             double salary, bool isSpecialist, string speciality, List<DoctorNotification> specialNotifications, string ordination) :
             base(id, name, secondname, ucin, date, phone, email, pasword, city, salary)
        {
            this.isSpecialist = isSpecialist;
            this.speciality = speciality;

            this.specialNotifications = specialNotifications;
            this.ordination = ordination;

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