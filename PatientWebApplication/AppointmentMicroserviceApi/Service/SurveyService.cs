using System.Collections.Generic;
using System.Linq;
using AppointmentMicroserviceApi.Repository;
using AppointmentMicroserviceApi.Patient;
using AppointmentMicroserviceApi.Adapters;
using AppointmentMicroserviceApi.Dtos;

namespace AppointmentMicroserviceApi.Service
{
    /// <summary>Class <c>FeedbackService</c> handles feedback business logic.
    /// </summary>
    public class SurveyService : ISurveyService
    {
        /// <value>Property <c>ISurveyRepository</c> represents the interface of repository used for data access.</value>
        private ISurveyRepository SurveyRepository { get; set; }

        /// <summary>This constructor injects the SurveyService with matching ISurveyRepository.</summary>
        public SurveyService(ISurveyRepository surveyRepository)
        {
            SurveyRepository = surveyRepository;
        }

        /// <summary> This method converts <paramref name="surveyDto"/> to <c>Survey</c> using <c>SurveyAdapter</c> and sends it to <c>SurveyRepository</c>. </summary>
        /// <returns>if survey exists returns successfully created survey; otherwise, return <c>null</c></returns>
        public Survey Create(SurveyDto surveyDto)
        {
            return SurveyRepository.Add(SurveyAdapter.SurveyDtoToSurvey(surveyDto));
        }

        /// <summary> This method is calling <c>SurveyRepository</c> to get list of all <c>Survey</c> that were created by patient with id <paramref name="id"/>. </summary>
        /// <returns> List of all surveys for that patient. </returns>
        public List<Survey> GetAllSurveysForPatientId(int id)
        {
            return SurveyRepository.GetAllSurveysForPatientId(id);
        }

        /// <summary> This method is calling <c>SurveyRepository</c> to get list of all<c>Survey</c>. </summary>
        /// <returns> List of all surveys. </returns>
        public List<Survey> GetAll()
        {
            return SurveyRepository.GetAll();
        }

        /// <summary> This method is calling <c>SurveyRepository</c> to get list of all <c>Survey</c> that were created by patient with id <paramref name="id"/>. </summary>
        /// <returns> List of all surveys for that patient. </returns>
        public List<MicroserviceSurveyDoctorAverageDto> GetAllDoctorAverageRates()
        {
            List<MicroserviceSurveyDoctorAverageDto> surveyDoctorAverage = new List<MicroserviceSurveyDoctorAverageDto>();
            foreach (int id in FindAllRatedDoctorsIds())
            {
                surveyDoctorAverage.Add(CountForSprecificDoctorAverage(id));
            }

            return surveyDoctorAverage;
        }

        /// <summary> This method is creating <c>SurveyAverageDto</c> with all informations from surveys. </summary>
        /// <returns> Created <c>SurveyAverageDto</c>. </returns>
        public SurveyAverageDto GetAllAverageRates()
        {
            return new SurveyAverageDto(CountDoctorAverage()[0], CountMedicalStaffAverage()[0], CountHospitalAverage()[0], CountDoctorAverage()[3], CountDoctorAverage()[2], CountDoctorAverage()[5], CountDoctorAverage()[4], CountDoctorAverage()[1], CountDoctorAverage()[6], CountMedicalStaffAverage()[3], CountMedicalStaffAverage()[2], CountMedicalStaffAverage()[5], CountMedicalStaffAverage()[4], CountMedicalStaffAverage()[1], CountMedicalStaffAverage()[6], CountHospitalAverage()[1], CountHospitalAverage()[2], CountHospitalAverage()[3], CountHospitalAverage()[4], CountHospitalAverage()[5]);
        }

