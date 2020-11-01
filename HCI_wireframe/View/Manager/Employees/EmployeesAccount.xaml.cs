using Class_diagram.Contoller;
using Class_diagram.Model.Employee;
using Class_diagram.Model.Hospital;
using Class_diagram.Model.Secretary;
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

namespace WpfApp2.Employees

{
    /// <summary>
    /// Interaction logic for EmployeesAccount.xaml
    /// </summary>
    public partial class EmployeesAccount : UserControl
    {
        DoctorController DocContr = new DoctorController();
        EmployeesScheduleController SchContr = new EmployeesScheduleController();
        SecretaryController SecContr = new SecretaryController();

        List<DoctorUser> lista = new List<DoctorUser>();
        List<Schedule> listaSch = new List<Schedule>();
        List<SecretaryUser> listaS = new List<SecretaryUser>();
        SecretaryUser su = new SecretaryUser();
        DoctorUser du = new DoctorUser();
        
        public string hours;
        public string spec;

        public EmployeesAccount(DoctorUser dok)
        {
            InitializeComponent();
            first.AppendText(dok.firstName);
            last.AppendText(dok.secondName);
            date.AppendText(dok.dateOfBirth);
            address.AppendText(dok.city);
            ucinTxt.AppendText(dok.uniqueCitizensidentityNumber);
            email.AppendText(dok.email);
          
            phone.AppendText(dok.phoneNumber);
            pass.AppendText(dok.password);
            speci.AppendText(dok.speciality);
           hour.AppendText(dok.salary.ToString());
            

            du = dok;
            su = new SecretaryUser(0, "", "", "", "", "", "", "", "", 0,"");

            if (!dok.isSpecialist)
            {
                G.IsChecked = true;
                speci.IsEnabled = false;
            }
            else
            {
                Sp.IsChecked = true;
            }



            RoomController RoomContr = new RoomController();
            List<Room> lista = new List<Room>();
            lista = RoomContr.GetAll();
            List<Room> sobeSaOpremom = new List<Room>();
            List<Room> sobe = new List<Room>();
            DoctorController rp = new DoctorController();
            List<DoctorUser> listad = rp.GetAll();
            Room doktorSoba = new Room();
            foreach (Room item in lista)
            {

                if (item.forUse == true)
                {
                    sobeSaOpremom.Add(item);
                }

                if (item.typeOfRoom.Equals(dok.ordination))
                {
                    doktorSoba = item;
                }

            }

            foreach (Room room in sobeSaOpremom)
            {


                bool available = true;

                foreach (DoctorUser doctor in listad)
                {


                    if (doctor.ordination.Equals(room.typeOfRoom))
                    {
                        available = false;

                    }
                }

                if (available)
                {
                    sobe.Add(room);
                }

            }

            sobe.Add(doktorSoba);
            Combo_Copy.ItemsSource = sobe;
            Combo_Copy.SelectedItem = doktorSoba;

        }
        public EmployeesAccount(SecretaryUser employee)
        {
          
            InitializeComponent();
            S.IsChecked = true;
            first.AppendText(employee.firstName);
            last.AppendText(employee.secondName);
            date.AppendText(employee.dateOfBirth);
            address.AppendText(employee.city);
            ucinTxt.AppendText(employee.uniqueCitizensidentityNumber);
            email.AppendText(employee.email);
           
            phone.AppendText(employee.phoneNumber);
            pass.AppendText(employee.password);
            speci.AppendText("null");
            speci.IsEnabled = false;
            hour.AppendText(employee.salary.ToString());

            su = employee;
            du = new DoctorUser(0, "", "", "", "", "", "", "", "", 0, false, "", null,"");


            RoomController RoomContr = new RoomController();
            List<Room> lista = new List<Room>();
            lista = RoomContr.GetAll();
            List<Room> sobeSaOpremom = new List<Room>();
            List<Room> sobe = new List<Room>();
            DoctorController rp = new DoctorController();
            List<DoctorUser> listad = rp.GetAll();
            Room sekretarSoba = new Room();


            foreach (Room item in lista)
            {
                
                if (item.typeOfRoom.Equals(employee.room))
                {
                  
                    sekretarSoba = item;
                }

            }


            sobe.Add(sekretarSoba);
            Combo_Copy.ItemsSource = sobe;
           
            Combo_Copy.SelectedItem = sekretarSoba;
           Combo_Copy.IsEnabled = false;

        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            SecretaryUser ss = new SecretaryUser();
            DoctorUser dd = new DoctorUser();

            Room s = new Room();

            if (Combo_Copy.SelectedItem != null)
            {
                s = (Room)Combo_Copy.Items.GetItemAt(Combo_Copy.SelectedIndex);
            }

            List<Schedule> listOfSchedule = new List<Schedule>();
            EmployeesScheduleController employeesSchedule = new EmployeesScheduleController();

            listOfSchedule = employeesSchedule.GetAll();


            foreach (Schedule schedule in listOfSchedule)
            {

                if (schedule.employeeid.Equals(du.id.ToString()))
                {

                    schedule.room = s.typeOfRoom;

                    employeesSchedule.Update(schedule);
                }
            }

            if (du.firstName != "")
            {
             
                if (S.IsChecked == true)
                {
                   
                    hours = hour.Text;
                    ss = new SecretaryUser(du.id, du.firstName, du.secondName, du.uniqueCitizensidentityNumber, du.dateOfBirth, du.phoneNumber, du.email, du.password, du.city, Double.Parse(hours),"SecretarysRoom");
                    DocContr.Remove(du);
                    SecContr.New(ss);

                    GridMain.Children.Clear();
                    UserControl usc = new ListOfEmployees();
                    GridMain.Children.Add(usc);
                    return;

                }


                if (G.IsChecked == true)
                {
                    
                    hours = hour.Text;
                    dd = new DoctorUser(du.id, du.firstName, du.secondName, du.uniqueCitizensidentityNumber, du.dateOfBirth, du.phoneNumber, du.email, du.password, du.city, Double.Parse(hours), false, null, null,s.typeOfRoom);
                    DocContr.Update(dd);

                    GridMain.Children.Clear();
                    UserControl usc = new ListOfEmployees();
                    GridMain.Children.Add(usc);
                    return;

                }


                if (Sp.IsChecked == true)
                {
                  
                    hours = hour.Text;
                    spec = speci.Text;
                    dd = new DoctorUser(du.id, du.firstName, du.secondName, du.uniqueCitizensidentityNumber, du.dateOfBirth, du.phoneNumber, du.email, du.password, du.city, Double.Parse(hours), true, spec, null,s.typeOfRoom);
                    DocContr.Update(dd);

                    GridMain.Children.Clear();
                    UserControl usc = new ListOfEmployees();
                    GridMain.Children.Add(usc);
                    return;
                }


            }

            if (su.firstName != "")
            {
              
                if (S.IsChecked == true)
                {
                    hours = hour.Text;
                   
                    ss = new SecretaryUser(su.id, su.firstName, su.secondName, su.uniqueCitizensidentityNumber, su.dateOfBirth, su.phoneNumber, su.email, su.password, su.city, Double.Parse(hours),"SecretarysRoom");
                    SecContr.Update(su);

                    GridMain.Children.Clear();
                    UserControl usc = new ListOfEmployees();
                    GridMain.Children.Add(usc);
                    return;


                }


                if (G.IsChecked == true)
                {
                   
                    hours = hour.Text;


                    dd = new DoctorUser(su.id, su.firstName, su.secondName, su.uniqueCitizensidentityNumber, su.dateOfBirth, su.phoneNumber, su.email, su.password, su.city, Double.Parse(hours), false, null, null,s.typeOfRoom);
                    SecContr.Remove(su);
                    DocContr.New(dd);

                    GridMain.Children.Clear();
                    UserControl usc = new ListOfEmployees();
                    GridMain.Children.Add(usc);
                    return;

                }


                if (Sp.IsChecked == true)
                {
                   
                    hours = hour.Text;
                    spec = speci.Text;
                    dd = new DoctorUser(su.id, su.firstName, su.secondName, su.uniqueCitizensidentityNumber, su.dateOfBirth, su.phoneNumber, su.email, su.password, su.city, Double.Parse(hours), true, spec, null,s.typeOfRoom);
                    SecContr.Remove(su);
                    DocContr.New(dd);

                    GridMain.Children.Clear();
                    UserControl usc = new ListOfEmployees();
                    GridMain.Children.Add(usc);
                    return;

                }
            }




          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new ListOfEmployees();
            GridMain.Children.Add(usc);
        }

       
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

