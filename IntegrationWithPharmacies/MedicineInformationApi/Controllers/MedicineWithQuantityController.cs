using MedicineInformationApi.DbContextModel;
using MedicineInformationApi.Dto;
using MedicineInformationApi.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MedicineInformationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineWithQuantityController : ControllerBase
    {  
        private MedicineWithQuantityService MedicineWithQuantityService { get; }

        public MedicineWithQuantityController(MyDbContext context)
        {
            MedicineWithQuantityService = new MedicineWithQuantityService(context);
        }

        [HttpPut("{medicine}")]
        public IActionResult UpdateMedicineQuantity(String medicine)
        {
            MedicineWithQuantityService.UpdateMedicineQuantityUrgentOrder(medicine);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(MedicineWithQuantityService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(MedicineWithQuantityDto dto)
        {
            MedicineWithQuantityService.CreateMedicineWithDescription(dto);
            return Ok();
        }
        [HttpGet("{medicineId}/{quantity}")]
        public IActionResult UpdateMedicineQuantity(int medicineId, int quantity)
        {
            MedicineWithQuantityService.UpdateQuantity(medicineId, quantity);
            return Ok();
        }

        [HttpGet("description/{medicine}")]
        public IActionResult GetMedicineDescription(String medicine)
        {
            return Ok(MedicineWithQuantityService.GetMedicineDescriptionFromDatabase(medicine));
        }
    }
}
