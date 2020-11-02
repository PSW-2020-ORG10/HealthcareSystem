using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using Class_diagram.Contoller;
using HCI_wireframe;
using HCI_wireframe.Model.Doctor;

namespace Klinika
{

    /// Interaction logic for GlavnidoktorProzor.xaml

    public partial class GlavnidoktorProzor : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public GlavnidoktorProzor()
        {
            InitializeComponent();

            this.DataContext = this;





        }

        private string email;
        private string lozinka;
        public static Nalog nalog = new Nalog();

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
            private get { return lozinka; }
            set
            {
                if (lozinka != value)
                {
                    lozinka = value;
                    OnPropertyChanged("Lozinka");
                }
            }
        }



        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.H)
            {
                MessageBox.Show(
                    "-Use LEFT CTRL to move on the next field.\n" +
                    "-Use RIGHT CTRL to return to the previous field"

                    );
            }

        }

        public ObservableCollection<DoctorUser> ListaLekari
        {
            get;
            set;
        }
        public DoctorUser prijavljen = new DoctorUser();
        private void prijava_Click_1(object sender, RoutedEventArgs e)
        {
            DoctorController dCont = new DoctorController();
            List<DoctorUser> lista = new List<DoctorUser>();
            lista = dCont.GetAll();
            List<DoctorUser> lekari = new List<DoctorUser>();
            //dataGridEquipment.DataContext = lista;
            // SecretaryUser prijavljen = new SecretaryUser();

            foreach (DoctorUser ee in lista)
            {
                
                  if (ee.email.Equals(EmailBox.Text))
                  {
                      if (PasswordBox.Password.Equals(ee.password))
                      {
                          prijavljen = ee;
                          App.Current.Properties["DoctorEmail"] = ee.email;
                          this.Close();
                          Nalog main = new Nalog();
                          main.Show();
                      }
                      else
                      {
                          PasswordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                        //  PassBoxError.Visibility = Visibility.Visible;


                      }

                  }
                  else
                  {

                      EmailBox.BorderBrush = new SolidColorBrush(Colors.Red);
                     // EmailBoxError.Visibility = Visibility.Visible;
                  }



              }
        
    
                
            }
        }
    }
    

    
