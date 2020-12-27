using System;
using HealthClinic.CL.Adapters;
using Microsoft.AspNetCore.Mvc;
using UserMicroserviceApi.Repository;
using UserMicroserviceApi.Service;

namespace UserMicroserviceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private DoctorService doctorService;

        /// <summary>This constructor initiates the DoctorAppointmentController's appointment service.</summary>
        public DoctorController()
        {
            doctorService = new DoctorService(new EmployeesScheduleRepository(), new DoctorRepository());
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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(doctorService.GetByid(id));
        }

        [HttpGet("appointment/{doctorId}/{time}/{date}")]
        public IActionResult DoesDoctorHaveAnAppointmentAtSpecificTime(int doctorId, TimeSpan time, string dateToString)
        {
            return Ok(doctorService.DoesDoctorHaveAnAppointmentAtSpecificTimeAsync(doctorService.GetByid(doctorId), time, dateToString));
        }

        [HttpGet("operation/{doctorId}/{time}/{date}")]
        public IActionResult DoesDoctorHaveAnOperationAtSpecificTime(int doctorId, TimeSpan time, string dateToString)
        {
            return Ok(doctorService.DoesDoctorHaveAnOperationAtSpecificTimeAsync(doctorService.GetByid(doctorId), time, dateToString));
        }
    }
}
