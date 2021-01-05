using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Adapters
{
   public class PharmacyTenderOfferAdapter
    {
        public static PharmacyTenderOffer PharmacyTenderOfferDtoToPharmacyTenderOffer(PharmacyTenderOfferDto dto)
        {
            return new PharmacyTenderOffer(dto.PharmacyApi, dto.IsWinner, dto.TenderId);
        }

        public static PharmacyTenderOfferDto PharmacyTenderOfferToPharmacyTenderOfferDto(PharmacyTenderOffer pharmacyTenderOffer)
        {
            return new PharmacyTenderOfferDto(pharmacyTenderOffer.PharmacyApi, pharmacyTenderOffer.IsWinner, pharmacyTenderOffer.TenderId);
        }

        public static PharmacyTenderOffer PharmacyTenderOrdedDtoToPharmacyTenderOffer(TenderOrder tenderOrder)
        {
            return new PharmacyTenderOffer(tenderOrder.PharmacyApi, false,tenderOrder.Id);
        }
    }
}
