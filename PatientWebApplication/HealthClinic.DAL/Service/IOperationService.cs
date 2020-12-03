/***********************************************************************
 * Module:  OperationService2.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Contoller.OperationService2
 ***********************************************************************/
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Service
{
    public interface IOperationService
    {
        HashSet<Operation> CreateOperationtSetForDate(DateTime date, int doctorId, int patientId);
        List<Operation> GetAll();
        Operation GetByid(int id);
        List<Operation> GetOperationsForPatient(int id);
        bool IsOperationInTimePeriod(TimeSpan time, List<Operation> operations);
        bool isTermNotAvailable(DoctorUser doctor, TimeSpan start, TimeSpan end, string dateToString, PatientUser patient);
        void New(DoctorAppointment appointment, Operation operation);
        void Remove(int operationid);
        List<Operation> SimpleSearchOperations(AppointmentReportSearchDto appointmentReportSearchDto);
        void Update(DoctorAppointment appointment, Operation operation);
    }
}