using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using Class_diagram.Contoller;
using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using HCI_wireframe.Contoller;
using HCI_wireframe.Model.Doctor;
using Path = System.IO.Path;

namespace HCI_wireframe.View.Doktor
{
    /// <summary>
    /// Interaction logic for Karton.xaml
    /// </summary>
    public partial class Karton : UserControl
    {
        public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }

        public class Lista
        {

            public String DoctorName { get; set; }

            public TimeSpan Time { get; set; }

            public String Date { get; set; }
            public int idapp { get; set; }

            public String ChangeName { get; set; }
            public String RemoveName { get; set; }
           

        }
        public List<DoctorAppointment> AppointmentList { get; set; }
        public ObservableCollection<DoctorAppointment> ListaNalazi
        {
            get;
            set;
        }

        List<DoctorAppointment> nalazi = new List<DoctorAppointment>();

        public Karton()
        {

            InitializeComponent();
            this.DataContext = this;


            AppointmentController ap = new AppointmentController();

           
            AppointmentList = ap.GetAll();

            foreach (DoctorAppointment ee in AppointmentList)
            {
                nalazi.Add(new DoctorAppointment { time = ee.time, date = ee.date, patient = ee.patient, doctor = ee.doctor});



            }



            dataGriKarton.ItemsSource = nalazi;




        }
        }
    }


     


       
