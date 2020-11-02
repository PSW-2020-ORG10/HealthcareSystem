using Class_diagram.Contoller;
using Class_diagram.Model.Patient;
using HCI_wireframe.Contoller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCI_wireframe.View.Patient
{
    /// <summary>
    /// Interaction logic for EditAccountxaml.xaml
    /// </summary>
    public partial class EditAccount : UserControl
    {
        string myProperty = App.Current.Properties["Patientid"].ToString();
        public PatientUser Patient { get; set; }
        public PatientController patientController;
        public EditAccount()
        {
            InitializeComponent();
            this.DataContext = this;
            Patient = new PatientUser();
            patientController = new PatientController();
            List<PatientUser> lista = patientController.GetAll();

            Patient = patientController.GetByid(int.Parse(myProperty));
            

            Firstname= Patient.firstName.ToString();
            Secondname = Patient.secondName.ToString();


            Date= Patient.dateOfBirth.ToString();
                 
            City_TextBox.Text = Patient.city.ToString();
            Phone = Patient.phoneNumber.ToString();
            Email = Patient.email.ToString();
                   
            Password_PasswordBox.Password = Patient.password.ToString();
            ConfirmPassword_PasswordBox.Password = Patient.password.ToString();
            allergieTextBox.Text = Patient.allergie.ToString();

              
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private String _email;
        private String _password;

        private String _firstaname;
        private String _secondname;
        private String _ucin;
        private String _medicalid;
        private String _date;
        private String _country;
        private String _city;
        private String _phone;
        private String _cityCode;
        private String _countryCode;
        public String CityCode
        {
            get { return _cityCode; }
            set
            {
                if (value != _cityCode)
                {
                    _cityCode = value;
                    OnPropertyChanged("CityCode");
                }
            }
        }
        public String CountryCode
        {
            get { return _countryCode; }
            set
            {
                if (value != _countryCode)
                {
                    _countryCode = value;
                    OnPropertyChanged("CountryCode");
                }
            }
        }
        public String Firstname
        {
            get { return _firstaname; }
            set
            {
                if (value != _firstaname)
                {
                    _firstaname = value;
                    OnPropertyChanged("Firstname");
                }
            }
        }
        public String Secondname
        {
            get { return _secondname; }
            set
            {
                if (value != _secondname)
                {
                    _secondname = value;
                    OnPropertyChanged("Secondname");
                }
            }
        }
        public String City
        {
            get { return _city; }
            set
            {
                if (value != _city)
                {
                    _city = value;
                    OnPropertyChanged("City");
                }
            }
        }
        public String Phone
        {
            get { return _phone; }
            set
            {
                if (value != _phone)
                {
                    _phone = value;
                    OnPropertyChanged("Phone");
                }
            }
        }
        public String Ucin
        {
            get { return _ucin; }
            set
            {
                if (value != _ucin)
                {
                    _ucin = value;
                    OnPropertyChanged("Ucin");
                }
            }
        }
        public String Medicalid
        {
            get { return _medicalid; }
            set
            {
                if (value != _medicalid)
                {
                    _medicalid = value;
                    OnPropertyChanged("Medicalid");
                }
            }
        }
        public String Date
        {
            get { return _date; }
            set
            {
                if (value != _date)
                {
                    _date = value;
                    OnPropertyChanged("Date");
                }
            }
        }
        public String Country
        {
            get { return _country; }
            set
            {
                if (value != _country)
                {
                    _country = value;
                    OnPropertyChanged("Country");
                }
            }
        }

        public String Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public String Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FirstName_TextBox.Focus();
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            
             if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.H)
            {
                MessageBox.Show(

                    "- Use CTRL + B to return to the first page of the application.\n" +
                       "- Use LEFT CTRL and RIGHT CTRL to move within fields.\n" +
                        "- Use  CTRL + 1  to select menu bar.\n" +
                          "-Use ENTER to select the button.\n" +
                    "- Use ENTER/SPACE to close this message.\n", "HELP");
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.B)
            {
                var s = new FirstPage();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }


            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.LeftCtrl)
            {
                if (helpButton.IsFocused)
                {
                    FirstName_TextBox.Focus();
                }
                else if (FirstName_TextBox.IsFocused)
                {
                    SecondName_TextBox.Focus();
                }
                
                else if (Phone_TextBox.IsFocused)
                {
                    Email_TextBox.Focus();
                }
                else if (Email_TextBox.IsFocused)
                {
                    Password_PasswordBox.Focus();
                }
                else if (Password_PasswordBox.IsFocused)
                {
                    ConfirmPassword_PasswordBox.Focus();
                }
                else if (ConfirmPassword_PasswordBox.IsFocused)
                {
                    CreateButton.Focus();
                }
                else if (CreateButton.IsFocused)
                {
                    backButton.Focus();
                }
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.RightCtrl)
            {
                if (FirstName_TextBox.IsFocused)
                {
                    helpButton.Focus();
                }
                else if (SecondName_TextBox.IsFocused)
                {
                    FirstName_TextBox.Focus();
                }
               
               


                else if (Email_TextBox.IsFocused)
                {
                    Phone_TextBox.Focus();
                }
                else if (Password_PasswordBox.IsFocused)
                {
                    Email_TextBox.Focus();
                }
                else if (ConfirmPassword_PasswordBox.IsFocused)
                {
                    Password_PasswordBox.Focus();
                }
                else if (CreateButton.IsFocused)
                {
                    ConfirmPassword_PasswordBox.Focus();
                }
                else if (backButton.IsFocused)
                {
                    CreateButton.Focus();
                }
                
            }
        }
        private bool allFilledCorectlly()
        {
            if (!Regex.Match(FirstName_TextBox.Text, "^[A-Z][a-zA-Z]*$").Success || !Regex.Match(SecondName_TextBox.Text, "^[A-Z][a-zA-Z]*$").Success ||
               
                !Regex.Match(Phone_TextBox.Text, @"^([0-9]+)$").Success || 
                 !Regex.Match(Email_TextBox.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").Success ||
                 !Regex.Match(Date_TextBox.Text, @"^([0-9]{2}/[0-9]{2}/[0-9]{4})$").Success)
            {
                return false;
            }
            return true;
        }

        private bool allFilled()
        {
            if (FirstName_TextBox.Text.Equals("") || SecondName_TextBox.Text.Equals("") || Email_TextBox.Text.Equals("") || Phone_TextBox.Text.Equals("")  ||
                         Date_TextBox.Text.Equals("") ||   City_TextBox.Text.Equals("") || Password_PasswordBox.Password.Length == 0 || ConfirmPassword_PasswordBox.Password.Length == 0)
            {
                return false;
            }

            return true;



        }

        private bool isValidName(String name)
        {
            Regex check = new Regex(@"^([A-Z][a-zA-Z]+)$");
            bool valid = false;

            valid = check.IsMatch(name);
            if (valid == false)
            {
                MessageBox.Show("Name format is not correct");
            }
            return valid;
        }

        private void CreateButton_IsKeyboardFocusedChanged_2(object sender, DependencyPropertyChangedEventArgs e)
        {

            ToolTip tt = (ToolTip)(sender as Control).ToolTip;
            //Places the Tooltip under the control rather than at the mouse position
            tt.PlacementTarget = (UIElement)sender;
            tt.Placement = PlacementMode.Right;
            tt.PlacementRectangle = new Rect(0, (sender as Control).Height, 0, 0);
            //Shows tooltip if KeyboardFocus is within.
            tt.IsOpen = (sender as Control).IsKeyboardFocusWithin;
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(

                   "- Use CTRL + B to return to the first page of the application.\n" +
                      "- Use LEFT CTRL and RIGHT CTRL to move within fields.\n" +
                       "- Use  CTRL + 1  to select menu bar.\n" +
                         "-Use ENTER to select the button.\n" +
                   "- Use ENTER/SPACE to close this message.\n", "HELP");
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new FirstPage();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!allFilled())
            {
                MessageBox.Show("Please fill in all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                FirstName_TextBox.Focus();
                return;
            }

            else if (!allFilledCorectlly())
            {
                MessageBox.Show("Please fill in all fields corectlly", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;

            }
            else if (!Password_PasswordBox.Password.Equals(ConfirmPassword_PasswordBox.Password))
            {
                MessageBox.Show("Passwords must be equal!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;

            }
            
            else
            {
                PatientUser patiendEdited = new PatientUser(Patient.id, FirstName_TextBox.Text, SecondName_TextBox.Text, Patient.uniqueCitizensidentityNumber, Date_TextBox.Text,
                    Phone_TextBox.Text, Patient.medicalIdNumber, allergieTextBox.Text, City_TextBox.Text, false,Email_TextBox.Text, Password_PasswordBox.Password,
                    false,Patient.notifications);

               
               Boolean isGoodUpdate =  patientController.Update(patiendEdited);
                if(isGoodUpdate==false)
                {
                    MessageBox.Show("Fields must be unique.\nCity must be in format : City, Street number, postal code, Country.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("Successfully changed infomration!", "Success", MessageBoxButton.OK);
                var usc = new AccountSettings();
                gridMain.Children.Clear();
                gridMain.Children.Add(usc);

            }
        }
    }
}
