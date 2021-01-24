using EPrescriptionApi.DbContextModel;

namespace EPrescriptionApi.AbstractFactory
{
    public class PharmacyFactoryGrpcAndSftp : AbstractFactory
    {
        public override IPharmacy GetIPharmacy(MyDbContext context)
        {
            return new PharmacyGrpcSftp(context);
        }
    }
}
