using Microsoft.AspNetCore.Mvc;
using UserMicroserviceApi.Adapters;
using UserMicroserviceApi.Repository;
using UserMicroserviceApi.Service;
using DoctorAdapter = UserMicroserviceApi.Adapters.DoctorAdapter;

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
            return Ok(MicroserviceDoctorAdapter.DoctorListToMicroserviceDoctorDtoList(doctorService.GetAll()));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(MicroserviceDoctorAdapter.DoctorToMicroserviceDoctorDto(doctorService.GetByid(id)));
        }
    }
}
