using System;

namespace TenderApi.Model
{
    public class MedicineTenderOffer : Entity
    {
        public String MedicineName { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public double Price { get; set; }
        public int PharmacyTenderOfferId { get; set; }
        public MedicineTenderOffer() { }

        public MedicineTenderOffer(int id, String medicineName, int quantity) : base(id)
        {
            MedicineName = medicineName;
            Quantity = quantity;
            AvailableQuantity = 0;
            Price = 0.0;
            PharmacyTenderOfferId = 0;
        }
        public MedicineTenderOffer(int id, String medicineName, int quantity, int availableQuantity, double price, int pharmacyTenderOfferId) : base(id)
        {
            MedicineName = medicineName;
            Quantity = quantity;
            AvailableQuantity = availableQuantity;
            Price = price;
            PharmacyTenderOfferId = pharmacyTenderOfferId;
        }
        public MedicineTenderOffer(String medicineName, int quantity)
        {
            MedicineName = medicineName;
            Quantity = quantity;
            AvailableQuantity = 0;
            Price = 0.0;
            PharmacyTenderOfferId = 0;
        }
        public MedicineTenderOffer(String medicineName, int quantity, int availableQuantity, double price, int pharmacyTenderOfferId)
        {
            MedicineName = medicineName;
            Quantity = quantity;
            AvailableQuantity = availableQuantity;
            Price = price;
            PharmacyTenderOfferId = pharmacyTenderOfferId;
        }
    }
}
