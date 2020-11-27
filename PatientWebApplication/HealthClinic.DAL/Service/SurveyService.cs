using HealthClinic.CL.Adapters;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinic.CL.Utility;
using System.Text;

namespace HealthClinic.CL.Service
{
    public class SurveyService : ISurveyService
    {
        private ISurveyRepository SurveyRepository { get; set; }

        public SurveyService(ISurveyRepository surveyRepository)
        {
            SurveyRepository = surveyRepository;           
        }

        public Survey Create(SurveyDto surveyDto)
        {                   
            return SurveyRepository.Add(SurveyAdapter.SurveyDtoToSurvey(surveyDto));
        }

        public List<Survey> GetAllSurveysForPatientId(int id)
        {
            return SurveyRepository.GetAllSurveysForPatientId(id);
        }

        public List<Survey> GetAll()
        {
            return SurveyRepository.GetAll();
        }

        public List<SurveyDoctorAverageDto> GetAllDoctorAverageRates(List<Survey> surveys)
        {
            List<SurveyDoctorAverageDto> surveyDoctorAverage = new List<SurveyDoctorAverageDto>();
            foreach(int id in FindAllRatedDoctorsIds(surveys))
            {
                surveyDoctorAverage.Add(CountForSprecificDoctorAverage(id));
            }
            
            return surveyDoctorAverage;
        }

        private SurveyDoctorAverageDto CountForSprecificDoctorAverage(int id)
        {
            SurveyDoctorAverageDto surveyDoctorAverage = new SurveyDoctorAverageDto();
            Double doctorAvg = 0;
            Double doctorsKnowledgeAvg = 0;
            Double doctorsPolitenessAvg = 0;
            Double doctorsProfessionalismAvg = 0;
            Double doctorsSkillAvg = 0;
            Double doctorsTechnicalityAvg = 0;
            Double doctorsWorkingPaceAvg = 0;
            int counter = 0;
            foreach (Survey s in GetAll())
            {
                if(s.appointment.DoctorUserId == id)
                {
                    counter += 1;
                    surveyDoctorAverage.Doctor = s.appointment.Doctor;
                    doctorAvg += s.doctorsKnowledge + s.doctorsPoliteness + s.doctorsProfessionalism + s.doctorsSkill + s.doctorsTechnicality + s.doctorsWorkingPace;
                    doctorsKnowledgeAvg += s.doctorsKnowledge;
                    doctorsPolitenessAvg += s.doctorsPoliteness;
                    doctorsProfessionalismAvg += s.doctorsProfessionalism;
                    doctorsSkillAvg += s.doctorsSkill;
                    doctorsTechnicalityAvg += s.doctorsTechnicality;
                    doctorsWorkingPaceAvg += s.doctorsWorkingPace;
                }
            }
            surveyDoctorAverage.DoctorAverage = doctorAvg / (counter * 5);
            surveyDoctorAverage.DoctorsKnowledgeAverage = doctorsKnowledgeAvg / counter;
            surveyDoctorAverage.DoctorsPolitenessAverage = doctorsPolitenessAvg / counter;
            surveyDoctorAverage.DoctorsProfessionalismAverage = doctorsProfessionalismAvg / counter;
            surveyDoctorAverage.DoctorsSkillAverage = doctorsSkillAvg / counter;
            surveyDoctorAverage.DoctorsTechnicalityAverage = doctorsTechnicalityAvg / counter;
            surveyDoctorAverage.DoctorsWorkingPaceAverage = doctorsWorkingPaceAvg / counter;
            return surveyDoctorAverage;
        }

        private List<int> FindAllRatedDoctorsIds(List<Survey> surveys)
        {
            List<int> doctors = new List<int>();
            foreach(Survey s in surveys)
            {
                doctors.Add(s.appointment.DoctorUserId);
            }
            return doctors.Distinct().ToList(); 
        }
        public SurveyAverageDto GetAllAverageRates(List<Survey> surveys)
        {
            SurveyAverageDto surveyAverage = new SurveyAverageDto();
            surveyAverage.DoctorAverage = CountDoctorAverage(surveys)[0];
            surveyAverage.DoctorsKnowledgeAverage = CountDoctorAverage(surveys)[1];
            surveyAverage.DoctorsPolitenessAverage = CountDoctorAverage(surveys)[2];
            surveyAverage.DoctorsProfessionalismAverage = CountDoctorAverage(surveys)[3];
            surveyAverage.DoctorsSkillAverage = CountDoctorAverage(surveys)[4];
            surveyAverage.DoctorsTechnicalityAverage = CountDoctorAverage(surveys)[5];
            surveyAverage.DoctorsWorkingPaceAverage = CountDoctorAverage(surveys)[6];

            surveyAverage.MedicalStaffAverage = CountMedicalStaffAverage(surveys)[0];
            surveyAverage.MedicalStaffsKnowledgeAverage = CountMedicalStaffAverage(surveys)[1];
            surveyAverage.MedicalStaffsPolitenessAverage = CountMedicalStaffAverage(surveys)[2];
            surveyAverage.MedicalStaffsProfessionalismAverage = CountMedicalStaffAverage(surveys)[3];
            surveyAverage.MedicalStaffsSkillAverage = CountMedicalStaffAverage(surveys)[4];
            surveyAverage.MedicalStaffsTechnicalityAverage = CountMedicalStaffAverage(surveys)[5];
            surveyAverage.MedicalStaffsWorkingPaceAverage = CountMedicalStaffAverage(surveys)[6];

            surveyAverage.HospitalAverage = CountHospitalAverage(surveys)[0];
            surveyAverage.HospitalEnvironmentAverage = CountHospitalAverage(surveys)[1];
            surveyAverage.HospitalEquipmentAverage = CountHospitalAverage(surveys)[2];
            surveyAverage.HospitalHygieneAverage = CountHospitalAverage(surveys)[3];
            surveyAverage.HospitalPricesAverage = CountHospitalAverage(surveys)[4];
            surveyAverage.HospitalWaitingTimeAverage = CountHospitalAverage(surveys)[5];

            return surveyAverage;  
        }
       
