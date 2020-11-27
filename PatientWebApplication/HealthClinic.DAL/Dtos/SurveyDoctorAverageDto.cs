using HealthClinic.CL.Model.Doctor;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class SurveyDoctorAverageDto
    {
        public DoctorUser Doctor { get; set; }
        public Double DoctorAverage { get; set; }
        public Double DoctorsProfessionalismAverage { get; set; }
        public Double DoctorsPolitenessAverage { get; set; }
        public Double DoctorsTechnicalityAverage { get; set; }
        public Double DoctorsSkillAverage { get; set; }
        public Double DoctorsKnowledgeAverage { get; set; }
        public Double DoctorsWorkingPaceAverage { get; set; }

        public SurveyDoctorAverageDto()
        {
        }

        public SurveyDoctorAverageDto(DoctorUser doctor, double doctorAverage, double doctorsProfessionalismAverage, double doctorsPolitenessAverage, double doctorsTechnicalityAverage, double doctorsSkillAverage, double doctorsKnowledgeAverage, double doctorsWorkingPaceAverage)
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
