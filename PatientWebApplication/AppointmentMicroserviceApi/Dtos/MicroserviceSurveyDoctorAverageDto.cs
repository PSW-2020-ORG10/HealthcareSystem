namespace AppointmentMicroserviceApi.Dtos
{
    public class MicroserviceSurveyDoctorAverageDto
    {
        public MicroserviceDoctorDto Doctor { get; set; }
        public double DoctorAverage { get; set; }
        public double DoctorsProfessionalismAverage { get; set; }
        public double DoctorsPolitenessAverage { get; set; }
        public double DoctorsTechnicalityAverage { get; set; }
        public double DoctorsSkillAverage { get; set; }
        public double DoctorsKnowledgeAverage { get; set; }
        public double DoctorsWorkingPaceAverage { get; set; }

        public MicroserviceSurveyDoctorAverageDto()
        {
        }

        public MicroserviceSurveyDoctorAverageDto(MicroserviceDoctorDto doctor, double doctorAverage, double doctorsProfessionalismAverage, double doctorsPolitenessAverage, double doctorsTechnicalityAverage, double doctorsSkillAverage, double doctorsKnowledgeAverage, double doctorsWorkingPaceAverage)
        {
            Doctor = doctor;
            DoctorAverage = doctorAverage;
            DoctorsProfessionalismAverage = doctorsProfessionalismAverage;
            DoctorsPolitenessAverage = doctorsPolitenessAverage;
            DoctorsTechnicalityAverage = doctorsTechnicalityAverage;
            DoctorsSkillAverage = doctorsSkillAverage;
            DoctorsKnowledgeAverage = doctorsKnowledgeAverage;
            DoctorsWorkingPaceAverage = doctorsWorkingPaceAverage;
        }
    }
}
