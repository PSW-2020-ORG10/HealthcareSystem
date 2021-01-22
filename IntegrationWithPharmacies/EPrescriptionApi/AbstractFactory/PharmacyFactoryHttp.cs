﻿

using EPrescriptionApi.DbContextModel;

namespace EPrescriptionApi.AbstractFactory
{
    public class PharmacyFactoryHttp : AbstractFactory
    {
        public override IPharmacy GetIPharmacy(string url, MyDbContext context)
        {
            return new PharmacyHttp(url, context);
        }

    }
}