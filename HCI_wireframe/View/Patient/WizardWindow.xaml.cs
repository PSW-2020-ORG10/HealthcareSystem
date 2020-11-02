using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HCI_wireframe.View.Patient
{
    /// <summary>
    /// Interaction logic for WizardWindow.xaml
    /// </summary>
    public partial class WizardWindow : Window
    {
        public static int number = 0;

        public string NextPage { get; private set; }

        public WizardWindow()
        {
            InitializeComponent();
           /* if (FirstNameTextBox.Text.Equals("") || SecondNameTextBox.Text.Equals("") || UCINTextBox.Text.Equals("") ||
               MedicalidTextBox.Text.Equals("") || DateTextBox.Text.Equals("") || CountryTextBox.Text.Equals("") ||
               CountryCodeTextBox.Text.Equals("") || CityTextBox.Text.Equals("") || CountryCodeTextBox.Text.Equals("") ||
              PhoneTextBox.Text.Equals("") || EmailTextBox.Text.Equals("") || PasswordTextBox.Text.Equals("") ||
              ConfirmPasswordTextBox.Text.Equals(""))
            {
                Page1.CanSelectNextPage = false;
            }
            else
            {
                Page1.CanSelectNextPage = true;
            }*/
        }

        private void FirstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(FirstNameTextBox.Text))
            {
                Page1.CanSelectNextPage = false;
            }
            else
            { number++; }
            if (number >= 13)
            {
                Page1.CanSelectNextPage = true;
            }
            
        }

        private void SecondNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(SecondNameTextBox.Text))
            {
                Page1.CanSelectNextPage = false;
            }
            else
            { number++; }
            if (number >=13)
            {
                Page1.CanSelectNextPage = true;
            }
        }

        private void UCINTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(UCINTextBox.Text))
            {
                Page1.CanSelectNextPage = false;
            }
            else
            { number++; }
            if (number >= 13)
            {
                Page1.CanSelectNextPage = true;
            }
        }

        private void MedicalidTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(MedicalidTextBox.Text))
            {
                Page1.CanSelectNextPage = false;
            }
            else
            { number++; }
            if (number >= 13)
            {
                Page1.CanSelectNextPage = true;
            }
        }

        private void DateTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(DateTextBox.Text))
            {
                Page1.CanSelectNextPage = false;
            }
            else
            { number++; }
            if (number >= 13)
            {
                Page1.CanSelectNextPage = true;
            }
        }

        private void CountryTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(CountryTextBox.Text))
            {
                Page1.CanSelectNextPage = false;
            }
            else
            { number++; }
            if (number >= 13)
            {
                Page1.CanSelectNextPage = true;
            }
        }

        private void CountryCodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(CountryCodeTextBox.Text))
            {
                Page1.CanSelectNextPage = false;
            }
            else
            { number++; }
            if (number >= 13)
            {
                Page1.CanSelectNextPage = true;
            }

        }

        private void CityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(CityTextBox.Text))
            {
                Page1.CanSelectNextPage = false;
            }
            else
            { number++; }
            if (number >= 13)
            {
                Page1.CanSelectNextPage = true;
            }
        }

        private void CityCodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(CityCodeTextBox.Text))
            {
                Page1.CanSelectNextPage = false;
            }
            else
            { number++; }
            if (number >= 13)
            {
                Page1.CanSelectNextPage = true;
            }

        }

        private void PhoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(PhoneTextBox.Text))
            {
                Page1.CanSelectNextPage = false;
            }
            else
            { number++; }
            if (number >= 13)
            {
                Page1.CanSelectNextPage = true;
            }
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(EmailTextBox.Text))
            {
                Page1.CanSelectNextPage = false;
            }
            else
            { number++; }
            if (number >= 13)
            {
                Page1.CanSelectNextPage = true;
            }
        }

        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(PasswordTextBox.Text))
            {
                Page1.CanSelectNextPage = false;
            }
            else
            { number++; }
            if (number >= 13)
            {
                Page1.CanSelectNextPage = true;
            }
        }

        private void ConfirmPasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(ConfirmPasswordTextBox.Text))
            {
                Page1.CanSelectNextPage = false;
            }
            else
            { number++; }
            if (number >= 13)
            {
                Page1.CanSelectNextPage = true;
            }
        }

        private void AllergicTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(AllergicTextBox.Text))
            {
                number++;
                // Page1.CanSelectNextPage = false;
            }
           
            if (number >= 13)
            {
                Page1.CanSelectNextPage = true;
            }
        }

    
    }
}
