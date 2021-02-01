﻿using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Utility
{
    public class UtilityMethods
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

        public static Boolean TryParseTimeSpanInCorrectFormat(String timeSpan)
        {
            var time = new TimeSpan();
            return TimeSpan.TryParseExact(timeSpan, "hh:\\mm\\:ss", CultureInfo.InvariantCulture, out time);
        }

        public static Boolean CheckIfDateIsToday(string dateString)
        {
            return ParseDateInCorrectFormat(dateString).Date == DateTime.Now.Date && ParseDateInCorrectFormat(dateString).Month == DateTime.Now.Month && ParseDateInCorrectFormat(dateString).Year == DateTime.Now.Year;
        }

        public static Boolean CheckIfDateIsToday(DateTime date)
        {
            return date.Date == DateTime.Now.Date && date.Month == DateTime.Now.Month && date.Year == DateTime.Now.Year;
        }

        public static Boolean CheckForSpecialty(DoctorUser doctor, string specialty)
        {
            return doctor.Speciality.Equals(specialty);
        }
    }
}
