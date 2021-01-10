using AppointmentMicroserviceApi.Dtos;
using AppointmentMicroserviceApi.Patient;

namespace AppointmentMicroserviceApi.Adapters
{
    public class SurveyAdapter
    {
        public static Survey SurveyDtoToSurvey(SurveyDto dto)
        {
            return new Survey(dto.PatientId, dto.AppointmentId, dto.DoctorsProfessionalism, dto.DoctorsPoliteness, dto.DoctorsTechnicality, dto.DoctorsSkill, dto.DoctorsKnowledge, dto.DoctorsWorkingPace, dto.MedicalStaffsProfessionalism, dto.MedicalStaffsPoliteness, dto.MedicalStaffsTechnicality, dto.MedicalStaffsSkill, dto.MedicalStaffsKnowledge, dto.MedicalStaffsWorkingPace, dto.HospitalEnvironment, dto.HospitalEquipment, dto.HospitalHygiene, dto.HospitalPrices, dto.HospitalWaitingTime);
        }
    }
}
