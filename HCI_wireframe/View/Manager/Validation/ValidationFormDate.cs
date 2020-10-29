using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp2.Validation

{
    class ValidationFormDate : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {


            try
            {
                var s = value as string;
             

                Regex regex1 = new Regex(@"^\s*(3[01]|[12][0-9]|0?[1-9])\/(1[012]|0?[1-9])\/((?:19|20)\d{2})\s*$");

                if (regex1.IsMatch(s))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Please enter a valid date(DD/MM/YYYY).");



            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");

            }
        }
    }
}
