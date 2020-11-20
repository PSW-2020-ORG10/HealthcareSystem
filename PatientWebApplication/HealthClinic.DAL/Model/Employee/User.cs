/***********************************************************************
 * Module:  User.cs
 * Author:  Luna
 * Purpose: Definition of the Class Model.Employee.User
 ***********************************************************************/

using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Model.Employee
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

        public User(string firstName, string secondName, string uniqueCitizensidentityNumber, string dateOfBirth, string phoneNumber) : base()
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