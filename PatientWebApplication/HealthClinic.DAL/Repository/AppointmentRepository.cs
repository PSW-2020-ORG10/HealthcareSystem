/***********************************************************************
 * Module:  AppointmentRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.AppointmentRepository
 ***********************************************************************/

using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Patient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinic.CL.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly MyDbContext dbContext;
        public AppointmentRepository()
        {
            this.dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
        }

        public DoctorAppointment New(DoctorAppointment appointment)
        {
            dbContext.DoctorAppointments.Add(appointment);
            dbContext.SaveChanges();
            return appointment;
        }

        public void Update(DoctorAppointment appointment)
        {
            dbContext.DoctorAppointments.Update(appointment);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            dbContext.DoctorAppointments.Remove(GetByid(id));
            dbContext.SaveChanges();
        }

        public List<DoctorAppointment> GetAll()
        {
            return dbContext.DoctorAppointments.ToList();
        }

        public DoctorAppointment GetByid(int id)
        {
            return dbContext.DoctorAppointments.SingleOrDefault(appointment => appointment.id == id);
        }

        public List<DoctorAppointment> GetAppointmentsForPatient(int idPatient)
        {
            return dbContext.DoctorAppointments.ToList().FindAll(appointment => (appointment.PatientUserId == idPatient) && (!appointment.IsCanceled));
        }

        public List<DoctorAppointment> GetAppointmentsForDoctor(int idDoctor)
        {
            return dbContext.DoctorAppointments.ToList().FindAll(appointment => appointment.DoctorUserId == idDoctor);
        }

        public DoctorAppointment CancelAppointment(DoctorAppointment appointment)
        {
            appointment.IsCanceled = true;
            dbContext.SaveChanges();
            return appointment;
        }
    }
}