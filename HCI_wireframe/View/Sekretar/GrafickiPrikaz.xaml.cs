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
//using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.Primitives;
//using System.Windows.Controls.DataVisualization.Charting;
using Class_diagram.Model.Patient;
using Class_diagram.Contoller;
using Class_diagram.Repository;
using System.IO;
using Path = System.IO.Path;

namespace HCI_wireframe.View.Sekretar
{
    /// <summary>
    /// Interaction logic for GrafickiPrikaz.xaml
    /// </summary>
    public partial class GrafickiPrikaz : UserControl
    {
        /* public List<DoctorAppointment> AppointmentList { get; set; }
         public GrafickiPrikaz()
         {
             InitializeComponent();
             this.DataContext = this;
             LoadColumnChartData();
         }
         private void LoadColumnChartData()
         {
             String b = bingPathToAppDir(@"JsonFiles\appointments.json");



             AppointmentList = new List<DoctorAppointment>();

             AppointmentRepository epr = new AppointmentRepository(b);
             if (epr != null)
             {
                 AppointmentList = epr.GetAll();

             }



             int prvi = 0;
             int drugi = 0;
             int treci = 0;
             int cetvrti = 0;
             int peti = 0;

             foreach(DoctorAppointment ap in AppointmentList)
             {
                 if(ap.Date.ToString().Equals("17/06/2020"))
                 {
                     prvi++;
                 }else if (ap.Date.ToString().Equals("18/06/2020"))
                 {
                     drugi++;
                 }else if (ap.Date.ToString().Equals("19/06/2020"))
                 {
                     treci++;
                 }else if (ap.Date.ToString().Equals("20/06/2020"))
                 {
                     cetvrti++;
                 }else if (ap.Date.ToString().Equals("21/06/2020"))
                 {
                     peti++;
                 }
             }

            ((ColumnSeries)mcChart.Series[0]).ItemsSource =
                 new KeyValuePair<string, int>[]{

             new KeyValuePair<string, int>("17/06/2020", prvi),
             new KeyValuePair<string, int>("18/06/2020", drugi),
             new KeyValuePair<string, int>("19/06/2020", treci),
             new KeyValuePair<string, int>("20/06/2020", cetvrti),
              new KeyValuePair<string, int>("21/06/2020", peti) };
         }
         public static string bingPathToAppDir(string localPath)
         {
             string currentDir = Environment.CurrentDirectory;
             DirectoryInfo directory = new DirectoryInfo(
                 Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath)));
             return directory.ToString();
         }
     }*/
    }
}