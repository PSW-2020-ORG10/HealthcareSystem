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


        public string ImageToSave(FileModel file)
        {
            try
            {
                string path = Directory.GetParent(Directory.GetCurrentDirectory()).FullName + "\\HealthClinic.DAL\\wwwroot\\" + file.FileName;


                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                }
                return path;
            }
            catch (Exception)
            {
                return null;

            }

        }

        public PatientUser GetOne(int id)
        {
            return PatientsRepository.FindOne(id);
        }


    }
}

