using System;
using System.Collections.Generic;
using System.Text;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Adapters
{
    public class TenderAdapter
    {
        public static Tender TenderDtoToTender(TenderDto dto)
        {
            return new Tender(dto.ActiveUntil,dto.Closed);
        }

        public TenderDto TenderToTenderDto(Tender tender)
        {
            return new TenderDto(tender.ActiveUntil,tender.Closed);
        }

    }
}
