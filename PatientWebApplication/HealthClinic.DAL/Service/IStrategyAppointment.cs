/***********************************************************************
 * Module:  IStrategyAppointment.cs
 * Author:  Luna
 * Purpose: Definition of the Interface Service.IStrategyAppointment
 ***********************************************************************/
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Service
{
    public interface IStrategyAppointment
    {
        void New(DoctorAppointment appointment, Operation operation);
        void Remove(int appointmentid, int operationid);
        void Update(DoctorAppointment appointment, Operation operation);
    }
}