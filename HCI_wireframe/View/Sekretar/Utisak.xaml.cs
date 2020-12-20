using System;
using System.Collections.Generic;
using System.IO;
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
using Class_diagram.Model.Employee;
using Class_diagram.Model.Manager;
using Class_diagram.Model.Secretary;
using Class_diagram.Repository;
using HCI_wireframe;
using HCI_wireframe.Model.Manager;
using Path = System.IO.Path;

namespace ProjekatHCI
{
    /// <summary>
    /// Interaction logic for Utisak.xaml
    /// </summary>
    public partial class Utisak : UserControl
    {
        string svojstvo = App.Current.Properties["SecretaryEmail"].ToString();
        public SecretaryUser sekretar { get; set; }
        bool odlicno = false;
        bool vrlodobro = false;
        bool dobro = false;
        bool zadovoljavajuce = false;
        bool nezad = false;
        int ocena { get; set; }
        public ManagerController cont;
        public List<ManagerUser> menadzeri { get; set; }
        public Utisak()
        {
            InitializeComponent();
            this.DataContext = this;
            cont = new ManagerController();
            menadzeri = cont.GetAll();
            this.DataContext = this;
            sekretar = new SecretaryUser();
            SecretaryController scon = new SecretaryController();
            List<SecretaryUser> lista = scon.GetAll();
            foreach (SecretaryUser s in lista)
            {
                if (s.email.Equals(svojstvo))
                {
                    sekretar = s;
                }
            }
        }
        public void Potvrdi_click(object sender, RoutedEventArgs e)
        {
            String f = bingPathToAppDir(@"JsonFiles\feedback.json");
            if (odlicno == true)
            {
                ocena = 5;
            }
            else if (vrlodobro == true)
            {
                ocena = 4;
            }
            else if (dobro == true)
            {
                ocena = 3;
            }else if(zadovoljavajuce == true)
            {
                ocena = 2;
            }
            else
            {
                ocena = 1;
            }
            foreach (ManagerUser user in menadzeri)
            {
                if (user.specialNotifications == null)
                {
                    user.specialNotifications = new List<ManagerNotification> ();
                }
                List<ManagerNotification> obavestenja = user.specialNotifications;

                obavestenja.Add(new ManagerNotification("Ocena sistema od strane sekretara  \n" + sekretar.firstName + " " + sekretar.secondName + "  - answer  -" + ocena));
                user.specialNotifications = obavestenja;
                cont.Update(user);

            }

            MessageBox.Show("Uspesno ste ocenili rad softvera", "Vas Utisak", MessageBoxButton.OK, MessageBoxImage.Information);
            Panel.Children.Clear();
            UserControl usc = new PocetnaStranica();
            Panel.Children.Add(usc);


        }
        public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }

        public void Odustani_click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new PocetnaStranica();
            Panel.Children.Add(usc);

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            odlicno = sender == odlBtn;
            vrlodobro = sender == vDbrBtn;
            dobro = sender == dbrbtn;
            zadovoljavajuce = sender == dovbtn;
            nezad = sender == nedbtn;

        }
       


    }
}