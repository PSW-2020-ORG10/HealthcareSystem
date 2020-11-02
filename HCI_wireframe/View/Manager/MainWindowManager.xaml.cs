using Class_diagram.Contoller;
using Class_diagram.Model.Manager;
using Class_diagram.Model.Secretary;
using HCI_wireframe.Model.Doctor;
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
using System.Windows.Shapes;
using WpfApp2;

namespace HCI_wireframe.View.Manager
{
    /// <summary>
    /// Interaction logic for MainWindowManager.xaml
    /// </summary>
    public partial class MainWindowManager : Window
    {

      
       
        ManagerController SecContr = new ManagerController();

        List<ManagerUser> lista = new List<ManagerUser>();
       
        public MainWindowManager()
        {
            InitializeComponent();
           

           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

             lista = SecContr.GetAll();

             foreach (ManagerUser ee in lista)
             {




                 if (ee.password.Equals(Password.Password) && ee.email.Equals(Username.Text))
                 {
                     var s = new Window4();
                     this.Close();
                     s.Show();
                     return;

                 }



             }



             MessageBox.Show("Please fill in all fields corectlly", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
             return;
           



        }

        private void Username_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
