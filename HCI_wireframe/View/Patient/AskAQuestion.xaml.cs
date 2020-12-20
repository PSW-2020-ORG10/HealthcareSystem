using Class_diagram.Contoller;
using Class_diagram.Model.Patient;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.View.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for AskAQuestion.xaml
    /// </summary>
    public partial class AskAQuestion : UserControl
    {
        public class ListaDoktoriIme
        {

            public String DoctorName { get; set; }

            public ListaDoktoriIme()
            {
            }

        }
        string myProperty = App.Current.Properties["Patientid"].ToString();
        public DoctorController doctorController;
        public PatientController patientController;
        public List<DoctorUser> listDoctors { get; set; }
        public List<PatientUser> listPatients { get; set; }
        public PatientUser Patient { get; set; }
        public static int numberid = 0;
        public AskAQuestion()
        {
            InitializeComponent(); this.DataContext = this;
            doctorController = new DoctorController();
            listDoctors = doctorController.GetAll();
            List<ListaDoktoriIme> listDoctorsBinding = new List<ListaDoktoriIme>();
            Patient = new PatientUser();
            patientController = new PatientController();
            listPatients = patientController.GetAll();

            foreach (DoctorUser d in listDoctors)
            {
                StringBuilder l = new StringBuilder();
                l.Append(d.firstName + " ");
                l.Append(d.secondName + " ");
                l.Append(d.id);
                ListaDoktoriIme a = new ListaDoktoriIme();
                a.DoctorName = l.ToString();
                listDoctorsBinding.Add(a);
            }

            Patient = patientController.GetByid(int.Parse(myProperty));

            doctorCombo.ItemsSource = listDoctorsBinding;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBloxk.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.H)
            {
                MessageBox.Show(
                    "- Use CTRL + B to return to the first page.\n" +
                      "- Use LEFT CTRL and RIGHT CTRL to move within fields.\n" +
                        "- Use  CTRL + O  to select menu bar.\n" +
                    "- Use ENTER/SPACE to close this message.", "HELP");
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.Q)
            {
                var s = new AccountSettings();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.B)
            {
                var s = new FirstPage();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.W )
            {
                var s = new Settings();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.O) { 
               
                        File_Name.Focus();
                    

                }
                else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.K )
                {
                    var s = new Help();
                    gridMain.Children.Clear();
                    gridMain.Children.Add(s);
                }
                else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.A)
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
                else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.X)
                {
                    var s = new MedicalHistory();
                    gridMain.Children.Clear();
                    gridMain.Children.Add(s);
                }
                else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.L)
                {
                    var s = new MedicalTherapyOnAWeeklyBasis();
                    s.Show();
                }
                else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.V)
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
                else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.LeftCtrl) {
                    if (textBloxk.IsFocused)
                    {
                        sendButton.Focus();
                    }
                    else if (sendButton.IsFocused)
                    {
                        backButton.Focus();
                    }
                    else if (helpButton.IsFocused) {
                        textBloxk.Focus();
                    }
                }
                else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.RightCtrl)
                {
                    if (textBloxk.IsFocused)
                    {
                        helpButton.Focus();
                    }
                    else if (sendButton.IsFocused)
                    {
                        textBloxk.Focus();
                    }
                    else if (backButton.IsFocused)
                    {
                        sendButton.Focus();
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

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            ListaDoktoriIme name = (ListaDoktoriIme)doctorCombo.SelectedValue;
            if (name == null)
            {
                MessageBox.Show("Please choose the doctor!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }


            else if (textBloxk.Text.Equals(""))
            {
                MessageBox.Show("Please enter the question.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                helpButton.Focus();
                return;
            }
            else
            {

                String imeDr = name.DoctorName;

                String[] delovi = imeDr.Split(' ');

                int idDoktor = int.Parse(delovi[2]);
                DoctorUser doctor = doctorController.GetByid(idDoktor);
                if (doctor.specialNotifications == null)
                {
                    doctor.specialNotifications = new List<DoctorNotification>();
                }
                List<DoctorNotification> obavestenja = doctor.specialNotifications;
                obavestenja.Add(new DoctorNotification("Patient - " + Patient.id + " -  " + textBloxk.Text));
                doctor.specialNotifications = obavestenja;
               Boolean isDoctorOk= doctorController.Update(doctor);
                if(isDoctorOk==false)
                {

                }
                else
                {
                    MessageBox.Show("Your question is sent.");
                }
                
            }
              
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                   "- Use CTRL + B to return to the first page.\n" +
                     "- Use LEFT CTRL and RIGHT CTRL to move within fields.\n" +
                       "- Use  CTRL + O  to select menu bar.\n" +
                   "- Use ENTER/SPACE to close this message.", "HELP");
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new FirstPage();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }
    }
}
