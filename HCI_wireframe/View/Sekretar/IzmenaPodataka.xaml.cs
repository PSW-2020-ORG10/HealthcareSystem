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
using Class_diagram.Model.Secretary;
using HCI_wireframe;

namespace ProjekatHCI
{
    /// <summary>
    /// Interaction logic for IzmenaPodataka.xaml
    /// </summary>
    /// 
 
    public partial class IzmenaPodataka : UserControl, INotifyPropertyChanged
    {
        string svojstvo = App.Current.Properties["SecretaryEmail"].ToString();
        public SecretaryUser sekretar { get; set; }
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
        private string funkcija;
        private int pol;
        private string lozinka;
        private string lozinka2;
        private int plata;




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
        public string BrojTelefona
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
        public string Funkcija
        {
            get { return funkcija; }
            set
            {
                if (funkcija != value)
                {
                    funkcija = value;
                    OnPropertyChanged("Funkcija");
                }
            }
        }
        public IzmenaPodataka()
        {
            InitializeComponent();
            this.DataContext = this;
            sekretar = new SecretaryUser();
            SecretaryController scon = new SecretaryController();
            List<SecretaryUser> lista = scon.GetAll();

            foreach (SecretaryUser s in lista)
            {                {
                    sekretar = s;
                    Ime = sekretar.firstName.ToString();
                    Prezime = sekretar.secondName.ToString();
                    DatumRodjenja = sekretar.dateOfBirth.ToString();
                    JMBGBox.Text = sekretar.uniqueCitizensidentityNumber.ToString();
                    AdresaBox.Text = sekretar.city.ToString();
                    BrojTelefona = sekretar.phoneNumber.ToString();
                    EmailBox.Text = sekretar.email.ToString();
                    LozinkaBox.Password = sekretar.password;
                    PotvLozinkaBox.Password = sekretar.password;
                    
                    if (sekretar.salary != null)
                    {
                        PlataBox.Text = sekretar.salary.ToString();
                    }
                    else
                    {
                        PlataBox.Text = "1500e";
                    }
                }
            }

            string loznika = LozinkaBox.Password.ToString();
            }
            private void Izmeni_Click(object sender, RoutedEventArgs e)
        {

           
            
                if ((LozinkaBox.Password.Equals(PotvLozinkaBox.Password)))
                {
                SecretaryController secContr = new SecretaryController();
                List<SecretaryUser> lista = secContr.GetAll();
                int id = 0;
                foreach(SecretaryUser sec in lista)
                {
                    if(sec.email.Equals(EmailBox.Text))
                    {
                        id = sec.id;
                    }
                }
                int plata = int.Parse(PlataBox.Text);
                SecretaryUser rp = new SecretaryUser(id, ImeBox.Text, PrezimeBox.Text, JMBGBox.Text, DatumRodjBox.Text,
                BrTelBox.Text, EmailBox.Text,LozinkaBox.Password,AdresaBox.Text,plata,"6");

              
              

                Boolean isOk = secContr.Update(rp);
                if(isOk==false)
                {
                    MessageBox.Show("Fields must be unique.\nCity must be in format : City, Street number, postal code, Country.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBox.Show("Uspijesno izmenjeni podaci!", "OK", MessageBoxButton.OK);
                Panel.Children.Clear();
                    UserControl usc = new MojiPodaci();
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
        public void Pomoc_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ukoliko zelite da izmenite odredjene podatke, kliknite na zeljeno polje i unesite novu vrednost.\n" +
                "Mozete menjati sve podatke osim JMBG-a i datuma rodjenja.\n Nakon obavljenih izemena, kliknite na dugme 'IZMENI' da biste sacuvali izmenjene podatke.");
        }
        private void setButtonVisibility()
        {
            if (ImeBox.Text != String.Empty && PrezimeBox.Text != String.Empty && JMBGBox.Text != String.Empty && LozinkaBox.Password != String.Empty && PotvLozinkaBox.Password != String.Empty
                && Regex.Match(ImeBox.Text, @"^[šŠđĐčČćĆžŽa-zA-Z_' ']+$").Success && Regex.Match(PrezimeBox.Text, @"^[šŠđĐčČćĆžŽa-zA-Z_' ']+$").Success
                && Regex.Match(DatumRodjBox.Text, @"^\d{2}/\d{2}/\d{4}$").Success && Regex.Match(JMBGBox.Text, @"^([0-9]+)$").Success
                && Regex.Match(BrTelBox.Text, @"^([0-9]+)$").Success && Regex.Match(EmailBox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$").Success
                && Regex.Match(LozinkaBox.Password, @"^.*(?=.{6,20})(?=.+\d)(?=.*[a-zA-Z]).*$").Success && Regex.Match(PotvLozinkaBox.Password, @"^.*(?=.{6,20})(?=.+\d)(?=.*[a-zA-Z]).*$").Success)
            {

                izmeni.IsEnabled = true;


            }



            else
            {
                izmeni.IsEnabled = false;
            }
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

        private void DatumRodjBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void AdresaBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void BrTelBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void EmailBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }

        private void LozinkaBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            setButtonVisibility();
        }

        private void PotvLozinkaBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            setButtonVisibility();
        }
    }
}
