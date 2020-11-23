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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace HealthClinic.CL.Service
{
    public class PatientService : IPatientService
    {
        private IPatientsRepository PatientsRepository { get; set; }
        private IEmailVerificationService EmailVerificationService { get; set; }

        public PatientService(IPatientsRepository patientsRepository, IEmailVerificationService emailVerificationService)
        {
            PatientsRepository = patientsRepository;
            EmailVerificationService = emailVerificationService;
        }

        public PatientUser Create(PatientDto patientDto)
        {
            PatientUser patient = PatientsRepository.Add(PatientAdapter.PatientDtoToPatient(patientDto));
            EmailVerificationService.SendVerificationMail(new MailAddress(patient.email), patient.id);
            return patient;
        }

        public PatientUser Validate(int id)
        {
            PatientUser patient = PatientsRepository.Find(id);
            if(patient != null)
            {
                return PatientsRepository.Validate(patient);
            }

            return null;
        }

        public List<PatientUser> GetAll()
        {
            return PatientsRepository.GetAll();
        }


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


    }
}

