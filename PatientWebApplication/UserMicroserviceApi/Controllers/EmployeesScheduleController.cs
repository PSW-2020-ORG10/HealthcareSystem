using Microsoft.AspNetCore.Mvc;
using UserMicroserviceApi.Adapters;
using UserMicroserviceApi.Dtos;
using UserMicroserviceApi.Repository;
using UserMicroserviceApi.Service;

namespace UserMicroserviceApi.Controllers
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
            return Ok(MicroserviceShiftAdapter.ShiftToMicroserviceShiftDto(employeesScheduleService.getShiftForDoctorForSpecificDay(dto.Date, doctorService.GetByid(dto.DoctorId))));
        }
    }
}
