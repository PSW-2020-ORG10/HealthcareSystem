using System;
using TenderApi.DbContextModel;

namespace TenderApi.AbstractFactory
{
    public abstract class AbstractFactory
    {
        public abstract IPharmacy GetIPharmacy(String url, MyDbContext context);
    }
}
