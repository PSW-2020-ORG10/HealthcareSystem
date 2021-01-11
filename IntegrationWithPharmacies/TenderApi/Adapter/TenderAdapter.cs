using TenderApi.Dto;
using TenderApi.Model;

namespace TenderApi.Adapter
{
    public class TenderAdapter
    {
        public static Tender TenderDtoToTender(TenderDto dto)
        {
            return new Tender(dto.ExpirationDate, dto.Closed);
        }

        public static TenderDto TenderToTenderDto(Tender tender)
        {
            return new TenderDto(tender.ExpirationDate, tender.Closed);
        }
    }
}
