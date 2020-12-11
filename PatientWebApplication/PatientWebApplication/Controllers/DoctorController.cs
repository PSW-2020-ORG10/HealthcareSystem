using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.CL.Adapters;
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

        /// <summary>This constructor initiates the DoctorAppointmentController's appointment service.</summary>
        public DoctorController()
        {
            this.doctorService = new DoctorService(new OperationRepository(), new AppointmentRepository(), new EmployeesScheduleRepository(), new DoctorRepository());
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
