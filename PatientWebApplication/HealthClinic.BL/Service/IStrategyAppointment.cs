/***********************************************************************
 * Module:  IStrategyAppointment.cs
 * Author:  Luna
 * Purpose: Definition of the Interface Service.IStrategyAppointment
 ***********************************************************************/
using HCI_wireframe.Model.Doctor;
using HealthClinic.BL.Model.Doctor;
using HealthClinic.BL.Model.Patient;
using System;
namespace Class_diagram.Service
{
    public interface IStrategyAppointment
    {
        void New(DoctorAppointment appointment, Operation operation);
        void Remove(int appointmentid, int operationid);
        void Update(DoctorAppointment appointment, Operation operation);
    }
}