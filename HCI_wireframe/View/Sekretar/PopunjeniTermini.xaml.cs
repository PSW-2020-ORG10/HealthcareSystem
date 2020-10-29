using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Class_diagram.Contoller;
using Class_diagram.Model.Doctor;
using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using HCI_wireframe.Contoller;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.View.Sekretar;

using Path = System.IO.Path;

namespace ProjekatHCI
{
    /// <summary>
    /// Interaction logic for PopunjeniTermini.xaml
    /// </summary>
    public partial class PopunjeniTermini : UserControl, INotifyPropertyChanged
    {
        public int vrsta = 0;
        public DataRowView ChosenItem { get; set; }
        public class Lista
        {
            public bool Pregled { get; set; }
            public bool Operacija { get; set; }
            public String DoctorName { get; set; }

            public TimeSpan Time { get; set; }
            public TimeSpan TimeEnd { get; set; }
            public String Date { get; set; }
            public int IDapp { get; set; }
            public String PatientName { get; set; }

            public String ChangeName { get; set; }
            public String RemoveName { get; set; }
            public String Ordinacija { get; set; }
         
            public Lista()
            {

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;


        private void setButtonVisibility()
        {
            if (datePicker.Text != String.Empty && Regex.Match(datePicker.Text, @"^\d{2}/\d{2}/\d{4}$").Success)

            {

                trazi.IsEnabled = true;


            }



            else
            {

                trazi.IsEnabled = false;



            }

        }
        public virtual void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
        public List<DoctorAppointment> AppointmentList { get; set; }
        public List<Operation> operationList { get; set; }
        public List<Lista> AppLista { get; set; }

        public List<Lista> li = new List<Lista>();
        PatientController patientController = new PatientController();
        public ObservableCollection<DoctorAppointment> listaTermini
        {
            get;
            set;
        }


        public PopunjeniTermini()
        {
            InitializeComponent();
            this.DataContext = this;

            String b = bingPathToAppDir(@"JsonFiles\appointments.json");



            AppointmentList = new List<DoctorAppointment>();

            AppointmentRepository epr = new AppointmentRepository(b);
            if (epr != null)
            {
                AppointmentList = epr.GetAll();

            }


            foreach (DoctorAppointment ee in AppointmentList)
            {

                String datum = ee.Date;
                String[] delovi = datum.Split('/');
                int mesec = int.Parse(delovi[1]);
                int dan = int.Parse(delovi[0]);
                int godina = int.Parse(delovi[2]);

                DateTime dt1 = new DateTime(godina, mesec, dan, 0, 0, 0);

                DateTime dt2 = DateTime.Now;


                if (dt1.Date >= dt2.Date)
                {
                    vrsta = 0;
                    DoctorUser doc = ee.doctor;
                    StringBuilder l = new StringBuilder();
                    l.Append(doc.FirstName + " ");
                    l.Append(doc.SecondName + " ");
                    l.Append(doc.speciality);
                    StringBuilder p = new StringBuilder();
                    PatientUser pat = ee.patient;
                    p.Append(pat.FirstName + " ");
                    p.Append(pat.SecondName);

                    li.Add(new Lista
                    {
                        DoctorName = l.ToString(),

                        IDapp = ee.ID,
                        Time = ee.Time,
                        TimeEnd = ee.Time + new TimeSpan(0,15,0),
                        Date = ee.Date,
                        ChangeName = "IZMENI " + ee.ID,
                        RemoveName = "OTKAŽI " + ee.ID,
                        PatientName = p.ToString(),
                        Ordinacija = ee.roomID.ToString(),
                        Pregled = true,
                        Operacija = false

                    });




                }

                AppLista = li;
                

            }
            String o = bingPathToAppDir(@"JsonFiles\operations.json");


            OperationRepository opRep = new OperationRepository(o);



            List<Operation> operationList = new List<Operation>();
            if (opRep.GetAll() != null)
            {
                operationList = opRep.GetAll();
            }



            foreach (Operation ee in operationList)
            {
                vrsta = 1;
                String datum1 = ee.Date;
                String[] delovi1 = datum1.Split('/');
                int mesec1 = int.Parse(delovi1[1]);
                int dan1 = int.Parse(delovi1[0]);
                int godina1 = int.Parse(delovi1[2]);

                DateTime dt3 = new DateTime(godina1, mesec1, dan1, 0, 0, 0);

                DateTime dt4 = DateTime.Now;


                if (dt3.Date >= dt4.Date)
                {

                    DoctorUser doc = ee.Responsable;
                    StringBuilder l = new StringBuilder();
                    l.Append(doc.FirstName + " ");
                    l.Append(doc.SecondName+" ");
                    l.Append(doc.speciality);
                    StringBuilder p = new StringBuilder();
                    PatientUser pat = ee.patient;
                    p.Append(pat.FirstName + " ");
                    p.Append(pat.SecondName);

                    li.Add(new Lista
                    {
                        DoctorName = l.ToString(),

                        IDapp = ee.ID,
                        Time = ee.Start,
                        TimeEnd = ee.End,
                        Date = ee.Date,
                        ChangeName = "IZMENI " + ee.ID,
                        RemoveName = "OTKAŽI " + ee.ID,
                        PatientName = p.ToString(),
                        Ordinacija = ee.Responsable.ordination.ToString(),
                        Pregled = false,
                        Operacija = true

                    });




                }


                AppLista = li;
              

            }

        }
        public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Lista ss = (Lista)dataGridTermini.Items.GetItemAt(dataGridTermini.SelectedIndex);
            string name1 = sender.ToString();
            string[] words = name1.Split(':');

            string[] words1 = name1.Split(' ');
            string id = words1[2];
            


            string sMessageBoxText = "Da li ste sigurni da zelite da izmenite ovaj termin?"+vrsta;
            string sCaption = "Izmena termina";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    PatientUser ovajPacijent = new PatientUser();



                    String o = bingPathToAppDir(@"JsonFiles\operations.json");
                    String b = bingPathToAppDir(@"JsonFiles\appointments.json");

                    AppointmentList = new List<DoctorAppointment>();
                    operationList = new List<Operation>();

                    OperationRepository oprep = new OperationRepository(o);
                    AppointmentRepository epr = new AppointmentRepository(b);
                    operationList = oprep.GetAll();
                    AppointmentList = epr.GetAll();



                    foreach (DoctorAppointment d in AppointmentList)
                    {

                        
                        if (d.ID.ToString().Equals(id) && ss.Pregled == true)
                        {


                            Console.WriteLine(id);
                            AppointmentList.Remove(d);
                            //patientController.update(ovajPacijent);
                            epr.Delete(d.ID);
                            PatientController patContr = new PatientController();


                            if (d.patient.Notifications == null)
                            {
                                d.patient.Notifications = new List<string>();
                            }
                            List<String> notifications1 = d.patient.Notifications;
                            // }

                            notifications1.Add("Postovani, pregled zakazan za datum: " + d.Date + " i vreme " + d.Time + " je otkazan.");
                            d.patient.Notifications = notifications1;



                            PatientController pCon = new PatientController();
                            pCon.Update(d.patient);

                            if (d.doctor.specialNotifications == null)
                            {
                                d.doctor.specialNotifications = new List<string>();
                            }
                            List<String> obavestenja = d.doctor.specialNotifications;
                            obavestenja.Add("Postovani, pregled zakazan za datum: " + d.Date + " i vreme " + d.Time + " je otkazan.");
                            d.doctor.specialNotifications = obavestenja;





                            DoctorController docContr1 = new DoctorController();

                            docContr1.Update(d.doctor);

                            var s = new ZakazivanjePregleda();
                            Panel.Children.Clear();
                            Panel.Children.Add(s);

                            break;
                        }


                    }
                    foreach (Operation d in operationList)
                    {
                        if (d.ID.ToString().Equals(id) && ss.Operacija == true)
                        {
                            operationList.Remove(d);
                            oprep.Delete(d.ID);
                            operationList.Remove(d);
                            oprep.Delete(d.ID);

                            if (d.patient.Notifications == null)
                            {
                                d.patient.Notifications = new List<string>();
                            }
                            List<String> notifications1 = d.patient.Notifications;


                            notifications1.Add("Postovani, operacija zakazana za datum: " + d.Date + " i vreme " + d.Start + " je otkazana.");
                            d.patient.Notifications = notifications1;



                            PatientController pCon = new PatientController();
                            pCon.Update(d.patient);





                            if (d.Responsable.specialNotifications == null)
                            {
                                d.Responsable.specialNotifications = new List<string>();
                            }
                            List<String> obavestenja = d.Responsable.specialNotifications;
                            obavestenja.Add("Postovani,operacija zakazana za datum: " + d.Date + " i vreme " + d.Start + " je otkazana.");
                            d.Responsable.specialNotifications = obavestenja;





                            DoctorController docContr1 = new DoctorController();

                            docContr1.Update(d.Responsable);
                            var s = new ZakazivanjePregleda();
                            Panel.Children.Clear();
                            Panel.Children.Add(s);
                            break;
                        }
                    }

                    break;

                case MessageBoxResult.No:

                    break;

                case MessageBoxResult.Cancel:

                    break;
            }
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Lista ss = (Lista)dataGridTermini.Items.GetItemAt(dataGridTermini.SelectedIndex);
            string name1 = sender.ToString();
            string[] words = name1.Split(':');

