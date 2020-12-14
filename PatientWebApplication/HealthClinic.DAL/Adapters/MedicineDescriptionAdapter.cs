using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Adapters
{
    public class MedicineDescriptionAdapter
    {
        public static MedicineDescription MedicineDescriptionDtoToMedicineDescription(MedicineDescriptionDto dto)
        {
            return new MedicineDescription(dto.Name, dto.Description, dto.MedicineDescriptionId);
        }

        public MedicineDescriptionDto MedicineDescriptionToMedicineDescriptionDto(MedicineDescription medicine)
        {
            return new MedicineDescriptionDto(medicine.Name, medicine.Description, medicine.MedicineDescriptionId);
        }
    }
}
