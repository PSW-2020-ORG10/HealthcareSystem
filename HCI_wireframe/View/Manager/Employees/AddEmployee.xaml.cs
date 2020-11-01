using Class_diagram.Contoller;
using Class_diagram.Model.Hospital;
using Class_diagram.Model.Secretary;
using HCI_wireframe.Model.Doctor;
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

namespace WpfApp2.Employees

{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : UserControl
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public int id;
        public string first;
        public string last;
        public string dateTxt;
        public string address;
        public string phoneTxt;
        public string ucin;
        public string spec;
        public double wage;
        public string pass;
        public string emailTxt;
     
        public DoctorUser doctorUser;
        public SecretaryUser secretaryUser;



        public AddEmployee()
        {
            InitializeComponent();
            this.DataContext = this;
            //Specijality.IsEnabled = false;

            DoctorController dc = new DoctorController();

            List<Room> sobe = new List<Room>();
            sobe = dc.getAvailableOrdinations();

            Combo_Copy.ItemsSource = sobe;
        }
      

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private int getNextid()
        {
            DoctorController rp = new DoctorController();
            SecretaryController sp = new SecretaryController();
            List<DoctorUser> lista = rp.GetAll();
            List<SecretaryUser> listaS = sp.GetAll();
            int number = 0;
           
            foreach (DoctorUser r in lista)
            {
                if (r.id > number)
                {
                    number = r.id;
                }
            }
            foreach (SecretaryUser r in listaS)
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
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DoctorController dc = new DoctorController();
            id = getNextid();
            first = First.Text;
            last = Last.Text;
            dateTxt = Date.Text;
            address = Address.Text;
            phoneTxt = Phone.Text;
            ucin = UCIN.Text;
            spec = Specijality.Text;
            
            
            if (Wage.Text == "")
            {
                wage = 0;
            }
            else
            {
                wage = Double.Parse(Wage.Text);
            }
            pass = Pass.Text;
            emailTxt = EmailTxt.Text;

            if(first=="" || last == "" || pass=="" ||emailTxt=="" )
            {
                MessageBox.Show("Please fill all fields marked with *.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Room s = new Room();
            if (Combo_Copy.SelectedItem != null)
            {
                s = (Room)Combo_Copy.Items.GetItemAt(Combo_Copy.SelectedIndex);
            }
            
           
            DoctorController DocContr = new DoctorController();
            SecretaryController SecContr = new SecretaryController();

            List<DoctorUser> lista = new List<DoctorUser>();
            lista = DocContr.GetAll();
            List<SecretaryUser> listaS = new List<SecretaryUser>();
            listaS = SecContr.GetAll();


            Boolean valid;

          
            if (Secretary.IsChecked == true)
            {
                Specijality.IsEnabled = false;
                secretaryUser = new SecretaryUser(id, first, last, ucin, date, phone, email, pass, address,wage,"SecretarysRoom");

                Boolean isSecretaryNew = SecContr.New(secretaryUser);
                if(isSecretaryNew==false)
                {

                    MessageBox.Show("Fields must be unique.\nCity must be in format : City, Street number, postal code, Country.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }
            if (Genral.IsChecked == true)
            {
                Specijality.IsEnabled = false;
                doctorUser = new DoctorUser(id, first, last, ucin, date, phone, email, pass, address, wage, false, null,null,s.typeOfRoom);

                Boolean isDoctorOk = DocContr.New(doctorUser);
                if(isDoctorOk==false)
                {
                    MessageBox.Show("Fields must be unique.\nCity must be in format : City, Street number, postal code, Country.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            }

            if (Specialist.IsChecked == true)
            {

                doctorUser = new DoctorUser(id, first, last, ucin, date, phone, email, pass, address, wage, true, spec, null,s.typeOfRoom);


                Boolean isDoctorOk = DocContr.New(doctorUser);
                if (isDoctorOk == false)
                {
                    MessageBox.Show("Fields must be unique.\nCity must be in format : City, Street number, postal code, Country.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


            }

            GridMain.Children.Clear();
            UserControl usc = new ListOfEmployees();
            GridMain.Children.Add(usc);
        }

        private void TextBlock_TextInput(object sender, TextCompositionEventArgs e)
        {

        }

       
        private String email;
        public String Email
        {
           
            get
            {
                return email;
            }
            set
            {

                

                if (value != email)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        private String ucinP;
        public String Ucin
        {
           
            get
            {
                return ucinP;
            }
            set
            {



                if (value != ucinP)
                {
                    ucinP = value;
                    OnPropertyChanged("Ucin");
                }
            }
        }


        private String date;
        public String DateOfBirth
        {
            get
            {
                return date;
            }
            set
            {
                if (value != date)
                {
                    date = value;
                    OnPropertyChanged("DateOfBirth");
                }
            }
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new ListOfEmployees();
            GridMain.Children.Add(usc);
        }

        private void Secretary_Click(object sender, RoutedEventArgs e)
        {
            Specijality.IsEnabled = false;
            Combo_Copy.IsEnabled = false;

        }

        private void Genral_Click(object sender, RoutedEventArgs e)
        {
            Specijality.IsEnabled = false;

        }

        private void Specialist_Click(object sender, RoutedEventArgs e)
        {
            Specijality.IsEnabled = true;

        }

       
    }
  
}