            string[] words1 = name1.Split(' ');
            string id = words1[2];
            

            string sMessageBoxText = "Da li ste sigurni da zelite da otkazete ovaj termin?" + id;
            string sCaption = "Otkazivanje termina.";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    PatientUser ovajPacijent = new PatientUser();

                    String o = bingPathToAppDir(@"JsonFiles\operations.json");
                    String b = bingPathToAppDir(@"JsonFiles\appointments.json");

                    AppointmentList = new List<DoctorAppointment>();
                    operationList = new List<Operation>();

                    OperationRepository oprep = new OperationRepository(o);
                    AppointmentRepository epr = new AppointmentRepository(b);
                    operationList = oprep.GetAll();
                    AppointmentList = epr.GetAll();


                    foreach (DoctorAppointment d in AppointmentList)
                    {
                        if (d.ID.ToString().Equals(id) && ss.Pregled == true)
                        {

                            
                            Console.WriteLine(id);
                            AppointmentList.Remove(d);
                            //patientController.update(ovajPacijent);
                            epr.Delete(d.ID);
                            PatientController patContr = new PatientController();
                           
                           
                            if (d.patient.Notifications == null)
                            {
                                d.patient.Notifications = new List<string>();
                            }
                            List<String> notifications1 = d.patient.Notifications;
                            // }

                            notifications1.Add("Postovani, pregled zakazan za datum: " + d.Date + " i vreme " + d.Time + " je otkazan.");
                            d.patient.Notifications = notifications1;
                           


                            PatientController pCon = new PatientController();
                            pCon.Update(d.patient);

                            if (d.doctor.specialNotifications == null)
                            {
                                d.doctor.specialNotifications = new List<string>();
                            }
                            List<String> obavestenja = d.doctor.specialNotifications;
                            obavestenja.Add("Postovani, pregled zakazan za datum: " + d.Date + " i vreme " + d.Time + " je otkazan.");
                            d.doctor.specialNotifications = obavestenja;



                          

                            DoctorController docContr1 = new DoctorController();

                            docContr1.Update(d.doctor);
                            var s = new PopunjeniTermini();
                            Panel.Children.Clear();
                            Panel.Children.Add(s);

                            break;
                        }

                    }

