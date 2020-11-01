using Class_diagram.Contoller;
using Class_diagram.Model.Hospital;
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
using WpfApp2.MedicineFolder;

namespace WpfApp2.MedicineFolder
{
    /// <summary>
    /// Interaction logic for DeclinedMedicine.xaml
    /// </summary>
    public partial class DeclinedMedicine : UserControl
    {
       
        MedicineController MedContr = new MedicineController();
        List<Medicine> lista = new List<Medicine>();
        public ObservableCollection<Medicine> Medicine
        {
            get;
            set;
        }
        

        public DeclinedMedicine()
        {
            InitializeComponent();


            Medicine = new ObservableCollection<Medicine>();



            lista = MedContr.GetAll();
            //List<Schedule> sobe = new List<Schedule>();



            foreach (Medicine ee in lista)
            {
                if (!ee.isConfirmed)
                {
                    Medicine.Add(new Medicine { id = ee.id, name = ee.name, quantity = ee.quantity });
                }



            }



            dataGridStudenti.ItemsSource = Medicine;
        }

      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new ListOfMedicine();
            GridMain.Children.Add(usc);
        }

     

        private void Add_new_room(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_medicine(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Medicine s = (Medicine)dataGridStudenti.Items.GetItemAt(dataGridStudenti.SelectedIndex);

            lista = MedContr.GetAll();
            Medicine = new ObservableCollection<Medicine>();

            foreach (Medicine ee in lista)
            {

                if (s.id == ee.id)
                {

                    MedContr.Remove(ee);
                }
               
            }
            List<Medicine> listaa = new List<Medicine>();
            listaa = MedContr.GetAll();
            foreach (Medicine ee in listaa)
            {

               
                if (!ee.isConfirmed)
                {
                    Medicine.Add(new Medicine { id = ee.id, name = ee.name, quantity = ee.quantity });
                }
            }



            dataGridStudenti.ItemsSource = Medicine;
        }
    }
}
