using System;

namespace TenderApi.Model
{
    public class MedicineTenderOffer : Entity
    {
        public String MedicineName { get; set; }
        public int RequiredQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        public double Price { get; set; }
        public int PharmacyTenderOfferId { get; set; }
        public MedicineTenderOffer() { }

        public MedicineTenderOffer(int id, String medicineName, int requiredQuantity) : base(id)
        {
            MedicineName = medicineName;
            RequiredQuantity = requiredQuantity;
            AvailableQuantity = 0;
            Price = 0.0;
            PharmacyTenderOfferId = 0;
        }
        public MedicineTenderOffer(int id, String medicineName, int requiredQuantity, int availableQuantity, double price, int pharmacyTenderOfferId) : base(id)
        {
            MedicineName = medicineName;
            RequiredQuantity = requiredQuantity;
            AvailableQuantity = availableQuantity;
            Price = price;
            PharmacyTenderOfferId = pharmacyTenderOfferId;
        }
        public MedicineTenderOffer(String medicineName, int requiredQuantity)
        {
            MedicineName = medicineName;
            RequiredQuantity = requiredQuantity;
            AvailableQuantity = 0;
            Price = 0.0;
            PharmacyTenderOfferId = 0;
        }
        public MedicineTenderOffer(String medicineName, int requiredQuantity, int availableQuantity, double price, int pharmacyTenderOfferId)
        {
            MedicineName = medicineName;
            RequiredQuantity = requiredQuantity;
            AvailableQuantity = availableQuantity;
            Price = price;
            PharmacyTenderOfferId = pharmacyTenderOfferId;
        }
    }
}
