using Class_diagram.Contoller;
using Class_diagram.Model.Manager;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2.Employees
{
    /// <summary>
    /// Interaction logic for MyProfile.xaml
    /// </summary>
    public partial class MyProfile : UserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ManagerUser mu = new ManagerUser();

        public int id;
       

        ManagerController mc = new ManagerController();
        ManagerUser managerU;
        public MyProfile()
        {
            InitializeComponent();
            this.DataContext = this;

            List<ManagerUser> lista = new List<ManagerUser>();
            managerU = new ManagerUser();
            lista = mc.GetAll();



            foreach(ManagerUser user in lista)
            {
                managerU = user;
                id = user.id;
                first.Text = user.firstName;
                last.Text = user.secondName;
                datetxt.Text = user.dateOfBirth;
                address.Text = user.city;
                emailtxt.AppendText(user.email.ToString());
              //  Console.WriteLine(user.Email);
                phonetxt.Text = user.phoneNumber;
                ucinTxt.Text = user.uniqueCitizensidentityNumber;
                hour.Text = user.salary.ToString();
                pass.Text = user.password;
                
            }
            


        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }



       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ManagerUser ss = new ManagerUser(managerU.id, first.Text, last.Text, ucinTxt.Text, datetxt.Text , phonetxt.Text, emailtxt.Text, pass.Text, address.Text, Double.Parse(hour.Text), managerU.specialNotifications);
            Console.WriteLine(id);

            mc.Update(ss);

            GridMain.Children.Clear();
            UserControl usc = new Notifications();
            GridMain.Children.Add(usc);



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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new Notifications();
            GridMain.Children.Add(usc);
        }
    }
}
