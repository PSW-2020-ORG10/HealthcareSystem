using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Adapters
{
    public class MedicineWithQuantityAdapter
    {
        public static MedicineWithQuantity MedicineWithQuantityDtoToMedicineWithQuantity(MedicineWithQuantityDto dto)
        {
            return new MedicineWithQuantity(dto.Name, dto.Quantity,dto.Description);
        }

        public static MedicineWithQuantityDto MedicineWithQuantityToMedicineWithQuantityDto(MedicineWithQuantity medicine)
        {
            return new MedicineWithQuantityDto(medicine.Name, medicine.Quantity,medicine.Description);
        }
    }
}
