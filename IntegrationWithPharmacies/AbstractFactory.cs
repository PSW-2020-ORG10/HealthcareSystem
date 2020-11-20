using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies
{
    public abstract class AbstractFactory
    {
        public abstract IPharmacy getIPharmacy(String pharmacyApiKey);
    }
}
