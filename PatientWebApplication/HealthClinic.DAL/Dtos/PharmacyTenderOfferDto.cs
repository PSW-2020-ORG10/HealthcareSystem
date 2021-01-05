using System;

namespace HealthClinic.CL.Dtos
{
    public class PharmacyTenderOfferDto
    {
        public String PharmacyApi { get; set; }
        public Boolean IsWinner { get; set; }
        public int TenderId {get;set;}
        public PharmacyTenderOfferDto() { }

        public PharmacyTenderOfferDto(String pharmacyApi) 
        {
            PharmacyApi = pharmacyApi;
            IsWinner = false;
            TenderId = 0;
        }
        public PharmacyTenderOfferDto(String pharmacyApi, Boolean isWinner,int tenderId)
        {
            PharmacyApi = pharmacyApi;
            IsWinner = isWinner;
            TenderId = tenderId;
        }
    }
}
