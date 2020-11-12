/***********************************************************************
 * Module:  User.cs
 * Author:  Luna
 * Purpose: Definition of the Class Model.Employee.User
 ***********************************************************************/

using HealthClinic.BL.Model.Patient;

namespace HealthClinic.BL.Model.Employee
{
    public class User : Entity
    {
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string uniqueCitizensidentityNumber { get; set; }
        public string dateOfBirth { get; set; }
        public string phoneNumber { get; set; }


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