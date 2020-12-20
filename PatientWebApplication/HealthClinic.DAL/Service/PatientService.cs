/***********************************************************************
 * Module:  PatientService.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using HealthClinic.CL.Adapters;
using HealthClinic.CL.Contoller;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace HealthClinic.CL.Service
{
    /// <summary>Class <c>PatientService</c> handles feedback business logic.
    /// </summary>
    public class PatientService : IPatientService
    {
        private RegularAppointmentService _regularAppointmentService { get; set; }
        /// <value>Property <c>IPatientsRepository</c> represents the interface of repository used for data access.</value>
        private IPatientsRepository PatientsRepository { get; set; }
        private IEmailVerificationService EmailVerificationService { get; set; }

        /// <summary>This constructor injects the PatientService with matching IPatientsRepository.</summary>
        public PatientService(IPatientsRepository patientsRepository, IEmailVerificationService emailVerificationService, RegularAppointmentService regularAppointmentService)
        {
            PatientsRepository = patientsRepository;
            EmailVerificationService = emailVerificationService;
            _regularAppointmentService = regularAppointmentService;
        }
        public PatientService(MyDbContext context)
        {
            PatientsRepository = new PatientsRepository(context);
        }

        /// <summary> This method converts <paramref name="patientDto"/> to <c>PatientUser</c> using <c>PatientAdapter</c> and sends it to <c>PatientsRepository</c>. </summary>
        /// <returns>Returns successfully created patient; otherwise, return <c>null</c></returns>
        public PatientUser Create(PatientDto patientDto)
        {
            PatientUser patient = PatientsRepository.Add(PatientAdapter.PatientDtoToPatient(patientDto));
            EmailVerificationService.SendVerificationMail(new MailAddress(patient.email), patient.id);
            return patient;
        }

        /// <summary> This method is calling <c>PatientsRepository</c> to validate patients account. </summary>
        /// <param name="id"><c>id</c> is id of patient who's account needs to be validated. 
        /// </param>
        /// <returns>if validated patient exists returns successfully validated patient; otherwise, return <c>null</c></returns>
        public PatientUser Validate(int id)
        {
            PatientUser patient = PatientsRepository.Find(id);
            if (patient != null)
            {
                return PatientsRepository.Validate(patient);
            }
            return null;
        }

        /// <summary> This method is calling <c>PatientsRepository</c> to get list of all<c>PatientUser</c>. </summary>
        /// <returns> List of all patients. </returns>
        public List<PatientUser> GetAll()
        {
            return PatientsRepository.GetAll();
        }

        /// <summary> This method saves image to wwwroots. </summary>
        /// <param name="path"><c>id</c> is path to wwwroots. 
        /// </param>
        /// <returns> If saving was successfull, returns filename of saved image, otherwise, returns null.</returns>
        public string ImageToSave(string path, FileModel file)
        {
            try
            {
                using (Stream stream = new FileStream(path + "\\images\\" + file.FileName, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                }
                return file.FileName;
            }
            catch (Exception)
            {
                return null;

            }
        }

        /// <summary> This method is calling <c>PatientRepository</c> to find one patient using <paramref name="id"/>. </summary>
        /// <param name="id"><c>id</c> is <c>id</c> of a <c>PatientUser</c> that needs to be found.
        /// <returns>One patient</returns>
        public PatientUser GetOne(int id)
        {
            return PatientsRepository.FindOne(id);
        }

        /// <summary> This method provides <c>PatientUser</c> <paramref name="patientId"/> and sends it to <c>PatientsRepository</c> there patient.IsBlocked will be set to true. </summary>
        /// <param name="patientId"><c>PatientUser</c> is <c>PatientUser</c> that needs to be blocked.
        /// </param>
        /// <returns>null if PatientUser is not valid; otherwise, succesfully blocked PatientUser. </returns>
        public PatientUser BlockPatient(int patientId)
        {
            PatientUser patient = PatientsRepository.FindOne(patientId);
            return (patient == null) ? null : PatientsRepository.BlockPatient(patient);
        }

        /// <summary> This method is getting list of filtered malicious<c>PatientUser</c>.</summary>
        /// <returns> List of filtered malicious patients. </returns>
        public List<PatientUser> GetMaliciousPatients()
        {
            return GetValidPatientsInLastMonth(GetCanceledAppointmentsInLastMonth(_regularAppointmentService.GetAll()));
        }

        private List<PatientUser> GetValidPatientsInLastMonth(Dictionary<int, int> dict) {
            List<PatientUser> maliciousPatients = new List<PatientUser>();
            foreach (int key in dict.Keys)
            {
                if (dict[key] >= 3)
                    maliciousPatients.Add(GetOne(key));
            }
            return maliciousPatients;
        }
        private Dictionary<int, int> GetCanceledAppointmentsInLastMonth(List<DoctorAppointment> appointments) {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (DoctorAppointment appointment in appointments)
            {
                if (appointment.IsCanceled == true && CheckIfAppointmentsAreInPastOneMonthFromToday(appointment) != null)
                {
                    GetPatients(dict, appointment);
                }
            }
            return dict;
        }

        private static void GetPatients(Dictionary<int, int> dict, DoctorAppointment appointment)
        {
            if (dict.ContainsKey(appointment.PatientUserId))
                dict[appointment.PatientUserId]++;
            else
                dict[appointment.PatientUserId] = 1;
        }


            private DoctorAppointment CheckIfAppointmentsAreInPastOneMonthFromToday(DoctorAppointment appointment)
        {
            return (UtilityMethods.ParseDateInCorrectFormat(appointment.CancelDateString) > DateTime.Now.AddDays(-32)) ? appointment : null;
        }
    }
}

