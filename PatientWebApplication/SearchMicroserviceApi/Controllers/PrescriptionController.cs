using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SearchMicroserviceApi.Adapters;
using SearchMicroserviceApi.DbContextModel;
using SearchMicroserviceApi.Dtos;
using SearchMicroserviceApi.Repository;
using SearchMicroserviceApi.Service;

namespace SearchMicroserviceApi.Controllers
{
    /// <summary>Class <c>FeedbackController</c> handles requests sent from client app.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        /// <value>Property <c>PrescriptionService</c> represents the service used for handling business logic.</value>
        private PrescriptionService PrescriptionService { get; set; }
        private MyDbContext dbContext;

        public PrescriptionController(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
            PrescriptionService = new PrescriptionService(new PrescriptionRepository(dbContext));
        }

        /// <summary> This method is calling <c>PrescriptionService</c> to get list of all <c>Prescription</c>.  </summary>
        /// <returns> 200 Ok with list of all prescriptions. </returns>
        [HttpGet]       // GET /api/prescription
        [Authorize(Roles = "admin")]
        public IActionResult Get()
        {
            return Ok(MicroservicePrescriptionAdapter.PrescriptionListToMicroservicePrescriptionDtoList(PrescriptionService.GetAll()));
        }

        /// <summary> This method is calling <c>PrescriptionService</c> to get list of all patient <c>Prescription</c>. </summary>
        /// <returns> 200 Ok with list of all patient prescriptions. </returns>
        [HttpGet("patient/{id}")]       // GET /api/prescription/patient
        [Authorize(Roles = "patient")]
        public IActionResult GetPrescriptionsForPatient(int id)
        {
            return Ok(MicroservicePrescriptionAdapter.PrescriptionListToMicroservicePrescriptionDtoList(PrescriptionService.GetPrescriptionsForPatient(id))); 
        }

        /// <summary> This method is calling <c>PrescriptionService</c> to get list of all patient <c>Prescription</c> that matches <c>Prescription dto</c>. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object of a <c>Prescription</c> that contains <c>Medicines</c>, <c>IsUsed</c>, <c>Comment</c>, <c>Doctor</c> and will be used for filtering prescriptions. 
        /// </param>
        /// <returns> 200 Ok with list of filtered patient prescriptions. </returns>
        [HttpPost("search")]
        [Authorize(Roles = "patient")]
        public IActionResult SimpleSearchPrescriptions(PrescriptionSearchDto dto)
        {
            return Ok(MicroservicePrescriptionAdapter.PrescriptionListToMicroservicePrescriptionDtoList(PrescriptionService.SimpleSearchPrescriptions(dto)));
        }

        [HttpPost("advancedsearch")]
        [Authorize(Roles = "patient")]
        public IActionResult AdvancedSearchPrescriptions(PrescriptionAdvancedSearchDto dto)
        {
            return Ok(MicroservicePrescriptionAdapter.PrescriptionListToMicroservicePrescriptionDtoList(PrescriptionService.AdvancedSearchPrescriptions(dto)));
        }
    }
}
