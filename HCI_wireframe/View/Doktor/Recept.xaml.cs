using System;
using System.Collections.Generic;
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
using Path = System.IO.Path;

namespace Klinika
{
    /// <summary>
    /// Interaction logic for Recept.xaml
    /// </summary>
    public partial class Recept : UserControl
    {
        public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }
        public Recept()
        {
            InitializeComponent();
            String d = bingPathToAppDir(@"JsonFiles\osobe.json");
            
            List<PatientUser> lista1 = new List<PatientUser>();
            PatientController pc = new PatientController();

            lista1 = pc.GetAll();
            PatientUser ovajPacijent = new PatientUser();
            List<PatientUser> pacijenti = new List<PatientUser>();

            foreach (PatientUser ee in lista1)
            {
                pacijenti.Add(new PatientUser { id = ee.id, firstName = ee.firstName, secondName = ee.secondName, uniqueCitizensidentityNumber = ee.uniqueCitizensidentityNumber, dateOfBirth = ee.dateOfBirth, phoneNumber = ee.phoneNumber, medicalIdNumber = ee.medicalIdNumber });
            }
            foreach (PatientUser regP in pacijenti)
            {
                ListaPacijenata.Items.Add(regP.firstName + " " + regP.secondName + " " + regP.medicalIdNumber);



            }
        }
    }
}