                    foreach (Operation d in operationList)
                    {
                        if (d.ID.ToString().Equals(id) && ss.Operacija == true)
                        {
                            operationList.Remove(d);
                            oprep.Delete(d.ID);
                          
                            if (d.patient.Notifications == null)
                            {
                                d.patient.Notifications = new List<string>();
                            }
                            List<String> notifications1 = d.patient.Notifications;
                          

                            notifications1.Add("Postovani, operacija zakazana za datum: " + d.Date + " i vreme " + d.Start + " je otkazana.");
                            d.patient.Notifications = notifications1;



                            PatientController pCon = new PatientController();
                            pCon.Update(d.patient);





                            if (d.Responsable.specialNotifications == null)
                            {
                                d.Responsable.specialNotifications = new List<string>();
                            }
                            List<String> obavestenja = d.Responsable.specialNotifications;
                            obavestenja.Add("Postovani,operacija zakazana za datum: " + d.Date + " i vreme " + d.Start + " je otkazana.");
                            d.Responsable.specialNotifications = obavestenja;





                            DoctorController docContr1 = new DoctorController();

                            docContr1.Update(d.Responsable);
                            var s = new PopunjeniTermini();
                            Panel.Children.Clear();
                            Panel.Children.Add(s);
                            break;
                        }
                    }


