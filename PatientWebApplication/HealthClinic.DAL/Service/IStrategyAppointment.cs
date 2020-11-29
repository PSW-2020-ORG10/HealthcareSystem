/***********************************************************************
 * Module:  IStrategyAppointment.cs
 * Author:  Luna
 * Purpose: Definition of the Interface Service.IStrategyAppointment
 ***********************************************************************/
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Patient;
using System.Collections.Generic;

namespace HealthClinic.CL.Service
{
    public interface IStrategyAppointment
    {
        void New(DoctorAppointment appointment, Operation operation);
        void Remove(int appointmentid);
        void Update(DoctorAppointment appointment, Operation operation);

    }
}