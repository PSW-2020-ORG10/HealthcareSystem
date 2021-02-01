using MedicineInformationApi.Dto;
using MedicineInformationApi.Model;

namespace MedicineInformationApi.Adapter
{
    public class MedicineInformationAdapter
    {
        public static MedicineInformation MedicineWithQuantityDtoToMedicineWithQuantity(MedicineInformationDto dto)
        {
            return new MedicineInformation(dto.MedicineDescription, dto.Quantity);
        }

        public static MedicineInformationDto MedicineWithQuantityToMedicineWithQuantityDto(MedicineInformation medicine)
        {
            return new MedicineInformationDto(medicine.MedicineDescription, medicine.Quantity);
        }
    }
}
