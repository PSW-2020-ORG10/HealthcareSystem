/***********************************************************************
 * Module:  User.cs
 * Author:  Luna
 * Purpose: Definition of the Class Model.Employee.User
 ***********************************************************************/

namespace UserMicroserviceApi.Model
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string UniqueCitizensidentityNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }


        public User(int id, string firstName, string secondName, string uniqueCitizensidentityNumber, string dateOfBirth, string phoneNumber) : base(id)
        {
            FirstName = firstName;
            SecondName = secondName;
            UniqueCitizensidentityNumber = uniqueCitizensidentityNumber;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
        }

        public User(string firstName, string secondName, string uniqueCitizensidentityNumber, string dateOfBirth, string phoneNumber) : base()
        {
            FirstName = firstName;
            SecondName = secondName;
            UniqueCitizensidentityNumber = uniqueCitizensidentityNumber;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
        }


        public User() : base() {}

    }
}