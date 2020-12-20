using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.CL.Adapters;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using Microsoft.AspNetCore.Mvc;

namespace PatientWebApplication.Controllers
{
    /// <summary>Class <c>OperationController</c> handles requests sent from client app.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : Controller
    {
        /// <value>Property <c>OperationService</c> represents the service used for handling business logic.</value>
        private OperationService operationService;

        /// <summary>This constructor initiates the OperationController's operation service.</summary>
        public OperationController()
        {
            this.operationService = new OperationService(new OperationRepository());
        }

        /// <summary> This method is calling <c>OperationService</c> to get list of all operations of one patient. </summary>
        /// <returns> 200 Ok with list of patient's operations. </returns>
        [HttpGet("{id}")]
        public IActionResult GetOperations(int id)
        {
            return Ok(new OperationAdapter().ConvertOperationListToOperationDtoList(this.operationService.GetOperationsForPatient(id)));
        }

        /// <summary> This method is calling <c>OperationService</c> to get list of all patient <c>Operation</c> that matches search dto. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object that contains <c>DoctorNameAndSurname</c>, <c>Start</c>, <c>End</c>, <c>AppointmentType</c>, <c>PatientId</c> and will be used for filtering operations. 
        /// </param>
        /// <returns> 200 Ok with list of filtered patient operations. </returns>
        [HttpPost("search")]
        public IActionResult SimpleSearchOperations(AppointmentReportSearchDto dto)
        {
            return Ok(new OperationAdapter().ConvertOperationListToOperationDtoList(this.operationService.SimpleSearchOperations(dto)));
        }
    }
}
