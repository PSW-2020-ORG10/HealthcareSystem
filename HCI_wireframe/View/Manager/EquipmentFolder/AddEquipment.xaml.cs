using Class_diagram.Contoller;
using Class_diagram.Model.Hospital;
using HCI_wireframe.Model.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddEquipment : UserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string name;
        public string quantity;

        public int id;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public AddEquipment()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private int getNextid()
        {
            EquipmentController rp = new EquipmentController();
            List<Equipment> lista = rp.GetAll();
            int number = 0;
            foreach (Equipment r in lista)
            {
                if (r.id > number)
                {
                    number = r.id;
                }
            }
            number += 1;
            return number;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            name = Name.Text;
            quantity = Quantity.Text;
            id = getNextid();

            Regex regex1 = new Regex(@"^([0-9]+)$");


            if (!regex1.IsMatch(quantity))
            {
                MessageBox.Show("Please, insert a number for quantity!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }






            if (name=="" || quantity == "")
            {

                MessageBox.Show("Please, fill all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


           

           

           


            List<ModelRoom> rooms = new List<ModelRoom>();

           

            Room s = new Room();
            RoomController RoomContr = new RoomController();
            List<Room> l = new List<Room>();
            l = RoomContr.GetAll();
            Equipment med = new Equipment();
            EquipmentController EqContr = new EquipmentController();

            List<Equipment> lista = new List<Equipment>();
            lista = EqContr.GetAll();

            Boolean valid = EqContr.isNameValid(name);

           
                if (!valid)
                {
                    MessageBox.Show("Equipment with this name already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                    return;
                }

            med = new Equipment(id, name, int.Parse(quantity), rooms);
            EqContr.New(med);

            



           


            
            GridMain.Children.Clear();
            UserControl usc = new ListOfEquipment();
            GridMain.Children.Add(usc);


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new ListOfEquipment();
            GridMain.Children.Add(usc);
        }

        private String phone;
        public String PhoneNumber
        {
            get
            {
                return phone;
            }
            set
            {
                if (value != phone)
                {
                    phone = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }
    }
}
