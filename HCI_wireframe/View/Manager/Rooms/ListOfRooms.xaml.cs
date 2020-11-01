using Class_diagram.Contoller;
using Class_diagram.Model.Hospital;
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
using WpfApp2.Rooms;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for ListOfRooms.xaml
    /// </summary>
    public partial class ListOfRooms : UserControl
    {
        List<Lista> li = new List<Lista>();
        RoomController MedContr = new RoomController();
        List<Room> lista = new List<Room>();
        public class Lista
        {

            public string Name { get; set; }

            public string Last { get; set; }



            public Lista()
            {

            }

        }
        public ListOfRooms()
        {
            InitializeComponent();
            lista = MedContr.GetAll();
            List<Room> oprema = new List<Room>();


            foreach (Room ee in lista)
            {

                li.Add(new Lista { Name = ee.typeOfRoom });
            }
            dataGridEquipment.ItemsSource = li;
        }

        private void Add_new_room(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new AddRoom();
            GridMain.Children.Add(usc);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            GridMain.Children.Clear();
            UserControl usc = new Rooms.RoomClass();
            GridMain.Children.Add(usc);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string name1 = sender.ToString();
            string[] words = name1.Split(':');

            string id = words[1].TrimEnd().TrimStart();
           

           

            lista = MedContr.GetAll();


            lista = MedContr.GetAll();



            foreach (Room ee in lista)
            {
               
                if (ee.typeOfRoom.Equals(id))
                {
                    GridMain.Children.Clear();
                   
                    UserControl usc = new RoomClass(ee);
                    GridMain.Children.Add(usc);


                }
            }
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