        private List<double> CountDoctorAverage()
        {
            double doctorAvg = 0, doctorsKnowledgeAvg = 0, doctorsPolitenessAvg = 0, doctorsProfessionalismAvg = 0, doctorsSkillAvg = 0, doctorsTechnicalityAvg = 0, doctorsWorkingPaceAvg = 0;
            foreach (Survey s in GetAll())
            {
                doctorAvg += s.DoctorsKnowledge + s.DoctorsPoliteness + s.DoctorsProfessionalism + s.DoctorsSkill + s.DoctorsTechnicality + s.DoctorsWorkingPace;
                doctorsKnowledgeAvg += s.DoctorsKnowledge;
                doctorsPolitenessAvg += s.DoctorsPoliteness;
                doctorsProfessionalismAvg += s.DoctorsProfessionalism;
                doctorsSkillAvg += s.DoctorsSkill;
                doctorsTechnicalityAvg += s.DoctorsTechnicality;
                doctorsWorkingPaceAvg += s.DoctorsWorkingPace;
            }
            return CountAverage(doctorAvg, doctorsKnowledgeAvg, doctorsPolitenessAvg, doctorsProfessionalismAvg, doctorsSkillAvg, doctorsTechnicalityAvg, doctorsWorkingPaceAvg);
        }

        private List<double> CountMedicalStaffAverage()
        {
            double medicalStaffAvg = 0, medicalStaffKnowledgeAvg = 0, medicalStaffPolitenessAvg = 0, medicalStaffProfessionalismAvg = 0, medicalStaffSkillAvg = 0, medicalStaffTechnicalityAvg = 0, medicalStaffWorkingPaceAvg = 0;
            foreach (Survey s in GetAll())
            {
                medicalStaffAvg += s.MedicalStaffsKnowledge + s.MedicalStaffsPoliteness + s.MedicalStaffsProfessionalism + s.MedicalStaffsSkill + s.MedicalStaffsTechnicality + s.MedicalStaffsWorkingPace;
                medicalStaffKnowledgeAvg += s.MedicalStaffsKnowledge;
                medicalStaffPolitenessAvg += s.MedicalStaffsPoliteness;
                medicalStaffProfessionalismAvg += s.MedicalStaffsProfessionalism;
                medicalStaffSkillAvg += s.MedicalStaffsSkill;
                medicalStaffTechnicalityAvg += s.MedicalStaffsTechnicality;
                medicalStaffWorkingPaceAvg += s.MedicalStaffsWorkingPace;
            }
            return CountAverage(medicalStaffAvg, medicalStaffKnowledgeAvg, medicalStaffPolitenessAvg, medicalStaffProfessionalismAvg, medicalStaffSkillAvg, medicalStaffTechnicalityAvg, medicalStaffWorkingPaceAvg);
        }

        private List<double> CountHospitalAverage()
        {
            double hospitalAvg = 0, hospitalEnvironmentAvg = 0, hospitalEquipmentAvg = 0, hospitalHygieneAvg = 0, hospitalPricesAvg = 0, hospitalWaitingTimeAvg = 0;
            foreach (Survey s in GetAll())
            {
                hospitalAvg += s.HospitalEnvironment + s.HospitalEquipment + s.HospitalHygiene + s.HospitalPrices + s.HospitalWaitingTime;
                hospitalEnvironmentAvg += s.HospitalEnvironment;
                hospitalEquipmentAvg += s.HospitalEquipment;
                hospitalHygieneAvg += s.HospitalHygiene;
                hospitalPricesAvg += s.HospitalPrices;
                hospitalWaitingTimeAvg += s.HospitalWaitingTime;
            }
            return CountAverageHospital(hospitalAvg, hospitalEnvironmentAvg, hospitalEquipmentAvg, hospitalHygieneAvg, hospitalPricesAvg, hospitalWaitingTimeAvg);
        }

