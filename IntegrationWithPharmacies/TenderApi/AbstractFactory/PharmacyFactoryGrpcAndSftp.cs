
using TenderApi.DbContextModel;

namespace TenderApi.AbstractFactory
{
    public class PharmacyFactoryGrpcAndSftp : AbstractFactory
    {
        public override IPharmacy GetIPharmacy(string url, MyDbContext context)
        {
            return new PharmacyGrpcSftp(url, context);
        }
    }
}
