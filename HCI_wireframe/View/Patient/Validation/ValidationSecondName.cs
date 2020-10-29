using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace HCI_wireframe.Validation
{


    public class ValidationSecondName : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                var s = value as string;

                Regex regex = new Regex(@"^([A-Z][a-zA-Z]+)$");

                if (regex.IsMatch(s))
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Please enter a valid secondname.");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
}
