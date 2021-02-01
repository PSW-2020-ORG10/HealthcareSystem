using System;
using System.Collections.Generic;
using UrgentMedicineOrderApi.Service;
using UrgentMedicineOrderApi.DbContextModel;
using UrgentMedicineOrderApi.Model;
using UrgentMedicineOrderApi.Adapter;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace UrgentMedicineOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrgentOrderController : Controller
    {
        private UrgentOrderService UrgentOrderService { get; }

        public UrgentOrderController(MyDbContext context)
        {
            UrgentOrderService = new UrgentOrderService(context);
        }

        [HttpGet("{medicine}")]
        public IActionResult FormUrgentOrder(String medicine)
        {
            return Ok(UrgentOrderService.FormUrgentOrder(medicine));
        }
      
    }
}
