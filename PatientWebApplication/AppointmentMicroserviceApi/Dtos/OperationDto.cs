using AppointmentMicroserviceApi.Doctor;

namespace AppointmentMicroserviceApi.Dtos
{
    public class OperationDto
    {
        public string DoctorNameAndSurname { get; set; }
        public OperationReferral OperationReferral { get; set; }
        public string Date { get; set; }

        public OperationDto(string doctorNameAndSurname, OperationReferral referral, string date)
        {
            DoctorNameAndSurname = doctorNameAndSurname;
            OperationReferral = referral;
            Date = date;
        }
    }
}
