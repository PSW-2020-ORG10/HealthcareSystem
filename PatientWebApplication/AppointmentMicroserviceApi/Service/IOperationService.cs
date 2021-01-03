/***********************************************************************
 * Module:  OperationService2.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Contoller.OperationService2
 ***********************************************************************/
using AppointmentMicroserviceApi.Doctor;
using AppointmentMicroserviceApi.Patient;
using HealthClinic.CL.Dtos;
using System;
using System.Collections.Generic;

namespace AppointmentMicroserviceApi.Service
{
    public interface IOperationService
    {
        HashSet<Operation> CreateOperationtSetForDate(DateTime date, int doctorId, int patientId);
        List<Operation> GetAll();
        Operation GetByid(int id);
        List<Operation> GetOperationsForPatient(int id);
        bool IsOperationInTimePeriod(TimeSpan time, List<Operation> operations);
        void New(DoctorAppointment appointment, Operation operation);
        void Remove(int operationid);
        List<Operation> SimpleSearchOperations(AppointmentReportSearchDto appointmentReportSearchDto);
        void Update(DoctorAppointment appointment, Operation operation);
    }
}