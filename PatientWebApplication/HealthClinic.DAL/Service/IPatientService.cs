/***********************************************************************
 * Module:  PatientService.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Patient;
using System.Collections.Generic;

namespace HealthClinic.CL.Service
{
    public interface IPatientService
    {
        PatientUser Create(PatientDto patientDto);
        List<PatientUser> GetAll();
        string ImageToSave(string path, FileModel file);
        PatientUser GetOne(int id);
    }
}