/***********************************************************************
 * Module:  AppointmentRepository.cs
 * Author:  Mladenka
 * Purpose: Definition of the Class Repository.AppointmentRepository
 ***********************************************************************/

using Class_diagram.Model.Doctor;
using Class_diagram.Model.Patient;
using HCI_wireframe.Model.Doctor;
using System;

namespace Class_diagram.Repository
{
   public class AppointmentRepository : GenericFileRepository<DoctorAppointment>
   {
        public AppointmentRepository(string filePath) : base(filePath)  { }
        public AppointmentRepository() : base() { }
   
    }
}