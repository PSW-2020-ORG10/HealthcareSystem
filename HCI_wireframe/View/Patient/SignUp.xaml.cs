

using Class_diagram.Contoller;
using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using HCI_wireframe.Contoller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Shapes;

namespace HCI_wireframe
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : UserControl, INotifyPropertyChanged
    {
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
        public PatientController patientController;
        public List<PatientUser> listPatients { get; set; }
        public SignUp()
        {
            InitializeComponent();
            this.DataContext = this;
            patientController = new PatientController();
            listPatients = patientController.GetAll();
                
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

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
        {  get{ return _firstaname; }
            set
            {if (value != _firstaname)
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
        private void FirstName_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl)
            {
                SecondName_TextBox.Focus();
            }
            else if(e.Key == Key.RightCtrl)
            {
                helpButton.Focus();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FirstName_TextBox.Focus();
            FirstName_TextBox.SelectAll();
        }
     
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.H)
            {
                MessageBox.Show(
                    "- Use LEFT CTRL to move on to the next field.\n" +
                    "- Use RIGHT CTRL to return to the previous field.\n" +
                    "- Use ENTER to select the button.\n" +
                    "- Use ENTER/SPACE to close this message.", "HELP");
            }
        
           else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.RightCtrl && helpButton.IsFocused)
           {
               FirstName_TextBox.Focus(); 
           }
           else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.RightCtrl && CreateButton.IsFocused)
           {
               allergieTextBox.Focus();
           }
        else { }


        }

        private int getNextid()
        {
            PatientController rp = new PatientController();
            List<PatientUser> lista = rp.GetAll();

            int number = 0;

            foreach(PatientUser r in lista)
            {
                if(r.id>number)
                {
                    number = r.id;
                }
            }

            number += 1;
            return number;

        }

        private bool allFilledCorectlly()
        {
            if (!Regex.Match(FirstName_TextBox.Text, "^[A-Z][a-zA-Z]*$").Success || !Regex.Match(SecondName_TextBox.Text, "^[A-Z][a-zA-Z]*$").Success ||
              
                !Regex.Match(Phone_TextBox.Text, @"^([0-9]+)$").Success || !Regex.Match(Ucin_TextBox.Text, @"^([0-9]+)$").Success ||
              
                !Regex.Match(medicalIdNumber_TextBox.Text, @"^([0-9]+)$").Success || !Regex.Match(Email_TextBox.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").Success ||
                 !Regex.Match(Date_TextBox.Text, @"^([0-9]{2}/[0-9]{2}/[0-9]{4})$").Success) {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool isValidName(String name)
       {
           Regex check = new Regex(@"^([A-Z][a-zA-Z]+)$");
           bool valid = false;

           valid = check.IsMatch(name);
           if (valid == false) {
               MessageBox.Show("Name format is not correct");
           }
           return valid;
       }

        private bool allFilled()
        {
            if (FirstName_TextBox.Text.Equals("") || SecondName_TextBox.Text.Equals("") || Email_TextBox.Text.Equals("") || Phone_TextBox.Text.Equals("") ||
                         Date_TextBox.Text.Equals("") ||
                       medicalIdNumber_TextBox.Text.Equals("") || Ucin_TextBox.Text.Equals("") || City_TextBox.Text.Equals("") ||
                       Password_PasswordBox.Password.Length.Equals("") || ConfirmPassword_PasswordBox.Password.Length.Equals("")) {
                return false;
            }
          
                return true;
            

        }

       private void SecondName_TextBox_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.Key == Key.LeftCtrl)
           {
               Ucin_TextBox.Focus();
           }
           else if (e.Key == Key.RightCtrl)
           {
               FirstName_TextBox.Focus();
           }
       }

       private void Ucin_TextBox_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.Key == Key.LeftCtrl)
           {
               medicalIdNumber_TextBox.Focus();
           }
           else if (e.Key == Key.RightCtrl)
           {
               SecondName_TextBox.Focus();
           }
       }

       private void medicalIdNumber_TextBox_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.Key == Key.LeftCtrl)
           {
               Date_TextBox.Focus();
           }
           else if (e.Key == Key.RightCtrl)
           {
               Ucin_TextBox.Focus();
           }
       }

 


       private void Email_TextBox_KeyDown(object sender, KeyEventArgs e)
       {
           if (e.Key == Key.LeftCtrl)
           {
               Password_PasswordBox.Focus();
           }
           else if (e.Key == Key.RightCtrl)
           {
               Phone_TextBox.Focus();
           }
       }

       private void Password_PasswordBox_KeyDown(object sender, KeyEventArgs e)
       {

           if (e.Key == Key.LeftCtrl)
           {
               ConfirmPassword_PasswordBox.Focus();
           }
           else if (e.Key == Key.RightCtrl)
           {
               Email_TextBox.Focus();
           }
       }


       private void ConfirmPassword_PasswordBox_KeyDown(object sender, KeyEventArgs e)
       {

           if (e.Key == Key.RightCtrl)
           {
               Password_PasswordBox.Focus();
           }
           else if (e.Key == Key.LeftCtrl) {
               allergieTextBox.Focus();
           }
       }

       private void helpButton_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
       {
           ToolTip tt = (ToolTip)(sender as Control).ToolTip;
           //Places the Tooltip under the control rather than at the mouse position
           tt.PlacementTarget = (UIElement)sender;
           tt.Placement = PlacementMode.Right;
           tt.PlacementRectangle = new Rect(0, (sender as Control).Height, 0, 0);
           //Shows tooltip if KeyboardFocus is within.
           tt.IsOpen = (sender as Control).IsKeyboardFocusWithin;
       }

        private void CityCode_TextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.RightCtrl)
            {
                City_TextBox.Focus();
            }
            else if (e.Key == Key.LeftCtrl)
            {
                Phone_TextBox.Focus();
            }
        }



        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                    "- Use LEFT CTRL to move on to the next field.\n" +
                    "- Use RIGHT CTRL to return to the previous field.\n" +
                    "- Use ENTER to select the button.\n" +
                    "- Use ENTER/SPACE to close this message.", "HELP");
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
            else if (yearOk(Date_TextBox.Text)==false)
            {
                MessageBox.Show("User must have at least 18 years!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
          
            
            else
            {
                PatientUser rp = new PatientUser(0, FirstName_TextBox.Text, SecondName_TextBox.Text, Ucin_TextBox.Text, Date_TextBox.Text,
                    Phone_TextBox.Text, medicalIdNumber_TextBox.Text, allergieTextBox.Text,City_TextBox.Text,false, Email_TextBox.Text, Password_PasswordBox.Password, false, null);


               Boolean okNewPatient =  patientController.New(rp);
                if (okNewPatient == false)
                {
                    MessageBox.Show("Fields must be unique.\nCity must be in format : City, Street number, postal code, Country.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                App.Current.Properties["Patientid"] = rp.id.ToString();
                var usc = new FirstPage();
                gridMain.Children.Clear();
                gridMain.Children.Add(usc);

            }
        }

        private bool yearOk(string datum)
        {
            String[] delovi2 = datum.Split('/');
            int mesec = int.Parse(delovi2[1]);
            int dan = int.Parse(delovi2[0]);
            int godina = int.Parse(delovi2[2]);

            DateTime dt1 = new DateTime(godina, mesec, dan, 0, 0, 0);

            DateTime dt2 = DateTime.Now.AddYears(-18);

            if (dt2 < dt1)
            {
                return false;
            }
            return true;
        }

        private void allergieTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.RightCtrl)
            {
                ConfirmPassword_PasswordBox.Focus();
            }
            else if (e.Key == Key.LeftCtrl)
            {
                CreateButton.Focus();
            }
        }

        private void City_TextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Date_TextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Phone_TextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
