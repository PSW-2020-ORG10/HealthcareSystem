using Class_diagram.Contoller;
using Class_diagram.Model.Employee;
using Class_diagram.Model.Hospital;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2.Rooms
{
    /// <summary>
    /// Interaction logic for RoomClass.xaml
    /// </summary>
    public partial class RoomClass : UserControl
    {
        public RoomClass()
        {
            InitializeComponent();
        }

        Room r = new Room();
        public RoomClass(Room room)
        {
            InitializeComponent();
            r = room;
            Type.Text = room.typeOfRoom;
         
        }


        private void Medicines(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new RoomMedicine(r);
            GridMain.Children.Add(usc);
        }

        private void Equipment(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new RoomEquipment(r);
            GridMain.Children.Add(usc);
        }

        private void Schedule(object sender, RoutedEventArgs e)
        {
           
        }

        private void AddRenovation(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new AddRenovation(r);
            GridMain.Children.Add(usc);
        }

        private void EditRenovation(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new EditRenovation(r);
            GridMain.Children.Add(usc);
        }

        private void Remove(object sender, RoutedEventArgs e)
        {

            RoomController RoomContr = new RoomController();
            RoomContr.Remove(r);


            DoctorController dc = new DoctorController();
            List<DoctorUser> lista = new List<DoctorUser>();
            lista = dc.GetAll();

            foreach(DoctorUser du in lista)
            {
                if (du.ordination.Equals(r.typeOfRoom))
                {
                    MessageBox.Show("Please change ordination of doctor " + du.firstName + " " + du.secondName + ".", "Notification", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }
            }

            GridMain.Children.Clear();
            UserControl usc = new ListOfRooms();
            GridMain.Children.Add(usc);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Type.Text == "")
            {
                MessageBox.Show("Please fill Name field.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            String type=Type.Text;

            r.typeOfRoom = type;

            RoomController rc = new RoomController();
            rc.Update(r);



            GridMain.Children.Clear();
            UserControl usc = new ListOfRooms();
            GridMain.Children.Add(usc);
        }
    }
}
