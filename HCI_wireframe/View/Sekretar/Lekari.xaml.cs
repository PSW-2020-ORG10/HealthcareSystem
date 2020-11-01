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
using Class_diagram.Contoller;
using HCI_wireframe.Model.Doctor;

namespace ProjekatHCI
{
    /// <summary>
    /// Interaction logic for Doctors.xaml
    /// </summary>
    public partial class Lekari : UserControl
    {
       
        public ObservableCollection<DoctorUser> ListaLekari
        {
            get;
            set;
        }
        List<DoctorUser> lista = new List<DoctorUser>();
        public Lekari()
        {

            InitializeComponent();
            this.DataContext = this;
           

            DoctorController DoctorContr = new DoctorController();
            
            lista = DoctorContr.GetAll();
            
            //dataGridEquipment.DataContext = lista;
/*
            foreach (DoctorUser ee in lista)
            {
                doktori.Add(new DoctorUser { id = ee.id, FirstName = ee.FirstName, SecondName = ee.SecondName, UniqueCitizensidentityNumber = ee.UniqueCitizensidentityNumber, DateOfBirth = ee.DateOfBirth, PhoneNumber = ee.PhoneNumber, Email = ee.Email, Password = ee.Password });



            }*/



            dataGridLekari.ItemsSource = lista;




        }


     
        List<DoctorUser> filterModeLisst = new List<DoctorUser>();

      
     
        private void Pretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            filterModeLisst.Clear();

            if (Pretraga.Text.Equals(""))
            {
                filterModeLisst.AddRange(lista);
            }
            else
            {
                foreach (DoctorUser anim in lista)
                {

                    if (anim.firstName.ToUpper().Contains(Pretraga.Text.ToUpper()) || anim.secondName.ToUpper().Contains(Pretraga.Text.ToUpper()))
                    {
                        filterModeLisst.Add(anim);
                    }
                }
            }

            dataGridLekari.ItemsSource = filterModeLisst.ToList();
        }
    }
}

