using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using Class_diagram.Repository;
using HCI_wireframe;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.Model.Employee;
using HCI_wireframe.Model.Manager;
using HCI_wireframe.Repository;
using Path = System.IO.Path;


namespace Klinika
{
    /// <summary>
    /// Interaction logic for Feedback.xaml
    /// </summary>
    public partial class Feedback : UserControl
    {
        bool odlicno = false;
        bool vrlodobro = false;
        bool dobro = false;
        bool zadovoljavajuce = false;
        bool nezad = false;
        int ocena { get; set; }
        string svojstvo = App.Current.Properties["DoctorEmail"].ToString();
        public DoctorUser lekar { get; set; }
        public ManagerController cont;
        public List<ManagerUser> menadzeri { get; set; }
        public Feedback()
        {
            InitializeComponent();
            this.DataContext = this;
            lekar = new DoctorUser();
            DoctorController scon = new DoctorController();
            List<DoctorUser> lista = scon.GetAll();
            cont = new ManagerController();
            menadzeri = cont.GetAll();

            foreach (DoctorUser s in lista)
            {
                if (s.email.Equals(svojstvo))
                {
                    lekar = s;
                }
            }
        }




        public void potvrdi_Click(object sender, RoutedEventArgs e)
        {
            
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
            }
            else if (zadovoljavajuce == true)
            {
                ocena = 2;
            }
            else
            {
                ocena = 1;
            }

            
            foreach(ManagerUser user in menadzeri)
            {
                if (user.specialNotifications == null)
                {
                    user.specialNotifications = new List<ManagerNotification>();
                }
                List<ManagerNotification> obavestenja = user.specialNotifications;

                obavestenja.Add(new ManagerNotification("Ocena sistema od strane doktora  \n" + lekar.firstName + " " + lekar.secondName + "  - answer  -" + ocena));
                user.specialNotifications = obavestenja;
                Boolean isOK = cont.Update(user);
                if(isOK==false)
                {
                    
                }
                else
                {
                    MessageBox.Show("Uspesno ste ocenili rad softvera", "Vas Utisak", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
           
           


        }

       

        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            odlicno = sender == odlBtn;
            vrlodobro = sender == vDbrBtn;
            dobro = sender == dbrBtn;
            zadovoljavajuce = sender == dovBtn;
            nezad = sender == nedBtn;
        }
    }
   


}
