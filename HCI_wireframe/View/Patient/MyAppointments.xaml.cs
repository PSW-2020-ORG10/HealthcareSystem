using Class_diagram.Contoller;
using Class_diagram.Model.Doctor;
using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using HCI_wireframe.Contoller;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.View.Patient;

using System;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;


namespace HCI_wireframe
{
    /// <summary>
    /// Interaction logic for MyAppointments.xaml
    /// </summary>
    public partial class MyAppointments : UserControl
    {
        public class Lista
        {

            public String DoctorName { get; set; }

            public TimeSpan Time { get; set; }

            public String Datum { get; set; }
            public DateTime DateT { get; set; }
            public int idapp { get; set; }
            public int idTabela { get; set; }
            public String Ordination { get; set; }
            public String ChangeName { get; set; }
            public String RemoveName { get; set; }
            public String Type { get; set; }
            public Lista()
            {

            }

        }

        string myProperty = App.Current.Properties["Patientid"].ToString();
        public List<DoctorAppointment> AppointmentList { get; set; }
        public List<DoctorAppointment> AppointmentListAll { get; set; }
        public List<Operation> OperationListAll { get; set; }
        public List<Operation> OperationList { get; set; }
        public List<Lista> AppLista { get; set; }

        public PatientUser patient { get; set; }
        public PatientController patientController { get; set; }
        public OperationController operationController { get; set; }
        public AppointmentController appointmentController { get; set; }
        public List<PatientUser> patients { get; set; }

