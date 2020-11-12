/***********************************************************************
 * Module:  AppointmentRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.AppointmentRepository
 ***********************************************************************/

using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Repository
{
    public class AppointmentRepository : GenericFileRepository<DoctorAppointment>
   {
        public AppointmentRepository(string filePath) : base(filePath)  { }
        public AppointmentRepository() : base() { }
   
    }
}