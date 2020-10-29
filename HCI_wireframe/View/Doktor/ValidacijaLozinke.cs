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
    class ValidacijaLozinke : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;
                Regex regex = new Regex(@"^.*(?=.{6,20})(?=.+\d)(?=.*[a-zA-Z]).*$");

                if (regex.IsMatch(s))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Molimo Vas da unesete lozinku koja sadrzi minimalno 6 karaktera, koja sadrzi minalno jedno slovo i broj");

            }
            catch
            {
                return new ValidationResult(false, "Doslo je do nepoznate greske.");
            }
        }
    }
}

