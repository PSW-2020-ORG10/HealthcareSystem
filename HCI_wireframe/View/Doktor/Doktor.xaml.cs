using System;
using System.Collections.Generic;
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
using HCI_wireframe;
using HCI_wireframe.Model.Doctor;

namespace Klinika
{
    /// <summary>
    /// Interaction logic for Doktor.xaml
    /// </summary>
    public partial class Doktor : UserControl
    {
        string myProperty = App.Current.Properties["DoctorEmail"].ToString();
        public DoctorUser lekar { get; set; }

        public Doktor()
        {
            InitializeComponent();
            this.DataContext = this;
            lekar = new DoctorUser();
            DoctorController doc = new DoctorController();
            List<DoctorUser> lista = doc.GetAll();

            foreach (DoctorUser s in lista)
            {
                if (s.Email.Equals(myProperty))
                {
                    lekar = s;
                    Ime.Text = lekar.FirstName.ToString();
                    Prezime.Text = lekar.SecondName.ToString();
                    Datum.Text = lekar.DateOfBirth.ToString();
                    Specijalnost.Text = "Hirurg";
                    JMBG.Text = lekar.UniqueCitizensIdentityNumber.ToString();

                    email.Text = lekar.Email.ToString();
                }



            }
        }


        private void Izmena_click(object sender, RoutedEventArgs e)
                {

                    Panel.Children.Clear();
                    UserControl usc = new IzmenaPodataka();
                    Panel.Children.Add(usc);

                }
            }
        }
