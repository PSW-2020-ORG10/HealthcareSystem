using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Class_diagram.Model.Patient;
using HCI_wireframe.Contoller;
using HCI_wireframe.Model.Patient;
using ProjekatHCI;

namespace HCI_wireframe.View.Sekretar
{
    /// <summary>
    /// Interaction logic for DodavanjeGuestPacijenta.xaml
    /// </summary>
    public partial class DodavanjeGuestPacijenta : UserControl, INotifyPropertyChanged
    {
        public DodavanjeGuestPacijenta()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string ime;
        private string prezime;
        private string datumRodjenja;
        private string jmbg;
      
        private string brojTelefona;
        private string adresa;
        private string brojZdrKnjizice;
        private int pol;



        public virtual void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
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
      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ImeBox.Focus();
            ImeBox.SelectAll();
        }


        private void dodaj_Click(object sender, RoutedEventArgs e)
        {

            
           

            int broj = getNextid();
            String emaail = broj.ToString() + "UNKNOWN";
            List<ModelNotification> notif = new List<ModelNotification>();
            notif.Add(new ModelNotification(""));
            PatientUser rp = new PatientUser(0, ImeBox.Text, PrezimeBox.Text, JMBGBox.Text, DatumRodjBox.Text,
                     BrojTelefonaBox.Text, KnjizicaBox.Text,"",AdresaBox.Text,true,emaail,"nopassword",true,notif);

            PatientController rpcontroller = new PatientController();
           
          
           Boolean isPatientOk = rpcontroller.New(rp);
            if(isPatientOk==false)
            {
                 MessageBox.Show("Fields must be unique.\nCity must be in format : City, Street number, postal code, Country.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                 return;
                
            }

            Panel.Children.Clear();
            UserControl usc = new GuestPacijenti();
            Panel.Children.Add(usc);

        }
        private int getNextid()
        {
            PatientController rp = new PatientController();
            List<PatientUser> lista = rp.GetAll();

            int number = 0;

            foreach (PatientUser r in lista)
            {
                if (r.id > number)
                {
                    number = r.id;
                }
            }

            number += 1;
            return number;

        }
        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new PocetnaStranica();
            Panel.Children.Add(usc);
        }
        private void Pomoc_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Otvorii ste formu za dodavanje guest pacijenata\n" +
                "Ukoliko zelite da dodate novog guest pacijenta u sistem bolnice, unesite sve potrebne podatke(u pravilnom formatu) i kliknite na dume 'DODAJ." +
                "Za odustanak, kliknite na dugme 'ODUSTANI'.");
        }

        private void ImeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void PrezimeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void JMBGBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void KnjizicaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void BrojTelefonaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void DatumRodjBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void AdresaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }
        private void setButtonVisibility()
        {
            if (ImeBox.Text != String.Empty && PrezimeBox.Text != String.Empty && KnjizicaBox.Text != String.Empty && JMBGBox.Text != String.Empty 
                 && Regex.Match(ImeBox.Text, @"^[šŠđĐčČćĆžŽa-zA-Z_' ']+$").Success && Regex.Match(PrezimeBox.Text, @"^[šŠđĐčČćĆžŽa-zA-Z_' ']+$").Success
                 && Regex.Match(DatumRodjBox.Text, @"^\d{2}/\d{2}/\d{4}$").Success && Regex.Match(JMBGBox.Text, @"^([0-9]+)$").Success
                 && Regex.Match(KnjizicaBox.Text, @"^([0-9]+)$").Success 
                 && Regex.Match(BrojTelefonaBox.Text, @"^([0-9]+)$").Success )
               
            {

                dodaj.IsEnabled = true;


            }



            else
            {

                dodaj.IsEnabled = false;



            }

        }


    }
}
