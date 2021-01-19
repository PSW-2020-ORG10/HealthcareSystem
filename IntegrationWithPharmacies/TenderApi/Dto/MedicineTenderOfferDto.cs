using System;

namespace TenderApi.Dto
{
    public class MedicineTenderOfferDto
    {
        public String MedicineName { get; set; }
        public int RequiredQuantity { get; set; }
        public int AvailableQuantity { get; set; }
        public double Price { get; set; }
        public int PharmacyTenderOfferId { get; set; }
        public MedicineTenderOfferDto() { }

        public MedicineTenderOfferDto(String medicineName, int requiredQuantity, int availableQuantity, double price, int pharmacyTenderOfferId)
        {
            MedicineName = medicineName;
            RequiredQuantity = requiredQuantity;
            AvailableQuantity = availableQuantity;
            Price = price;
            PharmacyTenderOfferId = pharmacyTenderOfferId;
        }
    }
}
