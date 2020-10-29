using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjekatHCI.Validacija
{
  public  class ValidacijaBrTel : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            try
            {
                var s = value as string;
                Regex regex = new Regex(@"^([0-9]+)$");

                if (regex.IsMatch(s))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Molimo Vas da unesete validnu vrednost.");

            }
            catch
            {
                return new ValidationResult(false, "Doslo je do nepoznate greske.");
            }
        }
    }
}
