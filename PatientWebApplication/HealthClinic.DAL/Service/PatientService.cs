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

namespace HealthClinic.CL.Service
{
    public class PatientService 
    {
        private PatientsRepository patientsRepository { get; set; }
        
        public PatientService(MyDbContext context)
        {
            patientsRepository = new PatientsRepository(context);
        }

        public PatientUser Create(PatientUser patientUser)
        {
            return patientsRepository.Add(patientUser);
        }

        

    }
}

