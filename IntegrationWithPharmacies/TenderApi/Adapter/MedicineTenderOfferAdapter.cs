using TenderApi.Dto;
using TenderApi.Model;

namespace TenderApi.Adapter
{
    public class MedicineTenderOfferAdapter
    {
        public static MedicineTenderOffer MedicineTenderOfferDtoToMedicineTenderOffer(MedicineTenderOfferDto dto)
        {
            return new MedicineTenderOffer(dto.MedicineName, dto.RequiredQuantity, dto.AvailableQuantity, dto.Price, dto.PharmacyTenderOfferId);
        }

        public static MedicineTenderOfferDto MedicineTenderOfferToMedicineTenderOfferDto(MedicineTenderOffer medicine)
        {
            return new MedicineTenderOfferDto(medicine.MedicineName, medicine.RequiredQuantity, medicine.AvailableQuantity, medicine.Price, medicine.PharmacyTenderOfferId);
        }
    }
}
