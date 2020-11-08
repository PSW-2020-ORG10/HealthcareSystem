using Class_diagram.Contoller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfApp2.MedicineFolder;
using Class_diagram.Model.Hospital;
using HCI_wireframe.Model.Doctor;
using System.Reflection;
using HCI_wireframe.Contoller;
using System.Text.RegularExpressions;
using HCI_wireframe.Model.Hospital;

namespace WpfApp2.MedicineFolder
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class AddMedicine : UserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string name;
        public string quantity;
        public string description;
        public int id;
        public DoctorUser doktor;
        public string bla;

        List<Lista> li = new List<Lista>();


        public class Lista
        {

            public string Name { get; set; }





            public Lista()
            {

            }

        }
        public AddMedicine()
        {
            InitializeComponent();
            this.DataContext = this;

            DoctorController DoctorContr = new DoctorController();
            List<DoctorUser> lista = new List<DoctorUser>();
            lista = DoctorContr.GetAll();






            foreach (DoctorUser ee in lista)
            {

                StringBuilder l = new StringBuilder();
                l.Append(ee.id + " ");
                l.Append(ee.firstName + " ");
                l.Append(ee.secondName);
                li.Add(new Lista { Name = l.ToString() });
            }




            Combo.ItemsSource = li;

        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private int getNextID()
        {
            RequestMedicineController rp = new RequestMedicineController();
            List<Medicine> lista = rp.GetAll();
            int number = 0;
            foreach (Medicine r in lista)
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
            description = Description.Text;
            id = getNextID();
            DoctorController DoctorContr = new DoctorController();
            List<DoctorUser> listad = new List<DoctorUser>();
            listad = DoctorContr.GetAll();


            Regex regex1 = new Regex(@"^([0-9]+)$");


            if (!regex1.IsMatch(quantity))
            {
                MessageBox.Show("Please, insert a number for quantity!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            Lista stt = (Lista)Combo.Items.GetItemAt(Combo.SelectedIndex);

            String[] str = stt.Name.Split(' ');


            foreach (DoctorUser dok in listad)
            {


                if (str[0].Equals(dok.id.ToString()))
                {

                    doktor = dok;


                }


            }

            if (name == "" || quantity == "" || description == "")
            {

                MessageBox.Show("Please, fill all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            List<ModelRoom> rooms = new List<ModelRoom>();



            Room s = new Room();
            RoomController RoomContr = new RoomController();
            List<Room> l = new List<Room>();
            l = RoomContr.GetAll();
            Medicine med = new Medicine();

            RequestMedicineController MedContr = new RequestMedicineController();
            MedicineController MMedContr = new MedicineController();
            List<Medicine> lista = new List<Medicine>();
            lista = MedContr.GetAll();


            Boolean valid = MMedContr.isNameValid(name);




            if (!valid)
            {


                MessageBox.Show("Medicine with this name already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;



            }



            med = new Medicine(id, name, int.Parse(quantity), description, rooms, doktor, true);

            MedContr.New(med);








            GridMain.Children.Clear();
            UserControl usc = new ListOfMedicine();
            GridMain.Children.Add(usc);


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            GridMain.Children.Clear();
            UserControl usc = new ListOfMedicine();
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DoctorController DoctorContr = new DoctorController();
            List<DoctorUser> lista = new List<DoctorUser>();
            lista = DoctorContr.GetAll();

            Lista d = (Lista)Combo.SelectedItem;
            string deo = d.Name.ToString();



        }

        private void Quantity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
