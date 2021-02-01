using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentMicroserviceApi.Dtos
{
    public class SurveyDto
    {
        public int PatientId { get; set; }
        public int AppointmentId { get; set; }
        public int DoctorsProfessionalism { get; set; }
        public int DoctorsPoliteness { get; set; }
        public int DoctorsTechnicality { get; set; }
        public int DoctorsSkill { get; set; }
        public int DoctorsKnowledge { get; set; }
        public int DoctorsWorkingPace { get; set; }
        public int MedicalStaffsProfessionalism { get; set; }
        public int MedicalStaffsPoliteness { get; set; }
        public int MedicalStaffsTechnicality { get; set; }
        public int MedicalStaffsSkill { get; set; }
        public int MedicalStaffsKnowledge { get; set; }
        public int MedicalStaffsWorkingPace { get; set; }
        public int HospitalEnvironment { get; set; }
        public int HospitalEquipment { get; set; }
        public int HospitalHygiene { get; set; }
        public int HospitalPrices { get; set; }
        public int HospitalWaitingTime { get; set; }

        public SurveyDto() : base()
        {

        }

        public SurveyDto(int patientId, int appointmentId, int doctorsProfessionalism, int doctorsPoliteness, int doctorsTechnicality, int doctorsSkill, int doctorsKnowledge, int doctorsWorkingPace, int medicalStaffsProfessionalism, int medicalStaffsPoliteness, int medicalStaffsTechnicality, int medicalStaffsSkill, int medicalStaffsKnowledge, int medicalStaffsWorkingPace, int hospitalEnvironment, int hospitalEquipment, int hospitalHygiene, int hospitalPrices, int hospitalWaitingTime) : base()
        {
            PatientId = patientId;
            AppointmentId = appointmentId;
            DoctorsProfessionalism = doctorsProfessionalism;
            DoctorsPoliteness = doctorsPoliteness;
            DoctorsTechnicality = doctorsTechnicality;
            DoctorsSkill = doctorsSkill;
            DoctorsKnowledge = doctorsKnowledge;
            DoctorsWorkingPace = doctorsWorkingPace;
            MedicalStaffsProfessionalism = medicalStaffsProfessionalism;
            MedicalStaffsPoliteness = medicalStaffsPoliteness;
            MedicalStaffsTechnicality = medicalStaffsTechnicality;
            MedicalStaffsSkill = medicalStaffsSkill;
            MedicalStaffsKnowledge = medicalStaffsKnowledge;
            MedicalStaffsWorkingPace = medicalStaffsWorkingPace;
            HospitalEnvironment = hospitalEnvironment;
            HospitalEquipment = hospitalEquipment;
            HospitalHygiene = hospitalHygiene;
            HospitalPrices = hospitalPrices;
            HospitalWaitingTime = hospitalWaitingTime;
        }
    }
}
