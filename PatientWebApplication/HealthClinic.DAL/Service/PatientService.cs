/***********************************************************************
 * Module:  PatientService.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using HealthClinic.CL.Contoller;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace HealthClinic.CL.Service
{
    public class PatientService 
    {
        private IPatientsRepository PatientsRepository { get; set; }
        private IEmailVerificationService EmailVerificationService { get; set; }

        public PatientService(IPatientsRepository patientsRepository, IEmailVerificationService emailVerificationService)
        {
            PatientsRepository = patientsRepository;
            EmailVerificationService = emailVerificationService;
        }

        public PatientUser Create(PatientUser patientUser)
        {
            EmailVerificationService.SendVerificationMail(new MailAddress(patientUser.email), patientUser.id);
            return PatientsRepository.Add(patientUser);
        }

        public PatientUser Validate(int id)
        {
            PatientUser patient = PatientsRepository.Find(id);
            if(patient != null)
            {
                return PatientsRepository.Validate(patient);
            }
            else
            {
                return null;
            }
            
        }

    }
}

