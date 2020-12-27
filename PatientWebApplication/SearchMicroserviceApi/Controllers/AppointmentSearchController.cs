using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using Microsoft.AspNetCore.Mvc;
using SearchMicroserviceApi.Service;

namespace SearchMicroserviceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentSearchController : ControllerBase
    {
        private AppointmentSearchService appointmentSearchService;
        public AppointmentSearchController(MyDbContext context)
        {
            appointmentSearchService = new AppointmentSearchService();
        }

        /// <summary> This method is calling <c>RegularAppointmentService</c> to get list of all patient <c>DoctorAppointment</c> that matches search dto. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object that contains <c>DoctorNameAndSurname</c>, <c>Start</c>, <c>End</c>, <c>AppointmentType</c>, <c>PatientId</c> and will be used for filtering appointments. 
        /// </param>
        /// <returns> 200 Ok with list of filtered patient appointments. </returns>
        [HttpPost("search")]
        public async Task<IActionResult> SimpleSearchAppointmentsAsync(AppointmentReportSearchDto dto)
        {
            return Ok(new AppointmentAdapter().ConvertAppointmentListToAppointmentDtoList(await appointmentSearchService.SimpleSearchAppointmentsAsync(dto)));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to get list of all <c>DoctorAppointment</c> that matches <c>Appointment dto</c>. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object of a <c>DoctorAppointment</c> that contains <c>Doctor</c>, <c>Date</c>, <c>Room</c> and will be used for filtering appointments. 
        /// </param>
        /// <returns> 200 Ok with list of filtered appointments. </returns>
        [HttpPost("advancedsearch")]
        public async Task<IActionResult> AdvancedSearchAppointmentsAsync(AppointmentAdvancedSearchDto dto)
        {
            return Ok(await appointmentSearchService.AdvancedSearchAppointmentsAsync(dto));
        }
    }
}
