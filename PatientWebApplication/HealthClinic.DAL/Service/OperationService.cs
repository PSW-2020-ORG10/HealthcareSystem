/***********************************************************************
 * Module:  OperationService2.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Contoller.OperationService2
 ***********************************************************************/
using HealthClinic.CL.Contoller;
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
namespace HealthClinic.CL.Service
{
    public class OperationService : BingPath, IStrategyAppointment
    {
        public OperationRepository operationRepository;
        String path = bingPathToAppDir(@"JsonFiles\operations.json");

        public OperationService()
        {
            operationRepository = new OperationRepository(path);
        }

        public List<Operation> GetAll()
        {
            return operationRepository.GetAll();
        }

        public Operation GetByid(int id)
        {
            return operationRepository.GetByid(id);
        }

        public void New(DoctorAppointment appointment, Operation operation)
        {
            operationRepository.New(operation);
        }

        public void Update(DoctorAppointment appointment, Operation operation)
        {
            operationRepository.Update(operation);
        }

        public void Remove(int appointmentid, int operationid)
        {
            operationRepository.Delete(operationid);
        }
        public Boolean isTermNotAvailable(DoctorUser doctor, TimeSpan start, TimeSpan end, String dateToString, PatientUser patient)
        {
            PatientController patientController = new PatientController();
            DoctorController doctorController = new DoctorController();
            Boolean hasAppointmentDoctor = doctorController.doesDoctorHaveAnAppointmentAtSpecificPeriod(doctor, start, end, dateToString);
            Boolean hasOperationDoctor = doctorController.doesDoctorHaveAnOperationAtSpecificPerod(doctor, start, end, dateToString);
            
            if (hasAppointmentDoctor || hasOperationDoctor ) return true;
            return false;
        }
       

    }
}