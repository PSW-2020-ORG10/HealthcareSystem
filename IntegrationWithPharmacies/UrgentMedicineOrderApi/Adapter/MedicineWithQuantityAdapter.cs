using UrgentMedicineOrderApi.Model;
using UrgentMedicineOrderApi.Dto;

namespace UrgentMedicineOrderApi.Adapter
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
