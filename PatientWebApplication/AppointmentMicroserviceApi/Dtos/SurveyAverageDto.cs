using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentMicroserviceApi.Dtos
{
    public class SurveyAverageDto
    {
        public double DoctorAverage { get; set; }
        public double MedicalStaffAverage { get; set; }
        public double HospitalAverage { get; set; }
        public double DoctorsProfessionalismAverage { get; set; }
        public double DoctorsPolitenessAverage { get; set; }
        public double DoctorsTechnicalityAverage { get; set; }
        public double DoctorsSkillAverage { get; set; }
        public double DoctorsKnowledgeAverage { get; set; }
        public double DoctorsWorkingPaceAverage { get; set; }
        public double MedicalStaffsProfessionalismAverage { get; set; }
        public double MedicalStaffsPolitenessAverage { get; set; }
        public double MedicalStaffsTechnicalityAverage { get; set; }
        public double MedicalStaffsSkillAverage { get; set; }
        public double MedicalStaffsKnowledgeAverage { get; set; }
        public double MedicalStaffsWorkingPaceAverage { get; set; }
        public double HospitalEnvironmentAverage { get; set; }
        public double HospitalEquipmentAverage { get; set; }
        public double HospitalHygieneAverage { get; set; }
        public double HospitalPricesAverage { get; set; }
        public double HospitalWaitingTimeAverage { get; set; }

        public SurveyAverageDto()
        {
        }

        public SurveyAverageDto(double doctorAverage, double medicalStaffAverage, double hospitalAverage, double doctorsProfessionalismAverage, double doctorsPolitenessAverage, double doctorsTechnicalityAverage, double doctorsSkillAverage, double doctorsKnowledgeAverage, double doctorsWorkingPaceAverage, double medicalStaffsProfessionalismAverage, double medicalStaffsPolitenessAverage, double medicalStaffsTechnicalityAverage, double medicalStaffsSkillAverage, double medicalStaffsKnowledgeAverage, double medicalStaffsWorkingPaceAverage, double hospitalEnvironmentAverage, double hospitalEquipmentAverage, double hospitalHygieneAverage, double hospitalPricesAverage, double hospitalWaitingTimeAverage)
        {
            DoctorAverage = doctorAverage;
            MedicalStaffAverage = medicalStaffAverage;
            HospitalAverage = hospitalAverage;
            DoctorsProfessionalismAverage = doctorsProfessionalismAverage;
            DoctorsPolitenessAverage = doctorsPolitenessAverage;
            DoctorsTechnicalityAverage = doctorsTechnicalityAverage;
            DoctorsSkillAverage = doctorsSkillAverage;
            DoctorsKnowledgeAverage = doctorsKnowledgeAverage;
            DoctorsWorkingPaceAverage = doctorsWorkingPaceAverage;
            MedicalStaffsProfessionalismAverage = medicalStaffsProfessionalismAverage;
            MedicalStaffsPolitenessAverage = medicalStaffsPolitenessAverage;
            MedicalStaffsTechnicalityAverage = medicalStaffsTechnicalityAverage;
            MedicalStaffsSkillAverage = medicalStaffsSkillAverage;
            MedicalStaffsKnowledgeAverage = medicalStaffsKnowledgeAverage;
            MedicalStaffsWorkingPaceAverage = medicalStaffsWorkingPaceAverage;
            HospitalEnvironmentAverage = hospitalEnvironmentAverage;
            HospitalEquipmentAverage = hospitalEquipmentAverage;
            HospitalHygieneAverage = hospitalHygieneAverage;
            HospitalPricesAverage = hospitalPricesAverage;
            HospitalWaitingTimeAverage = hospitalWaitingTimeAverage;
        }
    }
}
