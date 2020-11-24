/***********************************************************************
 * Module:  AppointmentRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.AppointmentRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Patient;
using System.Collections.Generic;

namespace HealthClinic.CL.Repository
{
    public interface IAppointmentRepository
    {
        void Delete(int id);
        List<DoctorAppointment> GetAll();
        List<DoctorAppointment> GetAppointmentsForPatient(int idPatient);
        DoctorAppointment GetByid(int id);
        void New(DoctorAppointment appointment);
        void Update(DoctorAppointment appointment);
    }
}