using System;

namespace TenderApi.Model
{
    public class PharmacyTenderOffer : Entity
    {
        public String PharmacyName { get; set; }
        public Boolean IsWinner { get; set; }
        public int TenderId { get; set; }
        public PharmacyTenderOffer() { }

        public PharmacyTenderOffer(int id, String pharmacyName) : base(id)
        {
            PharmacyName = pharmacyName;
            IsWinner = false;
            TenderId = 0;
        }
        public PharmacyTenderOffer(int id, String pharmacyName, Boolean isWinner, int tenderId) : base(id)
        {
            PharmacyName = pharmacyName;
            IsWinner = isWinner;
            TenderId = tenderId;
        }
        public PharmacyTenderOffer(String pharmacyName, Boolean isWinner, int tenderId)
        {
            PharmacyName = pharmacyName;
            IsWinner = isWinner;
            TenderId = tenderId;
        }
    }
}
