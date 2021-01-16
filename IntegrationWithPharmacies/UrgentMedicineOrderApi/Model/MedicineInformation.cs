
namespace UrgentMedicineOrderApi.Model
{
    public class MedicineInformation : Entity
    {
        public virtual MedicineDescription MedicineDescription { get; set; }
        public int Quantity { get; set; }

        public MedicineInformation() : base() { }
        public MedicineInformation(int id, MedicineDescription medicineDescription, int quantity) : base(id)
        {
            MedicineDescription = medicineDescription;
            Quantity = quantity;
        }
        public MedicineInformation(int id, int quantity) : base(id)
        {
            Quantity = quantity;
        }
        public MedicineInformation(MedicineDescription medicineDescription, int quantity)
        {
            MedicineDescription = medicineDescription;
            Quantity = quantity;
        }

    }
}
