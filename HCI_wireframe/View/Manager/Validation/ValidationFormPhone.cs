using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp2.Validation
{
    class ValidationFormPhone : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            

            try
            {
                var s = value as string;


                Regex regex1 = new Regex(@"^([0-9]+)$");

                if (regex1.IsMatch(s))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Please enter a valid phone number.");



            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");

            }
        }
    }




    
}
