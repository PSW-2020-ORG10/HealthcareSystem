/***********************************************************************
 * Module:  AppointmentRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.AppointmentRepository
 ***********************************************************************/

using HealthClinic.BL.Model.Patient;

namespace HealthClinic.BL.Repository
{
    public class AppointmentRepository : GenericFileRepository<DoctorAppointment>
   {
        public AppointmentRepository(string filePath) : base(filePath)  { }
        public AppointmentRepository() : base() { }
   
    }
}