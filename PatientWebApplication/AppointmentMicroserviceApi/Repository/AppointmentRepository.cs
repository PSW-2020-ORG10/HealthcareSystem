/***********************************************************************
 * Module:  AppointmentRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.AppointmentRepository
 ***********************************************************************/

using AppointmentMicroserviceApi.Patient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using MyDbContext = AppointmentMicroserviceApi.DbContextModel.MyDbContext;

namespace AppointmentMicroserviceApi.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly MyDbContext dbContext;
        public AppointmentRepository(MyDbContext context)
        {
            dbContext = context;
        }

        public AppointmentRepository()
        {
            dbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
        }

        public DoctorAppointment New(DoctorAppointment appointment)
        {
            dbContext.DoctorAppointments.Add(appointment);
            dbContext.SaveChanges();
            return appointment;
        }

        public DoctorAppointment Create(DoctorAppointment appointment)
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
            return dbContext.DoctorAppointments.SingleOrDefault(appointment => appointment.Id == id);
        }

        public List<DoctorAppointment> GetAppointmentsForPatient(int idPatient)
        {
            return dbContext.DoctorAppointments.ToList().FindAll(appointment => appointment.PatientUserId == idPatient && !appointment.IsCanceled);
        }

        public List<DoctorAppointment> GetAppointmentsForDoctor(int idDoctor)
        {
            return dbContext.DoctorAppointments.ToList().FindAll(appointment => appointment.DoctorUserId == idDoctor);
        }

        public DoctorAppointment CancelAppointment(DoctorAppointment appointment)
        {
            appointment.IsCanceled = true;
            appointment.CancelDateString = DateTime.Now.ToString("dd/MM/yyyy");
            dbContext.SaveChanges();
            return appointment;
        }
    }
}