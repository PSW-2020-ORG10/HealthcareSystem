using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Adapters
{
    public class MedicineTenderOfferAdapter
    {
        public static MedicineTenderOffer MedicineTenderOfferDtoToMedicineTenderOffer(MedicineTenderOfferDto dto)
        {
            return new MedicineTenderOffer(dto.MedicineName, dto.Quantity, dto.AvailableQuantity, dto.Price, dto.PharmacyTenderOfferId);
        }

        public static MedicineTenderOfferDto MedicineTenderOfferToMedicineTenderOfferDto(MedicineTenderOffer medicine)
        {
            return new MedicineTenderOfferDto(medicine.MedicineName, medicine.Quantity, medicine.AvailableQuantity, medicine.Price, medicine.PharmacyTenderOfferId);
        }
    }
}
