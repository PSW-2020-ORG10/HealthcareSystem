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
        private MedicineInformationService MedicineInformationService { get; }

        public MedicineWithQuantityController(MyDbContext context)
        {
            MedicineInformationService = new MedicineInformationService(context);
        }

        [HttpPut("{medicine}")]
        public IActionResult UpdateMedicineQuantity(String medicine)
        {
            MedicineInformationService.UpdateMedicineQuantityUrgentOrder(medicine);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(MedicineInformationService.GetAll());
        }

        [HttpPost]
        public IActionResult Post(MedicineInformationDto dto)
        {
            MedicineInformationService.CreateMedicineWithDescription(dto);
            return Ok();
        }
        [HttpGet("{medicineId}/{quantity}")]
        public IActionResult UpdateMedicineQuantity(int medicineId, int quantity)
        {
            MedicineInformationService.UpdateQuantity(medicineId, quantity);
            return Ok();
        }

        [HttpGet("description/{medicine}")]
        public IActionResult GetMedicineDescription(String medicine)
        {
            return Ok(MedicineInformationService.GetMedicineDescriptionFromDatabase(medicine));
        }
        [HttpGet("all")]
        public IActionResult GetMedicineNames()
        {
            return Ok(MedicineInformationService.GetAllMedicinesFromDatabase());
        }
    }
}
