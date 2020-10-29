using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace HCI_wireframe.View.Doktor
{
    class ValidacijaRaci : ValidationRule

    {


        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;

                Regex regex = new Regex(@"^[šŠđĐčČćĆžŽa-zA-Z_' ']+$");

                if (regex.IsMatch(s))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Molimo Vas da unesete tacna slova.");

            }
            catch
            {
                return new ValidationResult(false, "Doslo je do nepoznate greske.");
            }
        }
    }
}
