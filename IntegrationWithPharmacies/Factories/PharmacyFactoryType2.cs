using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies.Factories
{
    public class PharmacyFactoryType2 : AbstractFactory
    {
        public override IPharmacy getIPharmacy(string pharmacyApiKey)
        {
            throw new NotImplementedException();
        }
    }
}
