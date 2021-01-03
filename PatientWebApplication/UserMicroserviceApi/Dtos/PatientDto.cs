using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Dtos
{
    public class PatientDto : User
    {

        public string medicalIdNumber { get; set; }
        public bool isVerified { get; set; }
        public string allergie { get; set; }
        public string city { get; set; }
        public bool guest { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool isMarried { get; set; }
        public string bornIn { get; set; }
        public string parentName { get; set; }
        public string exLastname { get; set; }
        public string file { get; set; }
        public string gender { get; set; }

        public PatientDto()
        {
        }

        public PatientDto(string name, string secondname, string gender, string ucin, string date, string phone, string medicalid, string allergie, string city, string email, string password, bool isMarried, string bornIn, string parentName, string exLastname, string file) : base(name, secondname, ucin, date, phone)
        {

            medicalIdNumber = medicalid;
            this.gender = gender;
            isVerified = false;
            this.allergie = allergie;
            this.city = city;
            this.email = email;
            this.password = password;
            this.isMarried = isMarried;
            this.bornIn = bornIn;
            this.parentName = parentName;
            this.exLastname = exLastname;
            this.file = file;
        }

        public PatientDto(string name, string secondname, string gender, string ucin, string date, string phone, string medicalid, string allergie, string city, string email, string password, bool isMarried, string bornIn, string parentName, string file) : base(name, secondname, ucin, date, phone)
        {
            medicalIdNumber = medicalid;
            isVerified = false;
            this.gender = gender;
            this.allergie = allergie;
            this.city = city;
            this.email = email;
            this.password = password;
            this.isMarried = isMarried;
            this.bornIn = bornIn;
            this.parentName = parentName;
            exLastname = "";
            this.file = file;

        }
    }
}
