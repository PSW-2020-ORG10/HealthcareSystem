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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Class_diagram.Contoller;
using Class_diagram.Model.Secretary;
using HCI_wireframe;
using HCI_wireframe.Model.Doctor;

namespace ProjekatHCI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Login : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public Login()
        {
            InitializeComponent();


            this.DataContext = this;
        }


        private string email;
        private string lozinka;

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




        //public static MainWindowSekretar main = new MainWindowSekretar();
        public ObservableCollection<SecretaryUser> ListaSekretari
        {
            get;
            set;
        }
        public SecretaryUser prijavljen = new SecretaryUser();
        private void Prijava_Click(object sender, RoutedEventArgs e)
        {
            SecretaryController secrContr = new SecretaryController();
            List<SecretaryUser> lista = new List<SecretaryUser>();
            lista = secrContr.GetAll();
            List<SecretaryUser> sekretari = new List<SecretaryUser>();
           // dataGridEquipment.DataContext = lista;
            SecretaryUser prijavljen = new SecretaryUser();

             foreach (SecretaryUser ee in lista)
            {

             if (ee.email.Equals(EmailBox.Text))
            {
                       if (PasswordBox.Password.Equals(ee.password))
                        {
                                    prijavljen = ee;
                                     App.Current.Properties["SecretaryEmail"] = ee.email;
                                    this.Close();
                                    MainWindowSekretar main = new MainWindowSekretar();
                                    main.Show();
                                    }
                      else
                                 {
                                         PasswordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                                         PassBoxError.Visibility = Visibility.Visible;


                                  }

             }
             else
             {

                 EmailBox.BorderBrush = new SolidColorBrush(Colors.Red);
                 EmailBoxError.Visibility = Visibility.Visible;
             }



         }


         //List<> sviKorisnici = Register.ListUsers();
         //User user = Register.HasUser(sviKorisnici, UsernameBox.Text);
         /* List<String> usernames = new List<string>();
          usernames.Add("mladenka@gmail.com");
          List<String> passwords = new List<String>();
          passwords.Add("maja");
          String user;
          foreach(String us in usernames)
          {
              if (us.Contains(EmailBox.Text))
              {

                  user = EmailBox.Text;
              }
              else
              {
                  user = null;
              }

          }*/
               /* if (EmailBox.Text.Equals("maja@gmail.com"))
                {
                    if (PasswordBox.Password.Equals("maja123"))
                    {

                        this.Close();
                        main.Show();
                    }
                    else
                    {
                        PasswordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                        PassBoxError.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    EmailBox.BorderBrush = new SolidColorBrush(Colors.Red);
                    EmailBoxError.Visibility = Visibility.Visible;
                }*/


            }

        
        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            PasswordBox.Password = "";

            EmailBoxError.Visibility = Visibility.Hidden;
            EmailBox.Text = "";
            PassBoxError.Visibility = Visibility.Hidden;


        }
       
            
      
        private void EmailBox_OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            EmailBox.ClearValue(BorderBrushProperty);
            EmailBoxError.Visibility = Visibility.Hidden;
        }
        private void PasswordBox_OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            PasswordBox.ClearValue(BorderBrushProperty);
            PassBoxError.Visibility = Visibility.Hidden;



        }
        private void Accept_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Register_OnClick(object sender, RoutedEventArgs e)
        {
           
        }
        public void Pomoc_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dobro dosli u aplikaciju nase klinike!" +
                "\n\n Da biste se prijavili na Vas nalog, unesite Vasu e-mail adresu i lozniku i kliknite na dugme 'PRIJAVI SE'." +
                "\nZa odustanak, kliknite dugme 'ODUSTANAK'.");
        }

        private void EmailBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EmailBoxError.Visibility = Visibility.Hidden;
        }
    }

}


