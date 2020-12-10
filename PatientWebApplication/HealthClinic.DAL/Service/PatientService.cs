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

        public PatientUser BlockPatient(int patientId)
        {
            PatientUser patient = PatientsRepository.FindOne(patientId);
            return (patient == null) ? null : PatientsRepository.BlockPatient(patient);
        }
        public List<PatientUser> GetMaliciousPatients()
        {
            Dictionary<int,int> hashMap = new Dictionary<int, int>();
            List<PatientUser> maliciousPatients = new List<PatientUser>();
            List<DoctorAppointment> appointments = _regularAppointmentService.GetAll();
            // List<PatientUser> patient = GetAll();
            // List<int> allValidPatients = new List<int>();
            foreach (DoctorAppointment appointment in appointments) {
                if (appointment.IsCanceled == true && CheckIfAppointmentsAreInPastOneMonthFromToday(appointment) != null)
                {
                    if (hashMap.ContainsKey(appointment.PatientUserId))
                    {
                        hashMap[appointment.PatientUserId]++;
                        // maliciousPatients.Add(id, GetOne(id));
                        //allValidPatients.Add(appointment.id);
                    }
                    else
                    {
                        hashMap[appointment.PatientUserId] = 1;
                    }
                }
            }
            foreach(int key in hashMap.Keys) {
                if(hashMap[key] >= 3)
                    maliciousPatients.Add(GetOne(key));
            }

                
            
            /*foreach (int validPatient in allValidPatients) {
                if (brojac == 3) {
                    maliciousPatients.Add(GetOne(validPatient));
                }
            }*/
            return maliciousPatients;
        }
        private DoctorAppointment CheckIfAppointmentsAreInPastOneMonthFromToday(DoctorAppointment appointment)
        {
            return (UtilityMethods.ParseDateInCorrectFormat(appointment.CancelDateString) > DateTime.Now.AddDays(-32)) ? appointment : null;
        }
    }
}

