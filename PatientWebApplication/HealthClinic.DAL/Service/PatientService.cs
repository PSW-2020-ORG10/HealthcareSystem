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
using System.Linq;

namespace HealthClinic.CL.Service
{
    public class PatientService : IPatientService
    {
        private IPatientsRepository patientsRepository { get; set; }

        public PatientService(IPatientsRepository ipatientsRepository)
        {
            patientsRepository = ipatientsRepository;
        }

        public PatientUser Create(PatientDto patientDto)
        {
            PatientUser patientUser = PatientAdapter.PatientDtoToPatient(patientDto);
            PatientUser trialPatient =  patientsRepository.Add(patientUser);
            return trialPatient;
        }

        public List<PatientUser> GetAll()
        {
            return patientsRepository.GetAll();
        }

    }
}

