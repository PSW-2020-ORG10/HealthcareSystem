using MedicineInformationApi.Model;

namespace MedicineInformationApi.Dto
{
    public class MedicineInformationDto
    {
        public virtual MedicineDescription MedicineDescription { get; set; }
        public int Quantity { get; set; }

        public MedicineInformationDto() { }
        public MedicineInformationDto(MedicineDescription medicineDescription, int quantity) 
        {
            MedicineDescription = medicineDescription;
            Quantity = quantity;
        }
  
    }
}
