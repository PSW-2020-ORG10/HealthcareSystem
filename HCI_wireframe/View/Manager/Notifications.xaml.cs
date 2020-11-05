using Class_diagram.Contoller;
using Class_diagram.Model.Manager;
using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using HCI_wireframe.Model.Manager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Notifications.xaml
    /// </summary>
    public partial class Notifications : UserControl
    {
        public class Lista
        {

            public string Name { get; set; }

            public string Last { get; set; }



            public Lista()
            {

            }

        }

        List<Lista> li = new List<Lista>();
        ManagerController SchDontr = new ManagerController();
        List<ManagerUser> lista = new List<ManagerUser>();

        public Notifications()
        {
            InitializeComponent();
            lista = SchDontr.GetAll();
            List<ManagerUser> oprema = new List<ManagerUser>();


            foreach (ManagerUser ee in lista)
            {
                if (ee.specialNotifications == null)
                {
                    ee.specialNotifications = new List<ManagerNotification>();
                }
                else
                {
                    foreach (ManagerNotification s in ee.specialNotifications)
                        li.Add(new Lista { Name = s.ToString() });
                }
            }

            dataGridStudenti.ItemsSource = li;
        }


    }
}
