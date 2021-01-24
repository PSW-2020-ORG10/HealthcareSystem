using EPrescriptionApi.DbContextModel;
using System;

namespace EPrescriptionApi.AbstractFactory
{
    public class PharmacyFactoryHttp : AbstractFactory
    {
        public override IPharmacy GetIPharmacy(MyDbContext context)
        {
            Console.WriteLine("OVDE SAM GAAAAAAAAAAAAAAAAAAAAAA");
            return new PharmacyHttp(context);
        }

    }
}
