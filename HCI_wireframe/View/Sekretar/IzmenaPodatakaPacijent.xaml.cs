using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Class_diagram.Model.Patient;
using HCI_wireframe.Model.Patient;

namespace ProjekatHCI
{
    /// <summary>
    /// Interaction logic for IzmenaPodatakaPacijent.xaml
    /// </summary>
    public partial class IzmenaPodatakaPacijent : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PatientUser pacijent { get; set; }
        public virtual void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }


        private string ime;
        private string prezime;
        private string datumRodjenja;
        private string jmbg;
        private string email;
        private string brojTelefona;
        private string adresa;
        private string brojZdrKnjizice;
        private int pol;
        private string lozinka;
        private string lozinka2;




        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public string Lozinka
        {
            get { return lozinka; }
            set
            {
                if (lozinka != value)
                {
                    lozinka = value;
                    OnPropertyChanged("Lozinka");
                }
            }
        }

        public string Lozinka2
        {
            get { return lozinka2; }
            set
            {
                if (lozinka2 != value)
                {
                    lozinka2 = value;
                    OnPropertyChanged("Lozinka2");
                }
            }
        }
        public string Ime
        {
            get { return ime; }
            set
            {
                if (ime != value)
                {
                    ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        public string Prezime
        {
            get { return prezime; }
            set
            {
                if (prezime != value)
                {
                    prezime = value;
                    OnPropertyChanged("Prezime");
                }
            }
        }


        public string DatumRodjenja
        {
            get { return datumRodjenja; }
            set
            {
                if (datumRodjenja != value)
                {
                    datumRodjenja = value;
                    OnPropertyChanged("DatumRodjenja");
                }
            }
        }
        public string Adresa
        {
            get { return adresa; }
            set
            {
                if (adresa != value)
                {
                    adresa = value;
                    OnPropertyChanged("Adresa");
                }
            }
        }
        public string BrTelefona
        {
            get { return brojTelefona; }
            set
            {
                if (brojTelefona != value)
                {
                    brojTelefona = value;
                    OnPropertyChanged("BrojTelefona");
                }
            }
        }
        public string Jmbg
        {
            get { return jmbg; }
            set
            {
                if (jmbg != value)
                {
                    jmbg = value;
                    OnPropertyChanged("Jmbg");
                }
            }
        }
        public int Pol
        {
            get { return pol; }
            set
            {
                if (pol != value)
                {
                    pol = value;
                    OnPropertyChanged("Pol");
                }
            }
        }
        public string BrKnjizice
        {
            get { return brojZdrKnjizice; }
            set
            {
                if (brojZdrKnjizice != value)
                {
                    brojZdrKnjizice = value;
                    OnPropertyChanged("BrKnjizice");
                }
            }
        }
    
        public IzmenaPodatakaPacijent()
        {
            InitializeComponent();
            this.DataContext = this;

            PatientController guestContr = new PatientController();
            List<PatientUser> pacijenti = guestContr.GetAll();






            ListaPacijenata.SelectedIndex = 0;
            foreach (PatientUser regP in pacijenti)
            {
                if (regP.isRegisteredBySecretary==true)
                {
                    ListaPacijenata.Items.Add(regP.firstName + " " + regP.secondName + " " + regP.id.ToString());
                }


            }
           
            pacijent = new PatientUser();

          
            foreach (PatientUser s in pacijenti)
            {
                
                    if (s.id.ToString().Equals(idPacijenta.Text))
                    {
                        pacijent = s;
                        ImeBox.Text = s.firstName.ToString();
                        Prezime = s.secondName.ToString();
                        DatumRodjenja = s.dateOfBirth.ToString();
                        Jmbg = s.uniqueCitizensidentityNumber.ToString();
                        BrKnjizice = s.medicalIdNumber.ToString();
                        Email = s.email.ToString();
                        Lozinka = s.password.ToString();
                        Lozinka2 = s.password.ToString();
                        AdresaBox.Text = s.city.ToString();
                        brojTelefona = s.phoneNumber.ToString();


                    }
               
            }

            
          
        }
        public void Potvrda_Click(object sender, RoutedEventArgs e)
        {
            List<Question> pitanja = new List<Question>();
            String alergije = "";
           
            Boolean guest = false;
            Boolean sekr = false;
            List<ModelNotification> notifications = new List<ModelNotification>();
            if ((LozinkaBox.Text.Equals(PotvLozinkaBox.Text)))
            {
                PatientController secContr = new PatientController();
                List<PatientUser> lista = secContr.GetAll();
                int id = 0;
                foreach (PatientUser sec in lista)
                {
                    if (sec.id.ToString().Equals(idPacijenta.Text))
                    {
                        id = sec.id;
                        
                        alergije = sec.allergie;
                      
                        guest = sec.guest;
                     
                        sekr = sec.isRegisteredBySecretary;
                        notifications = sec.notifications;
                    }
                }

                PatientController rpcontroller = new PatientController();
                if(notifications == null)
                {
                    notifications = new List<ModelNotification>();
                }

                PatientUser rp = new PatientUser(id, ImeBox.Text, PrezimeBox.Text, JMBGBox.Text, DatumRodjBox.Text,
                BrojTelefonaBox.Text,KnjizicaBox.Text,alergije,AdresaBox.Text,false,EmailBox.Text,LozinkaBox.Text,sekr,notifications);

                MessageBox.Show("Uspijesno izmenjeni podaci/registrovan guest pacijent!", "OK", MessageBoxButton.OK);


               Boolean isPatientUpdateOk = secContr.Update(rp);
                if(isPatientUpdateOk==false)
                {

                    MessageBox.Show("Fields must be unique.\nCity must be in format : City, Street number, postal code, Country.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Lozinke se moraju poklapati!", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
           


            Panel.Children.Clear();
            UserControl usc = new RegistrovaniPacijenti();
            Panel.Children.Add(usc);

        }
        public void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new RegistrovaniPacijenti();
            Panel.Children.Add(usc);
        }
        private void ListaPacijenata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selektovano = ListaPacijenata.SelectedItem.ToString();
                string[] tokens = selektovano.Split(' ');
                string id = tokens[2];
                PatientController guestContr = new PatientController();
                List<PatientUser> pacijenti = guestContr.GetAll();
                //MessageBox.Show(id, "kakaka", MessageBoxButton.OK);

                idPacijenta.Text = id.ToString();
                foreach (PatientUser s in pacijenti)
                {

                    if (s.id.ToString().Equals(idPacijenta.Text))
                    {
                        pacijent = s;
                        Ime = s.firstName.ToString();
                        Prezime = s.secondName.ToString();
                        DatumRodjenja = s.dateOfBirth.ToString();
                        Jmbg = s.uniqueCitizensidentityNumber.ToString();
                        BrKnjizice = s.medicalIdNumber.ToString();
                        Email = s.email.ToString();
                        Lozinka = s.password.ToString();
                        Lozinka2 = s.password.ToString();
                        adresa = s.city.ToString();
                        brojTelefona = s.phoneNumber.ToString();


                    }

                }

            }
            catch (Exception ex)
            {
                idPacijenta.Text = "";

               

            }
        }

        public void Pomoc_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ukoliko zelite da izmenite odredjene podatke, kliknite na zeljeno polje i unesite novu vrednost.\n" +
                "Mozete menjati sve podatke osim JMBG-a i datuma rodjenja.\n Nakon obavljenih izemena, kliknite na dugme 'IZMENI' da biste sacuvali izmenjene podatke.");
        }
    }
}
