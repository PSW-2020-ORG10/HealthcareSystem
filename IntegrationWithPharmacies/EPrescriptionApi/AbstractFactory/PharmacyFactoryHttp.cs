using EPrescriptionApi.DbContextModel;
using System;

namespace EPrescriptionApi.AbstractFactory
{
    public class PharmacyFactoryHttp : AbstractFactory
    {
        public override IPharmacy GetIPharmacy(MyDbContext context)
        {
            return new PharmacyHttp(context);
        }

    }
}
