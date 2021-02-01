
using UrgentMedicineOrderApi.DbContextModel;

namespace UrgentMedicineOrderApi.AbstractFactory
{
    public class PharmacyFactoryGrpcAndSftp : AbstractFactory
    {
        public override IPharmacy GetIPharmacy(MyDbContext context)
        {
            return new PharmacyGrpcSftp(context);
        }
    }
}
