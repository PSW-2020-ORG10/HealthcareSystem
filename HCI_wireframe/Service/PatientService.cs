/***********************************************************************
 * Module:  PatientService.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using Class_diagram.Contoller;
using Class_diagram.Model.Doctor;
using Class_diagram.Model.Employee;
using Class_diagram.Model.Patient;
using HCI_wireframe.Repository;
using HCI_wireframe.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text.RegularExpressions;

namespace Class_diagram.Service
{
    public class PatientService: AbstractUserService<PatientUser>
    {
        PatientsRepository patientsRepository;
        String path = bingPathToAppDir(@"JsonFiles\patients.json");
 
        public PatientService() {
            patientsRepository = new PatientsRepository(path);
        }


        public override List<PatientUser> GetAll()
        {
            return patientsRepository.GetAll();
        }

        public override Boolean New(PatientUser patient)
        {
            if (isDataValid(patient.Email, patient.UniqueCitizensIdentityNumber,patient) && isCityValid(patient.City) && isMedicalIdValid(patient.MedicalIDnumber,patient))
            {
                patientsRepository.New(patient);
                return true;
            }
            return false;
        }

        private bool isMedicalIdValid(string medicalIDnumber,PatientUser patient)
        {
            List<PatientUser> patients = GetAll();
            foreach (PatientUser patient2 in patients)
            {
                if (patient.ID != patient2.ID)
                {
                    if (patient2.MedicalIDnumber.Equals(medicalIDnumber))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override Boolean Update(PatientUser patient)
        {
            if (isDataValid(patient.Email, patient.UniqueCitizensIdentityNumber,patient) && isCityValid(patient.City))
            {
                patientsRepository.Update(patient);
                return true;
            }
            return false;
        }

        public override PatientUser GetByID(int ID)
        {
            return patientsRepository.GetByID(ID);
        }

        public override void Remove(PatientUser patient)
        {
            patientsRepository.Delete(patient.ID);
        }
        public Boolean doesPatientHaveAnAppointmentAtSpecificTime(TimeSpan time, string date, PatientUser patient)
        {
           AppointmentController appointmentController = new AppointmentController();
            List<DoctorAppointment> listOfAppointments = appointmentController.GetAll();
            if (listOfAppointments == null)
            {
                listOfAppointments = new List<DoctorAppointment>();
            }
            foreach (DoctorAppointment appointment in listOfAppointments)
            {
                PatientUser patientOnAppointment = appointment.patient;
                if (patient.ID == patientOnAppointment.ID)
                {
                    if (appointment.Date.Equals(date))
                    {
                        TimeSpan time1 = TimeSpan.FromMinutes(15);
                        TimeSpan krajPr = appointment.Time.Add(time1);
                        int result = TimeSpan.Compare(time, appointment.Time);
                        int result1 = TimeSpan.Compare(time, krajPr);
                        if ((result == 1 && result1 == -1) || result == 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool doesPatientHaveAnAppointmentAtSpecificPeriod(TimeSpan start, TimeSpan end, string dateToString, PatientUser patient)
        {
            bool zauzet = false;
            AppointmentController appController = new AppointmentController();

            List<DoctorAppointment> listaPregleda = appController.GetAll();
            foreach (DoctorAppointment dd in listaPregleda)
            {
                PatientUser dr = dd.patient;
                if (dr.ID == patient.ID)
                {
                    if (dd.Date.Equals(dateToString))
                    {
                        TimeSpan time1 = TimeSpan.FromMinutes(15);
                        TimeSpan krajPr = dd.Time.Add(time1);
                        int result = TimeSpan.Compare(start, dd.Time);
                        int result1 = TimeSpan.Compare(start, krajPr);
                        if ((result == 1 && result1 == -1) || result == 0)
                        {
                            zauzet = true;
                        }
                        int rezultat = TimeSpan.Compare(end, dd.Time);
                        int rezultat1 = TimeSpan.Compare(end, krajPr);
                        if ((rezultat == 1 && rezultat1 == -1) || rezultat == 0)
                        {

                            zauzet = true;
                        }
                    }


                }

            }
            return zauzet;
        }

        public bool doesPatientHaveAnOperationAtSpecificPeriod(TimeSpan start, TimeSpan end, string dateToString, PatientUser patient)
        {
            bool zauzet = false;
            OperationController operationController = new OperationController();

            List<Operation> listOfOperation = operationController.GetAll();
            foreach (Operation dd in listOfOperation)
            {
                PatientUser dr = dd.patient;
                if (dr.ID == patient.ID)
                {
                    if (dd.Date.Equals(dateToString))
                    {
                        int result = TimeSpan.Compare(start, dd.Start);
                        int result1 = TimeSpan.Compare(start, dd.End);
                        if ((result == 1 && result1 == -1) || result == 0)
                        {
                            zauzet = true;
                        }
                        int rezultat = TimeSpan.Compare(end, dd.Start);
                        int rezultat1 = TimeSpan.Compare(end, dd.End);
                        if ((rezultat == 1 && rezultat1 == -1) || rezultat == 0)
                        {


                            zauzet = true;
                        }
                    }

                }
            }
            return zauzet;

        }

        public Boolean doesPatientHaveAnOperationAtSpecificTime(TimeSpan time, string date, PatientUser patient)
        {
            OperationController operationController = new OperationController();
            int result1 = 0;
            int result2 = 0;
            List<Operation> listOfOperation =operationController.GetAll();
            if (listOfOperation == null)
            {
                listOfOperation = new List<Operation>();
            }
            foreach (Operation operation in listOfOperation)
            {
                PatientUser patientOnOperation = operation.patient;
                if (patientOnOperation.ID == patient.ID)
                {
                    if (operation.Date.Equals(date))
                    {
                        result1 = TimeSpan.Compare(operation.Start, time);
                        result2 = TimeSpan.Compare(time, operation.End);

                        if ((result1 == -1 && result2 == -1) || result1 == 0)
                        {
                            return true;
                        }

                    }
                }

            }
            return false;
        }

     
    }
}

