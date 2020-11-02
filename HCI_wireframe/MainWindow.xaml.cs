
using Class_diagram.Model.Hospital;
using Class_diagram.Repository;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HCI_wireframe.Properties;
using System.IO;
using Path = System.IO.Path;


using HCI_wireframe.Model.Doctor;
using HCI_wireframe.View.Patient;
using HCI_wireframe.View.Manager;
using Class_diagram.Contoller;
using Class_diagram.Model.Employee;
using Class_diagram.Model.Patient;
using Class_diagram.Model.Doctor;
using ProjekatHCI;
using Klinika;

namespace HCI_wireframe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
        }

        public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }

        private void Patient_Click(object sender, RoutedEventArgs e)
        {

          
            var s = new PatientMainWindow();
           s.Show();

        }

        private void Doctor_Click(object sender, RoutedEventArgs e)
        {
            var s = new GlavnidoktorProzor();
            s.Show();

        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
           String b = bingPathToAppDir(@"JsonFiles\equipment.json");
            String p = bingPathToAppDir(@"JsonFiles\room.json");


        


           var s = new MainWindowManager();
           s.Show();
        }

        private void Secretary_Click(object sender, RoutedEventArgs e)
        {
            var s = new Login();
            s.Show();
        }
    }
}
