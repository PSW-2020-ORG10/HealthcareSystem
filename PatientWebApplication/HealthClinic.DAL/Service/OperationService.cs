/***********************************************************************
 * Module:  OperationService2.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Contoller.OperationService2
 ***********************************************************************/
using HealthClinic.CL.Adapters;
using HealthClinic.CL.Contoller;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace HealthClinic.CL.Service
{
    public class OperationService : BingPath, IStrategyAppointment
    {
        private IOperationRepository _operationRepository;

        public OperationService(IOperationRepository operationRepository)
        {
            this._operationRepository = operationRepository;
        }

        public List<Operation> GetAll()
        {
            return _operationRepository.GetAll();
        }

        public Operation GetByid(int id)
        {
            return _operationRepository.GetByid(id);
        }

        public void New(DoctorAppointment appointment, Operation operation)
        {
            _operationRepository.New(operation);
        }

        public void Update(DoctorAppointment appointment, Operation operation)
        {
            _operationRepository.Update(operation);
        }

        public void Remove(int operationid)
        {
            _operationRepository.Delete(operationid);
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

        public List<Operation> GetOperationsForPatient(int id)
        {
            return _operationRepository.GetOperationsForPatient(id);
        }

        public List<Operation> SimpleSearchOperations(AppointmentReportSearchDto appointmentReportSearchDto)
        {
            return SearchForAppointmentType(SearchForDoctorNameAndSurname(SearchForDate(GetOperationsForPatient(appointmentReportSearchDto.PatientId), appointmentReportSearchDto),appointmentReportSearchDto),appointmentReportSearchDto);
        }

        private List<Operation> SearchForDoctorNameAndSurname(List<Operation> operations, AppointmentReportSearchDto appointmentSearchDto)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.DoctorNameAndSurname))
            {
                operations = operations.FindAll(operation => operation.Doctor.firstName.Contains(appointmentSearchDto.DoctorNameAndSurname) || operation.Doctor.secondName.Contains(appointmentSearchDto.DoctorNameAndSurname));
            }
            return operations;
        }

        private List<Operation> SearchForDate(List<Operation> operations, AppointmentReportSearchDto appointmentSearchDto)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.Start) && !UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.End))
            {
                DateTime startDate = DateTime.ParseExact(appointmentSearchDto.Start, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime endDate = DateTime.ParseExact(appointmentSearchDto.End, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                operations = operations.FindAll(operation => startDate <= DateTime.ParseExact(operation.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture) && DateTime.ParseExact(operation.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture) <= endDate);
            }
            else if (UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.Start) && !UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.End))
            {
                DateTime endDate = DateTime.ParseExact(appointmentSearchDto.End, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                operations = operations.FindAll(operation => DateTime.ParseExact(operation.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture) <= endDate);
            }
            else if (!UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.Start) && UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.End))
            {
                DateTime startDate = DateTime.ParseExact(appointmentSearchDto.Start, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                operations = operations.FindAll(operation => startDate <= DateTime.ParseExact(operation.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture));
            }
            return operations;

        }

        private List<Operation> SearchForAppointmentType(List<Operation> operations, AppointmentReportSearchDto appointmentSearchDto)
        {
            if (UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.AppointmentType) || CheckIfOperation(appointmentSearchDto.AppointmentType) )
            {
                return operations;
            }
            return new List<Operation>();
        }

        private Boolean CheckIfOperation(String stringToCheck)
        {
            return stringToCheck.Equals("Operation");
        }

    }
}