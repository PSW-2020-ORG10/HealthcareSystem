using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PatientWebApplication.Controllers
{
    /// <summary>Class <c>FeedbackController</c> handles requests sent from client app.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        /// <value>Property <c>PrescriptionService</c> represents the service used for handling business logic.</value>
        private PrescriptionService PrescriptionService { get; set; }

        /// <summary>This constructor injects the PrescriptionController with matching PrescriptionService.</summary>
        /// <param name="context"><c>context</c> is type of <c>DbContext</c>, and it's used for accessing MYSQL database.</param>
        public PrescriptionController(MyDbContext context)
        {
            PrescriptionService = new PrescriptionService(context);
        }

        /// <summary> This method is calling <c>PrescriptionService</c> to get list of all <c>Prescription</c>.  </summary>
        /// <returns> 200 Ok with list of all prescriptions. </returns>
        [HttpGet]       // GET /api/prescription
        public IActionResult Get()
        {
            return Ok(PrescriptionService.GetAll());
        }

        /// <summary> This method is calling <c>PrescriptionService</c> to get list of all patient <c>Prescription</c>. </summary>
        /// <returns> 200 Ok with list of all patient prescriptions. </returns>
        [HttpGet("patient")]       // GET /api/prescription/patient
        public IActionResult GetPrescriptionsForPatient()
        { 
            return Ok(PrescriptionService.GetPrescriptionsForPatient(1)); //idPatient set to 1 no login, change after
        }
    }
}
