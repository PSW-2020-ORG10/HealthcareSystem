using HealthClinic.CL.Dtos;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesScheduleController : ControllerBase
    {
        private EmployeesScheduleService employeesScheduleService;
        private DoctorService doctorService;

        /// <summary>This constructor initiates the DoctorAppointmentController's appointment service.</summary>
        public EmployeesScheduleController()
        {
            this.employeesScheduleService = new EmployeesScheduleService(new EmployeesScheduleRepository());
            this.doctorService = new DoctorService(new OperationRepository(), new AppointmentRepository(), new EmployeesScheduleRepository(), new DoctorRepository());
        }

        [HttpPost]
        public IActionResult GetShiftForDoctorForSpecificDay(DoctorShiftSearchDto dto)
        {
            return Ok(employeesScheduleService.getShiftForDoctorForSpecificDay(dto.Date, doctorService.GetByid(dto.DoctorId)));
        }
    }
}
