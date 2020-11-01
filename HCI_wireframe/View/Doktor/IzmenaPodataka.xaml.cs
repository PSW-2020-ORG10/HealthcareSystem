using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Class_diagram.Repository;
using HCI_wireframe;
using HCI_wireframe.Model.Doctor;
using Path = System.IO.Path;


namespace Klinika
{
    /// <summary>
    /// Interaction logic for IzmenaPodataka.xaml
    /// </summary>
    public partial class IzmenaPodataka : UserControl, INotifyPropertyChanged
    {
        string svojstvo = App.Current.Properties["DoctorEmail"].ToString();
        public DoctorUser lekar { get; set; }
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
        private String Hirurg;

        public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }


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
                    OnPropertyChanged("BrTelefona");
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


        public IzmenaPodataka()
        {
            InitializeComponent();

            this.DataContext = this;
            lekar = new DoctorUser();
            DoctorController scon = new DoctorController();
            List<DoctorUser> lista = scon.GetAll();

            foreach (DoctorUser s in lista)
            {
                if (s.email.Equals(svojstvo))
                {
                    lekar = s;
                    Ime = lekar.firstName.ToString();
                    Prezime = lekar.secondName.ToString();
                    DatumRodjenja = lekar.dateOfBirth.ToString();
                    Jmbg = lekar.uniqueCitizensidentityNumber.ToString();

                    BrTelefona = lekar.phoneNumber.ToString();
                    Email = lekar.email.ToString();
                    LozinkaBox.Text = lekar.password;
                    PotvLozinkaBox.Text = lekar.password;
                    AdresaBox.Text = lekar.city;
                    LozinkaBox.Text = lekar.password;
                    PotvLozinkaBox.Text = lekar.password;

                }
            }

        }


        private void setButtonVisibility()
        {
            if (ImeBox.Text != String.Empty && PrezimeBox.Text != String.Empty && JMBGBox.Text != String.Empty && LozinkaBox.Text != String.Empty && PotvLozinkaBox.Text != String.Empty
                && Regex.Match(ImeBox.Text, @"^[šŠđĐčČćĆžŽa-zA-Z_' ']+$").Success && Regex.Match(PrezimeBox.Text, @"^[šŠđĐčČćĆžŽa-zA-Z_' ']+$").Success
                && Regex.Match(DatumRodjBox.Text, @"^\d{2}/\d{2}/\d{4}$").Success && Regex.Match(JMBGBox.Text, @"^\d{13}$").Success
                
                && Regex.Match(BrTelBox.Text, @"^\d{13}$").Success && Regex.Match(EmailBox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$").Success
                && Regex.Match(LozinkaBox.Text, @"^.*(?=.{6,20})(?=.+\d)(?=.*[a-zA-Z]).*$").Success && Regex.Match(PotvLozinkaBox.Text, @"^.*(?=.{6,20})(?=.+\d)(?=.*[a-zA-Z]).*$").Success)
            {

                izmeni.IsEnabled = true;


            }



            else
            {
                izmeni.IsEnabled = false;
            }
        }

        private void izmeni_Click(object sender, RoutedEventArgs e)
        {
            if(LozinkaBox.Text.Equals("") || PotvLozinkaBox.Text.Equals(""))
            {
                MessageBox.Show("Polja moraju bitit popunjena.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            else if((!LozinkaBox.Text.Equals(PotvLozinkaBox.Text)))
            {
                MessageBox.Show("Sifre moraju da budu iste.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            else { 
            
                DoctorController Contr = new DoctorController();
                List<DoctorUser> lista = Contr.GetAll();
                int id = 0;
                DoctorUser ovajDoktor = new DoctorUser();
                foreach (DoctorUser sec in lista)
                {
                    if (sec.email.Equals(EmailBox.Text))
                    {
                        id = sec.id;
                        ovajDoktor = sec;
                    }
                }
               
                DoctorUser rp = new DoctorUser(id, ImeBox.Text, PrezimeBox.Text, JMBGBox.Text, DatumRodjBox.Text,
                BrTelBox.Text, EmailBox.Text, LozinkaBox.Text, AdresaBox.Text, ovajDoktor.salary, ovajDoktor.isSpecialist,ovajDoktor.speciality, ovajDoktor.specialNotifications, ovajDoktor.ordination);

                

               

                DoctorController eq = new DoctorController();

               Boolean isOk = eq.Update(rp);
                if(isOk==false)
                {
                    MessageBox.Show("Fields must be unique.\nCity must be in format : City, Street number, postal code, Country.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBox.Show("Uspijesno izmenjeni podaci!", "OK", MessageBoxButton.OK);


                



                Panel.Children.Clear();
                UserControl usc = new IzmenaPodataka();
                Panel.Children.Add(usc);
            }
           


        }


    }
}
   

