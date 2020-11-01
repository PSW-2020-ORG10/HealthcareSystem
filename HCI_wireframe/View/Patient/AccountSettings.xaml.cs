using Class_diagram.Contoller;
using Class_diagram.Model.Patient;
using HCI_wireframe.Contoller;
using HCI_wireframe.View.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for AccountSettings.xaml
    /// </summary>
    public partial class AccountSettings : UserControl
    {
        string myProperty = App.Current.Properties["Patientid"].ToString();
        public PatientUser Patient { get; set; }
        public PatientController patientController;
        public List<PatientUser> listPatients;


        public AccountSettings()
        {
            InitializeComponent();
            this.DataContext = this;
            Patient = new PatientUser();
            patientController = new PatientController();
            listPatients = patientController.GetAll();

            Patient = patientController.GetByid(int.Parse(myProperty));
            string grad = Patient.city;
                  
            firstName_Text.Text = Patient.firstName.ToString();
            secondName_Text.Text = Patient.secondName.ToString();
            ucin_Text.Text = Patient.uniqueCitizensidentityNumber.ToString();
            medicalid_Text.Text = Patient.medicalIdNumber.ToString();
            date_Text.Text = Patient.dateOfBirth.ToString();
                  
            City_text.Text = grad;
                  
            phone_text.Text = Patient.phoneNumber.ToString();
            email_text.Text = Patient.email.ToString();

                
               
            

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            helpButton.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
          
             if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.H)
            {
                MessageBox.Show(
                    
                    "- Use CTRL + B to return to the first page of the application.\n" +
                       "- Use LEFT CTRL and RIGHT CTRL to move within fields.\n" +
                        "- Use  CTRL + O  to select menu bar.\n" +
                         "-Use ENTER to select the button." +
                    "- Use ENTER/SPACE to close this message.\n", "HELP");
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.B)
            {
                var s = new FirstPage();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }

            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.Q)
            {
                var s = new AccountSettings();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
        

            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.W)
            {
                var s = new Settings();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.O) { 
                
                        File_Name.Focus();
                    
                }
                else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.K)
            {
                var s = new Help();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.A )
            {
                var s = new AskAQuestion();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.F)
            {
                var s = new FillInAQuestionarie();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D)
            {
                string sMessageBoxText = "Are you sure you want to log out?";
                string sCaption = "Log out";

                MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
                MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

                switch (rsltMessageBox)
                {
                    case MessageBoxResult.Yes:
                        var s = new PatientMainWindow();
                       s.Show();
                        break;

                    case MessageBoxResult.No:

                        break;

                    case MessageBoxResult.Cancel:

                        break;
                }
            }
               
                else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.Z)
            {
                
                    var s = new MyAppointments();
                    gridMain.Children.Clear();
                    gridMain.Children.Add(s);
                
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.X )
            {
                var s = new MedicalHistory();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.L)
            {
                var s = new MedicalTherapyOnAWeeklyBasis();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.V )
            {
                var s = new EmergencyPhoneNumbers();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.N)
            {
                var s = new Notification();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.M)
            {
                var s = new MakeAnAppointment();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
                else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.LeftCtrl)
                {
                    if (helpButton.IsFocused)
                    {
                        editButton.Focus();
                    }
                  
                    else if (editButton.IsFocused)
                    {
                        backButton.Focus();
                    }
                }
                else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.RightCtrl)
                {
                   
                  
                     if (backButton.IsFocused)
                    {
                        editButton.Focus();
                    }
                   else if (editButton.IsFocused)
                    {
                        helpButton.Focus();
                    }
                }
        }

        private void backButton_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ToolTip tt = (ToolTip)(sender as Control).ToolTip;
            //Places the Tooltip under the control rather than at the mouse position
            tt.PlacementTarget = (UIElement)sender;
            tt.Placement = PlacementMode.Right;
            tt.PlacementRectangle = new Rect(0, (sender as Control).Height, 0, 0);
            //Shows tooltip if KeyboardFocus is within.
            tt.IsOpen = (sender as Control).IsKeyboardFocusWithin;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new EditAccount();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new FirstPage();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(

                    "- Use CTRL + B to return to the first page of the application.\n" +
                       "- Use LEFT CTRL and RIGHT CTRL to move within fields.\n" +
                        "- Use  CTRL + O  to select menu bar.\n" +
                        "-Use ENTER to select the button."+
                    "- Use ENTER/SPACE to close this message.\n", "HELP");
        }

     
    }
}
