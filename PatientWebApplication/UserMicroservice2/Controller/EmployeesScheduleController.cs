using HealthClinic.CL.Dtos;
using Microsoft.AspNetCore.Mvc;
using UserMicroservice.Repository;
using UserMicroservice.Service;

namespace UserMicroservice.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesScheduleController : ControllerBase
    {
        private EmployeesScheduleService employeesScheduleService;
        private readonly DoctorService doctorService;

        /// <summary>This constructor initiates the DoctorAppointmentController's appointment service.</summary>
        public EmployeesScheduleController()
        {
            employeesScheduleService = new EmployeesScheduleService(new EmployeesScheduleRepository());
            doctorService = new DoctorService(new EmployeesScheduleRepository(), new DoctorRepository());
        }

        [HttpPost]
        public IActionResult GetShiftForDoctorForSpecificDay(DoctorShiftSearchDto dto)
        {
            return Ok(employeesScheduleService.getShiftForDoctorForSpecificDay(dto.Date, doctorService.GetByid(dto.DoctorId)));
        }
    }
}
