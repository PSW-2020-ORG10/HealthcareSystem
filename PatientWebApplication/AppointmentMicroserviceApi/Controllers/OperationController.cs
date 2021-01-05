using AppointmentMicroserviceApi.Adapters;
using AppointmentMicroserviceApi.Dtos;
using AppointmentMicroserviceApi.Repository;
using AppointmentMicroserviceApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentMicroservice.Controller
{
    /// <summary>Class <c>OperationController</c> handles requests sent from client app.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        /// <value>Property <c>OperationService</c> represents the service used for handling business logic.</value>
        private OperationService operationService;
        private MyDbContext dbContext;

        public OperationController(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
            operationService = new OperationService(new OperationRepository(dbContext));
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(operationService.GetAll());
        }

        /// <summary> This method is calling <c>OperationService</c> to get list of all operations of one patient. </summary>
        /// <returns> 200 Ok with list of patient's operations. </returns>
        [HttpGet("{id}")]
        public IActionResult GetOperations(int id)
        {
            return Ok(new OperationAdapter().ConvertOperationListToOperationDtoList(operationService.GetOperationsForPatient(id)));
        }

        /// <summary> This method is calling <c>OperationService</c> to get list of all patient <c>Operation</c> that matches search dto. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object that contains <c>DoctorNameAndSurname</c>, <c>Start</c>, <c>End</c>, <c>AppointmentType</c>, <c>PatientId</c> and will be used for filtering operations. 
        /// </param>
        /// <returns> 200 Ok with list of filtered patient operations. </returns>
        [HttpPost("search")]
        public IActionResult SimpleSearchOperations(AppointmentReportSearchDto dto)
        {
            return Ok(new OperationAdapter().ConvertOperationListToOperationDtoList(operationService.SimpleSearchOperations(dto)));
        }

        [HttpGet("operationsForDoctor/{doctorId}")]
        public IActionResult DoesDoctorHaveAnAppointmentAtSpecificTime(int doctorId)
        {
            return Ok(operationService.GetOperationsForDoctor(doctorId));
        }
    }
}
