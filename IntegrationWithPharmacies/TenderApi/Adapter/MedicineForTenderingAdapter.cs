using TenderApi.Dto;
using TenderApi.Model;

namespace TenderApi.Adapter
{
    public class MedicineForTenderingAdapter
    {
        public static MedicineForTendering MedicineForTenderingDtoToMedicineForTendering(MedicineForTenderingDto dto)
        {
            return new MedicineForTendering(dto.Name, dto.Quantity, dto.TenderId);
        }

        public static MedicineForTenderingDto MedicineForebderingToMedicineForTenderingDto(MedicineForTendering medicine)
        {
            return new MedicineForTenderingDto(medicine.Name, medicine.Quantity, medicine.TenderId);
        }
    }
}
