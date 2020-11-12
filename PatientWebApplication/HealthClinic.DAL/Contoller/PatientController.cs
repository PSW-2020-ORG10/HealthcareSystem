/***********************************************************************
 * Module:  PatientController.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Contoller.PatientController
 ***********************************************************************/

using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Service;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Contoller
{

    public class PatientController : IUserController<PatientUser>
    {
        public PatientService patientsService;

        public PatientController() {
            patientsService = new PatientService();
        }

        public List<PatientUser> GetAll()
        {
            return patientsService.GetAll();
        }
        public Boolean New(PatientUser patient)
        {
           return patientsService.New(patient);
        }
        public Boolean Update(PatientUser patient)
        {
           return patientsService.Update(patient);
        }
        public PatientUser GetByid(int id)
        {
            return patientsService.GetByid(id);
        }
      

        public Boolean doesPatientHaveAnAppointmentAtSpecificTime(TimeSpan time, string date, PatientUser patient)
        {
            return patientsService.doesPatientHaveAnAppointmentAtSpecificTime(time, date, patient);
        }
        public Boolean doesPatientHaveAnOperationAtSpecificTime(TimeSpan time, string date, PatientUser patient)
        {
            return patientsService.doesPatientHaveAnOperationAtSpecificTime(time, date, patient);
        }

        public bool doesPatientHaveAnOperationAtSpecificPeriod(TimeSpan start, TimeSpan end, string dateToString, PatientUser patient)
        {

            return patientsService.doesPatientHaveAnOperationAtSpecificPeriod(start,end, dateToString, patient);
        }

        public bool doesPatientHaveAnAppointmentAtSpecificPeriod(TimeSpan start, TimeSpan end, string dateToString, PatientUser patient)
        {
            return patientsService.doesPatientHaveAnAppointmentAtSpecificPeriod(start,end, dateToString, patient);
        }

        public void Remove(PatientUser patient)
        {
            patientsService.Remove(patient);
        }
     
    }
  
   
}