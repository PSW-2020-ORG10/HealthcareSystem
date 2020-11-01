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
using Class_diagram.Model.Hospital;
using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using HCI_wireframe;
using HCI_wireframe.Contoller;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.View.Doktor;
using Path = System.IO.Path;

namespace Klinika
{
    /// <summary>
    /// Interaction logic for Nalaz.xaml
    /// </summary>
    public partial class Nalaz : UserControl
    {

        public String tipLacenja;
        string prijavljen = App.Current.Properties["DoctorEmail"].ToString();
       public List<Medicine> lekovi { get; set; }
       public MedicineController medicineController;
        public Nalaz()
        {
            InitializeComponent();
            PatientController patientController = new PatientController();
            AppointmentController ap = new AppointmentController();

            List<PatientUser> lista1 = new List<PatientUser>();
            List<DoctorAppointment> d= new List<DoctorAppointment>();
            d = ap.GetAll();
            lista1 = patientController.GetAll();
            List<PatientUser> pacijenti = new List<PatientUser>();
            List<DoctorAppointment> pregledi = new List<DoctorAppointment>();
            //dataGridEquipment.DataContext = lista;
            medicineController = new MedicineController();

            foreach (PatientUser ee in lista1)
            {
                pacijenti.Add(new PatientUser { id = ee.id, firstName = ee.firstName, secondName = ee.secondName, uniqueCitizensidentityNumber = ee.uniqueCitizensidentityNumber, dateOfBirth = ee.dateOfBirth, phoneNumber = ee.phoneNumber, medicalIdNumber = ee.medicalIdNumber});
            }
            foreach (PatientUser regP in pacijenti)
            {
                ListaPacijenata.Items.Add(regP.firstName + " " + regP.secondName + " " + regP.medicalIdNumber);



            }
            foreach (DoctorAppointment ee in d)
            {
                String datum = ee.date;
                String[] delovi = datum.Split('/');
                int mesec = int.Parse(delovi[1]);
                int dan = int.Parse(delovi[0]);
                int godina = int.Parse(delovi[2]);

                DateTime dt1 = new DateTime(godina, mesec, dan, 0, 0, 0);

                DateTime dt2 = DateTime.Now;
                if (dt1.Date < dt2.Date)
                {
                    pregledi.Add(new DoctorAppointment { id = ee.id, patient = ee.patient, doctor = ee.doctor });
                }
            }
           
            foreach (DoctorAppointment preg in pregledi)
            {
                combo.Items.Add(preg.id + " " + preg.patient.firstName+ " " + preg.patient.secondName + " " + preg.doctor.firstName + " " + preg.doctor.secondName);

            }
            List<String> naziviLeka = new List<string>();
           lekovi = medicineController.GetAll();
            foreach(Medicine m in lekovi)
            {
                naziviLeka.Add(m.name);
            }
            lekNaziv.ItemsSource = naziviLeka;

        }
        public ObservableCollection<PatientUser> listaReg
        {
            get;
            set;
        }
        public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }
      
        private void Karton_click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new Karton();
            Panel.Children.Add(usc);
        }

        private void Sale_click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new Zauzetost();
            Panel.Children.Add(usc);
        }
        private void PromeniMe_click(object sender, RoutedEventArgs e)
        {
            Panel.Background = Brushes.White;
        }
        DoctorUser ovaj = new DoctorUser();

        private void pregled_Click(object sender, RoutedEventArgs e)
        {
         
            PatientController patientRepo = new PatientController();
            List<PatientUser> patientLista = patientRepo.GetAll();
            PatientUser ovajPacijent = new PatientUser();
            foreach (PatientUser r1 in patientLista)
            {
                if (r1.medicalIdNumber.Equals(KnjizicaBox.Text.ToString()))
                {
                    ovajPacijent = r1;
                }
            }
            if(Kucno.IsChecked == true)
            {
                tipLacenja = "Poslat na kucno lecenje";
            }
            if(Izlecen.IsChecked == true)
            {
                tipLacenja = "Izlecen";
            }
            if(Operacija.IsChecked == true)
            {
                tipLacenja = "Poslat na operaciju";
            }
            if(Operisan.IsChecked == true)
            {
                tipLacenja = "Operisan";
            }
            if(Klinicko.IsChecked == true)
            {
                tipLacenja = "Klinicko lecenje";
            }
            String dijagnoza = Dijagnoza.Text;
            String ord;
            
            Random rnd = new Random();
            int broj = rnd.Next(1, 9000);
            DoctorController dc = new DoctorController();
            List<DoctorUser> lista = dc.GetAll();
            foreach (DoctorUser s in lista)
            {
                if (s.email.Equals(prijavljen))
                {
                    ovaj = s;
                    
                }
            }
            Medicine lekm = new Medicine();
            String lekIzvucen = (String)lekNaziv.SelectedValue;
            foreach(Medicine m in lekovi)
            {
                if( m.name.Equals(lekIzvucen)) {
                    lekm = m;
                }
            }
            String alergija = ovajPacijent.allergie;
            String opisLeka = lekm.description;
            if(opisLeka.Contains(','))
            {
                String[] deloviOpisa = opisLeka.Split(',');
                for (int i = 0; i < deloviOpisa.Length; i++)
                {
                    if (deloviOpisa[i].ToLower().Equals(alergija.ToLower()))
                    {
                        MessageBox.Show("Pacijent je alergican na sastojak " + deloviOpisa[i], "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                        return;
                    }
                }
            }
            else
            {
                if (opisLeka.ToLower().Equals(alergija.ToLower()))
                {
                    MessageBox.Show("Pacijent je alergican na sastojak " + opisLeka, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }
            }
            


            Referral rf = new Referral(1, lekIzvucen, dataPicker.SelectedDate.ToString(), 1, tipLacenja, dijagnoza) ;
            
            

            AppointmentController ap = new AppointmentController();
            List<DoctorAppointment> sviPregledi = new List<DoctorAppointment>();
            sviPregledi = ap.GetAll();
            String kombo = (String)combo.SelectedValue;



            String[] novi= kombo.Split(' ');

            String neki = novi[0];
            Console.WriteLine(neki);
            DoctorAppointment zaUpdate = new DoctorAppointment();

            foreach(DoctorAppointment doc in sviPregledi)
            {
                if(neki.Equals(doc.id.ToString()))
                {
                    zaUpdate = doc;
                }
            }
            Console.WriteLine(zaUpdate.id);
            List<Referral> nalazi = new List<Referral>();

            nalazi = zaUpdate.referral;
            if (nalazi == null)
            {

                nalazi = new List<Referral>();
            }
           
            nalazi.Add(rf);
            zaUpdate.referral = nalazi;
            
            ap.Update(zaUpdate, null);




        }
    }
}