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
using Path = System.IO.Path;

using Klinika;
using HCI_wireframe.Model.Patient;

namespace HCI_wireframe.View.Doktor
{
    /// <summary>
    /// Interaction logic for ZakazivanjePregleda.xaml
    /// </summary>
    public partial class ZakazivanjePregleda : UserControl, INotifyPropertyChanged
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

        public ZakazivanjePregleda()
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
                ListaLekara.Items.Add(lekar.firstName + " " + lekar.secondName + " " + lekar.speciality+ " " + lekar.email + " " + lekar.ordination);

            }

            ListaLekara.SelectedIndex = 0;
            PatientController guestContr = new PatientController();
            List<PatientUser> pacijenti = new List<PatientUser>();
            pacijenti = guestContr.GetAll();
            List<PatientUser> lista1 = new List<PatientUser>();


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
            if (!Regex.Match(Time1Box.Text, "^[0-9]{2}:[0-9]{2}$").Success || !Regex.Match(Time2Box.Text, "^[0-9]{2}:[0-9]{2}$").Success)
            {
                MessageBox.Show("Vreme mora biti u formatu 00:00", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            String[] startParts = Time1Box.Text.Split(':');
            String[] endParts = Time2Box.Text.Split(':');
            int startIntPart1 = int.Parse(startParts[0]);
            int startIntPart2 = int.Parse(startParts[1]);
            int ensIntPart1 = int.Parse(endParts[0]);
            int endtIntPart2 = int.Parse(endParts[1]);


            if (startIntPart1 > 23 || startIntPart2 > 60 || ensIntPart1 > 23 || endtIntPart2 > 60 || startIntPart1 > ensIntPart1)
            {
                MessageBox.Show("Najveca vrednost za vreme je 23:59", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            TimeSpan vremee = new TimeSpan(startIntPart1, startIntPart2, 00);
            TimeSpan vremee2 = new TimeSpan(ensIntPart1, endtIntPart2, 00);

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


                /* foreach (DoctorAppointment dd in listaPregleda)
                 {
                     DoctorUser dr = dd.doctor;
                     if (dr.id == drOvaj.id)
                     {
                         if (dd.Date.Equals(DatumBox.Text))
                         {
                             TimeSpan krajPr = dd.Time + new TimeSpan(0, 15, 0);
                             int result = TimeSpan.Compare(vremee, dd.Time);
                             int result1 = TimeSpan.Compare(vremee, krajPr);
                             if ((result == 1 && result1 == -1) || result == 0)
                             {
                                 MessageBox.Show("Izvinjavamo se! Trazeni termin je vec zauzet!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                                 return;
                             }
                         }




                     }
                 }*/
                /*  String pre = bingPathToAppDir(@"JsonFiles\operations.json");
                  OperationRepository apc1 = new OperationRepository(pre);
                  List<Operation> listaPregleda1 = apc1.GetAll();
                  foreach (Operation dd in listaPregleda1)
                  {
                      DoctorUser dr = dd.isResponiable;
                      if (dr.id == drOvaj.id)
                      {
                          if (dd.Date.Equals(DatumBox.Text))
                          {
                              int result = TimeSpan.Compare(vremee, dd.Start);
                              int result1 = TimeSpan.Compare(vremee, dd.End);
                              if ((result == 1 && result1 == -1)||result==0 ||result1==0)
                              {

                                  MessageBox.Show("Izvinjavamo se! Trazeni termin je vec zauzet!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                                  return;
                              }

                          }




                      }
                  }*/









                EmployeesScheduleController schCon = new EmployeesScheduleController();
                List<Schedule> listaRasporeda = schCon.GetAll();
                Shift smena = schCon.getShiftForDoctorForSpecificDay(DatumBox.Text, drOvaj);
                if (smena == null || smena.startTime == null || smena.endTime == null)
                {
                    MessageBox.Show("Trazeni termin nije dostupan.Lekar ne radi tog dana.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }
                AppointmentController appointmentController = new AppointmentController();
                Boolean notAvaible = appointmentController.isTermNotAvailable(drOvaj, vremee, DatumBox.Text, ovajPacijent);
                if (notAvaible == true)
                {
                    MessageBox.Show("Izvinjavamo se! Trazeni termin je vec zauzet!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                /* foreach (Schedule s in listaRasporeda)
                 {

                     if (s.employeeid.Equals(drOvaj.id.ToString()))
                     {
                         if (s.Date.Equals(DatumBox.Text))
                         {
                             smena = s.shift;
                         }
                     }
                 }
                 if(smena.StartTime==null || smena.EndTime == null)
                 {

                 }*/

                bool slobodan = schCon.isDoctorWorkingAtSpecifiedTime(DatumBox.Text, drOvaj, vremee);
                if (slobodan == false)
                {
                    MessageBox.Show("Trazeni termin nije dostupan.Lekar ne radi u to vreme.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }

                /* String pocetak = smena.StartTime;
                 String kraj = smena.EndTime;
                 String[] deloviPocetak = pocetak.Split(':');
                 String[] deloviKraj = kraj.Split(':');

                 TimeSpan pocetakTime = new TimeSpan(int.Parse(deloviPocetak[0]), int.Parse(deloviPocetak[1]), 0);
                 TimeSpan krajTime = new TimeSpan(int.Parse(deloviKraj[0]), int.Parse(deloviKraj[1]), 0);
                 int result3 = TimeSpan.Compare(vremee, pocetakTime);
                 int result4 = TimeSpan.Compare(krajTime, vremee);

                 if (result3 != 1 || result4 != 1)
                 {
                     MessageBox.Show("Trazeni termin nije dostupan.Lekar ne radi u to vreme.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

                     return;

                 }*/


                AppointmentController apCon = new AppointmentController();
                apCon.New(drap, null);
                int id1 = 0;
                String ime = "";
                String prezime = "";
                String jmbg = "";
                String datumRodj = "";
                String brojTel = "";
                String brKnj = "";
                List<Question> pitanja = new List<Question>();
                String alergije = "";
                String grad = "";
                Boolean guest = false;
                String email = "";
                String password = "";
                Boolean sekr = false;

                //  foreach (PatientUser pat in lista)
                // {
                // if (pat.id.Equals(d.patient.id))
                // {
                id1 = drap.patient.id;
                ime = drap.patient.firstName;
                prezime = drap.patient.secondName;
                jmbg = drap.patient.uniqueCitizensidentityNumber;
                datumRodj = drap.patient.dateOfBirth;
                brKnj = drap.patient.medicalIdNumber;
                brojTel = drap.patient.phoneNumber;
               
                alergije = drap.patient.allergie;
                grad = drap.patient.city;
                email = drap.patient.email;
                guest = drap.patient.guest;
                password = drap.patient.password;
                sekr = drap.patient.isRegisteredBySecretary;
                if (drap.patient.notifications == null)
                {
                    drap.patient.notifications = new List<ModelNotification>();
                }
                List<ModelNotification> notifications = drap.patient.notifications;
                // }

                notifications.Add(new ModelNotification("Postovani, zakazana vam je novi pregled datuma : " + drap.date + " u " + drap.time + " h kod lekara " + drap.doctor.firstName + " " + drap.doctor.secondName + ". Ordinacija: " + drap.roomid));
                drap.patient.notifications = notifications;
                // PatientUser rp = new PatientUser(id1, ime, prezime, jmbg, datumRodj, brojTel, brKnj, pitanja, alergije, grad, guest, email, password, sekr, notifications);


                PatientController pCon = new PatientController();
                pCon.Update(drap.patient);
                Panel.Children.Clear();
                UserControl usc = new RezervisaniiTermini();
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
                /*  List<DoctorAppointment> listaPregleda = apc.GetAll();
                  foreach (DoctorAppointment dd in listaPregleda)
                  {
                      DoctorUser dr = dd.doctor;
                      if (dr.id == drOvaj.id)
                      {
                          if (dd.Date.Equals(DatumBox.Text))
                          {
                              TimeSpan krajPr = dd.Time + new TimeSpan(0, 15, 0);
                              int result = TimeSpan.Compare(vremee, dd.Time);
                              int result1 = TimeSpan.Compare(vremee, krajPr);
                              if ((result == 1 && result1 == -1) || result == 0)
                              {
                                  MessageBox.Show("Izvinjavamo se! Trazeni termin je vec zauzet!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                                  return;
                              }
                              int rezultat = TimeSpan.Compare(vremee2, dd.Time);
                              int rezultat1 = TimeSpan.Compare(vremee2, krajPr);
                              if ((rezultat == 1 && rezultat1 == -1) || rezultat == 0)
                              {

                                  MessageBox.Show("Izvinjavamo se! Trazeni termin je vec zauzet!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                                  return;
                              }
                          }




                      }
                  }*/
                /*String pre = bingPathToAppDir(@"JsonFiles\operations.json");
                OperationRepository apc1 = new OperationRepository(pre);
                List<Operation> listaPregleda1 = apc1.GetAll();
                foreach (Operation dd in listaPregleda1)
                {
                    DoctorUser dr = dd.isResponiable;
                    if (dr.id == drOvaj.id)
                    {
                        if (dd.Date.Equals(DatumBox.Text))
                        {
                            int result = TimeSpan.Compare(vremee, dd.Start);
                            int result1 = TimeSpan.Compare(vremee, dd.End);
                            if ((result == 1 && result1 == -1) || result == 0)
                            {

                                MessageBox.Show("Izvinjavamo se! Trazeni termin je vec zauzet!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                            int rezultat = TimeSpan.Compare(vremee2, dd.Start);
                            int rezultat1 = TimeSpan.Compare(vremee2, dd.End);
                            if ((rezultat == 1 && rezultat1 == -1) || rezultat == 0)
                            {

                                MessageBox.Show("Izvinjavamo se! Trazeni termin je vec zauzet!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }




                    }
                }*/



                OperationController opCon = new OperationController();

                bool zauzetTermin = opCon.isTermNotAvailable(drOvaj, vremee, vremee2, DatumBox.Text, ovajPacijent);
                if (zauzetTermin == true)
                {
                    MessageBox.Show("Trazeni termin nije dostupan.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }

                EmployeesScheduleController schCon = new EmployeesScheduleController();
                List<Schedule> listaRasporeda = schCon.GetAll();
                Shift smena = schCon.getShiftForDoctorForSpecificDay(DatumBox.Text, drOvaj);
                if (smena == null || smena.startTime == null || smena.endTime == null)
                {
                    MessageBox.Show("Trazeni termin nije dostupan.Lekar ne radi tog dana.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }

                bool slobodan = schCon.isDoctorWorkingAtSpecifiedTime(DatumBox.Text, drOvaj, vremee);
                if (slobodan == false)
                {
                    MessageBox.Show("Trazeni termin nije dostupan.Lekar ne radi u to vreme.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }


                String pocetak = smena.startTime;
                String kraj = smena.endTime;
                String[] deloviPocetak = pocetak.Split(':');
                String[] deloviKraj = kraj.Split(':');

                TimeSpan pocetakTime = new TimeSpan(int.Parse(deloviPocetak[0]), int.Parse(deloviPocetak[1]), int.Parse("00"));
                TimeSpan krajTime = new TimeSpan(int.Parse(deloviKraj[0]), int.Parse(deloviKraj[1]), int.Parse("00"));
                int result3 = TimeSpan.Compare(vremee2, pocetakTime);
                int result4 = TimeSpan.Compare(krajTime, vremee2);

                if (result3 != 1 || result4 != 1)
                {
                    MessageBox.Show("Trazeni termin nije dostupan.Lekar ne radi u to vreme.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;

                }
               

                /* EmployeesScheduleController schCon = new EmployeesScheduleController();
                 List<Schedule> listaRasporeda = schCon.GetAll();
                 Shift smena = new Shift();
                 foreach (Schedule s in listaRasporeda)
                 {

                     if (s.employeeid.Equals(drOvaj.id.ToString()))
                     {
                         if (s.Date.Equals(DatumBox.Text))
                         {
                             smena = s.shift;
                         }
                     }
                 }
                 if (smena.StartTime == null || smena.EndTime == null)
                 {
                     MessageBox.Show("Trazeni termin nije dostupan.Lekar ne radi tog dana.", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);

                     return;
                 }*/
                /* String pocetak = smena.StartTime;
                 String kraj = smena.EndTime;
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

                 }*/


                opCon.New(null, op);
                PatientController pCon = new PatientController();
                List<PatientUser> pacijenti = pCon.GetAll();

                int id1 = 0;
                String ime = "";
                String prezime = "";
                String jmbg = "";
                String datumRodj = "";
                String brojTel = "";
                String brKnj = "";
                List<Question> pitanja = new List<Question>();
                String alergije = "";
                String grad = "";
                Boolean guest = false;
                String email = "";
                String password = "";
                Boolean sekr = false;
                List<ModelNotification> notifications = new List<ModelNotification>();
                //  foreach (PatientUser pat in lista)
                // {
                // if (pat.id.Equals(d.patient.id))
                // {
                id1 = op.patient.id;
                ime = op.patient.firstName;
                prezime = op.patient.secondName;
                jmbg = op.patient.uniqueCitizensidentityNumber;
                datumRodj = op.patient.dateOfBirth;
                brojTel = op.patient.phoneNumber;
              
                alergije = op.patient.allergie;
                grad = op.patient.city;
                email = op.patient.email;
                guest = op.patient.guest;
                password = op.patient.password;
                sekr = op.patient.isRegisteredBySecretary;
                notifications = op.patient.notifications;
                // }
                if (notifications == null)
                {
                    notifications = new List<ModelNotification>();
                }
                notifications.Add(new ModelNotification("Postovani, zakazana Vam je nova operacija datuma : " + op.date + " u " + op.start + " h, kod lekara " + op.isResponiable.firstName + " " + op.isResponiable.secondName + " Sala " + op.idRoom));

                PatientUser rp = new PatientUser(id1, ime, prezime, jmbg, datumRodj, brojTel, brKnj, alergije, grad, guest, email, password, sekr, notifications);



                pCon.Update(rp);


                Panel.Children.Clear();
                UserControl usc = new RezervisaniiTermini();
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
                 && Regex.Match(emailLekarBox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$").Success && DatumBox.Text.ToString() != ""  && ListaPacijenata.SelectedItem.ToString() != "" && ListaLekara.SelectedItem.ToString() != "")

            {

                zakazi.IsEnabled = true;


            }



            else
            {
                zakazi.IsEnabled = false;



            }

        }

       
        public void RasporedLekara_Click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new RezervisaniiTermini();
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
                string ordinacija = tokens[4] + tokens[5];



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
            Time2Box.IsEnabled = true;

        }
        private void RadioButton_Checked1(object sender, RoutedEventArgs e)
        {
            operacija = sender == operacijaBtn;
            Time2Box.IsEnabled = true;


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

        private void Termini_Click(object sender, RoutedEventArgs e)
        {

            String m = bingPathToAppDir(@"JsonFiles\doctors.json");
            AppointmentController apcon = new AppointmentController();

            List<DoctorAppointment> pregledi = apcon.GetAll();
            OperationController opcon = new OperationController();
            List<Operation> operacije = opcon.GetAll();
            DoctorRepository docRepo = new DoctorRepository(m);
            List<DoctorUser> doktori = docRepo.GetAll();
            DoctorUser drOvaj = new DoctorUser();
            String poruka = "";
            foreach (DoctorUser d1 in doktori)
            {
                if (d1.email.Equals(emailLekarBox.Text.ToString()))
                {
                    drOvaj = d1;

                }
            }
            EmployeesScheduleController schCon = new EmployeesScheduleController();
            List<Schedule> raspored = schCon.GetAll();
            Boolean duznost = false;
            foreach (Schedule rasp in raspored)
            {
                if (rasp.employeeid.Equals(drOvaj.id.ToString()))
                {
                    if (DatumBox.Text.Equals(rasp.date))
                    {
                        duznost = true;
                        poruka += "Lekar datuma " + rasp.date + " radi od " + rasp.shift.startTime + " do " + rasp.shift.endTime + ".\n";


                    }


                }
            }
            if (duznost == false)
            {
                poruka += "Lekar nije da duznosti trazenog datuma.";

            }
            if (duznost == true)
            {
                poruka += "Zauzeti termini su: \n";
                foreach (DoctorAppointment d in pregledi)
                {
                    TimeSpan kraj = d.time + new TimeSpan(0, 15, 0);
                    if (d.doctor.id.ToString().Equals(drOvaj.id.ToString()))
                    {
                        if (d.date.Equals(DatumBox.Text))
                        {

                            poruka += " " + d.time + " - " + kraj + "\n";
                        }
                    }
                }
                foreach (Operation d in operacije)
                {

                    if (d.isResponiable.id.ToString().Equals(drOvaj.id.ToString()))
                    {
                        if (d.date.Equals(DatumBox.Text))
                        {

                            poruka += " " + d.start + " - " + d.end + "\n";
                        }
                    }
                }
            }
            MessageBox.Show(poruka, "Raspored lekara za trazeni datum", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
