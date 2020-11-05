using Class_diagram.Contoller;
using Class_diagram.Model.Hospital;
using HCI_wireframe.Model.Hospital;
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

namespace WpfApp2.Rooms
{
    /// <summary>
    /// Interaction logic for RoomEquipment.xaml
    /// </summary>
    public partial class RoomEquipment : UserControl
    {
        List<Lista> li = new List<Lista>();
        EquipmentController MedContr = new EquipmentController();
        List<Equipment> lista = new List<Equipment>();

        Room r = new Room();
        public class Lista
        {

            public string Name { get; set; }

            public Lista()
            {

            }

        }
        public RoomEquipment(Room room)
        {
            InitializeComponent();
            lista = MedContr.GetAll();
            r = room;
            
            
            
             foreach (Equipment ee in lista)
             {
                
                 if (r.equipment.Contains(new ModelEquipment(ee.name)))
                 {
                     li.Add(new Lista { Name = ee.name });
                 }
             }

            dataGridEquipment.ItemsSource = li;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new RoomClass(r);
            GridMain.Children.Add(usc);
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
