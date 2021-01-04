using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using HealthClinic.CL.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PatientWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private DoctorService doctorService;
        private MyDbContext dbContext;

      public DoctorController(MyDbContext dbContext)
      {
         this.dbContext = dbContext;
         this.doctorService = new DoctorService(new OperationRepository(dbContext), new AppointmentRepository(dbContext), new EmployeesScheduleRepository(dbContext), new DoctorRepository(dbContext));
      }

      [HttpGet("available")]
        public IActionResult GetAvailableDoctors(string specialty, string date, int patientId)
        {
            return Ok(new DoctorAdapter().ConvertDoctorListToDoctorDtoList(doctorService.GetDoctorsBySpecialty(specialty)));
        }

        [HttpGet]       // GET /api/doctor
        public IActionResult Get()
        {
            return Ok(doctorService.GetAll());
        }
    }
}