                    break;


                case MessageBoxResult.No:

                    break;

                case MessageBoxResult.Cancel:

                    break;
            }







        }

        private void Pretraga_TextChanged(object sender, TextChangedEventArgs e)
        {


            List<Lista> filtered = new List<Lista>();

            foreach (Lista ee in li)
            {

                if (ee.DoctorName.ToLower().Contains(pretragaText.Text.ToLower())||ee.PatientName.ToLower().Contains(pretragaText.Text.ToLower()))
                {


                    filtered.Add(new Lista { DoctorName = ee.DoctorName, IDapp = ee.IDapp, Time = ee.Time, Date = ee.Date, ChangeName = ee.ChangeName, RemoveName = ee.RemoveName, PatientName = ee.PatientName, Ordinacija = ee.Ordinacija, Pregled = ee.Pregled, Operacija = ee.Operacija });


                }


            }

            dataGridTermini.ItemsSource = filtered;


        }

      
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {





            if (combo.SelectedIndex == 0)
            {
                List<Lista> filtered = new List<Lista>();

                foreach (Lista eee in li)
                {


                    filtered.Add(new Lista { DoctorName = eee.DoctorName, IDapp = eee.IDapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });





                }

                dataGridTermini.ItemsSource = filtered;

                return;

            }

            else if (combo.SelectedIndex == 1)
            {
                List<Lista> filtered = new List<Lista>();

                foreach (Lista eee in li)
                {

                    if (eee.DoctorName.ToLower().Contains("kardiolog"))
                    {


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, IDapp = eee.IDapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


                    }


                }

                dataGridTermini.ItemsSource = filtered;

                return;

            }
            else if (combo.SelectedIndex == 2)
            {
                List<Lista> filtered = new List<Lista>();

                foreach (Lista eee in li)
                {

                    if (eee.DoctorName.ToLower().Contains("oftamolog"))
                    {


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, IDapp = eee.IDapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


                    }


                }

                dataGridTermini.ItemsSource = filtered;

                return;


            }
            else if (combo.SelectedIndex == 3)
            {
                List<Lista> filtered = new List<Lista>();

                foreach (Lista eee in li)
                {

                    if (eee.DoctorName.ToLower().Contains("ginekolog"))
                    {


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, IDapp = eee.IDapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


                    }


                }

                dataGridTermini.ItemsSource = filtered;

                return;
            }
            else if (combo.SelectedIndex == 4)
            {
                List<Lista> filtered = new List<Lista>();

                foreach (Lista eee in li)
                {

                    if (eee.DoctorName.ToLower().Contains("onkolog"))
                    {


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, IDapp = eee.IDapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


                    }


                }

                dataGridTermini.ItemsSource = filtered;

                return;
            }
            else if (combo.SelectedIndex == 5)
            {
                List<Lista> filtered = new List<Lista>();

                foreach (Lista eee in li)
                {

                    if (eee.DoctorName.ToLower().Contains("hirurg"))
                    {


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, IDapp = eee.IDapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


                    }


                }

                dataGridTermini.ItemsSource = filtered;

                return;
            }
            else if (combo.SelectedIndex == 6)
            {
                List<Lista> filtered = new List<Lista>();

                foreach (Lista eee in li)
                {

                    if (eee.DoctorName.ToLower().Contains("porodicni_doktor"))
                    {


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, IDapp = eee.IDapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


                    }


                }

                dataGridTermini.ItemsSource = filtered;

                return;
            }
            else if (combo.SelectedIndex == 7)
            {
                List<Lista> filtered = new List<Lista>();

                foreach (Lista eee in li)
                {

                    if (eee.DoctorName.ToLower().Contains("dermatolog"))
                    {


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, IDapp = eee.IDapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


                    }


                }

                dataGridTermini.ItemsSource = filtered;

                return;
            }
            else if (combo.SelectedIndex == 8)
            {
                List<Lista> filtered = new List<Lista>();

                foreach (Lista eee in li)
                {

                    if (eee.DoctorName.ToLower().Contains("neurolog"))
                    {


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, IDapp = eee.IDapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


                    }


                }

                dataGridTermini.ItemsSource = filtered;

                return;
            }
            else if (combo.SelectedIndex == 9)
            {
                List<Lista> filtered = new List<Lista>();

                foreach (Lista eee in li)
                {

                    if (eee.DoctorName.ToLower().Contains("patolog"))
                    {


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, IDapp = eee.IDapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


                    }


                }

                dataGridTermini.ItemsSource = filtered;

                return;
            }
            else if (combo.SelectedIndex == 10)
            {
                List<Lista> filtered = new List<Lista>();

                foreach (Lista eee in li)
                {

                    if (eee.DoctorName.ToLower().Contains("pedijatar"))
                    {


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, IDapp = eee.IDapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


                    }


                }

                dataGridTermini.ItemsSource = filtered;

                return;
            }










        }

        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            List<Lista> filtered = new List<Lista>();
            foreach (Lista eee in li)
            {

                String datum = eee.Date;
                String[] delovi = datum.Split('/');
                int mesec = int.Parse(delovi[1]);
                int dan = int.Parse(delovi[0]);
                int godina = int.Parse(delovi[2]);

                DateTime datumTermina = new DateTime(godina, mesec, dan, 0, 0, 0);
                //try
               // {
                    
                    String unetDatum = datePicker.Text;
                    String[] delovi2 = unetDatum.Split('/');
                    int mesec2 = int.Parse(delovi2[1]);
                    int dan2 = int.Parse(delovi2[0]);
                    int godina2 = int.Parse(delovi2[2]);

                    DateTime trazeniDatum = new DateTime(godina2, mesec2, dan2, 0, 0, 0);
                    if (datumTermina == trazeniDatum)
                    {


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, IDapp = eee.IDapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


                    }

                    

                    //return;


               // }
               /* catch (Exception ex)
                {



                    
                    List<Lista> filtered = new List<Lista>();


                    filtered.Add(new Lista { DoctorName = eee.DoctorName, IDapp = eee.IDapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });







                    dataGridTermini.ItemsSource = filtered;

                    return;

                }*/
            }
            dataGridTermini.ItemsSource = filtered;
            return;
        }

        private void datePicker_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            var s = new IzmjenaTermina();
            Panel.Children.Clear();
            Panel.Children.Add(s);
        }
    }
}

        
    

    



