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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for EquipmentClass.xaml
    /// </summary>
    public partial class EquipmentClass : UserControl
    {
        public EquipmentClass()
        {
            InitializeComponent();
            this.DataContext = this;

            
        }

        Equipment eq = new Equipment();
        public EquipmentClass(Equipment equipment)

        {
            InitializeComponent();
            this.DataContext = this;
            eq = equipment;

            name.Text = equipment.name;
            quantity.Text = equipment.quantity.ToString();
            RoomController RoomContr = new RoomController();
            List<Room> lista = new List<Room>();
            lista = RoomContr.GetAll();
            List<Room> sobe = new List<Room>();
            List<Room> sobeSaOpremom = new List<Room>();
           

            foreach (Room item in lista)
            {
                if (item.forUse == true)
                {
                    if (eq.room != null)
                    {
                        for (int i = 0; i < eq.room.Count; i++)
                        {
                            ModelRoom soba = eq.room[i];

                            if (soba.Equals(item.typeOfRoom))
                            {
                                sobeSaOpremom.Add(item);
                            }
                        }
                    }
                }
            }

            foreach (Room item in lista)
            {
                if (item.forUse == true) { 

                    bool postoji = false;
                foreach (Room saOpremom in sobeSaOpremom)
                {
                    if (item.id == saOpremom.id)
                    {
                        postoji = true;
                    }
                }

                if (!postoji)
                {
                    sobe.Add(item);
                }
            }
            }



            Combo.ItemsSource = sobe;
            Combo_Copy.ItemsSource = sobeSaOpremom;
            Combo_Copy1.ItemsSource = sobeSaOpremom;



        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string name1 = sender.ToString();
            string[] words = name1.Split(':');

            ModelRoom id = new ModelRoom(words[1].TrimEnd().TrimStart());


            eq.room.Remove(id);

            Room s = new Room();
            RoomController RoomContr = new RoomController();
            List<Room> lista = new List<Room>();
            lista = RoomContr.GetAll();

            foreach (Room ee in lista)
            {
               
                    if (ee.typeOfRoom.Equals(id))
                {
                    s = ee;
                    s.equipment.Remove(new ModelEquipment(eq.name));

                }


            }


            EquipmentController EquipmentContr = new EquipmentController();

            EquipmentContr.Update(eq);



            RoomContr.Update(s);







            lista = RoomContr.GetAll();
            List<Room> sobe = new List<Room>();
            List<Room> sobeSaOpremom = new List<Room>();
            //dataGridEquipment.DataContext = lista;


            foreach (Room item in lista)
            {
                if (item.forUse == true)
                {
                    for (int i = 0; i < eq.room.Count; i++)
                    {
                        ModelRoom soba = eq.room[i];

                        if (soba.Equals(item.typeOfRoom))
                        {
                            sobeSaOpremom.Add(item);
                        }
                    }
                }
            }

            foreach (Room item in lista)
            {
                if (item.forUse == true)
                {
                    bool postoji = false;
                    foreach (Room saOpremom in sobeSaOpremom)
                    {
                        if (item.id == saOpremom.id)
                        {
                            postoji = true;
                        }
                    }

                    if (!postoji)
                    {
                        sobe.Add(item);
                    }
                }
            }




            Combo.ItemsSource = sobe;
            Combo_Copy.ItemsSource = sobeSaOpremom;
            Combo_Copy1.ItemsSource = sobeSaOpremom;








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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            




            if (name.Text == "" || quantity.Text == "")
            {
                MessageBox.Show("Please fill Name and Quantity fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Regex regex1 = new Regex(@"^([0-9]+)$");


            if (!regex1.IsMatch(quantity.Text))
            {
                MessageBox.Show("Please, insert a number for quantity!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            Equipment equ = new Equipment(eq.id, name.Text, int.Parse(quantity.Text), eq.room);

            EquipmentController EquipmentContr = new EquipmentController();

            EquipmentContr.Update(equ);


            GridMain.Children.Clear();
            UserControl usc = new WpfApp2.ListOfEquipment();
            GridMain.Children.Add(usc);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string name1 = sender.ToString();
            string[] words = name1.Split(':');

            ModelRoom id = new ModelRoom(words[1].TrimEnd().TrimStart());
            

            eq.room.Add(id);

            Room s = new Room();
            RoomController RoomContr = new RoomController();
            List<Room> lista = new List<Room>();
            lista = RoomContr.GetAll();

            foreach (Room ee in lista)
            {
                if (ee.forUse == true)
                {
                    if (ee.typeOfRoom.Equals(id))
                    {
                        s = ee;
                        s.equipment.Add(new ModelEquipment(eq.name));

                    }
                }
                
            }


            EquipmentController EquipmentContr = new EquipmentController();

            EquipmentContr.Update(eq);

            

            RoomContr.Update(s);



          


          
            lista = RoomContr.GetAll();
            List<Room> sobe = new List<Room>();
            List<Room> sobeSaOpremom = new List<Room>();
            //dataGridEquipment.DataContext = lista;


            foreach (Room item in lista)
            {
                if (item.forUse == true)
                {
                    for (int i = 0; i < eq.room.Count; i++)
                    {
                        ModelRoom soba = eq.room[i];

                        if (soba.Equals(item.typeOfRoom))
                        {
                            sobeSaOpremom.Add(item);
                        }
                    }
                }
            }

            foreach (Room item in lista)
            {
                if (item.forUse == true)
                {
                    bool postoji = false;
                    foreach (Room saOpremom in sobeSaOpremom)
                    {
                        if (item.id == saOpremom.id)
                        {
                            postoji = true;
                        }
                    }

                    if (!postoji)
                    {
                        sobe.Add(item);
                    }
                }
            }




            Combo.ItemsSource = sobe;
            Combo_Copy.ItemsSource = sobeSaOpremom;
            Combo_Copy1.ItemsSource = sobeSaOpremom;


           

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<Equipment> lista = new List<Equipment>();
            EquipmentController EqContr = new EquipmentController();
            lista = EqContr.GetAll();


            EqContr.Remove(eq);





            GridMain.Children.Clear();
            UserControl usc = new ListOfEquipment();
            GridMain.Children.Add(usc);
        }
    }
}
