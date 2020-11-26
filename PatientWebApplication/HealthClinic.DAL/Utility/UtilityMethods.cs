using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Utility
{
    public static class UtilityMethods
    {
        public static Boolean CheckIfStringIsEmpty(String stringToCheck)
        {
            return stringToCheck.IsNullOrEmpty();
        }
    }
}
