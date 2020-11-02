using Class_diagram.Contoller;
using Class_diagram.Model.Secretary;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.Model.Employee;
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
using WpfApp2.Employees;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for ListOfEmployees.xaml
    /// </summary>
    public partial class ListOfEmployees : UserControl
    {
        public class Lista
        {

            public string Name  { get; set; }
            
            public string Last { get; set; }

            

            public  Lista()
            {

            }

        }

        DoctorController DoctorContr = new DoctorController();
        SecretaryController SecretaryContr = new SecretaryController();
        List<DoctorUser> lista = new List<DoctorUser>();
        List<SecretaryUser> listaS = new List<SecretaryUser>();
        List<Lista> li = new List<Lista>();
        public ListOfEmployees()
        {
            InitializeComponent();

            

           

           
            lista = DoctorContr.GetAll();
            List<DoctorUser> doktori = new List<DoctorUser>();

            

            foreach (DoctorUser ee in lista)
            {
             
                StringBuilder l = new StringBuilder();
                l.Append(ee.id+" ");
                l.Append(ee.firstName+" ");
                l.Append(ee.secondName);
                li.Add(new Lista { Name = l.ToString() });
            }

           



          
   
            listaS = SecretaryContr.GetAll();
            List<SecretaryUser> sekretari = new List<SecretaryUser>();
          
            foreach (SecretaryUser ee in listaS)
            {

                // l.Add(new Lista { Name = ee.FirstName, Last = ee.SecondName });
                StringBuilder l = new StringBuilder();
                l.Append(ee.id + " ");
                l.Append(ee.firstName + " ");
                l.Append(ee.secondName);
                li.Add(new Lista { Name = l.ToString() });

            }



            // EmployeeList.ItemsSource = l;
            EmployeeList.ItemsSource = li;
        }

        private List<T> List<T>()
        {
            throw new NotImplementedException();
        }

        private void Add_new_employee(object sender, RoutedEventArgs e)
        {
            
            GridMain.Children.Clear();
            UserControl usc = new AddEmployee();
            GridMain.Children.Add(usc);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
           

        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string name1 = sender.ToString();
            string[] words = name1.Split(':');
           
            string[] words1 = name1.Split(' ');
            string id = words1[1];

            lista = DoctorContr.GetAll();
           
            listaS = SecretaryContr.GetAll();
           

          
            foreach (DoctorUser ee in lista)
            {
               
                if ((ee.id.ToString()).Equals(words1[1]) && (ee.firstName).Equals(words1[2]) && (ee.secondName).Equals(words1[3]))
                {
                   
                    GridMain.Children.Clear();
                    UserControl usc = new EmployeesAccount(ee);
                    GridMain.Children.Add(usc);

                }
            }

            foreach (SecretaryUser ee in listaS)
            {
                if ((ee.id.ToString()).Equals(words1[1]) && (ee.firstName).Equals(words1[2]) && (ee.secondName).Equals(words1[3]))
                {
                    GridMain.Children.Clear();
                    UserControl usc = new EmployeesAccount(ee);
                    GridMain.Children.Add(usc);

                }
            }



        }

        private void DataGridEquipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Lista> filtered = new List<Lista>();

            foreach (Lista ee in li)
            {

                if (ee.Name.ToLower().Contains(Search.Text.ToLower()))
                {


                    filtered.Add(new Lista { Name = ee.Name });


                }


            }

            EmployeeList.ItemsSource = filtered;
            foreach (Lista ee in filtered)
            {
                Console.WriteLine(ee.Name);

            }
        }
    }
}
