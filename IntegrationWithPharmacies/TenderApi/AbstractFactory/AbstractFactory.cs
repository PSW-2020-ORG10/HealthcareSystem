using System;
using TenderApi.DbContextModel;

namespace TenderApi.AbstractFactory
{
    public abstract class AbstractFactory
    {
        public abstract IPharmacy GetIPharmacy(MyDbContext context);
    }
}
