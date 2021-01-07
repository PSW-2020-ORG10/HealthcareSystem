using MedicineReportApi.DbContextModel;
using MedicineReportApi.Model;
using MedicineReportApi.Repository;
using System.Collections.Generic;

namespace MedicineReportApi.Service
{
    public class MedicineForTenderingService
    {
        public MedicineForTenderingRepository MedicineForTenderingRepository { get; }
        public TenderService TenderService { get; }
        public MedicineForTenderingService() { }

        public MedicineForTenderingService(MyDbContext context)
        {
            MedicineForTenderingRepository = new MedicineForTenderingRepository(context);
            TenderService = new TenderService(context);
        }

        public List<MedicineForTendering> GetAll()
        {
            return MedicineForTenderingRepository.GetAll();
        }
    }
}
