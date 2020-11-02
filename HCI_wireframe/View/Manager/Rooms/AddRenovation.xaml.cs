using Class_diagram.Contoller;
using Class_diagram.Model.Hospital;
using HCI_wireframe.Model.Doctor;
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

namespace WpfApp2.Rooms
{
    /// <summary>
    /// Interaction logic for AddRenovation.xaml
    /// </summary>
    public partial class AddRenovation : UserControl
    {
        public AddRenovation()
        {
            InitializeComponent();
        }
        Room r = new Room();
        public DatePicker start;
        public DatePicker end;

        public AddRenovation(Room room)
        {
            InitializeComponent();
            r = room;
            start = StartDate;
            end = EndDate;
            
        }
        private int getNextid()
        {
            RenovationController rp = new RenovationController();
            List<Renovation> lista = rp.GetAll();
            int number = 0;
            foreach (Renovation r in lista)
            {
                if (r.id > number)
                {
                    number = r.id;
                }
            }
            number += 1;
            return number;
        }
        private void Submit(object sender, RoutedEventArgs e)
        {
            if (StartDate.ToString() == "" || EndDate.ToString() == "")
            {


                MessageBox.Show("Please, choose start and end date!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            String datum = StartDate.ToString();
            String[] deo = datum.Split(' ');
            String[] delovi = deo[0].Split('/');
            Console.WriteLine(delovi[0] + delovi[1]);
            int mesec = int.Parse(delovi[1]);
            int dan = int.Parse(delovi[0]);
            int godina = int.Parse(delovi[2]);
            DateTime dt1 = new DateTime(godina, dan, mesec, 0, 0, 0);
            DateTime dt2 = DateTime.Now;
            if (dt1.Date < dt2.Date)
            {
                MessageBox.Show("Start date has to be in the future.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            String datum1 = EndDate.ToString();
            String[] deo1 = datum1.Split(' ');
            String[] delovi1 = deo1[0].Split('/');
            int mesec1 = int.Parse(delovi1[1]);
            int dan1 = int.Parse(delovi1[0]);
            int godina1 = int.Parse(delovi1[2]);
            DateTime dt11 = new DateTime(godina1, dan1, mesec1, 0, 0, 0);
            DateTime dt21 = DateTime.Now;
            if (dt11.Date < dt21.Date)
            {
                MessageBox.Show("End date has to be in the future.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            string d = start.ToString();
            string[] niz = d.Split(' ');
            string ee = end.ToString();
            string[] nize = ee.Split(' ');

            int id = getNextid();

            if(niz[0]=="" || nize[0] == "")
            {


                MessageBox.Show("Please, choose start and end date!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Renovation med = new Renovation(id,r.typeOfRoom, niz[0],nize[0]);

            RenovationController EqContr = new RenovationController();

            List<Renovation> lista = new List<Renovation>();
            lista = EqContr.GetAll();

            EqContr.New(med);

            Room ro = new Room(r.id,r.typeOfRoom,r.equipment,r.medicine, false);
            RoomController rC = new RoomController();
            rC.Update(ro);

            

            DoctorController DocContr = new DoctorController();

            List<DoctorUser> listad = new List<DoctorUser>();
            listad = DocContr.GetAll();

            foreach(DoctorUser doc in listad)
            {
                if (doc.ordination.Equals(r.typeOfRoom))
                {

                    MessageBox.Show("Please change ordination of doctor " + doc.firstName + " " + doc.secondName + " because of renovation.", "Notification", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }
            }

            GridMain.Children.Clear();
            UserControl usc = new RoomClass(r);
            GridMain.Children.Add(usc);


        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new RoomClass(r);
            GridMain.Children.Add(usc);
        }

        
    }
}
