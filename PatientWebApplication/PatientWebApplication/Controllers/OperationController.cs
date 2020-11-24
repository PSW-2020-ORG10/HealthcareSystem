using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using Microsoft.AspNetCore.Mvc;

namespace PatientWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : Controller
    {
        private OperationService operationService;
        public OperationController()
        {
            this.operationService = new OperationService(new OperationRepository());
        }

        [HttpGet("{id}")]
        public IActionResult GetOperations(int id)
        {
            return Ok(this.operationService.GetOperationsForPatient(id));
        }

        [HttpPost("search")]
        public IActionResult SimpleSearchOperations(AppointmentReportSearchDto dto)
        {
            return Ok(this.operationService.SimpleSearchOperations(dto));
        }
    }
}
