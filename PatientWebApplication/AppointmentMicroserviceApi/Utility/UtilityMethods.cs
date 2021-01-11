using Castle.Core.Internal;
using System;
using System.Globalization;

namespace AppointmentMicroserviceApi.Utility
{
    public class UtilityMethods
    {
        public static bool CheckIfStringIsEmpty(string stringToCheck)
        {
            return stringToCheck.IsNullOrEmpty();
        }

        public static bool CheckIfStringsMatch(string string1, string string2)
        {
            return string1.Equals(string2);
        }

        public static DateTime ParseDateInCorrectFormat(string dateString)
        {
            return DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public static bool TryParseDateInCorrectFormat(string dateString)
        {
            var date = new DateTime();
            return DateTime.TryParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
        }

        public static bool TryParseTimeSpanInCorrectFormat(string timeSpan)
        {
            var time = new TimeSpan();
            return TimeSpan.TryParseExact(timeSpan, "hh:\\mm\\:ss", CultureInfo.InvariantCulture, out time);
        }

        public static bool CheckIfDateIsToday(string dateString)
        {
            return ParseDateInCorrectFormat(dateString).Date == DateTime.Now.Date && ParseDateInCorrectFormat(dateString).Month == DateTime.Now.Month && ParseDateInCorrectFormat(dateString).Year == DateTime.Now.Year;
        }

        public static bool CheckIfDateIsToday(DateTime date)
        {
            return date.Date == DateTime.Now.Date && date.Month == DateTime.Now.Month && date.Year == DateTime.Now.Year;
        }
    }
}
