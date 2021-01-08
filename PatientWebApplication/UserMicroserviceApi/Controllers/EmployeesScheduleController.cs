using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserMicroserviceApi.Adapters;
using UserMicroserviceApi.DbContextModel;
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
        private MyDbContext dbContext;

        /// <summary>This constructor initiates the DoctorAppointmentController's appointment service.</summary>
        public EmployeesScheduleController(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
            employeesScheduleService = new EmployeesScheduleService(new EmployeesScheduleRepository(dbContext));
            doctorService = new DoctorService(new EmployeesScheduleRepository(dbContext), new DoctorRepository(dbContext));
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetShiftForDoctorForSpecificDay(DoctorShiftSearchDto dto)
        {
            return Ok(MicroserviceShiftAdapter.ShiftToMicroserviceShiftDto(employeesScheduleService.getShiftForDoctorForSpecificDay(dto.Date, doctorService.GetByid(dto.DoctorId))));
        }
    }
}
