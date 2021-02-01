﻿using SearchMicroserviceApi.DbContextModel;
using SearchMicroserviceApi.Dtos;
using SearchMicroserviceApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchMicroserviceApi.Service
{
    public class AppointmentSearchService
    {
        private readonly MyDbContext dbContext;

        public AppointmentSearchService(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary> This method is calling SearchForAppointmentType, SearchForDoctorNameAndSurname, SearchForDate to get list of filtered <c>DoctorAppointment</c> of one patient. </summary>
        /// <param name="appointmentReportSearchDto"><c>appointmentReportSearchDto</c> is Data Transfer Object of a <c>Operation</c> that is being used to filter appointments.
        /// </param>
        /// <returns> List of filtered patient's appointments. </returns>
        public async Task<List<AppointmentDto>> SimpleSearchAppointmentsAsync(AppointmentReportSearchDto appointmentReportSearchDto)
        {
            return SearchForAppointmentType(SearchForDoctorNameAndSurname(SearchForDate(await Utility.HttpRequests.GetAppointmentsForPatientDtoSimple(appointmentReportSearchDto.PatientId), appointmentReportSearchDto), appointmentReportSearchDto), appointmentReportSearchDto);
        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of one patient by doctor's name and surname. </summary>
        /// /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <param name="appointmentReportSearchDto"><c>appointmentReportSearchDto</c> is Data Transfer Object of a <c>Operation</c> that is being used to filter operations.
        /// </param>
        /// <returns> List of filtered patient's appointments. </returns>
        private List<AppointmentDto> SearchForDoctorNameAndSurname(List<AppointmentDto> appointments, AppointmentReportSearchDto appointmentSearchDto)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.DoctorNameAndSurname))
            {
                appointments = appointments.FindAll(appointment => appointment.DoctorNameAndSurname.Contains(appointmentSearchDto.DoctorNameAndSurname));
            }
            return appointments;
        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of one patient by date. </summary>
        /// /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <param name="appointmentReportSearchDto"><c>appointmentReportSearchDto</c> is Data Transfer Object of a <c>Operation</c> that is being used to filter operations.
        /// </param>
        /// <returns> List of filtered patient's appointments. </returns>
        private List<AppointmentDto> SearchForDate(List<AppointmentDto> appointments, AppointmentReportSearchDto appointmentSearchDto)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.Start) && !UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.End))
            {
                appointments = GetAppointmentsBetweenDates(appointmentSearchDto.Start, appointmentSearchDto.End, appointments);
            }
            else if (UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.Start) && !UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.End))
            {
                appointments = GetAppointmentsBeforeDate(appointmentSearchDto.End, appointments);
            }
            else if (!UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.Start) && UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.End))
            {
                appointments = GetAppointmentsAfterDate(appointmentSearchDto.Start, appointments);
            }
            return appointments;

        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of one patient that are between two dates. </summary>
        /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <param name="start"><c>start</c> is first date of search.
        /// </param>
        /// <param name="end"><c>end</c> is last date of search.
        /// </param>
        /// <returns> List of filtered patient's appointments. </returns>
        private List<AppointmentDto> GetAppointmentsBetweenDates(string start, string end, List<AppointmentDto> appointments)
        {
            return appointments.FindAll(appointment => UtilityMethods.ParseDateInCorrectFormat(start) <= UtilityMethods.ParseDateInCorrectFormat(appointment.Date) && UtilityMethods.ParseDateInCorrectFormat(appointment.Date) <= UtilityMethods.ParseDateInCorrectFormat(end));
        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of one patient that are before given date. </summary>
        /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <param name="date"><c>date</c> is last date of search.
        /// </param>
        /// <returns> List of filtered patient's appointments. </returns>
        private List<AppointmentDto> GetAppointmentsBeforeDate(string date, List<AppointmentDto> appointments)
        {
            return appointments.FindAll(appointment => UtilityMethods.ParseDateInCorrectFormat(appointment.Date) <= UtilityMethods.ParseDateInCorrectFormat(date));
        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of one patient that are after given date. </summary>
        /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <param name="date"><c>date</c> is first date of search.
        /// </param>
        /// <returns> List of filtered patient's appointments. </returns>
        private List<AppointmentDto> GetAppointmentsAfterDate(string date, List<AppointmentDto> appointments)
        {
            return appointments.FindAll(appointment => UtilityMethods.ParseDateInCorrectFormat(date) <= UtilityMethods.ParseDateInCorrectFormat(appointment.Date));
        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of one patient by appointment type. </summary>
        /// /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <param name="appointmentSearchDto"><c>appointmentSearchDto</c> is Data Transfer Object that is being used to filter operations.
        /// </param>
        /// <returns> List of filtered patient's appointments. </returns>
        private List<AppointmentDto> SearchForAppointmentType(List<AppointmentDto> appointments, AppointmentReportSearchDto appointmentSearchDto)
        {
            return (UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.AppointmentType) || CheckIfAppointment(appointmentSearchDto.AppointmentType)) ? appointments : new List<AppointmentDto>();
        }

        /// <summary> This method is checks if given string equals appointment. </summary>
        /// <param name="stringToCheck"><c>stringToCheck</c> is string that needs to be checked.
        /// </param>
        /// <returns> <c>true</c> if string equals Appointment; otherwise returns <c>false</c>. </returns>
        private bool CheckIfAppointment(string stringToCheck)
        {
            return stringToCheck.Equals("Appointment");
        }

        /// <summary> This method is calling searchForFirstParameter, searchForOtherParameters to get list of filtered <c>DoctorAppointment</c> of logged patient. </summary>
        /// /// <param name="dto"><c>AppointmentAdvancedSearchDto</c> is Data Transfer Object of a <c>DoctorAppointment</c> that is be used to filter appointments.
        /// </param>
        /// <returns> List of filtered appointments. </returns>
        public async Task<List<MicroserviceSearchAppointmentDto>> AdvancedSearchAppointmentsAsync(AppointmentAdvancedSearchDto dto)
        {
            return SearchForOtherParameters(await Utility.HttpRequests.GetAppointmentsForPatientDto(dto.PatientId), dto, SearchForFirstParameter(await Utility.HttpRequests.GetAppointmentsForPatientDto(dto.PatientId), dto));
        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> that match list of parameters in <c>AppointmentAdvnacedSearchDto</c></summary>
        /// <param name="appointments"> List of all <c>DoctorAppointment</c> of logged user.
        /// </param>
        /// <param name="dto"><c>AppointmentAdvancedSearchDto</c> is Data Transfer Object of a <c>DoctorAppointment</c> that is be used to filter appointments.
        /// </param>
        /// <param name="firstAppointments"> List of <c>DoctorAppointment</c> that contains appointments that matches first parameter.
        /// </param>
        /// <returns> List of filtered appointments. </returns>
        private List<MicroserviceSearchAppointmentDto> SearchForOtherParameters(List<MicroserviceSearchAppointmentDto> appointments, AppointmentAdvancedSearchDto dto, List<MicroserviceSearchAppointmentDto> firstAppointments)
        {
            for (int i = 0; i < dto.RestRoles.Length; i++)
            {
                firstAppointments = SearchForLogicOperators(dto.LogicOperators[i], SearchForOtherRoles(dto.RestRoles[i], dto.Rest[i], appointments), firstAppointments);
            }
            return firstAppointments;
        }

        private List<MicroserviceSearchAppointmentDto> SearchForLogicOperators(string logicOperator, List<MicroserviceSearchAppointmentDto> othersAppointments, List<MicroserviceSearchAppointmentDto> finalAppointments)
        {
            return logicOperator.Equals("or") ? othersAppointments.Union(finalAppointments).ToList() : othersAppointments.Intersect(finalAppointments).ToList();
        }

        private List<MicroserviceSearchAppointmentDto> SearchForOtherRoles(string otherParameter, string otherValue, List<MicroserviceSearchAppointmentDto> appointments)
        {
            return otherParameter.Equals("doctor") ? SearchForDoctorAdvanced(appointments, otherValue) :
               otherParameter.Equals("date") ? SearchForDateAdvanced(appointments, otherValue) :
               SearchForRoomAdvanced(appointments, otherValue);
        }

        private List<MicroserviceSearchAppointmentDto> SearchForFirstParameter(List<MicroserviceSearchAppointmentDto> appointments, AppointmentAdvancedSearchDto dto)
        {
            return dto.FirstRole.Equals("doctor") || UtilityMethods.CheckIfStringIsEmpty(dto.FirstRole) ? SearchForDoctorAdvanced(appointments, dto.First) :
                dto.FirstRole.Equals("date") ? SearchForDateAdvanced(appointments, dto.First) : SearchForRoomAdvanced(appointments, dto.First);
        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of logged patient by parameter <c>Doctor</c>. </summary>
        /// /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <returns> List of filtered appointments. </returns>
        private List<MicroserviceSearchAppointmentDto> SearchForDoctorAdvanced(List<MicroserviceSearchAppointmentDto> appointments, string searchField)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(searchField))
            {
                appointments = appointments.FindAll(appointment => appointment.Doctor.Name.Contains(searchField) || appointment.Doctor.Surname.Contains(searchField) || appointment.Doctor.DoctorFullName().Contains(searchField));
            }
            return appointments;
        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of logged patient by parameter <c>Date</c>. </summary>
        /// /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <returns> List of filtered appointments. </returns>
        private List<MicroserviceSearchAppointmentDto> SearchForDateAdvanced(List<MicroserviceSearchAppointmentDto> appointments, string searchField)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(searchField))
            {
                appointments = appointments.FindAll(appointment => appointment.Date.Equals(searchField));
            }
            return appointments;
        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of logged patient by parameter <c>Room</c>. </summary>
        /// /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <returns> List of filtered appointments. </returns>
        private List<MicroserviceSearchAppointmentDto> SearchForRoomAdvanced(List<MicroserviceSearchAppointmentDto> appointments, string searchField)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(searchField))
            {
                appointments = appointments.FindAll(appointment => appointment.RoomId.Contains(searchField));
            }
            return appointments;
        }
    }
}
