
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Class_diagram.Model.Employee;
using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using HCI_wireframe.Contoller;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.Repository;
using ProjekatHCI;
using Path = System.IO.Path;

namespace HCI_wireframe.View.Sekretar
{
    /// <summary>
    /// Interaction logic for ZakazivanjePregleda.xaml
    /// </summary>
    public partial class IzmjenaTermina : UserControl, INotifyPropertyChanged
    {
        private string datum;
        private DateTime currentDateTime;
        private DateTime endDateTime;
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
        private string timeText;
        public String TimeText
        {
            get
            {
                return timeText;
            }
            set
            {
                timeText = value;
                OnPropertyChanged1();
            }
        }

        private string timeText1;
        public String TimeText1
        {
            get
            {
                return timeText1;
            }
            set
            {
                timeText1 = value;
                OnPropertyChanged1();
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
                OnPropertyChanged1();
            }
        }
        public DateTime EndDateTime
        {
            get
            {
                return endDateTime;
            }
            set
            {
                endDateTime = value;
                TimeText1 = String.Format("{0:t}", EndDateTime);
                OnPropertyChanged1();
            }
        }
        protected void OnPropertyChanged1([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public IzmjenaTermina()
        {

            InitializeComponent();


            DoctorController DoctorContr = new DoctorController();
            List<DoctorUser> lista = new List<DoctorUser>();
            lista = DoctorContr.GetAll();
            List<DoctorUser> doktori = new List<DoctorUser>();
            CurrentDateTime = new DateTime(2020, 6, 20, 14, 9, 22);
            TimeText = String.Format("{0:t}", CurrentDateTime);
            EndDateTime = new DateTime(2020, 6, 20, 14, 9, 22);
            TimeText1 = String.Format("{0:t}", EndDateTime);
            this.DataContext = this;


            foreach (DoctorUser lekar in lista)
            {
                ListaLekara.Items.Add(lekar.firstName + " " + lekar.secondName + " " + lekar.speciality + " " + lekar.email + " " + lekar.ordination);

            }

            ListaLekara.SelectedIndex = 0;
            PatientController guestContr = new PatientController();
            List<PatientUser> pacijenti = new List<PatientUser>();
            pacijenti = guestContr.GetAll();
            List<PatientUser> lista1 = new List<PatientUser>();
            AppointmentController apCon = new AppointmentController();
            List<DoctorAppointment> pregledi = apCon.GetAll();
            foreach(DoctorAppointment preg in pregledi)
            {
                ListaTermina.ItemsSource = preg.date + preg.time + preg.doctor + preg.patient;
            }


            ListaPacijenata.SelectedIndex = 0;

            foreach (PatientUser ee in lista1)
            {
                pacijenti.Add(new PatientUser { id = ee.id, firstName = ee.firstName, secondName = ee.secondName, uniqueCitizensidentityNumber = ee.uniqueCitizensidentityNumber, dateOfBirth = ee.dateOfBirth, phoneNumber = ee.phoneNumber, medicalIdNumber = ee.medicalIdNumber, isRegisteredBySecretary = ee.isRegisteredBySecretary });
            }
            foreach (PatientUser regP in pacijenti)
            {
                ListaPacijenata.Items.Add(regP.firstName + " " + regP.secondName + " " + regP.medicalIdNumber);



            }
            foreach (PatientUser ee in lista1)
            {
                if (ListaPacijenata.SelectedItem.Equals(ee.firstName + " " + ee.secondName + " " + ee.medicalIdNumber))
                {
                    KnjizicaBox.Text = ee.medicalIdNumber;

                }
            }
            
        }

        public String Datum
        {
            get { return datum; }
            set
            {
                if (value != datum)
                {
                    datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }

        public ObservableCollection<DoctorUser> ListaLekari
        {
            get;
            set;
        }
        public ObservableCollection<PatientUser> listaGeust
        {
            get;
            set;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }

        private void Zakazi_click(object sender, RoutedEventArgs e)
        {
            String b = bingPathToAppDir(@"JsonFiles\appointments.json");
            String c = bingPathToAppDir(@"JsonFiles\refferal.json");
            String d = bingPathToAppDir(@"JsonFiles\patients.json");
            String m = bingPathToAppDir(@"JsonFiles\doctors.json");


            PatientsRepository patientRepo = new PatientsRepository(d);
            List<PatientUser> patientLista = patientRepo.GetAll();

            PatientUser ovajPacijent = new PatientUser();
            foreach (PatientUser r1 in patientLista)
            {
                if (r1.medicalIdNumber.Equals(KnjizicaBox.Text.ToString()))
                {
                    ovajPacijent = r1;
                    KnjizicaBox.Text = r1.medicalIdNumber;
                }
            }





            DoctorRepository docRepo = new DoctorRepository(m);
            List<DoctorUser> doktori = docRepo.GetAll();
            DoctorUser drOvaj = new DoctorUser();

            foreach (DoctorUser d1 in doktori)
            {
                if (d1.email.Equals(emailLekarBox.Text.ToString()))
                {
                    drOvaj = d1;

                }
            }

            String vreme = TimeText;
            String vreme2 = TimeText1;
            String[] deloviVreme = vreme.Split(':');
            String[] deloviVreme2 = vreme2.Split(':');

            TimeSpan vremee = new TimeSpan(int.Parse(deloviVreme[0]), int.Parse(deloviVreme[1]), 0);
            TimeSpan vremee2 = new TimeSpan(int.Parse(deloviVreme2[0]), int.Parse(deloviVreme2[1]), 0);

            int broj = getNextid();

            DoctorAppointment drap = new DoctorAppointment(broj, vremee, DatumBox.Text.ToString(), ovajPacijent, drOvaj, null, ordinacijaBox.Text);

            AppointmentRepository arepo = new AppointmentRepository(b);
            List<DoctorAppointment> lista2 = new List<DoctorAppointment>();
            PatientController regPat = new PatientController();
            List<PatientUser> pac = new List<PatientUser>();
            pac = regPat.GetAll();
            if (arepo.GetAll() != null)
            {
                lista2 = arepo.GetAll();
            }


            String o = bingPathToAppDir(@"JsonFiles\operations.json");
            int broj1 = getNextid1();
            Operation op = new Operation(broj1, ovajPacijent, DatumBox.Text.ToString(), vremee, vremee2, drOvaj, ordinacijaBox.Text, null);

            OperationRepository opRep = new OperationRepository(o);
            List<Operation> lista3 = new List<Operation>();
            if (opRep.GetAll() != null)
            {
                lista3 = opRep.GetAll();
            }

            if (pregled == true)
            {
                String datum = DatumBox.Text;
                String[] delovi2 = datum.Split('/');
                int mesec = int.Parse(delovi2[1]);
                int dan = int.Parse(delovi2[0]);
                int godina = int.Parse(delovi2[2]);

                DateTime dt1 = new DateTime(godina, mesec, dan, 0, 0, 0);

                DateTime dt2 = DateTime.Now;

                if (dt1 < dt2)
                {
                    MessageBox.Show("Molimo vas da unesete datum koji tek predstoji", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                String x = bingPathToAppDir(@"JsonFiles\appointments.json");
                AppointmentRepository apc = new AppointmentRepository(x);
                List<DoctorAppointment> listaPregleda = apc.GetAll();

                foreach (DoctorAppointment dd in listaPregleda)
                {
                    DoctorUser dr = dd.doctor;
                    if (dr.id == drOvaj.id)
                    {
                        if (dd.date.Equals(DatumBox.Text))
                        {
                            TimeSpan krajPr = dd.time + new TimeSpan(0, 15, 0);
                            int result = TimeSpan.Compare(vremee, dd.time);
                            int result1 = TimeSpan.Compare(vremee, krajPr);
                            if ((result == 1 && result1 == -1) || result == 0 || result1 == 0)
                            {
                                MessageBox.Show("Izvinjavamo se! Trazeni termin je vec zauzet!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }




                    }
                }
                String pre = bingPathToAppDir(@"JsonFiles\operations.json");
                OperationRepository apc1 = new OperationRepository(pre);
                List<Operation> listaPregleda1 = apc1.GetAll();
                foreach (Operation dd in listaPregleda1)
                {
                    DoctorUser dr = dd.isResponiable;
                    if (dr.id == drOvaj.id)
                    {
                        if (dd.date.Equals(DatumBox.Text))
                        {
                            int result = TimeSpan.Compare(vremee, dd.start);
                            int result1 = TimeSpan.Compare(vremee, dd.end);
                            if ((result == 1 && result1 == -1) || result == 0 || result1 == 0)
                            {

                                MessageBox.Show("Izvinjavamo se! Trazeni termin je vec zauzet!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }




                    }
                }









                EmployeesScheduleController schCon = new EmployeesScheduleController();
                List<Schedule> listaRasporeda = schCon.GetAll();
                Shift smena = new Shift();
                foreach (Schedule s in listaRasporeda)
                {

                    if (s.employeeid.Equals(drOvaj.id.ToString()))
                    {
                        if (s.date.Equals(DatumBox.Text))
                        {
                            smena = s.shift;
                        }
                    }
                }
                if (smena.startTime == null || smena.endTime == null)
                {
                    MessageBox.Show("Trazeni termin nije dostupan.Lekar ne radi tog dana.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }
                String pocetak = smena.startTime;
                String kraj = smena.endTime;
                String[] deloviPocetak = pocetak.Split(':');
                String[] deloviKraj = kraj.Split(':');

                TimeSpan pocetakTime = new TimeSpan(int.Parse(deloviPocetak[0]), int.Parse(deloviPocetak[1]), int.Parse("00"));
                TimeSpan krajTime = new TimeSpan(int.Parse(deloviKraj[0]), int.Parse(deloviKraj[1]), int.Parse("00"));
                int result3 = TimeSpan.Compare(vremee, pocetakTime);
                int result4 = TimeSpan.Compare(krajTime, vremee);

                if (result3 != 1 || result4 != 1)
                {
                    MessageBox.Show("Trazeni termin nije dostupan.Lekar ne radi u to vreme.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;

                }


                AppointmentController apCon = new AppointmentController();
                apCon.New(drap, null);
                Panel.Children.Clear();
                UserControl usc = new PopunjeniTermini();
                Panel.Children.Add(usc);
            }
            else if (operacija == true)
            {
                String datum = DatumBox.Text;
                String[] delovi2 = datum.Split('/');
                int mesec = int.Parse(delovi2[1]);
                int dan = int.Parse(delovi2[0]);
                int godina = int.Parse(delovi2[2]);

                DateTime dt1 = new DateTime(godina, mesec, dan, 0, 0, 0);

                DateTime dt2 = DateTime.Now;

                if (dt2 > dt1)
                {
                    MessageBox.Show("Molimo vas da unesete termin koji tek predstoji", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                String x = bingPathToAppDir(@"JsonFiles\appointments.json");
                AppointmentRepository apc = new AppointmentRepository(x);
                List<DoctorAppointment> listaPregleda = apc.GetAll();
                foreach (DoctorAppointment dd in listaPregleda)
                {
                    DoctorUser dr = dd.doctor;
                    if (dr.id == drOvaj.id)
                    {
                        if (dd.date.Equals(DatumBox.Text))
                        {
                            TimeSpan krajPr = dd.time + new TimeSpan(0, 15, 0);
                            int result = TimeSpan.Compare(vremee, dd.time);
                            int result1 = TimeSpan.Compare(vremee, krajPr);
                            if ((result == 1 && result1 == -1) || result == 0 || result1 == 0)
                            {
                                MessageBox.Show("Izvinjavamo se! Trazeni termin je vec zauzet!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }




                    }
                }
                String pre = bingPathToAppDir(@"JsonFiles\operations.json");
                OperationRepository apc1 = new OperationRepository(pre);
                List<Operation> listaPregleda1 = apc1.GetAll();
                foreach (Operation dd in listaPregleda1)
                {
                    DoctorUser dr = dd.isResponiable;
                    if (dr.id == drOvaj.id)
                    {
                        if (dd.date.Equals(DatumBox.Text))
                        {
                            int result = TimeSpan.Compare(vremee, dd.start);
                            int result1 = TimeSpan.Compare(vremee, dd.end);
                            if ((result == 1 && result1 == -1) || result == 0 || result1 == 0)
                            {

                                MessageBox.Show("Izvinjavamo se! Trazeni termin je vec zauzet!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }




                    }
                }









                EmployeesScheduleController schCon = new EmployeesScheduleController();
                List<Schedule> listaRasporeda = schCon.GetAll();
                Shift smena = new Shift();
                foreach (Schedule s in listaRasporeda)
                {

                    if (s.employeeid.Equals(drOvaj.id.ToString()))
                    {
                        if (s.date.Equals(DatumBox.Text))
                        {
                            smena = s.shift;
                        }
                    }
                }
                if (smena.startTime == null || smena.endTime == null)
                {
                    MessageBox.Show("Trazeni termin nije dostupan.Lekar ne radi tog dana.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }
                String pocetak = smena.startTime;
                String kraj = smena.endTime;
                String[] deloviPocetak = pocetak.Split(':');
                String[] deloviKraj = kraj.Split(':');

                TimeSpan pocetakTime = new TimeSpan(int.Parse(deloviPocetak[0]), int.Parse(deloviPocetak[1]), int.Parse("00"));
                TimeSpan krajTime = new TimeSpan(int.Parse(deloviKraj[0]), int.Parse(deloviKraj[1]), int.Parse("00"));
                int result3 = TimeSpan.Compare(vremee, pocetakTime);
                int result4 = TimeSpan.Compare(krajTime, vremee);

                if (result3 != 1 || result4 != 1)
                {
                    MessageBox.Show("Trazeni termin nije dostupan.Lekar ne radi u to vreme.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;

                }

                OperationController opCon = new OperationController();
                opCon.New(null, op);
                Panel.Children.Clear();
                UserControl usc = new PopunjeniTermini();
                Panel.Children.Add(usc);
            }

        }

        private int getNextid()
        {
            AppointmentController rp = new AppointmentController();
            List<DoctorAppointment> lista = rp.GetAll();

            int number = 0;

            foreach (DoctorAppointment r in lista)
            {
                if (r.id > number)
                {
                    number = r.id;
                }
            }

            number += 1;
            return number;

        }
        private int getNextid1()
        {
            OperationController rp = new OperationController();
            List<Operation> lista = rp.GetAll();

            int number = 10;

            foreach (Operation r in lista)
            {
                if (r.id > number)
                {
                    number = r.id;
                }
            }

            number += 1;
            return number;

        }

        public void Izaberi_click(object sender, RoutedEventArgs e)
        {

        }
        private void setButtonVisibility()
        {
            if (KnjizicaBox.Text != String.Empty && ordinacijaBox.Text != String.Empty && emailLekarBox.Text != String.Empty && Regex.Match(KnjizicaBox.Text, @"^([0-9]+)$").Success && Regex.Match(DatumBox.Text, @"^\d{2}/\d{2}/\d{4}$").Success
                 && Regex.Match(emailLekarBox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$").Success && DatumBox.Text.ToString() != "" && timeButton.Value.ToString() != "" && ListaPacijenata.SelectedItem.ToString() != "" && ListaLekara.SelectedItem.ToString() != "")

            {

                zakazi.IsEnabled = true;


            }



            else
            {
                zakazi.IsEnabled = false;



            }

        }
        public List<DoctorAppointment> GetAll()
        {
            String b = bingPathToAppDir(@"JsonFiles\pregledi.json");
            AppointmentRepository eq = new AppointmentRepository(b);


            List<DoctorAppointment> areq = eq.GetAll();


            return areq;
        }
        /*public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                System.IO.Path.GetFullPath(System.IO.Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }
        internal void addNew(DoctorAppointment appointment)
        {
            String b = bingPathToAppDir(@"JsonFiles\pregledi.json");
            AppointmentRepository eq = new AppointmentRepository(b);


            List<DoctorAppointment> areq = eq.GetAll();

            areq.Add(appointment);
            eq.NewWithList(areq);


        }
        public void Zakazi_click(object sender, RoutedEventArgs e)
        {
            //string[] delovi = ListaPacijenata.SelectedItem;
            // RegistredPatientController scon = new RegistredPatientController();
            //List<RegistredPatient> lista = scon.GetAll();

            // foreach (RegistredPatient s in lista)
            //{
            //  if (s.medicalIdNumber.Equals(KnjizicaBox.Text))
            //{


            //AppointmentController rpcontroller = new AppointmentController();
            String b = bingPathToAppDir(@"JsonFiles\pregledi.json");
           // String c = bingPathToAppDir(@"JsonFiles\refferal.json");
            String d = bingPathToAppDir(@"JsonFiles\osobe.json");

            RegistredPatientRepository patientRepo = new RegistredPatientRepository(d);
            List<RegistredPatient> patientLista = patientRepo.GetAll();

            RegistredPatient ovajPacijent = new RegistredPatient();
            foreach (RegistredPatient r1 in patientLista)
            {
                if (r1.Email.Equals("nikola@gmail.com"))
                {
                    ovajPacijent = r1;
                }
            }
          //  Referral rf = new Referral(0, ovajPacijent, Classification.HomeTreatment);

           // ReferralRepository refRepo = new ReferralRepository(c);
            //List<Referral> lista = refRepo.GetAll();
            //lista.Add(rf);
           // refRepo.NewWithList(lista);

            TimeSpan interval = new TimeSpan(12, 14, 18);

            DoctorAppointment drap = new DoctorAppointment(0, interval, "12.12.1231", ovajPacijent, null, null, false);

            AppointmentRepository arepo = new AppointmentRepository(b);
            List<DoctorAppointment> lista2 = arepo.GetAll();
            lista2.Add(drap);
            arepo.NewWithList(lista2);
            //  rpcontroller.addNew(rp);
            // }
            //}

            Panel.Children.Clear();
            UserControl usc = new PopunjeniTermini();
            Panel.Children.Add(usc);

        }*/
        public void Odustani_click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new PocetnaStranica();
            Panel.Children.Add(usc);
        }
        public void RasporedLekara_Click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new RasporedLekara();
            Panel.Children.Add(usc);
        }
        public void RasporedProstorija_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            setButtonVisibility();
        }
        public void Pomoc_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Otvorili ste formu za zakazivanje pregleda.\n" +
                " Unesite ime i prezime pacijenta kom zelite da zakazete pregled. Ukoliko pacijent nije registrovan u sistem nase bolnice, prvo ga registrujte ili dodajte u spisak guest pacijenata." +
                "\n Izaberite lekara, ordinaciju, datum, vreme i vrstu zakazivanja a nakon toga kliknite na dugme 'ZAKAZI' da biste izvrsili zakazivanje." +
                "\n Za odustanak kliknite dugme 'ODUSTANAK'.");
        }

        private void KnjizicaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void emailLekarBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }
        private void DatumRodjBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }
        private void ordinacijaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void datum_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void timePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            setButtonVisibility();
        }

        private void ListaLekara_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selektovano = ListaLekara.SelectedItem.ToString();
                string[] tokens = selektovano.Split(' ');
                string email = tokens[3];
                string ordinacija = tokens[4];


                emailLekarBox.Text = email;
                ordinacijaBox.Text = ordinacija;
                setButtonVisibility();
            }
            catch (Exception ex)
            {
                emailLekarBox.Text = "";
                ordinacijaBox.Text = "";
                setButtonVisibility();

            }
        }
        public Boolean pregled = false;
        public Boolean operacija = false;
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

            pregled = sender == pregledBtn;
            endTimeButton.IsEnabled = false;

        }
        private void RadioButton_Checked1(object sender, RoutedEventArgs e)
        {
            operacija = sender == operacijaBtn;
            endTimeButton.IsEnabled = true;


        }
        private void ListaPacijenata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selektovano = ListaPacijenata.SelectedItem.ToString();
                string[] tokens = selektovano.Split(' ');
                string brknj = tokens[2];

                KnjizicaBox.Text = brknj;
                setButtonVisibility();
            }
            catch (Exception ex)
            {
                KnjizicaBox.Text = "";
                setButtonVisibility();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
