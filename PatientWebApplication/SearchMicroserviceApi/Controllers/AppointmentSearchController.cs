using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SearchMicroserviceApi.DbContextModel;
using SearchMicroserviceApi.Dtos;
using SearchMicroserviceApi.Service;

namespace SearchMicroserviceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentSearchController : ControllerBase
    {
        private AppointmentSearchService appointmentSearchService;
        private MyDbContext dbContext;
        public AppointmentSearchController(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
            appointmentSearchService = new AppointmentSearchService(dbContext);
        }

        /// <summary> This method is calling <c>RegularAppointmentService</c> to get list of all patient <c>DoctorAppointment</c> that matches search dto. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object that contains <c>DoctorNameAndSurname</c>, <c>Start</c>, <c>End</c>, <c>AppointmentType</c>, <c>PatientId</c> and will be used for filtering appointments. 
        /// </param>
        /// <returns> 200 Ok with list of filtered patient appointments. </returns>
        [HttpPost("search")]
        [Authorize(Roles = "patient")]
        public async Task<IActionResult> SimpleSearchAppointmentsAsync(AppointmentReportSearchDto dto)
        {
            return Ok(await appointmentSearchService.SimpleSearchAppointmentsAsync(dto));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to get list of all <c>DoctorAppointment</c> that matches <c>Appointment dto</c>. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object of a <c>DoctorAppointment</c> that contains <c>Doctor</c>, <c>Date</c>, <c>Room</c> and will be used for filtering appointments. 
        /// </param>
        /// <returns> 200 Ok with list of filtered appointments. </returns>
        [HttpPost("advancedsearch")]
        [Authorize(Roles = "patient")]
        public async Task<IActionResult> AdvancedSearchAppointmentsAsync(AppointmentAdvancedSearchDto dto)
        {
            return Ok(await appointmentSearchService.AdvancedSearchAppointmentsAsync(dto));
        }
    }
}
