using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using HCI_wireframe.View.Sekretar;

namespace ProjekatHCI
{
    /// <summary>
    /// Interaction logic for GuestPacijenti.xaml
    /// </summary>
    public partial class GuestPacijenti : UserControl
    {
        public ObservableCollection<PatientUser> guestPacijeti
        {
            get;
            set;
        }
        List<PatientUser> guests = new List<PatientUser>();
        public GuestPacijenti()
        {

            InitializeComponent();
            this.DataContext = this;

            PatientController guestContr = new PatientController();
            List<PatientUser> lista = new List<PatientUser>();
            lista = guestContr.GetAll();
           
            //dataGridEquipment.DataContext = lista;

            foreach (PatientUser ee in lista)
            {
                if (ee.guest == true)
                {
                    guests.Add(new PatientUser { ID = ee.ID, FirstName = ee.FirstName, SecondName = ee.SecondName, UniqueCitizensIdentityNumber = ee.UniqueCitizensIdentityNumber, DateOfBirth = ee.DateOfBirth, PhoneNumber = ee.PhoneNumber, MedicalIDnumber = ee.MedicalIDnumber });

                }

            }


            
            dataGridGuest.ItemsSource =guests;


        }
        public void Zakazivanje_Click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new ZakazivanjePregleda();
            Panel.Children.Add(usc);

        }
        public void Registracija_Click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new RegistracijaPacijenata();
            Panel.Children.Add(usc);
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new DodavanjeGuestPacijenta();
            Panel.Children.Add(usc);

        }
        List<PatientUser> filterModeLisst = new List<PatientUser>();

        private void Pretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            filterModeLisst.Clear();

            if (Pretraga.Text.Equals(""))
            {
                filterModeLisst.AddRange(guests);
            }
            else
            {
                foreach (PatientUser anim in guests)
                {

                    if (anim.FirstName.ToUpper().Contains(Pretraga.Text.ToUpper()) || anim.SecondName.ToUpper().Contains(Pretraga.Text.ToUpper()))
                    {
                        if (anim.guest == true)
                        {
                            filterModeLisst.Add(anim);
                        }
                    }
                }
            }

            dataGridGuest.ItemsSource = filterModeLisst.ToList();
        }
    }
}
