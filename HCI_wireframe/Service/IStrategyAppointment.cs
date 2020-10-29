/***********************************************************************
 * Module:  IStrategyAppointment.cs
 * Author:  Luna
 * Purpose: Definition of the Interface Service.IStrategyAppointment
 ***********************************************************************/
using Class_diagram.Model.Doctor;
using Class_diagram.Model.Patient;
using HCI_wireframe.Model.Doctor;
using System;
namespace Class_diagram.Service
{
    public interface IStrategyAppointment
    {
        void New(DoctorAppointment appointment, Operation operation);
        void Remove(int appointmentID, int operationID);
        void Update(DoctorAppointment appointment, Operation operation);
    }
}