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
        public string medicalIdNumber { get; set; }

        public bool isVerified { get; set; }
        public string allergie { get; set; }
        public string city { get; set; }
        public bool guest { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool isRegisteredBySecretary { get; set; }
        public virtual List<ModelNotification> notifications { get; set; }
        public bool isMarried { get; set; }
        public string bornIn { get; set; }
        public string parentName { get; set; }
        public string exLastname { get; set; }
        public string gender { get; set; }
        public string file { get; set; }

        public bool isBlocked { get; set; }

        public PatientUser() : base()
        {

        }

        public PatientUser(int id, string name, string secondname, string gender, string ucin, string date, string phone, string medicalid, string allergie, string city, bool guest,
            string email, string password, bool isRegisteredBySecretary, List<ModelNotification> notifications, bool isMarried, string bornIn, string parentName, string exLastname, string file)
           : base(id, name, secondname, ucin, date, phone)
        {
            medicalIdNumber = medicalid;
            isVerified = false;
            this.gender = gender;
            this.allergie = allergie;
            this.city = city;
            this.guest = guest;
            this.email = email;
            this.password = password;
            this.isRegisteredBySecretary = isRegisteredBySecretary;
            this.notifications = notifications;
            this.isMarried = isMarried;
            this.bornIn = bornIn;
            this.parentName = parentName;
            this.exLastname = exLastname;
            this.file = file;
            isBlocked = false;
        }
        public PatientUser(int id, string name, string secondname, string gender, string ucin, string date, string phone, string medicalid, string allergie, string city, bool guest,
            string email, string password, bool isMarried, string bornIn, string parentName, string file)
           : base(id, name, secondname, ucin, date, phone)
        {
            medicalIdNumber = medicalid;
            isVerified = false;
            this.gender = gender;
            this.allergie = allergie;
            this.city = city;
            this.guest = guest;
            this.email = email;
            this.password = password;
            isRegisteredBySecretary = isRegisteredBySecretary;
            notifications = notifications;
            this.isMarried = isMarried;
            this.bornIn = bornIn;
            this.parentName = parentName;
            exLastname = "";
            this.file = file;
            isBlocked = false;
        }



        public PatientUser(string name, string secondname, string gender, string ucin, string date, string phone, string allergie, string city, bool guest,
             string email, string password, bool isRegisteredBySecretary, List<ModelNotification> notifications, bool isMarried, string bornIn, string parentName, string exLastname, string file)
            : base(name, secondname, ucin, date, phone)
        {

            this.gender = gender;
            isVerified = false;
            this.allergie = allergie;
            this.city = city;
            this.guest = guest;
            this.email = email;
            this.password = password;
            this.isRegisteredBySecretary = isRegisteredBySecretary;
            this.notifications = notifications;
            this.isMarried = isMarried;
            this.bornIn = bornIn;
            this.parentName = parentName;
            this.exLastname = exLastname;
            this.file = file;
            isBlocked = false;
        }
        public PatientUser(string name, string secondname, string gender, string ucin, string date, string phone, string allergie, string city, bool guest,
           string email, string password, bool isMarried, string bornIn, string parentName, string file)
          : base(name, secondname, ucin, date, phone)
        {

            isVerified = false;
            this.gender = gender;
            this.allergie = allergie;
            this.city = city;
            this.guest = guest;
            this.email = email;
            this.password = password;
            isRegisteredBySecretary = isRegisteredBySecretary;
            notifications = notifications;
            this.isMarried = isMarried;
            this.bornIn = bornIn;
            this.parentName = parentName;
            exLastname = "";
            this.file = file;
            isBlocked = false;
        }

        public PatientUser(PatientUser patient)
           : base(patient.id, patient.firstName, patient.secondName, patient.uniqueCitizensidentityNumber, patient.dateOfBirth, patient.phoneNumber)
        {
            medicalIdNumber = patient.medicalIdNumber;
            isVerified = true;
            allergie = patient.allergie;
            city = patient.city;
            guest = patient.guest;
            email = patient.email;
            password = patient.password;
            isRegisteredBySecretary = patient.isRegisteredBySecretary;
            notifications = patient.notifications;
            isMarried = patient.isMarried;
            bornIn = patient.bornIn;
            parentName = patient.parentName;
            exLastname = patient.exLastname;
            isBlocked = false;
        }
    }



}