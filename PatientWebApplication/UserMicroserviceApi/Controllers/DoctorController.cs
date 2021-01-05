using Microsoft.AspNetCore.Mvc;
using UserMicroserviceApi.Adapters;
using UserMicroserviceApi.Repository;
using UserMicroserviceApi.Service;
using DoctorAdapter = UserMicroserviceApi.Adapters.DoctorAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UserMicroserviceApi.DbContextModel;

namespace UserMicroserviceApi.Controllers
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
            this.doctorService = new DoctorService(new EmployeesScheduleRepository(dbContext), new DoctorRepository(dbContext));
        }

        [HttpGet("available")]
        public IActionResult GetAvailableDoctors(string specialty, string date, int patientId)
        {
            return Ok(new DoctorAdapter().ConvertDoctorListToDoctorDtoList(doctorService.GetDoctorsBySpecialty(specialty)));
        }

        [HttpGet]       // GET /api/doctor
        public IActionResult Get()
        {   
            return Ok(MicroserviceDoctorAdapter.DoctorListToMicroserviceDoctorDtoList(doctorService.GetAll()));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(MicroserviceDoctorAdapter.DoctorToMicroserviceDoctorDto(doctorService.GetByid(id)));
        }
    }
}
