using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
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
using Path = System.IO.Path;

namespace HCI_wireframe.View.Doktor
{
    /// <summary>
    /// Interaction logic for RezervisaniiTermini.xaml
    /// </summary>
    public partial class RezervisaniiTermini : UserControl
    {
        public int vrsta = 0;
        public class Lista
        {
            public bool Pregled { get; set; }
            public bool Operacija { get; set; }
            public String DoctorName { get; set; }

            public TimeSpan Time { get; set; }

            public String Date { get; set; }
            public int idapp { get; set; }
            public String PatientName { get; set; }

            public String ChangeName { get; set; }
            public String RemoveName { get; set; }
            public String Ordinacija { get; set; }
            public bool pregled { get; set; }
            public Lista()
            {

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


        public RezervisaniiTermini()
        {
            InitializeComponent();
            this.DataContext = this;

            String b = bingPathToAppDir(@"JsonFiles\appointments.json");



            AppointmentList = new List<DoctorAppointment>();

            AppointmentRepository epr = new AppointmentRepository(b);
            
                AppointmentList = epr.GetAll();

            


            foreach (DoctorAppointment ee in AppointmentList)
            {

               
                    DoctorUser doc = ee.doctor;
                    StringBuilder l = new StringBuilder();
                    l.Append(doc.firstName + " ");
                    l.Append(doc.secondName + " ");
                    l.Append(doc.speciality);
                    StringBuilder p = new StringBuilder();
                    PatientUser pat = ee.patient;
                    p.Append(pat.firstName + " ");
                    p.Append(pat.secondName);

                    li.Add(new Lista
                    {
                        DoctorName = l.ToString(),

                        idapp = ee.id,
                        Time = ee.time,
                        Date = ee.date,
                        ChangeName = "IZMENI " + ee.id,
                        RemoveName = "OTKAŽI " + ee.id,
                        PatientName = p.ToString(),
                       // Ordinacija = ee.ordination.ToString(),
                        Pregled = true,
                        Operacija = false

                    });




                

                AppLista = li;
                vrsta = 0;

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

                String datum1 = ee.date;
                String[] delovi1 = datum1.Split('/');
                int mesec1 = int.Parse(delovi1[1]);
                int dan1 = int.Parse(delovi1[0]);
                int godina1 = int.Parse(delovi1[2]);

                DateTime dt3 = new DateTime(godina1, mesec1, dan1, 0, 0, 0);

                DateTime dt4 = DateTime.Now;


                if (dt3.Date >= dt4.Date)
                {

                    DoctorUser doc = ee.isResponiable;
                    StringBuilder l = new StringBuilder();
                    l.Append(doc.firstName + " ");
                    l.Append(doc.secondName + " ");
                    l.Append(doc.speciality);
                    StringBuilder p = new StringBuilder();
                    PatientUser pat = ee.patient;
                    p.Append(pat.firstName + " ");
                    p.Append(pat.secondName);

                    li.Add(new Lista
                    {
                        DoctorName = l.ToString(),

                        idapp = ee.id,
                        //Time = ee.Time,
                        Date = ee.date,
                        ChangeName = "IZMENI " + ee.id,
                        RemoveName = "OTKAŽI " + ee.id,
                        PatientName = p.ToString(),
                        Ordinacija = ee.idRoom.ToString(),
                        Pregled = false,
                        Operacija = true

                    });




                }


                AppLista = li;
                vrsta = 1;

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

            string name1 = sender.ToString();
            string[] words = name1.Split(':');

            string[] words1 = name1.Split(' ');
            string id = words1[2];


            string sMessageBoxText = "Da li ste sigurni da zelite da izmenite ovaj termin?" + id;
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

                        Console.WriteLine(d.id);
                        if (d.id.ToString().Equals(id))
                        {


                            Console.WriteLine(id);
                            AppointmentList.Remove(d);
                          
                            epr.Delete(d.id);
                            var s = new ZakazivanjePregleda();
                            Panel.Children.Clear();
                            Panel.Children.Add(s);

                            break;
                        }


                    }
                    foreach (Operation op in operationList)
                    {
                        if (op.id.ToString().Equals(id))
                        {
                            operationList.Remove(op);
                            oprep.Delete(op.id);
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
                        if (d.id.ToString().Equals(id))
                        {


                       
                            AppointmentList.Remove(d);
                            //patientController.update(ovajPacijent);
                            epr.Delete(d.id);
                            var s = new RezervisaniiTermini();
                            Panel.Children.Clear();
                            Panel.Children.Add(s);

                            break;
                        }

                    }

                    foreach (Operation op in operationList)
                    {
                        if (op.id.ToString().Equals(id))
                        {
                            operationList.Remove(op);
                            oprep.Delete(op.id);
                            var s = new RezervisaniiTermini();
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

                if (ee.DoctorName.ToLower().Contains(Pretraga.Text.ToLower()) || ee.PatientName.ToLower().Contains(Pretraga.Text.ToLower()))
                {


                    filtered.Add(new Lista { DoctorName = ee.DoctorName, idapp = ee.idapp, Time = ee.Time, Date = ee.Date, ChangeName = ee.ChangeName, RemoveName = ee.RemoveName, PatientName = ee.PatientName, Ordinacija = ee.Ordinacija, Pregled = ee.Pregled, Operacija = ee.Operacija });


                }


            }

            dataGridTermini.ItemsSource = filtered;


        }

        private void dataGridTermini_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {





            if (combo.SelectedIndex == 0)
            {
                List<Lista> filtered = new List<Lista>();

                foreach (Lista eee in li)
                {


                    filtered.Add(new Lista { DoctorName = eee.DoctorName, idapp = eee.idapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });





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


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, idapp = eee.idapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


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


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, idapp = eee.idapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


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


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, idapp = eee.idapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


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


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, idapp = eee.idapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


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


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, idapp = eee.idapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


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


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, idapp = eee.idapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


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


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, idapp = eee.idapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


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


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, idapp = eee.idapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


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


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, idapp = eee.idapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


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


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, idapp = eee.idapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


                    }


                }

                dataGridTermini.ItemsSource = filtered;

                return;
            }










        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {


            foreach (Lista eee in li)
            {

                String datum = eee.Date;
                String[] delovi = datum.Split('/');
                int mesec = int.Parse(delovi[1]);
                int dan = int.Parse(delovi[0]);
               // int godina = int.Parse(delovi[2]);

                DateTime datumTermina = new DateTime(2020, mesec, dan, 0, 0, 0);
                try
                {
                    List<Lista> filtered = new List<Lista>();
                    String unetDatum = datePicker.Text;
                    String[] delovi2 = unetDatum.Split('/');
                    int mesec2 = int.Parse(delovi2[1]);
                    int dan2 = int.Parse(delovi2[0]);
                    int godina2 = int.Parse(delovi2[2]);

                    DateTime trazenidatum = new DateTime(godina2, mesec2, dan2, 0, 0, 0);
                    if (datumTermina == trazenidatum)
                    {


                        filtered.Add(new Lista { DoctorName = eee.DoctorName, idapp = eee.idapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });


                    }

                    dataGridTermini.ItemsSource = filtered;

                    return;


                }
                catch (Exception ex)
                {




                    List<Lista> filtered = new List<Lista>();


                    filtered.Add(new Lista { DoctorName = eee.DoctorName, idapp = eee.idapp, Time = eee.Time, Date = eee.Date, ChangeName = eee.ChangeName, RemoveName = eee.RemoveName, PatientName = eee.PatientName, Ordinacija = eee.Ordinacija, Pregled = eee.Pregled, Operacija = eee.Operacija });







                    dataGridTermini.ItemsSource = filtered;

                    return;

                }
            }
        }
    }
}









