using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;


namespace HealthClinic.CL.Adapters
{
    public class MedicineForOrderingAdapter
    {
        public static MedicineForOrdering MedicineOrderDtoToMedicineOrder(MedicineForOrderingDto dto)
        {
            return new MedicineForOrdering(dto.Name, dto.Quantity, dto.Description, dto.OrderId);
        }

        public MedicineForOrderingDto MedicineOrderToMedicineOrderDto(MedicineForOrdering medicine)
        {
            return new MedicineForOrderingDto(medicine.Name, medicine.Quantity, medicine.Description, medicine.OrderId);
        }

    }
}
