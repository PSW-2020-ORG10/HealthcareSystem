using Class_diagram.Contoller;
using Class_diagram.Model.Doctor;
using Class_diagram.Model.Patient;
using HCI_wireframe.Contoller;
using HCI_wireframe.Model.Doctor;
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
    /// Interaction logic for MedicalHistory.xaml
    /// </summary>
    /// 

    public class Lista
    {

        public String DoctorName { get; set; }

        public TimeSpan Time { get; set; }
        public DateTime DateT { get; set; }
        public String Date { get; set; }
        public int idapp { get; set; }
        public int idTabela { get; set; }

        public String ReportName { get; set; }
        public String Type { get; set; }
        public Lista()
        {

        }

    }
    
    public partial class MedicalHistory : UserControl
    {
        string myProperty = App.Current.Properties["Patientid"].ToString();
        public List<DoctorAppointment> AppointmentList { get; set; }
        public List<DoctorAppointment> AppointmentListAll { get; set; }
        public List<Operation> OperationListAll { get; set; }
        public List<Operation> OperationList { get; set; }
        public List<Lista> AppLista { get; set; }
        public List<PatientUser> patients { get; set; }
        public PatientUser patient { get; set; }
        public PatientController patientController { get; set; }
        public OperationController operationController { get; set; }
        public AppointmentController appointmentController { get; set; }
        public MedicalHistory()
        {
            InitializeComponent();
            this.DataContext = this;
           
            patientController = new PatientController();
            operationController = new OperationController();
            appointmentController = new AppointmentController();

            AppointmentListAll = appointmentController.GetAll();
            OperationListAll = operationController.GetAll();
            patients = patientController.GetAll();
            patient = new PatientUser();
            List<Lista> li = new List<Lista>();
            AppointmentList = new List<DoctorAppointment>();
            OperationList = new List<Operation>();

            patient = patientController.GetByid(int.Parse(myProperty));
          
            if (patient.allergie != null)
            {
                allergieText.Text = patient.allergie.ToString();
            }
            else
            {
                allergieText.Text = "";

            }
          
          
             if (AppointmentListAll == null)
             {
                 MessageBox.Show("You dont have any previous appointments!");
             }
             else
             {
                foreach (DoctorAppointment doctorApp in AppointmentListAll)
                {
                    PatientUser idPacijent = doctorApp.patient;
                    if (idPacijent.id == patient.id)
                    {
                        AppointmentList.Add(doctorApp);
                    }
                }
                foreach (Operation operationd in OperationListAll)
                {
                    PatientUser idPacijent = operationd.patient;
                    if (idPacijent.id == patient.id)
                    {
                        OperationList.Add(operationd);
                    }
                }
                if (AppointmentList == null)
                {
                    MessageBox.Show("You dont have any appointments!");
                }
                int num = 0;
                 foreach (DoctorAppointment d in AppointmentList)
                 {
                     String datum = d.date;
                     String[] delovi = datum.Split('/');
                     int mesec = int.Parse(delovi[1]);
                     int dan = int.Parse(delovi[0]);
                     int godina = int.Parse(delovi[2]);

                     DateTime dt1 = new DateTime(godina, mesec, dan, 0, 0, 0);

                     DateTime dt2 = DateTime.Now;
                     if (dt1.Date < dt2.Date)
                     {
                         DoctorUser doc = d.doctor;
                         StringBuilder l = new StringBuilder();
                         l.Append(doc.firstName + " ");
                         l.Append(doc.secondName);

                         li.Add(new Lista
                         {
                             idTabela = num + 1,
                             DoctorName = l.ToString(),
                             idapp = d.id,
                             Time = d.time,
                             Date = d.date,
                             DateT = dt1,
                             ReportName = "REPORT",
                             Type = "Regular appointment"

                         });
                         num += 1;
                     }


                }
                foreach (Operation operation in OperationList)
                {
                    String datum = operation.date;
                    String[] delovi = datum.Split('/');
                    int mesec = int.Parse(delovi[1]);
                    int dan = int.Parse(delovi[0]);
                    int godina = int.Parse(delovi[2]);

                    DateTime dt1 = new DateTime(godina, mesec, dan, 0, 0, 0);

                    DateTime dt2 = DateTime.Now;


                    if (dt1.Date < dt2.Date)
                    {
                        DoctorUser doc = operation.isResponiable;
                        StringBuilder l = new StringBuilder();
                        l.Append(doc.firstName + " ");
                        l.Append(doc.secondName);

                        li.Add(new Lista
                        {
                            idTabela = num + 1,
                            DoctorName = l.ToString(),
                            idapp = operation.id,
                            Time = operation.start,
                            Date = operation.date,
                            DateT = dt1,
                            ReportName = "REPORT",

                            Type = "Operation"
                        });

                    }
                }
                    int num2 = 0;
                 List<Lista> SortedList = li.OrderBy(o => o.DateT).ToList();
                 foreach(Lista l in SortedList)
                 {
                     l.idTabela = num2 + 1;
                     num2 += 1;
                 }
                 AppLista = new List<Lista>();
                 AppLista = SortedList;
             }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            backButton.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.B)
            {
                var s = new FirstPage();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key==Key.O)
            {
                
                        File_Name.Focus();
                    
                

            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.LeftCtrl && helpButton.IsFocused)
            {
                backButton.Focus();
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.RightCtrl && backButton.IsFocused)
            {
                helpButton.Focus();

            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.Q )
            {
                var s = new AccountSettings();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.H)
            {
                MessageBox.Show(
                    "- Use CTRL + B to return to the first page.\n" +
                    "- Use LEFT CTRL and RIGHT CTRL to move within fields.\n" +
                    "- Use  CTRL + O  to select menu bar.\n" +
                      "- Use TAB to select table.\n" +
                    "- Use AAROWS to move within field in table.\n" +
                    "- Use TAB to focus field.\n" +
                    "- Use TAB to select wanted report.\n" +
                    "- Use ENTER/SPACE to close this message.", "HELP");
                helpButton.Focus();
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
            else if(Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.LeftCtrl && helpButton.IsFocused)
            {
                backButton.Focus();
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.Right && backButton.IsFocused)
            {
                helpButton.Focus();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            Lista s = (Lista)medicalHistoryGrid.Items.GetItemAt(medicalHistoryGrid.SelectedIndex);
            int id = s.idapp;
            String tip = s.Type;

            string sMessageBoxText = "Do you want to see the report of appointment ?\n";
            string sCaption = "REPORT";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:

                    StringBuilder poruka = new StringBuilder();
                    if(tip.Equals("Regular appointment"))
                    {
                        foreach (DoctorAppointment d in AppointmentList)
                        {
                            List<Referral> nalazi = d.referral;
                            
                            if (d.id == id)
                            {
                               
                                if (nalazi == null)
                                {
                                    MessageBox.Show("There is no report for this appoitnment.");
                                    return;
                                }
                                foreach (Referral r in nalazi)
                                {
                                    String uputstvo = r.classify;
                                
                                    poruka.Append(" ********   REPORT :     *********\n");
                                    poruka.Append("Patient is on   :" + uputstvo + "\n");
                                    poruka.Append("Perscripted medicine is:   " + r.medicine + "\n");
                                    poruka.Append("Take medicine daily until    :   " + r.takeMedicineUntil + "\n");
                                    poruka.Append("Take medicine   :   " + r.quantityPerDay + "  time per day " + "\n");
                                    poruka.Append("Comment    :  " + r.comment + "\n");
                                    poruka.Append("\n");
                                }

                                if (poruka.Equals(""))
                                {
                                    MessageBox.Show("There is no report for this appoitnment.");
                                }
                                else
                                {
                                    MessageBox.Show(poruka.ToString());
                                }
                                break;
                            }
                        }
                    }
                    if (tip.Equals("Operation"))
                    {
                        foreach (Operation d in OperationList)
                        {
                            Referral nalazi = new Referral();
                            nalazi = d.operationReferral;

                            if (d.id == id)
                            {
                                Console.WriteLine("isti  id");
                                if (nalazi == null)
                                {
                                    MessageBox.Show("There is no report for this appoitnment.");
                                    return;
                                }
                               
                                    String uputstvo = nalazi.classify;

                                    poruka.Append(" ********   REPORT :     *********\n");
                                    poruka.Append("Patient is on   :" + uputstvo + "\n");
                                    poruka.Append("Perscripted medicine is:   " + nalazi.medicine + "\n");
                                    poruka.Append("Take medicine daily until    :   " + nalazi.takeMedicineUntil + "\n");
                                    poruka.Append("Take medicine   :   " + nalazi.quantityPerDay + "  time per day " + "\n");
                                    poruka.Append("\n");
                                

                                if (poruka.Equals(""))
                                {
                                    MessageBox.Show("There is no report for this appoitnment.");
                                }
                                else
                                {
                                    MessageBox.Show(poruka.ToString());
                                }
                                break;
                            }
                        }
                    }
                    
                    
                    break;

                case MessageBoxResult.No:

                    break;

                case MessageBoxResult.Cancel:

                    break;
            }
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                       "- Use CTRL + B to return to the first page.\n" +
                       "- Use LEFT CTRL and RIGHT CTRL to move within fields.\n" +
                       "- Use  CTRL + O  to select menu bar.\n" +
                         "- Use TAB to select table.\n" +
                    "- Use AAROWS to move within field in table.\n" +
                    "- Use TAB to focus field.\n" +
                    "- Use TAB to select wanted report.\n" +
                       "- Use ENTER/SPACE to close this message.", "HELP");
            

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new FirstPage();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }

        private void medicalHistoryGrid_Scroll(object sender, ScrollEventArgs e)
        {

        }
    }
}
