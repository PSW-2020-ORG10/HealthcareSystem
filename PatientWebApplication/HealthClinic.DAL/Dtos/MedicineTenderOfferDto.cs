using System;

namespace HealthClinic.CL.Dtos
{
    public class MedicineTenderOfferDto
    {
        public String MedicineName { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public double Price { get; set; }
        public int PharmacyTenderOfferId { get; set; }
        public MedicineTenderOfferDto() { }

        public MedicineTenderOfferDto(String medicineName, int quantity, int availableQuantity, double price, int pharmacyTenderOfferId)
        {
            MedicineName = medicineName;
            Quantity = quantity;
            AvailableQuantity = availableQuantity;
            Price = price;
            PharmacyTenderOfferId = pharmacyTenderOfferId;
        }
    }
}
