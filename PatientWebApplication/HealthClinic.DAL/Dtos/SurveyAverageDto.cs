using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class SurveyAverageDto
    {
        public Double DoctorAverage { get; set; }
        public Double MedicalStaffAverage { get; set; }
        public Double HospitalAverage { get; set; }
        public Double DoctorsProfessionalismAverage { get; set; }
        public Double DoctorsPolitenessAverage { get; set; }
        public Double DoctorsTechnicalityAverage { get; set; }
        public Double DoctorsSkillAverage { get; set; }
        public Double DoctorsKnowledgeAverage { get; set; }
        public Double DoctorsWorkingPaceAverage { get; set; }
        public Double MedicalStaffsProfessionalismAverage { get; set; }
        public Double MedicalStaffsPolitenessAverage { get; set; }
        public Double MedicalStaffsTechnicalityAverage { get; set; }
        public Double MedicalStaffsSkillAverage { get; set; }
        public Double MedicalStaffsKnowledgeAverage { get; set; }
        public Double MedicalStaffsWorkingPaceAverage { get; set; }
        public Double HospitalEnvironmentAverage { get; set; }
        public Double HospitalEquipmentAverage { get; set; }
        public Double HospitalHygieneAverage { get; set; }
        public Double HospitalPricesAverage { get; set; }
        public Double HospitalWaitingTimeAverage { get; set; }

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
