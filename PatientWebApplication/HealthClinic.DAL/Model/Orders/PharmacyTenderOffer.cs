using HealthClinic.CL.Model.Patient;
using System;

namespace HealthClinic.CL.Model.Orders
{
    public class PharmacyTenderOffer : Entity
    {
        public String PharmacyApi { get; set; }
        public Boolean IsWinner { get; set; }
        public int TenderId { get; set; }
        public PharmacyTenderOffer() { }

        public PharmacyTenderOffer(int id, String pharmacyApi) : base(id)
        {
            PharmacyApi = pharmacyApi;
            IsWinner = false;
            TenderId = 0;
        }
        public PharmacyTenderOffer(int id, String pharmacyApi, Boolean isWinner, int tenderId) : base(id)
        {
            PharmacyApi = pharmacyApi;
            IsWinner = isWinner;
            TenderId = tenderId;
        }
        public PharmacyTenderOffer(String pharmacyApi, Boolean isWinner, int tenderId) 
        {
            PharmacyApi = pharmacyApi;
            IsWinner = isWinner;
            TenderId = tenderId;
        }
    }
}
