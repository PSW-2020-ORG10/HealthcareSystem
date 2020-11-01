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
using HCI_wireframe.Contoller;

namespace ProjekatHCI
{
    /// <summary>
    /// Interaction logic for RegistrovaniPacijenti.xaml
    /// </summary>
    public partial class RegistrovaniPacijenti : UserControl
    {
        public ObservableCollection<PatientUser> registrovaniPacijenti
        {
            get;
            set;
        }
        List<PatientUser> pacijenti = new List<PatientUser>();
        public RegistrovaniPacijenti()
        {
            InitializeComponent();
            this.DataContext = this;
            PatientController patientController = new PatientController();
            List<PatientUser> lista = new List<PatientUser>();
            lista = patientController.GetAll();
           
            //dataGridEquipment.DataContext = lista;

            foreach (PatientUser ee in lista)
            {
                if (ee.guest != true)
                {
                    pacijenti.Add(new PatientUser { id = ee.id, firstName = ee.firstName, secondName = ee.secondName, uniqueCitizensidentityNumber = ee.uniqueCitizensidentityNumber, dateOfBirth = ee.dateOfBirth, phoneNumber = ee.phoneNumber, medicalIdNumber = ee.medicalIdNumber, isRegisteredBySecretary = ee.isRegisteredBySecretary });
                }


            }

           

            dataGridPacijenti.ItemsSource = pacijenti;

        }
       // ObservableCollection<String> pacijenti;
        
        
        public ObservableCollection<String> Pacijenti
        {
            get;
            set;
        }

        private void IzmenaPodataka_Click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new IzmenaPodatakaPacijent();
            Panel.Children.Add(usc);

        }
        private void Zakazivanje_Click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new ZakazivanjePregleda();
            Panel.Children.Add(usc);
        }
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new RegistracijaPacijenata();
            Panel.Children.Add(usc);
        }

        List<PatientUser> filterModeLisst = new List<PatientUser>();
        private void Pretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            

          
                filterModeLisst.Clear();

                if (Pretraga.Text.Equals(""))
                {
                    filterModeLisst.AddRange(pacijenti);
                }
                else
                {
                    foreach (PatientUser anim in pacijenti)
                    {

                    if (anim.firstName.ToUpper().Contains(Pretraga.Text.ToUpper()) || anim.secondName.ToUpper().Contains(Pretraga.Text.ToUpper()))
                    {
                        if (anim.guest == false)
                        {
                            filterModeLisst.Add(anim);
                        }
                    }
                    }
                }

                dataGridPacijenti.ItemsSource = filterModeLisst.ToList();
            }
        }
    }
