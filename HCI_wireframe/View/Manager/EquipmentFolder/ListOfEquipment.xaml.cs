using Class_diagram.Contoller;
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
using Class_diagram.Model.Hospital;
using WpfApp2.Employees;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for ListOfEquipment.xaml
    /// </summary>
    public partial class ListOfEquipment : UserControl
    {
        List<Lista> li = new List<Lista>();
        EquipmentController EquipmentContr = new EquipmentController();
        List<Equipment> lista = new List<Equipment>();
        public class Lista
        {

            public string Name { get; set; }

            public string Last { get; set; }



            public Lista()
            {

            }

        }
        public ListOfEquipment()
        {
           
            InitializeComponent();
            
         
            lista= EquipmentContr.GetAll();
            List<Equipment> oprema = new List<Equipment>();
            //dataGridEquipment.DataContext = lista;
            
            foreach (Equipment ee in lista)
            {
                //oprema.Add(new Equipment { id=ee.id, Name=ee.Name, Quantity=ee.Quantity});
                li.Add(new Lista { Name = ee.name});
            }
            dataGridEquipment.ItemsSource = li;
        
        }

        private void Add_new_equipment(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new AddEquipment();
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

            lista = EquipmentContr.GetAll();

         
            
            foreach (Equipment ee in lista)
            {

                if (ee.name.Equals(id))
                {
                    GridMain.Children.Clear();
                    UserControl usc = new EquipmentClass(ee);
                    GridMain.Children.Add(usc);


                }
            }


          
        }

       
       

        private void TextBox_TouchEnter(object sender, TouchEventArgs e)
        {
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Lista> filtered = new List<Lista>();

            foreach (Lista ee in li)
            {

                if (ee.Name.ToLower().Contains(SearchBox.Text.ToLower()))
                {


                    filtered.Add(new Lista { Name = ee.Name });


                }


            }

            dataGridEquipment.ItemsSource = filtered;
            foreach (Lista ee in filtered)
            {
                Console.WriteLine(ee.Name);

            }

        }
    }
}
