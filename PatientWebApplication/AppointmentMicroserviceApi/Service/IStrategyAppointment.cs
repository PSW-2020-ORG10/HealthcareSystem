/***********************************************************************
 * Module:  IStrategyAppointment.cs
 * Author:  Luna
 * Purpose: Definition of the Interface Service.IStrategyAppointment
 ***********************************************************************/
using AppointmentMicroserviceApi.Doctor;
using AppointmentMicroserviceApi.Patient;

namespace AppointmentMicroserviceApi.Service
{
    public interface IStrategyAppointment
    {
        void New(DoctorAppointment appointment, Operation operation);
        void Remove(int appointmentid);
        void Update(DoctorAppointment appointment, Operation operation);

    }
}