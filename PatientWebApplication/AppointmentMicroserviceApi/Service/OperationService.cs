/***********************************************************************
 * Module:  OperationService2.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Contoller.OperationService2
 ***********************************************************************/
using AppointmentMicroserviceApi.Doctor;
using AppointmentMicroserviceApi.Dtos;
using AppointmentMicroserviceApi.Patient;
using AppointmentMicroserviceApi.Repository;
using AppointmentMicroserviceApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppointmentMicroserviceApi.Service
{
    /// <summary>Class <c>OperationService</c> handles operation business logic.
    /// </summary>
    public class OperationService : IStrategyAppointment
    {
        /// <value>Property <c>_operationRepository</c> represents the repository used for data access.</value>
        private IOperationRepository _operationRepository;

        /// <summary>This constructor injects the <c>OperationService</c> with matching <c>OperationRepository</c>.</summary>
        public OperationService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        /// <summary> This method is calling <c>OperationRepository</c> to get list of all operations. </summary>
        /// <returns> List of all operations. </returns>
        public List<Operation> GetAll()
        {
            return _operationRepository.GetAll();
        }

        /// <summary> This method is calling <c>OperationRepository</c> to get operation by it's id. </summary>
        /// <param name="id"><c>id</c> is id of operation we need.</param>
        /// <returns> One operation. </returns>
        public Operation GetByid(int id)
        {
            return _operationRepository.GetByid(id);
        }

        /// <summary> This method is calling <c>OperationRepository</c> to create new operation. </summary>
        /// <param name="operation"><c>operation</c> is operation we want to create.</param>
        /// <returns> Created operation. </returns>
        public void New(DoctorAppointment appointment, Operation operation)
        {
            _operationRepository.New(operation);
        }

        /// <summary> This method is calling <c>OperationRepository</c> to update operation. </summary>
        /// <param name="operation"><c>operation</c> is operation we want to update.</param>
        /// <returns> Updated operation. </returns>
        public void Update(DoctorAppointment appointment, Operation operation)
        {
            _operationRepository.Update(operation);
        }

        /// <summary> This method is calling <c>OperationRepository</c> to remove operation. </summary>
        /// <param name="operationid"><c>operationid</c> is id of operation we want to delete.</param>
        /// <returns> Removed operation. </returns>
        public void Remove(int operationid)
        {
            _operationRepository.Delete(operationid);
        }

        /// <summary> This method is calling <c>OperationRepository</c> to get all operation's of one patient. </summary>
        /// <param name="id"><c>id</c> is id of patient who's operations we need.</param>
        /// <returns> List of patient's operations. </returns>
        public List<Operation> GetOperationsForPatient(int id)
        {
            return _operationRepository.GetOperationsForPatient(id);
        }

        /// <summary> This method is calling SearchForAppointmentType, SearchForDoctorNameAndSurname, SearchForDate to get list of filtered <c>Operation</c> of one patient. </summary>
        /// /// <param name="appointmentReportSearchDto"><c>appointmentReportSearchDto</c> is Data Transfer Object of a <c>Operation</c> that is being used to filter operations.
        /// </param>
        /// <returns> List of filtered patient's operations. </returns>
        public List<Operation> SimpleSearchOperations(AppointmentReportSearchDto appointmentReportSearchDto)
        {
            return SearchForAppointmentType(SearchForDoctorNameAndSurname(SearchForDate(GetOperationsForPatient(appointmentReportSearchDto.PatientId), appointmentReportSearchDto), appointmentReportSearchDto), appointmentReportSearchDto);
        }

        /// <summary> This method is getting list of filtered <c>Operation</c> of one patient by doctor's name and surname. </summary>
        /// /// <param name="operations"><c>operations</c> is List of operations that matches search fields.
        /// </param>
        /// /// <param name="appointmentReportSearchDto"><c>appointmentReportSearchDto</c> is Data Transfer Object of a <c>Operation</c> that is being used to filter operations.
        /// </param>
        /// <returns> List of filtered patient's operations. </returns>
        private List<Operation> SearchForDoctorNameAndSurname(List<Operation> operations, AppointmentReportSearchDto appointmentSearchDto)
        {      
            if (!UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.DoctorNameAndSurname))
            {
                operations = operations.FindAll(operation => Utility.HttpRequests.GetDoctorByIdAsync(operation.DoctorUserId).Result.Name.Contains(appointmentSearchDto.DoctorNameAndSurname) || Utility.HttpRequests.GetDoctorByIdAsync(operation.DoctorUserId).Result.Surname.Contains(appointmentSearchDto.DoctorNameAndSurname));
            }
            return operations;
        }

        /// <summary> This method is getting list of filtered <c>Operation</c> of one patient by date. </summary>
        /// /// <param name="operations"><c>operations</c> is List of operations that matches search fields.
        /// </param>
        /// /// <param name="appointmentReportSearchDto"><c>appointmentReportSearchDto</c> is Data Transfer Object of a <c>Operation</c> that is being used to filter operations.
        /// </param>
        /// <returns> List of filtered patient's operations. </returns>
        private List<Operation> SearchForDate(List<Operation> operations, AppointmentReportSearchDto appointmentSearchDto)
        {
            operations = (!UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.Start) && !UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.End)) ? GetOperationsBetweenDates(appointmentSearchDto.Start, appointmentSearchDto.End, operations) : 
                (UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.Start) && !UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.End)) ? GetOperationsBeforeDate(appointmentSearchDto.End, operations) : 
                (!UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.Start) && UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.End)) ? operations = GetOperationsAfterDate(appointmentSearchDto.Start, operations) : operations;
            return operations;

            
        }

        /// <summary> This method is getting list of filtered <c>Operation</c> of one patient that are between two dates. </summary>
        /// <param name="operations"><c>operations</c> is List of operations that matches search fields.
        /// </param>
        /// <param name="start"><c>start</c> is first date of search.
        /// </param>
        /// /// <param name="end"><c>end</c> is last date of search.
        /// </param>
        /// <returns> List of filtered patient's operations. </returns>
        private List<Operation> GetOperationsBetweenDates(string start, string end, List<Operation> operations)
        {
            return operations.FindAll(operation => UtilityMethods.ParseDateInCorrectFormat(start) <= UtilityMethods.ParseDateInCorrectFormat(operation.Date) && UtilityMethods.ParseDateInCorrectFormat(operation.Date) <= UtilityMethods.ParseDateInCorrectFormat(end));
        }

        /// <summary> This method is getting list of filtered <c>Operation</c> of one patient that are before given date. </summary>
        /// <param name="operations"><c>operations</c> is List of operations that matches search fields.
        /// </param>
        /// <param name="date"><c>date</c> is last date of search.
        /// </param>
        /// <returns> List of filtered patient's operations. </returns>
        private List<Operation> GetOperationsBeforeDate(string date, List<Operation> operations)
        {
            return operations.FindAll(operation => UtilityMethods.ParseDateInCorrectFormat(operation.Date) <= UtilityMethods.ParseDateInCorrectFormat(date));
        }

        /// <summary> This method is getting list of filtered <c>Operation</c> of one patient that are after given date. </summary>
        /// <param name="operations"><c>operations</c> is List of operations that matches search fields.
        /// </param>
        /// <param name="date"><c>date</c> is first date of search.
        /// </param>
        /// <returns> List of filtered patient's operations. </returns>
        private List<Operation> GetOperationsAfterDate(string date, List<Operation> operations)
        {
            return operations.FindAll(operation => UtilityMethods.ParseDateInCorrectFormat(date) <= UtilityMethods.ParseDateInCorrectFormat(operation.Date));
        }

        /// <summary> This method is getting list of filtered <c>Operation</c> of one patient by appointment type. </summary>
        /// /// <param name="operations"><c>operations</c> is List of operations that matches search fields.
        /// </param>
        /// <param name="appointmentReportSearchDto"><c>appointmentReportSearchDto</c> is Data Transfer Object of a <c>Operation</c> that is being used to filter operations.
        /// </param>
        /// <returns> List of filtered patient's operations. </returns>
        private List<Operation> SearchForAppointmentType(List<Operation> operations, AppointmentReportSearchDto appointmentSearchDto)
        {
            return (UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.AppointmentType) || CheckIfOperation(appointmentSearchDto.AppointmentType)) ? operations : new List<Operation>();
        }

        /// <summary> This method is checks if given string equals operation. </summary>
        /// <param name="stringToCheck"><c>stringToCheck</c> is string that needs to be checked.
        /// </param>
        /// <returns> <c>true</c> if string equals Operation; otherwise returns <c>false</c>. </returns>
        private bool CheckIfOperation(string stringToCheck)
        {
            return stringToCheck.Equals("Operation");
        }

        /// <summary> This method is getting all operations of one doctor on given date. </summary>
        /// <returns> list of all doctor's operations on specific date. </returns>
        private List<Operation> GetAllOperationsByDateAndDoctor(DateTime date, int doctorId)
        {
            return _operationRepository.GetOperationsForDoctor(doctorId).FindAll(operation => date == UtilityMethods.ParseDateInCorrectFormat(operation.Date));
        }

        /// <summary> This method is getting all operations of one patient on given date. </summary>
        /// <returns> list of all patient's operations on specific date. </returns>
        private List<Operation> GetAllOperationsByDateAndPatient(DateTime date, int patientId)
        {
            return GetOperationsForPatient(patientId).FindAll(operation => date == UtilityMethods.ParseDateInCorrectFormat(operation.Date));
        }

        /// <summary> This method is creating a set out of list of doctor's and patient's operations on specific date. </summary>
        /// <returns> <c>HashSet</c> of operations. </returns>
        public HashSet<Operation> CreateOperationtSetForDate(DateTime date, int doctorId, int patientId)
        {
            HashSet<Operation> appointmentsSet = new HashSet<Operation>(GetAllOperationsByDateAndDoctor(date, doctorId));
            appointmentsSet.UnionWith(GetAllOperationsByDateAndPatient(date, patientId));
            return appointmentsSet;
        }

        /// <summary> This method is creating a set out of list of doctor's and patient's operations on specific date. </summary>
        /// <returns> <c>HashSet</c> of operations. </returns>
        public bool IsOperationInTimePeriod(TimeSpan time, List<Operation> operations)
        {
            foreach (Operation operation in operations)
            {
                if (time >= operation.Start && time < operation.End) return true;
            }
            return false;
        }

        public List<Operation> GetOperationsForDoctor(int doctorId)
        {
            return _operationRepository.GetOperationsForDoctor(doctorId);
        }

        public OperationReferral GetOperationalReferralById(int id)
        {
            return GetAll().SingleOrDefault(operation => operation.OperationReferral.Id == id).OperationReferral;
        }
    }
}