            if (!su.firstName.Equals(""))
            {
                SecContr.Remove(su);
            }

            if (!du.firstName.Equals(""))
            {
                DocContr.Remove(du);
            }
           
            
        
            GridMain.Children.Clear();
            UserControl usc = new ListOfEmployees();
            GridMain.Children.Add(usc);

        }

        private void S_Click(object sender, RoutedEventArgs e)
        {
            speci.IsEnabled = false;

            RoomController RoomContr = new RoomController();
            List<Room> lista = new List<Room>();
            lista = RoomContr.GetAll();
            List<Room> sobe = new List<Room>();
            Room sekretarSoba = new Room();


            foreach (Room item in lista)
            {

                if (item.typeOfRoom.Equals("SecretarysRoom"))
                {

                    sekretarSoba = item;
                }

            }


            sobe.Add(sekretarSoba);
            Combo_Copy.ItemsSource = sobe;

            Combo_Copy.SelectedItem = sekretarSoba;
            Combo_Copy.IsEnabled = false;

        }

        private void G_Click(object sender, RoutedEventArgs e)
        {
            speci.IsEnabled = false;
            Combo_Copy.IsEnabled = true;

            RoomController RoomContr = new RoomController();
            List<Room> lista = new List<Room>();
            lista = RoomContr.GetAll();
            List<Room> sobeSaOpremom = new List<Room>();
            List<Room> sobe = new List<Room>();
            DoctorController rp = new DoctorController();
            List<DoctorUser> listad = rp.GetAll();
            Room doktorSoba = new Room();

            foreach (Room item in lista)
            {

                if (item.forUse == true)
                {
                    sobeSaOpremom.Add(item);
                }
                

            }

            foreach (Room room in sobeSaOpremom)
            {


                bool available = true;

                foreach (DoctorUser doctor in listad)
                {


                    if (doctor.ordination.Equals(room.typeOfRoom))
                    {
                        available = false;

                    }
                }

                if (available)
                {
                    sobe.Add(room);
                }

            }

            Combo_Copy.ItemsSource = sobe;
       
        }

        private void Sp_Click(object sender, RoutedEventArgs e)
        {
            speci.IsEnabled = true;
            Combo_Copy.IsEnabled = true;
            RoomController RoomContr = new RoomController();
            List<Room> lista = new List<Room>();
            lista = RoomContr.GetAll();
            List<Room> sobeSaOpremom = new List<Room>();
            List<Room> sobe = new List<Room>();
            DoctorController rp = new DoctorController();
            List<DoctorUser> listad = rp.GetAll();
            Room doktorSoba = new Room();

            foreach (Room item in lista)
            {

                if (item.forUse == true)
                {
                    sobeSaOpremom.Add(item);
                }


            }

            foreach (Room room in sobeSaOpremom)
            {


                bool available = true;

                foreach (DoctorUser doctor in listad)
                {


                    if (doctor.ordination.Equals(room.typeOfRoom))
                    {
                        available = false;

                    }
                }

                if (available)
                {
                    sobe.Add(room);
                }

            }
            Combo_Copy.ItemsSource = sobe;
        }
    }
}
