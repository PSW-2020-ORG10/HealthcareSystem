using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Class_diagram.Model.Doctor;
using Class_diagram.Model.Employee;
using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using HCI_wireframe.Model.Doctor;
using Path = System.IO.Path;

namespace ProjekatHCI
{
    /// <summary>
    /// Interaction logic for RasporedLekara.xaml
    /// </summary>
    public partial class RasporedLekara : UserControl, INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;

       

        public virtual void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }


        List<Schedule> lista = new List<Schedule>();
        public RasporedLekara()
        {

            InitializeComponent();
            this.DataContext = this;
            

            EmployeesScheduleController empContr = new EmployeesScheduleController();

            lista = empContr.GetAll();

            //dataGridEquipment.DataContext = lista;

            /* foreach (Schedule ee in lista)
             {
                rasporedi.Add(new Schedule { id = ee.id });



             }*/



            dataGridRaspored.ItemsSource = lista;





        }
        public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }

        List<Schedule> filterModeLisst = new List<Schedule>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            filterModeLisst.Clear();

            if (datePicker.Text.Equals(""))
            {
                filterModeLisst.AddRange(lista);
            }
            else
            {
                foreach (Schedule anim in lista)
                {

                    if (anim.date == datePicker.Text)
                    {
                        filterModeLisst.Add(anim);
                    }
                }
            }

            dataGridRaspored.ItemsSource = filterModeLisst.ToList();


        }
    

            private void pretragaText_TextChanged(object sender, TextChangedEventArgs e)
            {

            filterModeLisst.Clear();

            if (pretragaText.Text.Equals(""))
            {
                filterModeLisst.AddRange(lista);
            }
            else
            {
                foreach (Schedule anim in lista)
                {

                    if (anim.employeeFirst.ToLower().StartsWith(pretragaText.Text.ToLower()) || anim.employeeLast.ToLower().StartsWith(pretragaText.Text.ToLower()) || anim.employeeid.ToString() == pretragaText.Text || anim.room.ToLower().Equals(pretragaText.Text.ToLower()))
                    {
                        filterModeLisst.Add(anim);
                    }
                }
            }

            dataGridRaspored.ItemsSource = filterModeLisst.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        /*  private void setButtonVisibility()
 {
     if ( datePicker.Text != String.Empty  && Regex.Match(datePicker.Text, @"^\d{2}/\d{2}/\d{4}$").Success)

     {

         trazi.IsEnabled = true;


     }



     else
     {

         trazi.IsEnabled = false;



     }

 }

 private void datePicker_TextChanged(object sender, TextChangedEventArgs e)
 {
     setButtonVisibility(); 
 }*/
    }
    }
          