using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HealthClinic.CL.Utility
{
    public static class UtilityMethods
    {
        public static Boolean CheckIfStringIsEmpty(String stringToCheck)
        {
            return stringToCheck.IsNullOrEmpty();
        }

        public static DateTime ParseDateInCorrectFormat(String dateString)
        {
            return DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public static Boolean TryParseDateInCorrectFormat(String dateString)
        {
            var date = new DateTime();
            return DateTime.TryParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }
    }
}
