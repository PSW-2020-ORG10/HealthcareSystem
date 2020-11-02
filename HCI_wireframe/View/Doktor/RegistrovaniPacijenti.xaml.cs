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
using Class_diagram.Model.Patient;
using HCI_wireframe.Contoller;

namespace Klinika
{
    /// <summary>
    /// Interaction logic for RegistrovaniPacijenti.xaml
    /// </summary>
    public partial class RegistrovaniPacijenti : UserControl
    {
       
        public ObservableCollection<PatientUser> ListaLekari
    {
        get;
        set;
    }

    List<PatientUser> pac = new List<PatientUser>();
    public RegistrovaniPacijenti()
    {

        InitializeComponent();
        this.DataContext = this;
        List<PatientUser> lista = new List<PatientUser>();

        PatientController cont = new PatientController();

        lista = cont.GetAll();

        //dataGridEquipment.DataContext = lista;

        foreach (PatientUser ee in lista)
        {
            pac.Add(new PatientUser { id = ee.id, firstName = ee.firstName, secondName = ee.secondName, uniqueCitizensidentityNumber = ee.uniqueCitizensidentityNumber, dateOfBirth = ee.dateOfBirth, phoneNumber = ee.phoneNumber });




        }



            dataGriRegPacijenti.ItemsSource = pac;




    }


    
    List<PatientUser> filterModeLisst = new List<PatientUser>();


    private void Pretraga_TextChanged(object sender, TextChangedEventArgs e)
    {
        filterModeLisst.Clear();

        if (Pretraga.Text.Equals(""))
        {
            filterModeLisst.AddRange(pac);
        }
        else
        {
            foreach (PatientUser anim in pac)
            {

                if (anim.firstName.ToUpper().Contains(Pretraga.Text.ToUpper()) || anim.secondName.ToUpper().Contains(Pretraga.Text.ToUpper()))
                {
                    filterModeLisst.Add(anim);
                }
            }
        }

            dataGriRegPacijenti.ItemsSource = filterModeLisst.ToList();
    }
}
}

