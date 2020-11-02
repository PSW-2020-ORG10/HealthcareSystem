using Class_diagram.Contoller;
using Class_diagram.Model.Employee;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp2.View.Manager.ScheduleFolder
{
    /// <summary>
    /// Interaction logic for ScheduleClass.xaml
    /// </summary>
    public partial class ScheduleClass : UserControl
    {
       
   
        public ObservableCollection<Schedule> Schedule
        {
            get;
            set;
        }

        public DatePicker datum;
        EmployeesScheduleController SchDontr = new EmployeesScheduleController();
        List<Schedule> Schlista = new List<Schedule>();

        public ScheduleClass()
        {
            InitializeComponent();
            this.DataContext = this;
            Schedule = new ObservableCollection<Schedule>();

           
           
            Schlista = SchDontr.GetAll();
            //List<Schedule> sobe = new List<Schedule>();
           
        

            foreach (Schedule ee in Schlista)
            {

                Schedule.Add(new Schedule { id=ee.id, employeeid = ee.employeeid, date =ee.date,isOnDuty=ee.isOnDuty, employeeFirst=ee.employeeFirst,employeeLast=ee.employeeLast,shift=ee.shift,room =ee.room });


               

            }






        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            UserControl usc = new AddToSchedule();
            GridMain.Children.Add(usc);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGridStudenti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGridStudenti_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void DatePicker_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
  
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            datum = DatePicker;

            
            string d = datum.ToString();

            if (d=="")
            {
                return;
            }

            string[] niz = d.Split(' ');
            

            String[] deloviNiz = niz[0].Split('/');
            String mesecNiz = deloviNiz[0];
            String danNiz = deloviNiz[1];
            String godinaNiz = deloviNiz[2];
            StringBuilder builder = new StringBuilder();

            if (danNiz.Equals("1") || danNiz.Equals("2") || danNiz.Equals("3") || danNiz.Equals("4") || danNiz.Equals("5") || danNiz.Equals("6") ||
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


            Schlista = SchDontr.GetAll();
            Schedule = new ObservableCollection<Schedule>();




            foreach (Schedule ee in Schlista)
            {
                if (ee.date.Equals(builder.ToString()))
                {
                   
                    Schedule.Add(new Schedule { id = ee.id, employeeid = ee.employeeid, date = ee.date, isOnDuty = ee.isOnDuty, employeeFirst = ee.employeeFirst, employeeLast = ee.employeeLast, shift = ee.shift, room = ee.room });
                   
                }


            }


            dataGridStudenti.ItemsSource = Schedule;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Schedule s=(Schedule)dataGridStudenti.Items.GetItemAt(dataGridStudenti.SelectedIndex);

            Schlista = SchDontr.GetAll();
            Schedule = new ObservableCollection<Schedule>();

            foreach (Schedule ee in Schlista)
            {

                if (s.id == ee.id)
                {


                    SchDontr.Remove(ee);

                }
                else
                {
                    Schedule.Add(new Schedule { id = ee.id, employeeid = ee.employeeid, date = ee.date, isOnDuty = ee.isOnDuty,  employeeFirst = ee.employeeFirst, employeeLast = ee.employeeLast, shift = ee.shift, room = ee.room });
                }
            }

       


            dataGridStudenti.ItemsSource = Schedule;
        }
    }
}
