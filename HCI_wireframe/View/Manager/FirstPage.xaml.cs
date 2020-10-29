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
using WpfApp2.Employees;
using HCI_wireframe.View.Manager;
using WpfApp2.View.Manager.ScheduleFolder;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            
            InitializeComponent();
            GridMain.Children.Clear();
            UserControl usc = new Notifications();
            GridMain.Children.Add(usc);
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

           switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "Employees":
                    usc = new ListOfEmployees();
                    GridMain.Children.Add(usc);
                    break;

                case "Schedule":

                    usc = new ScheduleClass();
                    GridMain.Children.Add(usc);
                    break;

                case "Equipment":

                    usc = new ListOfEquipment();
                    GridMain.Children.Add(usc);
                    break;

                case "Medicines":

                    usc = new ListOfMedicine();
                    GridMain.Children.Add(usc);
                    break;

                case "Rooms":

                    usc = new ListOfRooms();
                    GridMain.Children.Add(usc);
                    break;
                    
                case "Notifications":
                  
                    usc = new Notifications();
                    GridMain.Children.Add(usc);
                    break;

                
                case "ProfileInformation":

                    usc = new MyProfile();
                    GridMain.Children.Add(usc);
                    break;


                case "Help":

                    usc = new Help();
                    GridMain.Children.Add(usc);
                    break;

                case "LogOut":
                    
                    Window us = new MainWindowManager();
                    this.Close();
                    us.Show();
                    break;
                default:
                    break;
            }
        }

        private void List_Of_Employees(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new ListOfEmployees();
            GridMain.Children.Add(usc);
        }

        private void Add_new_employee(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new AddEmployee();
            GridMain.Children.Add(usc);
        }

        private void See_schedule(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new ScheduleClass();
            GridMain.Children.Add(usc);
        }

        private void Add_to_schedule(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new AddToSchedule();
            GridMain.Children.Add(usc);
        }

        private void List_of_medicines(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new ListOfMedicine();
            GridMain.Children.Add(usc);
        }

        private void Add_new_medicine(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new MedicineFolder.AddMedicine();
            GridMain.Children.Add(usc);
        }

        private void List_of_equipment(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new ListOfEquipment();
            GridMain.Children.Add(usc);
        }

        private void Add_new_equipment(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new AddEquipment();
            GridMain.Children.Add(usc);
        }

        private void List_of_rooms(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new ListOfRooms();
            GridMain.Children.Add(usc);
        }

        private void Add_new_room(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new AddRoom();
            GridMain.Children.Add(usc);
        }

        
    }
}
