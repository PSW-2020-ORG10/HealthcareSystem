/***********************************************************************
 * Module:  ContextAppointmentService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.ContextAppointmentService
 ***********************************************************************/
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Patient;
namespace HealthClinic.CL.Service
{
    public class ContextAppointmentService
    {
        public IStrategyAppointment iStrategyAppointment;
        public ContextAppointmentService()
        {
           
        }
        public ContextAppointmentService(IStrategyAppointment iStrategy)
        {
            this.iStrategyAppointment = iStrategy;
        }
        public void SetServce_StrategyAppointmentStrategy_(IStrategyAppointment iStrategy)
        {
            this.iStrategyAppointment = iStrategy;
        }
       
        public void New(DoctorAppointment appointment, Operation operation)
        {
            this.iStrategyAppointment.New(appointment, operation);
        }
        public void Update(DoctorAppointment appointment, Operation operation)
        {
            this.iStrategyAppointment.Update(appointment, operation);
        }
        public void Remove(int appointmentid, int operatioid)
        {
            this.iStrategyAppointment.Remove(appointmentid);
        }
   
    }
}