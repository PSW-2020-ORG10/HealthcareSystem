using Class_diagram.Contoller;
using Class_diagram.Model.Hospital;
using Class_diagram.Model.Secretary;
using HCI_wireframe.Model.Doctor;
using System;
using System.Collections.Generic;
using System.Data;
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
using Class_diagram.Model.Employee;
using WpfApp2.View.Manager.ScheduleFolder;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for AddToSchedule.xaml
    /// </summary>
    public partial class AddToSchedule : UserControl
    {
        public DatePicker date;
        public DateTime date2;
        public string start;
        public int id;
        public string end;
        public Boolean yes = false;
        public DoctorUser doktor;
        public SecretaryUser secretary;
        
        public string employee;
        public Shift shift = null;

        public class Lista
        {

            public string Name { get; set; }

            public string Last { get; set; }



            public Lista()
            {

            }

        }

        DoctorController DoctorContr = new DoctorController();
        EmployeesScheduleController SchDontr = new EmployeesScheduleController();
        SecretaryController SecretaryContr = new SecretaryController();
        List<DoctorUser> lista = new List<DoctorUser>();
        List<Schedule> Schlista = new List<Schedule>();
        List<SecretaryUser> listaS = new List<SecretaryUser>();
        RoomController RoomContr = new RoomController();
        
      

        public AddToSchedule()
        {
            InitializeComponent();
            List<Lista> li = new List<Lista>();


            lista = DoctorContr.GetAll();
            List<DoctorUser> doktori = new List<DoctorUser>();



            foreach (DoctorUser ee in lista)
            {

                StringBuilder l = new StringBuilder();
                l.Append(ee.id + " ");
                l.Append(ee.firstName + " ");
                l.Append(ee.secondName);
                li.Add(new Lista { Name = l.ToString() });
               
            }

            

            listaS = SecretaryContr.GetAll();
            List<SecretaryUser> sekretari = new List<SecretaryUser>();

            foreach (SecretaryUser ee in listaS)
            {

               
                StringBuilder l = new StringBuilder();
                l.Append(ee.id + " ");
                l.Append(ee.firstName + " ");
                l.Append(ee.secondName);
                li.Add(new Lista { Name = l.ToString() });

            }


            Employe.ItemsSource = li;

           

        }

        private int getNextid()
        {
            EmployeesScheduleController rp = new EmployeesScheduleController();
            List<Schedule> lista = rp.GetAll();
            int number = 0;
            foreach (Schedule r in lista)
            {
                if (r.id > number)
                {
                    number = r.id;
                }
            }
            number += 1;
            return number;
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            if (Date.ToString() == "")
            {
                MessageBox.Show("Please fill all fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }



            String datum = Date.ToString();
            String[] deo = datum.Split(' ');
            String[] delovi = deo[0].Split('/');
            int mesec = int.Parse(delovi[1]);
            int dan = int.Parse(delovi[0]);
            int godina = int.Parse(delovi[2]);
            DateTime dt1 = new DateTime(godina, dan, mesec, 0, 0, 0);
            DateTime dt2 = DateTime.Now;
            if (dt1.Date < dt2.Date)
            {
                MessageBox.Show("Date has to be in the future.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

           // Console.WriteLine(date2.ToString());
            string d2 = date2.ToString();
            string[] niz2 = d2.Split(' ');
            date = Date;
            string d=date.ToString();
            string[] niz = d.Split(' ');
            String[] deloviNiz = niz[0].Split('/');
            String mesecNiz = deloviNiz[0];
            String danNiz = deloviNiz[1];
            String godinaNiz = deloviNiz[2];
            StringBuilder builder = new StringBuilder();
           
            if(danNiz.Equals("1") || danNiz.Equals("2") || danNiz.Equals("3") || danNiz.Equals("4") || danNiz.Equals("5") || danNiz.Equals("6") ||
                danNiz.Equals("7") || danNiz.Equals("8") || danNiz.Equals("9"))
            {
                danNiz = "0" + danNiz;
            }
            if (mesecNiz.Equals("1") || mesecNiz.Equals("2") || mesecNiz.Equals("3") || mesecNiz.Equals("4") || mesecNiz.Equals("5") || mesecNiz.Equals("6") ||
               mesecNiz.Equals("7") || mesecNiz.Equals("8") || mesecNiz.Equals("9"))
            {
                mesecNiz = "0" + mesecNiz;
            }
            builder.Append(danNiz);
            builder.Append("/");
            builder.Append(mesecNiz);
            builder.Append("/");
            builder.Append(godinaNiz);
            String prosledjivanje = builder.ToString();

            id = getNextid();
            start = Start.Text;
            end = End.Text;

            Boolean isTimeInGoodFormat = SchDontr.isTimeInGoodFormat(start, end);
            if(isTimeInGoodFormat==false)
            {
                MessageBox.Show("Time must be in format 00:00. Maximum value for time is 23:59", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (Yes.IsChecked == true)
            {
                yes = true;
            }

            shift = new Shift(start, end);

           
          
            Lista l = (Lista)Employe.SelectedValue;
          
            if ( l == null )
            {


                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            employee = l.Name.ToString();

            string[] idEmployee = employee.Split(' ');

            
            lista = DoctorContr.GetAll();
            listaS = SecretaryContr.GetAll();
           
            




            if (niz[0] == null || start == "" || end == "" )
            {


                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            foreach (DoctorUser ee in lista)
            {

                if ((ee.id.ToString()).Equals(idEmployee[0]) && (ee.firstName).Equals(idEmployee[1]) && (ee.secondName).Equals(idEmployee[2]))
                {

                    doktor = ee;


                   



                    Schedule novo = new Schedule(id, doktor.id.ToString(),prosledjivanje, yes, doktor.firstName,doktor.secondName, shift, doktor.ordination);
                  
                    SchDontr.New(novo);

                }
            }


            foreach (SecretaryUser ee in listaS)
            {

                if ((ee.id.ToString()).Equals(idEmployee[0]) && (ee.firstName).Equals(idEmployee[1]) && (ee.secondName).Equals(idEmployee[2]))
                {

                    secretary = ee;
                    Schedule novo = new Schedule(id, secretary.id.ToString(), prosledjivanje, yes, secretary.firstName, secretary.secondName, shift, secretary.room);

                    SchDontr.New(novo);
                }
            }
            GridMain.Children.Clear();
            UserControl usc = new ScheduleClass();
            GridMain.Children.Add(usc);

        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new ScheduleClass();
            GridMain.Children.Add(usc);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
