using System;
using System.Collections.Generic;
using System.Text;
using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;

namespace HealthClinic.CL.Service
{
    public class TenderService: ITenderService
    {
        public TenderRepository TenderRepository { get; }
        public ITenderRepository ITenderRepository { get; }
        public TenderService() { }

        public TenderService(MyDbContext context)
        {
            TenderRepository = new TenderRepository(context);
        }

        public Tender Create(TenderDto dto)
        {
            return TenderRepository.Create(TenderAdapter.TenderDtoToTender(dto));
        }
        public TenderService(ITenderRepository tenderRepository)
        {
            ITenderRepository = tenderRepository;
        }

        public List<Tender> GetAll()
        {
            return TenderRepository.GetAll();
        }
    }
}