        public MyAppointments()
        {

            InitializeComponent();
            this.DataContext = this;

            OperationList = new List<Operation>();
            AppointmentList = new List<DoctorAppointment>();

            appointmentController = new AppointmentController();
            patientController = new PatientController();
            operationController = new OperationController();

             patients = patientController.GetAll();
            AppointmentListAll = appointmentController.GetAll();
            OperationListAll = operationController.GetAll();

           
          
            patient = new PatientUser();
            List<Lista> li = new List<Lista>();

            patient = patientController.GetByid(int.Parse(myProperty));
            if (AppointmentListAll == null)
            {
                MessageBox.Show("You dont have any appointments!");
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
                foreach(Operation operationd in OperationListAll)
                {
                    PatientUser idPacijent = operationd.patient;
                    if (idPacijent.id == patient.id)
                    {
                        OperationList.Add(operationd);
                    }
                }
                if(AppointmentList==null)
                {
                    MessageBox.Show("You dont have any appointments!");
                }
                foreach (DoctorAppointment d in AppointmentList)
                {
                    String datum = d.date;
                    String[] delovi = datum.Split('/');
                    int mesec = int.Parse(delovi[1]);
                    int dan = int.Parse(delovi[0]);
                    int godina = int.Parse(delovi[2]);

                    DateTime dt1 = new DateTime(godina, mesec, dan, 0, 0, 0);

                    DateTime dt2 = DateTime.Now;


                    if (dt1.Date > dt2.Date)
                    {
                        DoctorUser doc = d.doctor;
                        StringBuilder l = new StringBuilder();
                        l.Append(doc.firstName + " ");
                        l.Append(doc.secondName);

                        li.Add(new Lista
                        {   idTabela = 0,
                            DoctorName = l.ToString(),
                            idapp = d.id,
                            Time = d.time,
                            DateT = dt1,
                            Datum = d.date,
                            Ordination = d.roomid,
                            ChangeName = "CHANGE",
                            RemoveName = "REMOVE",
                            Type = "Regular appointment"
                        }) ;

                    }
                 
                }

                foreach(Operation operation in OperationList)
                {
                    String datum = operation.date;
                    String[] delovi = datum.Split('/');
                    int mesec = int.Parse(delovi[1]);
                    int dan = int.Parse(delovi[0]);
                    int godina = int.Parse(delovi[2]);

                    DateTime dt1 = new DateTime(godina, mesec, dan, 0, 0, 0);

                    DateTime dt2 = DateTime.Now;


                    if (dt1.Date > dt2.Date)
                    {
                        DoctorUser doc = operation.isResponiable;
                        StringBuilder l = new StringBuilder();
                        l.Append(doc.firstName + " ");
                        l.Append(doc.secondName);

                        li.Add(new Lista
                        {
                            idTabela = 0,
                            DoctorName = l.ToString(),
                            idapp = operation.id,
                            Time = operation.start,
                            DateT = dt1,
                            Datum = operation.date,
                            Ordination = operation.idRoom,
                            ChangeName = "CHANGE",
                            RemoveName = "REMOVE",
                             Type = "Operation"
                        });

                    }
                }
            
                int num2 = 0;
                List<Lista> SortedList = li.OrderBy(o => o.DateT).ToList();
                foreach (Lista l in SortedList)
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

            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.H)
            {
                MessageBox.Show(
                    "- Use CTRL + B to return to the first page.\n" +
                     "- Use TAB to select the table.\n" +
                    "- Use  ARROWS to move within rows and columns in table.\n" +
                     "- Use TAB to select change or remove button.\n" +
                    "- Use  ENTER to choose that button.\n" +
                    "- Use LEFT CTRL and RIGHT CTRL to move within fields.\n" +
                    "- Use  CTRL + O  to select menu bar.\n" +
                    "- Use ENTER/SPACE to close this message.", "HELP");
                helpButton.Focus();
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.B)
            {
                var s = new FirstPage();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.LeftCtrl && helpButton.IsFocused)
            {
                backButton.Focus();
            }

            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.RightCtrl && backButton.IsFocused)
            {
                helpButton.Focus();

            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.O)
            {

                File_Name.Focus();

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
            Lista ss = (Lista)myAppointmentGrid.Items.GetItemAt(myAppointmentGrid.SelectedIndex);
            int id = ss.idapp;
            string sMessageBoxText = "Are you sure you want to DELETE appointment?";
            string sCaption = "Remove appointment";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    if (ss.Type.Equals("Regular appointment"))
                    {
                        DoctorAppointment d = appointmentController.GetByid(id);

                        String datum = d.date;
                        String[] delovi = datum.Split('/');
                        int mesec = int.Parse(delovi[1]);
                        int dan = int.Parse(delovi[0]);
                        int godina = int.Parse(delovi[2]);
                        TimeSpan tm = d.time;
                        String vreme = tm.ToString();
                        String[] deloviVreme = vreme.Split(':');
                        int sat = int.Parse(deloviVreme[0]);
                        int minut = int.Parse(deloviVreme[1]);
                        int sekund = int.Parse(deloviVreme[2]);
                        DateTime dt1 = new DateTime(godina, mesec, dan, sat, minut, sekund);

                        DateTime dt2 = DateTime.Now.AddDays(1);


                        if (dt1.Date > dt2.Date)
                        {
                            Console.WriteLine(id);

                            appointmentController.Remove(id, 0);

                            MessageBox.Show("APPOINTMENT DELETED");
                            var s = new MyAppointments();
                            gridMain.Children.Clear();
                            gridMain.Children.Add(s);

                            break;
                        }
                        else
                        {
                            MessageBox.Show("This appointment cant be deleted! It is in next 24h!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else if(ss.Type.Equals("Operation"))
                    {
                        Operation operation = operationController.GetByid(id);
                        String datum = operation.date;
                        String[] delovi = datum.Split('/');
                        int mesec = int.Parse(delovi[1]);
                        int dan = int.Parse(delovi[0]);
                        int godina = int.Parse(delovi[2]);
                        TimeSpan tm = operation.start;
                        String vreme = tm.ToString();
                        String[] deloviVreme = vreme.Split(':');
                        int sat = int.Parse(deloviVreme[0]);
                        int minut = int.Parse(deloviVreme[1]);
                        int sekund = int.Parse(deloviVreme[2]);
                        DateTime dt1 = new DateTime(godina, mesec, dan, sat, minut, sekund);

                        DateTime dt2 = DateTime.Now.AddDays(1);


                        if (dt1.Date > dt2.Date)
                        {
                            Console.WriteLine(id);

                            operationController.Remove(0, id);

                            MessageBox.Show("OPERATION DELETED");
                            var s = new MyAppointments();
                            gridMain.Children.Clear();
                            gridMain.Children.Add(s);

                            break;
                        }
                        else
                        {
                            MessageBox.Show("This operation cant be deleted! It is in next 24h!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }
                   
                     
                    break;

                case MessageBoxResult.No:

                    break;

                case MessageBoxResult.Cancel:

                    break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Lista ss = (Lista)myAppointmentGrid.Items.GetItemAt(myAppointmentGrid.SelectedIndex);
            int id = ss.idapp;

            if(ss.Type.Equals("Operation"))
            {
                MessageBox.Show("Term of operation can not be changed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            string sMessageBoxText = "Are you sure you want to EDIT appointment?";
            string sCaption = "EDIT appointment";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    
                        DoctorAppointment d = appointmentController.GetByid(id);

                            String datum = d.date;
                            String[] delovi = datum.Split('/');
                            int mesec = int.Parse(delovi[1]);
                            int dan = int.Parse(delovi[0]);
                            int godina = int.Parse(delovi[2]);
                            TimeSpan tm = d.time;
                            String vreme = tm.ToString();
                            String[] deloviVreme = vreme.Split(':');
                            int sat = int.Parse(deloviVreme[0]);
                            int minut = int.Parse(deloviVreme[1]);
                            int sekund = int.Parse(deloviVreme[2]);
                            DateTime dt1 = new DateTime(godina, mesec, dan, sat, minut, sekund);

                            DateTime dt2 = DateTime.Now.AddDays(1);

                            if (dt1.Date > dt2.Date)
                            {
                                appointmentController.Remove(id, 0);
                                var s = new MakeAnAppointment();
                                gridMain.Children.Clear();
                                gridMain.Children.Add(s);
                                break;
                            }else
                            {
                                MessageBox.Show("This appointment cant be changed! It is in next 24h!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                  
                    
                    break;

                case MessageBoxResult.No:

                    break;

                case MessageBoxResult.Cancel:

                    break;
            }
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
                   "- Use CTRL + B to return to the first page.\n" +
                    "- Use TAB to select the table.\n" +
                   "- Use  ARROWS to move within rows and columns in table.\n" +
                    "- Use TAB to select change or remove button.\n" +
                   "- Use  ENTER to choose that button.\n" +
                   "- Use LEFT CTRL and RIGHT CTRL to move within fields.\n" +
                   "- Use  CTRL + O  to select menu bar.\n" +
                   "- Use ENTER/SPACE to close this message.", "HELP");
            helpButton.Focus();
        }

        private void myAppointmentGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
