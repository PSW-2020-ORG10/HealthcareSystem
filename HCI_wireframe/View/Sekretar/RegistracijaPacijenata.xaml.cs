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

namespace ProjekatHCI
{
    /// <summary>
    /// Interaction logic for RegistracijaPacijenata.xaml
    /// </summary>
    /// 

    public partial class RegistracijaPacijenata : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
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
        public RegistracijaPacijenata()
        {
            InitializeComponent();
            this.DataContext = this;
            ImeBox.Focus();
            //ImeBox.SelectAll();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           ImeBox.Focus();
            ImeBox.SelectAll();
        }



        private void Registruj_Click(object sender, RoutedEventArgs e)
        {




            if ((LozinkaBox.Password.Equals(PotvLozinkaBox.Password)))
            {
                



                
                int broj = getNextid();
                List<ModelNotification> notif = new List<ModelNotification>();
                notif.Add(new ModelNotification(""));
                PatientUser rp =  new PatientUser(0, ImeBox.Text, PrezimeBox.Text, JMBGBox.Text, DatumRodjBox.Text,
                        BrojTelefonaBox.Text, KnjizicaBox.Text,"" ,AdresaBox.Text,false, EmailBox.Text, LozinkaBox.Password, true,notif);

                PatientController rpcontroller = new PatientController();
               

              Boolean isPatientOk =  rpcontroller.New(rp);
                if (isPatientOk == false)
                {
                    MessageBox.Show("Fields must be unique.\nCity must be in format : City, Street number, postal code, Country.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }

                Panel.Children.Clear();
                UserControl usc = new RegistrovaniPacijenti();
                Panel.Children.Add(usc);
            }
            else
            {
                PassBoxError.Visibility = Visibility.Visible;
            }


        }
        private void Odustani_Click(object sender, RoutedEventArgs e)
        {

            Panel.Children.Clear();
            UserControl usc = new PocetnaStranica();
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

        private void AdresaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
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
        private void BrTelBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void KjizicaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void LozinkaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void PotvLozinkaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
            PassBoxError.Visibility = Visibility.Hidden;
        }

        private void EmailBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void DatumRodjBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }
        public void Pomoc_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Otvorii ste formu za registraciju pacijenata\n" +
                "Ukoliko zelite da registrujete novog pacijenta u sistem bolnice, unesite sve potrebne podatke(u pravilnom formatu) i kliknite na dume 'REGISTRUJ." +
                "Za odustanak, kliknite na dugme 'ODUSTANI'.");
        }

        private void LozinkaBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            setButtonVisibility();
        }

        private void PotvLozinkaBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            setButtonVisibility();
        }
        private void setButtonVisibility()
        {
            if (ImeBox.Text != String.Empty && PrezimeBox.Text != String.Empty && KnjizicaBox.Text != String.Empty && JMBGBox.Text != String.Empty && LozinkaBox.Password != String.Empty && PotvLozinkaBox.Password != String.Empty
                 && Regex.Match(ImeBox.Text, @"^[šŠđĐčČćĆžŽa-zA-Z_' ']+$").Success && Regex.Match(PrezimeBox.Text, @"^[šŠđĐčČćĆžŽa-zA-Z_' ']+$").Success
                 && Regex.Match(DatumRodjBox.Text, @"^\d{2}/\d{2}/\d{4}$").Success && Regex.Match(JMBGBox.Text, @"^([0-9]+)$").Success
                 && Regex.Match(KnjizicaBox.Text, @"^([0-9]+)$").Success 
                 && Regex.Match(BrojTelefonaBox.Text, @"^([0-9]+)$").Success && Regex.Match(EmailBox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$").Success
                 && Regex.Match(LozinkaBox.Password, @"^.*(?=.{6,20})(?=.+\d)(?=.*[a-zA-Z]).*$").Success && Regex.Match(PotvLozinkaBox.Password, @"^.*(?=.{6,20})(?=.+\d)(?=.*[a-zA-Z]).*$").Success )
             {

                 registruj.IsEnabled = true;


             }



             else
             {
                 registruj.IsEnabled = false;



             }
           
        }
  

    }
}
