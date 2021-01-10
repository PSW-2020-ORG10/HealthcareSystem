using System.Collections.Generic;

namespace UserMicroserviceApi.Model
{
    public class DoctorUser : EmployeeUser
    {
        public bool IsSpecialist { get; set; }

        public virtual List<DoctorNotification> SpecialNotifications { get; set; }
        public string Ordination { get; set; }
        public string Speciality { get; set; }

        public string DoctorFullName()
        {
            return FirstName + " " + SecondName;
        }

        public DoctorUser(int id, string name, string secondname, string ucin, string date, string phone, string email, string pasword, string city,
             double salary, bool isSpecialist, string speciality, List<DoctorNotification> specialNotifications, string ordination) :
             base(id, name, secondname, ucin, date, phone, email, pasword, city, salary)
        {
            IsSpecialist = isSpecialist;
            Speciality = speciality;
            SpecialNotifications = specialNotifications;
            Ordination = ordination;
        }

        public DoctorUser(int id, string name, string secondname, string ucin, string date, string phone, string email, string pasword) :
            base(id, name, secondname, ucin, date, phone, email, pasword) {}

        public DoctorUser() : base() {}

    }
}