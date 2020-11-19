using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies.IPharmacies
{
    interface IPharmacyType2 : IPharmacy
    {
        public void openTender();
        public void notifyPharmacy();
    }
}
