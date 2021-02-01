﻿/***********************************************************************
 * Module:  PatientService.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using System.Collections.Generic;
using UserMicroserviceApi.Dtos;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Service
{
    public interface IPatientService
    {
        PatientUser Create(PatientDto patientDto);
        List<PatientUser> GetAll();
        string ImageToSave(string path, FileModel file);
        PatientUser GetOne(int id);
        PatientUser BlockPatient(int patientId);
        List<PatientUser> GetMaliciousPatients();
    }
}