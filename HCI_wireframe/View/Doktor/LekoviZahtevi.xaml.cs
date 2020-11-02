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
using Class_diagram.Model.Hospital;
using Class_diagram.Repository;
using HCI_wireframe;
using HCI_wireframe.Contoller;
using HCI_wireframe.Model.Doctor;
using Path = System.IO.Path;

namespace Klinika
{
    /// <summary>
    /// Interaction logic for LekoviZahtevi.xaml
    /// </summary>
    /// 
    public partial class LekoviZahtevi : UserControl

    {
        public string name { get; set; }
        public string quantity;
        public string description;
        public int id;
        public DoctorUser doktor;
        public DoctorUser lekar { get; set; }
       
        string svojstvo = App.Current.Properties["DoctorEmail"].ToString();




        public List<Medicine> Tablete { get; set; }
     
        List<Medicine> lekovi = new List<Medicine>();
       
        public LekoviZahtevi()
        {
            InitializeComponent();
            this.DataContext = this;
        
           

            Tablete = new List<Medicine>();

            RequestMedicineController medC = new RequestMedicineController();


             Tablete = medC.GetAll();
     

             foreach (Medicine ee in Tablete)
             {
                 lekovi.Add(new Medicine { id = ee.id, name = ee.name, quantity = ee.quantity, description = ee.description, room = ee.room }) ;

               
            }


            dataZahtevi.ItemsSource = lekovi;



        }
 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
         

            Medicine s = (Medicine)dataZahtevi.Items.GetItemAt(dataZahtevi.SelectedIndex);



            name = s.name;
            description = s.description;
            DoctorController doctorController = new DoctorController();
            List<DoctorUser> listaDoktora = doctorController.GetAll();
            foreach (DoctorUser d in listaDoktora)
            {
                if (d.email.Equals(svojstvo))
                {
                    lekar = d;

                }
            }


            //Medicine med = new Medicine(s.id, name, s.Quantity, description, s.room, lekar, true);


            bool conf = s.isConfirmed;
            conf = true;
            s.isConfirmed = true;
            s.doctor = lekar;


            RequestMedicineController rq = new RequestMedicineController();
            rq.Remove(s);


            MedicineController  mRepo = new MedicineController();
            
            mRepo.New(s);



          

            
          

            Panel.Children.Clear();
            UserControl usc = new LekoviZahtevi();
            Panel.Children.Add(usc);
        }
        private int getNextid()
        {
            MedicineController rp = new MedicineController();
            List<Medicine> lista = rp.GetAll();
            int number = 0;
            foreach (Medicine r in lista)
            {
                if (r.id > number)
                {
                    number = r.id;
                }
            }
            number += 1;
            return number;
        }

        private void Ne_Click(object sender, RoutedEventArgs e)
        {
           

            Medicine s = (Medicine)dataZahtevi.Items.GetItemAt(dataZahtevi.SelectedIndex);



            name = s.name;
            description = s.description;
            DoctorController doctorController = new DoctorController();
            List<DoctorUser> listaDoktora = doctorController.GetAll();
            foreach (DoctorUser d in listaDoktora)
            {
                if (d.email.Equals(svojstvo))
                {
                    lekar = d;

                }
            }


            // Medicine med = new Medicine(s.id, name, s.Quantity, description, s.room, lekar, false);
            s.isConfirmed = false;
            s.doctor = lekar;
            RequestMedicineController rq = new RequestMedicineController();
            rq.Remove(s);

            MedicineController mRepo = new MedicineController();

            mRepo.New(s);

            Panel.Children.Clear();
            UserControl usc = new LekoviZahtevi();
            Panel.Children.Add(usc);



        }

        public void dataZahtevi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
