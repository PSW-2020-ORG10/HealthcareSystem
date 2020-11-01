using System;

using Class_diagram.Model.Hospital;
using Class_diagram.Repository;

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
using System.IO;
using Path = System.IO.Path;
using Class_diagram.Model.Patient;
using HCI_wireframe.Contoller;
using Class_diagram.Contoller;

namespace HCI_wireframe.View.Patient
{
    /// <summary>
    /// Interaction logic for PatientMainWindow.xaml
    /// </summary>
    public partial class PatientMainWindow : Window, INotifyPropertyChanged
    {
       
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
        public PatientMainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

        }
        public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(System.IO.Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Email_TextBox.Focus();
            Email_TextBox.SelectAll();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.H)
            {
                MessageBox.Show(
                    "- Use LEFT CTRL to move on to the next field.\n" +
                    "- Use RIGHT CTRL to return to the previous field.\n" +
                      "- Use ENTER to select the button.\n" +
                        "- If you have an account - select button CONFIRM after filling the fields email and password.\n" +
                         "- If you want to create account- select button SIGN IN .\n" +

                    "- Use ENTER/SPACE to close this message.", "HELP");
            }


            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.LeftCtrl)
            {
                if (confirmButton.IsFocused)
                {
                    signINButton.Focus();
                }
                else if (helpButton.IsFocused)
                {
                    Email_TextBox.Focus();
                }
                else if (Email_TextBox.IsFocused)
                {
                    Password_TextBox.Focus();
                }
                else if (Password_TextBox.IsFocused)
                {
                    confirmButton.Focus();
                }
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.RightCtrl)
            {
                if (signINButton.IsFocused)
                {
                    confirmButton.Focus();
                }
                else if (confirmButton.IsFocused)
                {
                    Password_TextBox.Focus();
                }
                else if (Password_TextBox.IsFocused)
                {
                    Email_TextBox.Focus();
                }
                else if (Email_TextBox.IsFocused)
                {
                    helpButton.Focus();
                }

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

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                  "- Use LEFT CTRL to move on to the next field.\n" +
                  "- Use RIGHT CTRL to return to the previous field.\n" +
                  "- Use ENTER to select the button.\n" +
                   "- If you have an account - select button CONFIRM after filling the fields email and password.\n" +
                         "- If you want to create account- select button SIGN IN .\n" +
                  "- Use ENTER/SPACE to close this message.", "HELP");
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (Email_TextBox.Text.Equals("") || !Regex.Match(Email_TextBox.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").Success
                   || Password_TextBox.Password.Length == 0)
            {

                MessageBox.Show("Please fill in all fields corectlly", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Email_TextBox.Focus();
                return;
            }


            PatientController rpp = new PatientController();
            List<PatientUser> lista = rpp.GetAll();

            foreach (PatientUser r1 in lista)
            {
                if (r1.password.Equals(Password_TextBox.Password) && r1.email.Equals(Email_TextBox.Text) && r1.guest==false)
                {
                    gridMain.Children.Clear();
                    UserControl userCon = new FirstPage();
                    gridMain.Children.Add(userCon);

                    App.Current.Properties["Patientid"] = r1.id.ToString();
                    return;
                }
            }
            MessageBox.Show("Please fill in all fields corectlly", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        private void signINButton_Click(object sender, RoutedEventArgs e)
        {

            gridMain.Children.Clear();
            UserControl userCon = new SignUp();
            gridMain.Children.Add(userCon);
        }
    }
}
