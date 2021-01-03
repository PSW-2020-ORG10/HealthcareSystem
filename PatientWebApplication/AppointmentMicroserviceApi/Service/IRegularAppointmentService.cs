/***********************************************************************
 * Module:  RegularAppointmentService.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Service.RegularAppointmentService
 ***********************************************************************/
using AppointmentMicroserviceApi.Doctor;
using AppointmentMicroserviceApi.Patient;
using HealthClinic.CL.Dtos;
using System;
using System.Collections.Generic;

namespace AppointmentMicroserviceApi.Service
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
        DoctorAppointment New(DoctorAppointment appointment, Operation operation);
        void Remove(int appointmentid);
        List<DoctorAppointment> SimpleSearchAppointments(AppointmentReportSearchDto appointmentReportSearchDto);
        void Update(DoctorAppointment appointment, Operation operation);
        DoctorAppointment GetRecommendedAppointment(RecommendedAppointmentDto dto);
        DoctorAppointment CancelAppointment(DoctorAppointment appointment);
    }
}