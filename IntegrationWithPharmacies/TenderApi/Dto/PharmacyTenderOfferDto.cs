using System;

namespace TenderApi.Dto
{
    public class PharmacyTenderOfferDto
    {
        public String PharmacyName { get; set; }
        public Boolean IsWinner { get; set; }
        public int TenderId { get; set; }
        public PharmacyTenderOfferDto() { }

        public PharmacyTenderOfferDto(String pharmacyName)
        {
            PharmacyName = pharmacyName;
            IsWinner = false;
            TenderId = 0;
        }
        public PharmacyTenderOfferDto(String pharmacyName, Boolean isWinner, int tenderId)
        {
            PharmacyName = pharmacyName;
            IsWinner = isWinner;
            TenderId = tenderId;
        }
    }
}
