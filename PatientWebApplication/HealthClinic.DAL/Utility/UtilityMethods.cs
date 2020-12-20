using Castle.Core.Internal;
using HealthClinic.CL.Model.Doctor;
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

        public static Boolean CheckIfStringsMatch(String string1, String string2)
        {
            return string1.Equals(string2);
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

        public static Boolean CheckForSpecialty(DoctorUser doctor, string specialty)
        {
            return doctor.speciality.Equals(specialty);
        }

        public static Boolean TryParseTimeSpanInCorrectFormat(String timeSpan)
        {
            var time = new TimeSpan();
            return TimeSpan.TryParseExact(timeSpan, "hh:\\mm\\:ss", CultureInfo.InvariantCulture, out time);
        }
    }
}