        private List<double> CountDoctorAverage(List<Survey> surveys)
        {
            List<Double> doctorInfo = new List<double>();
            Double doctorAvg = 0;
            Double doctorsKnowledgeAvg = 0;
            Double doctorsPolitenessAvg = 0;
            Double doctorsProfessionalismAvg = 0;
            Double doctorsSkillAvg = 0;
            Double doctorsTechnicalityAvg = 0;
            Double doctorsWorkingPaceAvg = 0;
            foreach (Survey s in surveys)
            {
                doctorAvg += s.doctorsKnowledge + s.doctorsPoliteness + s.doctorsProfessionalism + s.doctorsSkill + s.doctorsTechnicality + s.doctorsWorkingPace;
                doctorsKnowledgeAvg += s.doctorsKnowledge;
                doctorsPolitenessAvg += s.doctorsPoliteness;
                doctorsProfessionalismAvg += s.doctorsProfessionalism;               
                doctorsSkillAvg += s.doctorsSkill;
                doctorsTechnicalityAvg += s.doctorsTechnicality;
                doctorsWorkingPaceAvg += s.doctorsWorkingPace;
            }
            doctorInfo.Add(doctorAvg / (surveys.Count * 5));
            doctorInfo.Add(doctorsKnowledgeAvg / surveys.Count);
            doctorInfo.Add(doctorsPolitenessAvg / surveys.Count);
            doctorInfo.Add(doctorsProfessionalismAvg / surveys.Count);
            doctorInfo.Add(doctorsSkillAvg / surveys.Count);
            doctorInfo.Add(doctorsTechnicalityAvg / surveys.Count);
            doctorInfo.Add(doctorsWorkingPaceAvg / surveys.Count);
            return doctorInfo;
        }

        private List<double> CountMedicalStaffAverage(List<Survey> surveys)
        {
            List<Double> medicalStaffInfo = new List<double>();
            Double medicalStaffAvg = 0;
            Double medicalStaffKnowledgeAvg = 0;
            Double medicalStaffPolitenessAvg = 0;
            Double medicalStaffProfessionalismAvg = 0;
            Double medicalStaffSkillAvg = 0;
            Double medicalStaffTechnicalityAvg = 0;
            Double medicalStaffWorkingPaceAvg = 0;
            foreach (Survey s in surveys)
            {
                medicalStaffAvg += s.medicalStaffsKnowledge + s.medicalStaffsPoliteness + s.medicalStaffsProfessionalism + s.medicalStaffsSkill + s.medicalStaffsTechnicality + s.medicalStaffsWorkingPace;
                medicalStaffKnowledgeAvg += s.medicalStaffsKnowledge;
                medicalStaffPolitenessAvg += s.medicalStaffsPoliteness;
                medicalStaffProfessionalismAvg += s.medicalStaffsProfessionalism;
                medicalStaffSkillAvg += s.medicalStaffsSkill;
                medicalStaffTechnicalityAvg += s.medicalStaffsTechnicality;
                medicalStaffWorkingPaceAvg += s.medicalStaffsWorkingPace;
            }
            medicalStaffInfo.Add(medicalStaffAvg / (surveys.Count * 5));
            medicalStaffInfo.Add(medicalStaffKnowledgeAvg / surveys.Count);
            medicalStaffInfo.Add(medicalStaffPolitenessAvg / surveys.Count);
            medicalStaffInfo.Add(medicalStaffProfessionalismAvg / surveys.Count);
            medicalStaffInfo.Add(medicalStaffSkillAvg / surveys.Count);
            medicalStaffInfo.Add(medicalStaffTechnicalityAvg / surveys.Count);
            medicalStaffInfo.Add(medicalStaffWorkingPaceAvg / surveys.Count);
            return medicalStaffInfo;
        }

        private List<double> CountHospitalAverage(List<Survey> surveys)
        {
            List<Double> hospitalInfo = new List<double>();
            Double hospitalAvg = 0;
            Double hospitalEnvironmentAvg = 0;
            Double hospitalEquipmentAvg = 0;
            Double hospitalHygieneAvg = 0;
            Double hospitalPricesAvg = 0;
            Double hospitalWaitingTimeAvg = 0;         
            foreach (Survey s in surveys)
            {
                hospitalAvg += s.hospitalEnvironment + s.hospitalEquipment + s.hospitalHygiene + s.hospitalPrices + s.hospitalWaitingTime;
                hospitalEnvironmentAvg += s.hospitalEnvironment;
                hospitalEquipmentAvg += s.hospitalEquipment;
                hospitalHygieneAvg += s.hospitalHygiene;
                hospitalPricesAvg += s.hospitalPrices;
                hospitalWaitingTimeAvg += s.hospitalWaitingTime;
            }
            hospitalInfo.Add(hospitalAvg / (surveys.Count * 5));
            hospitalInfo.Add(hospitalEnvironmentAvg / surveys.Count);
            hospitalInfo.Add(hospitalEquipmentAvg / surveys.Count);
            hospitalInfo.Add(hospitalHygieneAvg / surveys.Count);
            hospitalInfo.Add(hospitalPricesAvg / surveys.Count);
            hospitalInfo.Add(hospitalWaitingTimeAvg / surveys.Count);
            return hospitalInfo;
        }      
    }
}
