

using Class_diagram.Contoller;
using Class_diagram.Model.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for EditRenovation.xaml
    /// </summary>
    public partial class EditRenovation : UserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public EditRenovation()
        {
            InitializeComponent();



        }

        Room r = new Room();


        public EditRenovation(Room room)
        {
            InitializeComponent();
            r = room;
            Class_diagram.Contoller.RenovationController EqContr = new Class_diagram.Contoller.RenovationController();

            List<Renovation> lista = new List<Renovation>();
            lista = EqContr.GetAll();

            foreach (Renovation renov in lista)
            {
              
                if (renov.room.Equals(room.typeOfRoom))
                {
                   
                   textBox.Text = renov.startDate.ToString();
                    textBox_Copy.Text = renov.endDate;

                }
            }
        }

       private String date;
        public String Date
        {
            get
            {
                return date;
            }
            set
            {
                if (value != date)
                {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

    

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "" || textBox_Copy.Text == "")
            {


                MessageBox.Show("Please, add start and end date!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Class_diagram.Contoller.RenovationController EqContr = new Class_diagram.Contoller.RenovationController();

            List<Renovation> lista = new List<Renovation>();
            lista = EqContr.GetAll();

            foreach (Renovation renov in lista)
            {
                if (renov.room.Equals(r.typeOfRoom))
                {

                    Renovation med = new Renovation(renov.id, renov.room, textBox.Text, textBox_Copy.Text);
                    EqContr.Update(med);
                }
            }









            GridMain.Children.Clear();
            UserControl usc = new RoomClass(r);
            GridMain.Children.Add(usc);


          

        }

        private void Cancel(object sender, RoutedEventArgs e)
        {

            Class_diagram.Contoller.RenovationController EqContr = new Class_diagram.Contoller.RenovationController();
            RoomController rc = new RoomController();

            


            List<Renovation> lista = new List<Renovation>();
            lista = EqContr.GetAll();

            foreach (Renovation renov in lista)
            {
                if (renov.room.Equals(r.typeOfRoom))
                {
                    r.forUse = true;
                    rc.Update(r);
                    EqContr.Remove(renov);
                }
            }



            GridMain.Children.Clear();
            UserControl usc = new RoomClass(r);
            GridMain.Children.Add(usc);
        }
    }
}
