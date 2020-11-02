using Class_diagram.Contoller;
using Class_diagram.Model.Doctor;
using Class_diagram.Model.Employee;
using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using HCI_wireframe.Contoller;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.View.Patient;
using Klinika;
using MaterialDesignThemes.Wpf;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Path = System.IO.Path;

namespace HCI_wireframe
{
    /// <summary>
    /// Interaction logic for MakeAnAppointment.xaml
    /// </summary>
    /// 
    public class Integer
    {
        public String DoctorName { get; set; }

        public Integer()
        {
        }

    }


    public partial class MakeAnAppointment : UserControl, INotifyPropertyChanged
    {
        private DateTime currentDateTime;
        private String _date;
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
        public String TimeText
        {
            get
            {
                return timeText;
            }
            set
            {
                timeText = value;
                OnPropertyChanged();
            }
        }

        public DateTime CurrentDateTime
        {
            get
            {
                return currentDateTime;
            }
            set
            {
                currentDateTime = value;
                TimeText = String.Format("{0:t}", CurrentDateTime);
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        string myProperty = App.Current.Properties["Patientid"].ToString();

        public List<Integer> AppLista { get; set; }
        public PatientUser patient { get; set; }
        public PatientController patientController = new PatientController();
        private string timeText;
        public DoctorController doctorController { get; set; }
        public List<DoctorUser> listDoctors { get; set; }
       public  List<Integer> listDoctorsBinding { get; set; }
        public AppointmentController appointmentController;
        public List<DoctorAppointment> listAppointments { get; set; }
      
        public List<DoctorAppointment> AppointmentListAll { get; set; }
        public OperationController operationController;
        public List<Operation> listOperations { get; set; }
        public EmployeesScheduleController employeesScheduleController;

        List<PatientUser> listPatients; 
        public MakeAnAppointment()
        {
            InitializeComponent();
            this.DataContext = this;
            listPatients = patientController.GetAll();
            listDoctorsBinding = new List<Integer>();
            doctorController = new DoctorController();
            appointmentController = new AppointmentController();
            operationController = new OperationController();
            listDoctors = new List<DoctorUser>();
            listOperations = operationController.GetAll();
            AppointmentListAll = appointmentController.GetAll();
            listDoctors = doctorController.GetAll();
            patient  = new PatientUser();
            listAppointments = new List<DoctorAppointment>();
            employeesScheduleController = new EmployeesScheduleController();
            CurrentDateTime = new DateTime(2020, 6, 20, 14, 00, 00);
            TimeText = String.Format("{0:t}", CurrentDateTime);
           
            foreach (DoctorUser d in listDoctors)
            { 
                if (d.isSpecialist == false)
                {
                    StringBuilder l = new StringBuilder();
                    l.Append(d.firstName + " ");
                    l.Append(d.secondName + " ");
                    l.Append(d.id);
                    Integer a = new Integer();
                    a.DoctorName = l.ToString();
                    listDoctorsBinding.Add(a);
                }
            }

            doctorCombo.ItemsSource = listDoctorsBinding;
            patient = patientController.GetByid(int.Parse(myProperty));
            foreach (DoctorAppointment doctorApp in AppointmentListAll)
            {
                PatientUser idPacijent = doctorApp.patient;
                if (idPacijent.id == patient.id)
                {
                    listAppointments.Add(doctorApp);
                }
            }
           
            if (listAppointments == null)
            {
                MessageBox.Show("You dont have any appointments!");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            recommendButton.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.H)
            {
                MessageBox.Show(
                      "-Use CTRL LEFT and CTRL RIGHT to move within the fields.\n" +
                    "- Use CTRL + O to select menu bar.\n" +
                    "- Use CTRL + B to return to the first page of the application.\n" +
                     "- Use CTRL + P to confirm choosen term for appointment.\n" +
                    "-Select recommend button to shcedule appointment with recmmendation.\n" +
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
                if (recommendButton.IsFocused)
                {
                    doctorCombo.Focus();
                }
                else if (doctorCombo.IsFocused)
                {
                    Date_TextBox.Focus();
                }
                else if (Date_TextBox.IsFocused)
                {
                    timeButton.Focus();
                }
                else if (timeButton.IsFocused)
                {
                    confirmButton.Focus();
                }

                else if (confirmButton.IsFocused)
                {
                    backButton.Focus();
                }
                else if (helpButton.IsFocused)
                {
                    recommendButton.Focus();
                }
                else if (backButton.IsFocused)
                {
                    helpButton.Focus();
                }


            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.RightCtrl)
            {
                if (recommendButton.IsFocused)
                {
                    helpButton.Focus();
                }
                else if (Date_TextBox.IsFocused)
                {
                    doctorCombo.Focus();
                }
                else if (doctorCombo.IsFocused)
                {
                    recommendButton.Focus();
                }

                else if (timeButton.IsFocused)
                {
                    Date_TextBox.Focus();
                }
                else if (confirmButton.IsFocused)
                {
                    timeButton.Focus();
                }
                else if (backButton.IsFocused)
                {
                    confirmButton.Focus();
                }
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.O)
            {

                File_Name.Focus();


            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.W)
            {
                var s = new Settings();
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

            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.K)
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
        }

        private int getid()
        {
            int number = 0;
           

            foreach (DoctorAppointment r in listAppointments)
            {
                if (r.id > number)
                {
                    number = r.id;

                }
                number += 1;
            }
            return number;
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

        private void Date_TextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void timeButton_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                    "-Use CTRL LEFT and CTRL RIGHT to move within the fields.\n" +
                    "- Use CTRL + O to select menu bar.\n" +
                    "- Use CTRL + B to return to the first page of the application.\n" +
                     "- Use CTRL + P to confirm choosen term for appointment.\n" +
                    "-Select recommend button to shcedule appointment with recmmendation.\n" +
                    "- Use ENTER/SPACE to close this message.\n", "HELP");
        }

        private void recommendButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new RecommendAppointment();
            s.Show();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            String datum = Date_TextBox.Text;
            String[] delovi2 = datum.Split('/');
            int mesec = int.Parse(delovi2[1]);
            int dan = int.Parse(delovi2[0]);
            int godina = int.Parse(delovi2[2]);

            DateTime dt1 = new DateTime(godina, mesec, dan, 0, 0, 0);

            DateTime dt2 = DateTime.Now;

            if (dt2 > dt1)
            {
                MessageBox.Show("Please enter the date that is yet to come.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Date_TextBox.Focus();
                return;
            }
            int id = 0;
            Integer name = (Integer)doctorCombo.SelectedValue;
            if (name == null || Date_TextBox.Text.Equals("") || !Regex.Match(Date_TextBox.Text, @"^([0-9]{2}/[0-9]{2}/[0-9]{4})$").Success)
            {
                MessageBox.Show("Please fill all fields corectlly!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Date_TextBox.Focus();

                return;
            }

            else
            {
                String imeDr = name.DoctorName;

                String[] delovi = imeDr.Split(' ');

                int idDoktor = int.Parse(delovi[2]);


                DoctorUser doktorPregled = doctorController.GetByid(idDoktor);
               

                String konacnoVreme = "";
                String vreme = TimeText;
                Console.WriteLine(vreme);
                String[] deliciVreme = vreme.Split(' ');
                String[] satIminut = deliciVreme[0].Split(':');
                String sat = satIminut[0];
                String minut = satIminut[1];
                String kada = deliciVreme[1];
                StringBuilder sb = new StringBuilder();
                if (kada.Equals("AM"))
                {
                    sb.Append(deliciVreme[0]);
                    sb.Append(":00");
                }
                else
                {
                    if (sat.Equals("1"))
                    {
                        sb.Append("13:");
                        sb.Append(minut);
                        sb.Append(":00");

                    }
                    else if (sat.Equals("2"))
                    {
                        sb.Append("14:");
                        sb.Append(minut);
                        sb.Append(":00");

                    }
                    else if (sat.Equals("3"))
                    {
                        sb.Append("15:");
                        sb.Append(minut);
                        sb.Append(":00");

                    }
                    else if (sat.Equals("4"))
                    {
                        sb.Append("16:");
                        sb.Append(minut);
                        sb.Append(":00");

                    }
                    else if (sat.Equals("5"))
                    {
                        sb.Append("17:");
                        sb.Append(minut);
                        sb.Append(":00");

                    }
                    else if (sat.Equals("6"))
                    {
                        sb.Append("18:");
                        sb.Append(minut);
                        sb.Append(":00");

                    }
                    else if (sat.Equals("7"))
                    {
                        sb.Append("19:");
                        sb.Append(minut);
                        sb.Append(":00");

                    }
                    else if (sat.Equals("8"))
                    {
                        sb.Append("20:");
                        sb.Append(minut);
                        sb.Append(":00");

                    }
                    else if (sat.Equals("9"))
                    {
                        sb.Append("21:");
                        sb.Append(minut);
                        sb.Append(":00");

                    }
                    else if (sat.Equals("10"))
                    {
                        sb.Append("22:");
                        sb.Append(minut);
                        sb.Append(":00");

                    }
                    else if (sat.Equals("11"))
                    {
                        sb.Append("23:");
                        sb.Append(minut);
                        sb.Append(":00");

                    }
                    else
                    {
                        sb.Append("00:");
                        sb.Append(minut);
                        sb.Append(":00");

                    }

                }
                konacnoVreme = sb.ToString();
                Console.WriteLine(konacnoVreme);
                String[] zaTs = konacnoVreme.Split(':');
                int minutiVreme = int.Parse(zaTs[1]);
                TimeSpan ts = new TimeSpan(int.Parse(zaTs[0]), minutiVreme, int.Parse(zaTs[2]));

               if(minutiVreme!=00 && minutiVreme!=15 && minutiVreme!=30 && minutiVreme!=45)
                {
                    MessageBox.Show("Appointment lasts 15 minutes! Minutes can be - 00/15/30/45", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Date_TextBox.Focus();

                    return;
                }

                DoctorAppointment dapp = new DoctorAppointment(0, ts, Date_TextBox.Text, patient, doktorPregled, null, doktorPregled.ordination);

                Shift smena = employeesScheduleController.getShiftForDoctorForSpecificDay(Date_TextBox.Text,doktorPregled);

                if (smena == null || smena.startTime == null || smena.endTime == null)
                {
                     MessageBox.Show("Doctor is not working that day.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                     Date_TextBox.Focus();
                     return;
                }

                Boolean notAvailbale = appointmentController.isTermNotAvailable(doktorPregled, ts, Date_TextBox.Text, patient);
                if (notAvailbale == true)
                {
                    MessageBox.Show("Appointment is not available. Please choose another term.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Date_TextBox.Focus();
                    return;
                }



                bool nijeUTokuSmene = employeesScheduleController.isDoctorWorkingAtSpecifiedTime(Date_TextBox.Text, doktorPregled, ts);
                if(nijeUTokuSmene==false)
                {

                    MessageBox.Show("Selected appointment is not available. Doctor is not working at that time.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Date_TextBox.Focus();
                    return;
                }


                    appointmentController.New(dapp, null);




                    DoctorUser doktorPunoIme = dapp.doctor;
                    String doktorPuno = doktorPunoIme.firstName + " " + doktorPunoIme.secondName;

                    MessageBox.Show("New appointment is scheduled\nTime     " + dapp.time.ToString() + "\nDate      " + dapp.date + "\nDoctor     " + doktorPuno, "SUCCESS");

                }
            
            }

            private void backButton_Click(object sender, RoutedEventArgs e)
            {
                var s = new FirstPage();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
        }
    } 
