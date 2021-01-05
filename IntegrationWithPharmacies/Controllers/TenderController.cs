using System;
using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Service;
using IntegrationWithPharmacies.FileProtocol;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationWithPharmacies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private TenderService TenderService { get; }
        private MedicineForTenderingService MedicineForTenderingService { get; }
        private MedicineTenderOfferService MedicineTenderOfferService { get; }
        private PharmacyTenderOfferService PharmacyTenderOfferService { get; }
        private MedicineWithQuantityService MedicineWithQuantityService { get; }
        private SmptServerService SmptServerService { get; }
        public TenderController(MyDbContext context)
        {
            MedicineForTenderingService = new MedicineForTenderingService(context);
            TenderService = new TenderService(context);
            MedicineTenderOfferService = new MedicineTenderOfferService(context);
            PharmacyTenderOfferService = new PharmacyTenderOfferService(context);
            SmptServerService = new SmptServerService();
            MedicineWithQuantityService = new MedicineWithQuantityService(context);
        }

        [HttpPost]
        public IActionResult Post(TenderOrder tender)
        {
            TenderService.Create(TenderAdapter.TenderToTenderDto(new Tender(DateTime.Parse(tender.Date), false)));
            MedicineForTenderingService.CreateAllMedicineForTendering(tender);
            return Ok();
        }

        [HttpGet("active")]
        public IActionResult GetActiveTenders()
        {
            return Ok(TenderService.GetAllActiveTenders());
        }

        [HttpGet("{id}")]
        public IActionResult GetTenderById(String id)
        {
            return Ok(TenderService.GetTenderById(Int32.Parse(id)));
        }

        [HttpPost("offer")]
        public IActionResult RecieveTenderOffer(TenderOrder tenderOrder)
        {
            PharmacyTenderOfferService.CreateFromTenderOrder(tenderOrder);
            MedicineTenderOfferService.CreateAllMedicineTenderOffers(tenderOrder.MedicinesWithQuantity);
            return Ok();
        }

        [HttpGet("allPharmacyOffers/{id}")]
        public IActionResult GetPharmacyOffers(int id)
        {
            return Ok(PharmacyTenderOfferService.GetAllPharmacyOffersForTender(id));
        }

        [HttpGet("pharmacyOffer/{offerId}/{tenderId}")]
        public IActionResult GetConcretePharmacyOffer(int offerId, int tenderId)
        {
            return Ok(PharmacyTenderOfferService.GetPharmacyOffer(offerId,tenderId));
        }

        [HttpGet("acceptOffer/{offerId}/{tenderId}")]
        public IActionResult AcceptPharmacyOffer(int offerId, int tenderId)
        { TenderOrder tender = PharmacyTenderOfferService.GetPharmacyOffer(offerId, tenderId);
            SmptServerService.SendEMailNotificationForTender(tender.MedicinesWithQuantity, tender.PharmacyApi);
            TenderService.CloseTender(tender);
            MedicineWithQuantityService.UpdateMedicineQuantity(offerId);
            return Ok();
        }      
    }
}