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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class AddRoom : UserControl
    {
        public string name;
        public int id;
        public AddRoom()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            name = Name.Text;
     
            id = getNextid();


            if (name == "")
            {
                MessageBox.Show("Please, fill all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            List<ModelEquipment> oprema = new List<ModelEquipment>();
            List<ModelMedicine> medicines = new List<ModelMedicine>();

            Room med = new Room(id, name,oprema, medicines,true);

            RoomController EqContr = new RoomController();

            List<Room> lista = new List<Room>();
            lista = EqContr.GetAll();

            Boolean valid = EqContr.isNameValid(name);
           
           
                if (!valid)
                {
                    MessageBox.Show("Room with this name already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
          
            EqContr.New(med);




            GridMain.Children.Clear();
            UserControl usc = new ListOfRooms();
            GridMain.Children.Add(usc);


        }
        private int getNextid()
        {
            RoomController rp = new RoomController();
            List<Room> lista = rp.GetAll();
            int number = 0;
            foreach (Room r in lista)
            {
                if (r.id > number)
                {
                    number = r.id;
                }
            }
            number += 1;
            return number;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

      
    }
}
