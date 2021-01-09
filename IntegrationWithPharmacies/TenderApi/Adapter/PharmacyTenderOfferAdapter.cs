using TenderApi.Dto;
using TenderApi.Model;

namespace TenderApi.Adapter
{
    public class PharmacyTenderOfferAdapter
    {
        public static PharmacyTenderOffer PharmacyTenderOfferDtoToPharmacyTenderOffer(PharmacyTenderOfferDto dto)
        {
            return new PharmacyTenderOffer(dto.PharmacyApi, dto.IsWinner, dto.TenderId);
        }

        public static PharmacyTenderOffer PharmacyTenderOrdedDtoToPharmacyTenderOffer(TenderOrder tenderOrder)
        {
            return new PharmacyTenderOffer(tenderOrder.PharmacyApi, false, tenderOrder.Id);
        }
    }
}
