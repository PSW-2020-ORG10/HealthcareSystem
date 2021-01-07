using MedicineReportApi.DbContextModel;
using MedicineReportApi.Model;
using MedicineReportApi.Repository;
using System.Collections.Generic;

namespace MedicineReportApi.Service
{
    public class TenderService 
    {
        public TenderRepository TenderRepository { get; }
        public TenderService() { }

        public TenderService(MyDbContext context)
        {
            TenderRepository = new TenderRepository(context);
        }
       
        public List<Tender> GetAll()
        {
            return TenderRepository.GetAll();
        }
    }
}
