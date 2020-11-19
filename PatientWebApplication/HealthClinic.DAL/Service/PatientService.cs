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
        /// <summary>This constructor injects the FeedbackService with matching FeedbackRepository.</summary>
        /// <param name="context"><c>context</c> is type of <c>DbContext</c>, and it's used for accessing MYSQL database.</param>
        public PatientService(MyDbContext context)
        {
            patientsRepository = new PatientsRepository(context);
        }

        public PatientUser Create(PatientUser patientUser)
        {
            return patientsRepository.Add(patientUser);
        }

        /*  public override List<PatientUser> GetAll()
          {
              return patientsRepository.GetAll();
          }

          public override Boolean New(PatientUser patient)
          {
              if (isDataValid(patient.email, patient.uniqueCitizensidentityNumber, patient) && isCityValid(patient.city) && isMedicalidValid(patient.medicalIdNumber, patient))
              {
                  patientsRepository.New(patient);
                  return true;
              }
              return false;
          }

          private bool isListOfPatientsEmpty(List<PatientUser> patients)
          {
              if (patients.Count == 0) return true;
              return false;
          }

          private bool isMedicalidValid(string medicalIdNumber, PatientUser patient)
          {
              List<PatientUser> patients = new List<PatientUser>();
              patients = GetAll();

              patients = patients.Where(patient2 => (patient.id != patient2.id && patient2.medicalIdNumber.Equals(medicalIdNumber))).ToList();
              return isListOfPatientsEmpty(patients);

          }

          public override Boolean Update(PatientUser patient)
          {
              if (isDataValid(patient.email, patient.uniqueCitizensidentityNumber, patient) && isCityValid(patient.city))
              {
                  patientsRepository.Update(patient);
                  return true;
              }
              return false;
          }

          public override PatientUser GetByid(int id)
          {
              return patientsRepository.GetByid(id);
          }

          public override void Remove(PatientUser patient)
          {
              patientsRepository.Delete(patient.id);
          }*/
/*
        private Boolean compareTimeForAppointment(TimeSpan time, DoctorAppointment appointment)
        {
            TimeSpan durationOfAppointment = TimeSpan.FromMinutes(15);
            TimeSpan endTime = appointment.time.Add(durationOfAppointment);
            int areSelectedAndAppointmentTimeEqual = TimeSpan.Compare(time, appointment.time);
            int areSelectedAndEndTimeEqual = TimeSpan.Compare(time, endTime);
            if ((areSelectedAndAppointmentTimeEqual == 1 && areSelectedAndEndTimeEqual == -1) || areSelectedAndAppointmentTimeEqual == 0) return true;
            return false;
        }

        private bool arePatientsEquals(PatientUser firstPatient, PatientUser secondPatient)
        {
            if (firstPatient.id == secondPatient.id) return true;
            return false;
        }

        public Boolean doesPatientHaveAnAppointmentAtSpecificTime(TimeSpan time, string date, PatientUser patient)
        {
            AppointmentController appointmentController = new AppointmentController();
            List<DoctorAppointment> listOfAppointments = appointmentController.GetAll();
            if (listOfAppointments == null) listOfAppointments = new List<DoctorAppointment>();

            foreach (DoctorAppointment appointment in listOfAppointments)
            {
                if (arePatientsEquals(patient, appointment.patient) && appointment.date.Equals(date) && compareTimeForAppointment(time, appointment)) return true;
            }
            return false;
        }

        public bool doesPatientHaveAnAppointmentAtSpecificPeriod(TimeSpan start, TimeSpan end, string dateToString, PatientUser patient)
        {
            bool busy = false;
            AppointmentController appointmentController = new AppointmentController();
            List<DoctorAppointment> listOfAppointments = appointmentController.GetAll();

            foreach (DoctorAppointment appointment in listOfAppointments)
            {
                PatientUser patientUser = appointment.patient;
                if (arePatientsEquals(patientUser, patient) && appointment.date.Equals(dateToString))
                {
                    busy = compareTimeForAppointment(start, appointment);
                    if (!busy) busy = compareTimeForAppointment(end, appointment);
                }
            }
            return busy;
        }

        private Boolean compareTimeForOperation(TimeSpan time, TimeSpan start, TimeSpan end)
        {
            int result1 = TimeSpan.Compare(time, start);
            int result2 = TimeSpan.Compare(time, end);
            if ((result1 == 1 && result2 == -1) || result1 == 0)
            {
                return true;
            }
            return false;
        }
        public bool doesPatientHaveAnOperationAtSpecificPeriod(TimeSpan start, TimeSpan end, string dateToString, PatientUser patient)
        {
            bool busy = false;
            OperationController operationController = new OperationController();
            List<Operation> listOfOperation = operationController.GetAll();

            foreach (Operation operation in listOfOperation)
            {
                PatientUser dr = operation.patient;
                if (dr.id == patient.id && operation.date.Equals(dateToString))
                {
                    busy = compareTimeForOperation(start, operation.start, operation.end);
                    if (!busy) busy = compareTimeForOperation(end, operation.start, operation.end);
                }
            }
            return busy;

        }

        public Boolean doesPatientHaveAnOperationAtSpecificTime(TimeSpan time, string date, PatientUser patient)
        {
            OperationController operationController = new OperationController();
            List<Operation> listOfOperation = operationController.GetAll();
            if (listOfOperation == null) listOfOperation = new List<Operation>();
            
            foreach (Operation operation in listOfOperation)
            {
                if (operation.patient.id == patient.id && operation.date.Equals(date) && compareTimeForOperation(time, operation.start, operation.end)) return true;
            }
            return false;
        }
*/

    }
}

