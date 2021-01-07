using MedicineInformationApi.DbContextModel;
using MedicineInformationApi.Service;
using Microsoft.AspNetCore.Mvc;

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
    }
}
