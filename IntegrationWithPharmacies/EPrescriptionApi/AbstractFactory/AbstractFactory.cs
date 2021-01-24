using System;
using EPrescriptionApi.DbContextModel;

namespace EPrescriptionApi.AbstractFactory
{
    public abstract class AbstractFactory
    {
        public abstract IPharmacy GetIPharmacy(MyDbContext context);
    }
}
