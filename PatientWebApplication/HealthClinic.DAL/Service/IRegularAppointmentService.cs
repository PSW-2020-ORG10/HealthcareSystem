/***********************************************************************
 * Module:  RegularAppointmentService.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Service.RegularAppointmentService
 ***********************************************************************/
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Service
{
    public interface IRegularAppointmentService
    {
        List<DoctorAppointment> AdvancedSearchAppointments(AppointmentAdvancedSearchDto dto);
        List<DoctorAppointment> FindAllValidAppointments(List<DoctorAppointment> allValidAppointments, List<Survey> surveys);
        List<DoctorAppointment> GetAll();
        List<DoctorAppointment> GetAllAvailableAppointmentsForDate(string dateString, int doctorId, int patientId);
        List<DoctorAppointment> GetAppointmentsForDoctor(int id);
        List<DoctorAppointment> GetAppointmentsForPatient(int id);
        DoctorAppointment GetByid(int id);
        bool isTermNotAvailable(DoctorUser doctor, TimeSpan time, string dateToString, PatientUser patient);
        DoctorAppointment New(DoctorAppointment appointment, Operation operation);
        DoctorAppointment RecommendAnAppointment(DoctorUser doctor, DateTime date1, DateTime date2, PatientUser patient);
        DoctorAppointment recommenedAnAppointmentDatePriority(DateTime date1, DateTime date2, PatientUser patient);
        void Remove(int appointmentid);
        List<DoctorAppointment> SimpleSearchAppointments(AppointmentReportSearchDto appointmentReportSearchDto);
        void Update(DoctorAppointment appointment, Operation operation);
        DoctorAppointment CancelAppointment(DoctorAppointment appointment);
    }
}