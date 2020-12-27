/***********************************************************************
 * Module:  ContextAppointmentService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.ContextAppointmentService
 ***********************************************************************/
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Patient;

namespace AppointmentMicroserviceApi.Service
{
    public class ContextAppointmentService
    {
        public IStrategyAppointment iStrategyAppointment;
        public ContextAppointmentService()
        {

        }
        public ContextAppointmentService(IStrategyAppointment iStrategy)
        {
            iStrategyAppointment = iStrategy;
        }
        public void SetServce_StrategyAppointmentStrategy_(IStrategyAppointment iStrategy)
        {
            iStrategyAppointment = iStrategy;
        }

        public void New(DoctorAppointment appointment, Operation operation)
        {
            iStrategyAppointment.New(appointment, operation);
        }
        public void Update(DoctorAppointment appointment, Operation operation)
        {
            iStrategyAppointment.Update(appointment, operation);
        }
        public void Remove(int appointmentid, int operatioid)
        {
            iStrategyAppointment.Remove(appointmentid);
        }

    }
}