using Class_diagram.Contoller;
using Class_diagram.Model.Doctor;
using Class_diagram.Model.Employee;
using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using HCI_wireframe.Contoller;
using HCI_wireframe.Model.Doctor;

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

    public partial class RecommendAppointment : Window, INotifyPropertyChanged
    {

        public class ListaDoktoriCeloIme
        {

            public String DoctorName { get; set; }

            public ListaDoktoriCeloIme()
            {
            }

        }

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
        private String _date1;
        public String Date1
        {
            get { return _date1; }
            set
            {
                if (value != _date1)
                {
                    _date1 = value;
                    OnPropertyChanged("Date1");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
       public DoctorController doctorController { get; set; }
        public AppointmentController appointmentController { get; set; }
        public List<DoctorAppointment> listAppointments { get; set; }
        public OperationController operationController { get; set; }
        public List<Operation> listOperations { get; set; }
        public List<DoctorUser> listDoctors { get; set; }
        string myProperty = App.Current.Properties["Patientid"].ToString();
        public PatientController patientController { get; set; }
        public List<PatientUser>listPatients { get; set; }
        public PatientUser patient = new PatientUser();
        EmployeesScheduleController employeesScheduleController = new EmployeesScheduleController();
        public RecommendAppointment()
        {
            InitializeComponent();
            this.DataContext = this;
            doctorController = new DoctorController();
            appointmentController = new AppointmentController();
            operationController = new OperationController();
            patientController = new PatientController();
            
            List<ListaDoktoriCeloIme> mojaLista = new List<ListaDoktoriCeloIme>();
            listAppointments = appointmentController.GetAll();
            listPatients = new List<PatientUser>();
            listPatients = patientController.GetAll();
            listDoctors = doctorController.GetAll();
            listOperations = operationController.GetAll();

            foreach (DoctorUser d in listDoctors)
            {if (d.isSpecialist == false)
                {
                    StringBuilder l = new StringBuilder();
                    l.Append(d.firstName + " ");
                    l.Append(d.secondName + " ");
                    l.Append(d.id);
                    ListaDoktoriCeloIme a = new ListaDoktoriCeloIme();
                    a.DoctorName = l.ToString();
                    mojaLista.Add(a);
                }
            }

            doctorCombo.ItemsSource = mojaLista;
        }

        private void cancelButton_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ToolTip tt = (ToolTip)(sender as Control).ToolTip;
            //Places the Tooltip under the control rather than at the mouse position
            tt.PlacementTarget = (UIElement)sender;
            tt.Placement = PlacementMode.Right;
            tt.PlacementRectangle = new Rect(0, (sender as Control).Height, 0, 0);
            //Shows tooltip if KeyboardFocus is within.
            tt.IsOpen = (sender as Control).IsKeyboardFocusWithin;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rb1Doctor.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.H)
            {
                MessageBox.Show(
                      "-Use CTRL LEFT and CTRL RIGHT to move within the fields.\n" +
                    "-Select prioriry for appointment.\n" +
                    "-Choose two dayes betwen which you want to schedule appointment.\n" +
                      "- Use ENTER to select the button.\n" +
                    "- Use ENTER/SPACE to close this message.\n", "HELP");
            }

            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.LeftCtrl)
            {
                if (rb1Doctor.IsFocused)
                {
                    rb1Date.Focus();
                }
                else if (helpButton.IsFocused)
                {
                    rb1Doctor.Focus();
                }
                else if (rb1Date.IsFocused)
                {
                    doctorCombo.Focus();
                }
                else if (doctorCombo.IsFocused)
                {
                    Date_TextBox.Focus();
                }
                else if (Date_TextBox.IsFocused)
                {
                    Date_TextBox2.Focus();
                }
                else if (Date_TextBox2.IsFocused)
                {
                    confirmButton.Focus();
                }
                else if (confirmButton.IsFocused)
                {
                    cancelButton.Focus();
                }

            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.RightCtrl)
            {
                if (rb1Doctor.IsFocused)
                {
                    helpButton.Focus();
                }
                else if (rb1Date.IsFocused)
                {
                    rb1Doctor.Focus();
                }
                else if (doctorCombo.IsFocused)
                {
                    rb1Date.Focus();
                }
                else if (Date_TextBox.IsFocused)
                {
                    doctorCombo.Focus();
                }
                else if (Date_TextBox2.IsFocused)
                {
                    Date_TextBox.Focus();
                }
                else if (confirmButton.IsFocused)
                {
                    Date_TextBox2.Focus();
                }
                else if (cancelButton.IsFocused)
                {
                    confirmButton.Focus();
                }

            }


        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            String priority = "";
            ListaDoktoriCeloIme name = (ListaDoktoriCeloIme)doctorCombo.SelectedValue;
            if (name == null || Date_TextBox.Text.Equals("") || !Regex.Match(Date_TextBox.Text, @"^([0-9]{2}/[0-9]{2}/[0-9]{4})$").Success
                || Date_TextBox2.Text.Equals("") || !Regex.Match(Date_TextBox2.Text, @"^([0-9]{2}/[0-9]{2}/[0-9]{4})$").Success)
            {
                doctorCombo.Focus();
                MessageBox.Show("Please fill all fields corectlly!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            else
            {
                String imeDr = name.DoctorName;

                String[] delovi = imeDr.Split(' ');

                int idDoktor = int.Parse(delovi[2]);



                DoctorUser doktorPregled = doctorController.GetByid(idDoktor);

               
                if (rb1Date.IsChecked == true)
                {
                    priority = "DATE";
                }
                else
                {
                    priority = "DOCTOR";
                }

                patient = patientController.GetByid(int.Parse(myProperty));

                String datum = Date_TextBox.Text;
                String[] delovi2 = datum.Split('/');
                int mesec = int.Parse(delovi2[1]);
                int dan = int.Parse(delovi2[0]);
                int godina = int.Parse(delovi2[2]);

                DateTime dt1 = new DateTime(godina, mesec, dan, 0, 0, 0);

                String datum2 = Date_TextBox2.Text;
                String[] delovi3 = datum2.Split('/');
                int mesec2 = int.Parse(delovi3[1]);
                int dan2 = int.Parse(delovi3[0]);
                int godina2 = int.Parse(delovi3[2]);

                DateTime dt2 = new DateTime(godina2, mesec2, dan2, 0, 0, 0);


                DateTime dtSad = DateTime.Now;

               
                if (dtSad > dt1 || dtSad > dt2)
                {
                    MessageBox.Show("Please enter dates that are yet to come.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (dt1 > dt2)
                {
                    MessageBox.Show("Please enter dates that are yet to come.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                String ime = doktorPregled.firstName;
              
             
               DoctorAppointment pronadjesApp = appointmentController.RecommendAnAppointment(doktorPregled, dt1, dt2, patient);
                if (pronadjesApp==null)
                {
                    
                    if (priority.Equals("DOCTOR"))
                    {
                       DateTime oduzimam =  dt1.AddDays(-3);
                        DateTime dodajem = dt2.AddDays(3);
                     
                        pronadjesApp = appointmentController.RecommendAnAppointment(doktorPregled, oduzimam, dodajem, patient);
                        
                    }
                    else if (priority.Equals("DATE"))
                    {
                        pronadjesApp = appointmentController.recommenedAnAppointmentDatePriority(dt1, dt2, patient);
                       
                    }
                    else { }
                }
                String imeDoktora = doktorPregled.firstName + " " + doktorPregled.secondName;
                if (pronadjesApp == null)
                {
                    MessageBox.Show("Sorry\nAppointment is not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    DoctorUser doktorIme = pronadjesApp.doctor;
                    string sMessageBoxText = "Do you want to schedule this appointment ? \n" + pronadjesApp.date + "\n" + pronadjesApp.time + "\n" + doktorIme.firstName + " " + doktorIme.secondName;
                    string sCaption = "New doctor appointment";

                    MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
                    MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                    MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
                    int id = 0;
                    switch (rsltMessageBox)
                    {
                        case MessageBoxResult.Yes:
                            id = getid();
                            pronadjesApp.id = id;
                            appointmentController.New(pronadjesApp,null);
                         
                            MessageBox.Show(
                           "Appointment is successfully scheduled!");

                            break;

                        case MessageBoxResult.No:

                            break;

                        case MessageBoxResult.Cancel:

                            break;

                    }

                }
            }
        }
        private int getid()
        {
            int number = 0;
            
            foreach (DoctorAppointment appointment in listAppointments)
            {
                 if(appointment.id>number)
                {
                    number = appointment.id;
                }
            }
            
            number += 1;
            return number;
        }
      
        
        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                     "-Use CTRL LEFT and CTRL RIGHT to move within the fields.\n" +
                   "-Select prioriry for appointment.\n" +
                   "-Choose two dayes betwen which you want to schedule appointment.\n" +
                    "- Use ENTER to select the button.\n" +
                   "- Use ENTER/SPACE to close this message.\n", "HELP");
        }
    }
}
