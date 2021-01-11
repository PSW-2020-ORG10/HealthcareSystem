/***********************************************************************
 * Module:  Patient.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Patient.Patient
 ***********************************************************************/

using System.Collections.Generic;

namespace UserMicroserviceApi.Model
{
    enum Priority
    {
        Doctor,
        Date,
        None
    }

    public class PatientUser : User
    {
        public string MedicalIdNumber { get; set; }
        public bool IsVerified { get; set; }
        public string Allergie { get; set; }
        public string City { get; set; }
        public bool Guest { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsRegisteredBySecretary { get; set; }
        public virtual List<ModelNotification> Notifications { get; set; }
        public bool IsMarried { get; set; }
        public string BornIn { get; set; }
        public string ParentName { get; set; }
        public string ExLastname { get; set; }
        public string Gender { get; set; }
        public string File { get; set; }
        public bool IsBlocked { get; set; }

        public PatientUser() : base() {}

        public PatientUser(int id, string name, string secondname, string gender, string ucin, string date, string phone, string medicalIdNumber, string allergie, string city, bool guest,
            string email, string password, bool isRegisteredBySecretary, List<ModelNotification> notifications, bool isMarried, string bornIn, string parentName, string exLastname, string file)
           : base(id, name, secondname, ucin, date, phone)
        {
            MedicalIdNumber = medicalIdNumber;
            IsVerified = false;
            Gender = gender;
            Allergie = allergie;
            City = city;
            Guest = guest;
            Email = email;
            Password = password;
            IsRegisteredBySecretary = isRegisteredBySecretary;
            Notifications = notifications;
            IsMarried = isMarried;
            BornIn = bornIn;
            ParentName = parentName;
            ExLastname = exLastname;
            File = file;
            IsBlocked = false;
        }
        public PatientUser(int id, string name, string secondname, string gender, string ucin, string date, string phone, string medicalIdNumber, string allergie, string city, bool guest,
            string email, string password, bool isMarried, string bornIn, string parentName, string file)
           : base(id, name, secondname, ucin, date, phone)
        {
            MedicalIdNumber = medicalIdNumber;
            IsVerified = false;
            Gender = gender;
            Allergie = allergie;
            City = city;
            Guest = guest;
            Email = email;
            Password = password;
            IsRegisteredBySecretary = false;
            Notifications = new List<ModelNotification>();
            IsMarried = isMarried;
            BornIn = bornIn;
            ParentName = parentName;
            ExLastname = "";
            File = file;
            IsBlocked = false;
        }



        public PatientUser(string name, string secondname, string gender, string ucin, string date, string phone, string allergie, string city, bool guest,
             string email, string password, bool isRegisteredBySecretary, List<ModelNotification> notifications, bool isMarried, string bornIn, string parentName, string exLastname, string file)
            : base(name, secondname, ucin, date, phone)
        {

            Gender = gender;
            IsVerified = false;
            Allergie = allergie;
            City = city;
            Guest = guest;
            Email = email;
            Password = password;
            IsRegisteredBySecretary = isRegisteredBySecretary;
            Notifications = notifications;
            IsMarried = isMarried;
            BornIn = bornIn;
            ParentName = parentName;
            ExLastname = exLastname;
            File = file;
            IsBlocked = false;
        }
        public PatientUser(string name, string secondname, string gender, string ucin, string date, string phone, string allergie, string city, bool guest,
           string email, string password, bool isMarried, string bornIn, string parentName, string file)
          : base(name, secondname, ucin, date, phone)
        {

            IsVerified = false;
            Gender = gender;
            Allergie = allergie;
            City = city;
            Guest = guest;
            Email = email;
            Password = password;
            IsRegisteredBySecretary = false;
            Notifications = new List<ModelNotification>();
            IsMarried = isMarried;
            BornIn = bornIn;
            ParentName = parentName;
            ExLastname = "";
            File = file;
            IsBlocked = false;
        }

        public PatientUser(PatientUser patient)
           : base(patient.Id, patient.FirstName, patient.SecondName, patient.UniqueCitizensidentityNumber, patient.DateOfBirth, patient.PhoneNumber)
        {
            MedicalIdNumber = patient.MedicalIdNumber;
            IsVerified = true;
            Allergie = patient.Allergie;
            City = patient.City;
            Guest = patient.Guest;
            Email = patient.Email;
            Password = patient.Password;
            IsRegisteredBySecretary = patient.IsRegisteredBySecretary;
            Notifications = patient.Notifications;
            IsMarried = patient.IsMarried;
            BornIn = patient.BornIn;
            ParentName = patient.ParentName;
            ExLastname = patient.ExLastname;
            IsBlocked = false;
        }
    }



}