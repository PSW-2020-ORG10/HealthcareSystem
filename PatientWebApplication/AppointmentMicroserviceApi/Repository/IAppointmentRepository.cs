﻿/***********************************************************************
 * Module:  AppointmentRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.AppointmentRepository
 ***********************************************************************/

using AppointmentMicroserviceApi.Patient;
using System.Collections.Generic;

namespace AppointmentMicroserviceApi.Repository
{
    public interface IAppointmentRepository
    {
        void Delete(int id);
        List<DoctorAppointment> GetAll();
        List<DoctorAppointment> GetAppointmentsForPatient(int idPatient);
        List<DoctorAppointment> GetAppointmentsForDoctor(int idDoctor);
        DoctorAppointment GetByid(int id);
        DoctorAppointment New(DoctorAppointment appointment);
        void Update(DoctorAppointment appointment);
        DoctorAppointment Create(DoctorAppointment appointment);
        DoctorAppointment CancelAppointment(DoctorAppointment appointment);
    }
}