using Class_diagram.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class_diagram.Model.Patient
{ 
    public class PatientUserWeb : User
    {
        public String medicalIdNumber { get; set; }

        public String allergie { get; set; }
        public String city { get; set; }
        public Boolean guest { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public Boolean isRegisteredBySecretary { get; set; }

        public PatientUserWeb() : base()
        {

        }

        public PatientUserWeb(int id, string name, string secondname, string ucin, String date, string phone, String medicalid, String allergie, String city, Boolean guest,
            String email, String password, Boolean isRegisteredBySecretary)
           : base(id, name, secondname, ucin, date, phone)
        {
            this.medicalIdNumber = medicalid;

            this.allergie = allergie;
            this.city = city;
            this.guest = guest;
            this.email = email;
            this.password = password;
            this.isRegisteredBySecretary = isRegisteredBySecretary;
        }


    }
}