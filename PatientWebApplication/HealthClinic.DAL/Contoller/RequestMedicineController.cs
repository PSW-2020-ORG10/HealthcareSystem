using System.Collections.Generic;
using HealthClinic.CL.Model.Hospital;
using HealthClinic.CL.Service;

namespace HealthClinic.CL.Contoller
{
    class RequestMedicineController : IController<Medicine>
    {
        public RequestMedicineService medicineService;

        public RequestMedicineController()
        {
            medicineService = new RequestMedicineService();
        }
      
        public void New(Medicine medicine)
        {
           medicineService.New(medicine);
        }
        public void Update(Medicine medicine)
        {
        }
        public void Remove(Medicine medicine)
        {
            medicineService.Remove(medicine);
        }
       
        public List<Medicine> GetAll()
        {
           return medicineService.GetAll();
        }

        public Medicine GetByid(int id)
        {
            return medicineService.GetByid(id);
        }
    }
}