        private List<double> CountAverage(double average, double average2, double average3, double average4, double average5, double average6, double average7)
        {
            List<double> doctorInfo = new List<double>();
            doctorInfo.Add(average / (GetAll().Count * 6));
            doctorInfo.Add(average2 / GetAll().Count);
            doctorInfo.Add(average3 / GetAll().Count);
            doctorInfo.Add(average4 / GetAll().Count);
            doctorInfo.Add(average5 / GetAll().Count);
            doctorInfo.Add(average6 / GetAll().Count);
            doctorInfo.Add(average7 / GetAll().Count);
            return doctorInfo;
        }

        private List<double> CountAverageHospital(double average, double average2, double average3, double average4, double average5, double average6)
        {
            List<double> doctorInfo = new List<double>();
            doctorInfo.Add(average / (GetAll().Count * 5));
            doctorInfo.Add(average2 / GetAll().Count);
            doctorInfo.Add(average3 / GetAll().Count);
            doctorInfo.Add(average4 / GetAll().Count);
            doctorInfo.Add(average5 / GetAll().Count);
            doctorInfo.Add(average6 / GetAll().Count);
            return doctorInfo;
        }

        private MicroserviceSurveyDoctorAverageDto CountAverageSingleDoctor(MicroserviceSurveyDoctorAverageDto surveyDoctorAverage, int counter, double average, double average2, double average3, double average4, double average5, double average6, double average7)
        {
            surveyDoctorAverage.DoctorAverage = average / (counter * 6);
            surveyDoctorAverage.DoctorsKnowledgeAverage = average2 / counter;
            surveyDoctorAverage.DoctorsPolitenessAverage = average3 / counter;
            surveyDoctorAverage.DoctorsProfessionalismAverage = average4 / counter;
            surveyDoctorAverage.DoctorsSkillAverage = average5 / counter;
            surveyDoctorAverage.DoctorsTechnicalityAverage = average6 / counter;
            surveyDoctorAverage.DoctorsWorkingPaceAverage = average7 / counter;
            return surveyDoctorAverage;
        }

        private MicroserviceSurveyDoctorAverageDto CountForSprecificDoctorAverage(int id)
        {
            MicroserviceSurveyDoctorAverageDto surveyDoctorAverage = new MicroserviceSurveyDoctorAverageDto();
            double doctorAvg = 0, doctorsKnowledgeAvg = 0, doctorsPolitenessAvg = 0, doctorsProfessionalismAvg = 0, doctorsSkillAvg = 0, doctorsTechnicalityAvg = 0, doctorsWorkingPaceAvg = 0;
            int counter = 0;
            foreach (Survey s in GetAll())
            {
                if (s.Appointment.DoctorUserId == id)
                {
                    counter += 1;
                    surveyDoctorAverage.Doctor = Utility.HttpRequests.GetDoctorByIdAsync(s.Appointment.DoctorUserId).Result;
                    doctorAvg += s.DoctorsKnowledge + s.DoctorsPoliteness + s.DoctorsProfessionalism + s.DoctorsSkill + s.DoctorsTechnicality + s.DoctorsWorkingPace;
                    doctorsKnowledgeAvg += s.DoctorsKnowledge;
                    doctorsPolitenessAvg += s.DoctorsPoliteness;
                    doctorsProfessionalismAvg += s.DoctorsProfessionalism;
                    doctorsSkillAvg += s.DoctorsSkill;
                    doctorsTechnicalityAvg += s.DoctorsTechnicality;
                    doctorsWorkingPaceAvg += s.DoctorsWorkingPace;
                }
            }
            return CountAverageSingleDoctor(surveyDoctorAverage, counter, doctorAvg, doctorsKnowledgeAvg, doctorsPolitenessAvg, doctorsProfessionalismAvg, doctorsSkillAvg, doctorsTechnicalityAvg, doctorsWorkingPaceAvg);
        }

        private List<int> FindAllRatedDoctorsIds()
        {
            List<int> doctors = new List<int>();
            foreach (Survey s in GetAll())
            {
                doctors.Add(s.Appointment.DoctorUserId);
            }
            return doctors.Distinct().ToList();
        }
    }
}
