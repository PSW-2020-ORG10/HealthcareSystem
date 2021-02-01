

using TenderApi.DbContextModel;

namespace TenderApi.AbstractFactory
{
    public class PharmacyFactoryHttp : AbstractFactory
    {
        public override IPharmacy GetIPharmacy(MyDbContext context)
        {
            return new PharmacyHttp(context);
        }

    }
}
