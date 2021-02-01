using System;
using UrgentMedicineOrderApi.DbContextModel;

namespace UrgentMedicineOrderApi.AbstractFactory
{
    public abstract class AbstractFactory
    {
        public abstract IPharmacy GetIPharmacy(MyDbContext context);
    }
}
