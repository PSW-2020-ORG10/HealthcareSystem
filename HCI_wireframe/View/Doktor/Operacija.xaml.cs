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
using Class_diagram.Contoller;
using Class_diagram.Model.Doctor;
using Class_diagram.Model.Patient;
using HCI_wireframe.Model.Doctor;

namespace HCI_wireframe.View.Doktor
{
    /// <summary>
    /// Interaction logic for Operacija.xaml
    /// </summary>
    public partial class Operacija : UserControl
    {
        string prijavljen = App.Current.Properties["DoctorEmail"].ToString();
        Operation o = new Operation();
        public Operacija()
        {
            InitializeComponent();
            PatientController patientController = new PatientController();
            OperationController op = new OperationController();
            List<Operation> d = new List<Operation>();
            d = op.GetAll();
            List<PatientUser> lista1 = new List<PatientUser>();
            lista1 = patientController.GetAll();
            List<PatientUser> pacijenti = new List<PatientUser>();
            //dataGridEquipment.DataContext = lista;

            foreach (PatientUser ee in lista1)
            {
                pacijenti.Add(new PatientUser { id = ee.id, firstName = ee.firstName, secondName = ee.secondName, uniqueCitizensidentityNumber = ee.uniqueCitizensidentityNumber, dateOfBirth = ee.dateOfBirth, phoneNumber = ee.phoneNumber, medicalIdNumber = ee.medicalIdNumber });
            }
            foreach (PatientUser regP in pacijenti)
            {
                ListaPacijenata.Items.Add(regP.firstName + " " + regP.secondName + " " + regP.medicalIdNumber);



            }
            List<Operation> operacije = new List<Operation>();
            foreach (Operation ee in d)
            {
                String datum = ee.date;
                String[] delovi = datum.Split('/');
                int mesec = int.Parse(delovi[1]);
                int dan = int.Parse(delovi[0]);
                int godina = int.Parse(delovi[2]);

                DateTime dt1 = new DateTime(godina, mesec, dan, 0, 0, 0);

                DateTime dt2 = DateTime.Now;
                if (dt1.Date < dt2.Date)
                {
                    operacije.Add(new Operation { id = ee.id, patient = ee.patient});
                }
            }

            foreach (Operation preg in operacije)
            {
                combo.Items.Add(preg.id + " " + preg.patient.firstName + " " + preg.patient.secondName + " ");

            }

        }




        private void posalji_Click(object sender, RoutedEventArgs e)
        {
            PatientController patientRepo = new PatientController();
            List<PatientUser> patientLista = patientRepo.GetAll();
            PatientUser ovajPacijent = new PatientUser();
            String dijagnoza = oper.Text;
      
            DoctorUser ovaj = new DoctorUser();

            Random rnd = new Random();
            int broj = rnd.Next(1, 9000);
            DoctorController dc = new DoctorController();
            List<DoctorUser> lista = dc.GetAll();
            foreach (DoctorUser s in lista)
            {
                if (s.email.Equals(prijavljen))
                {
                    ovaj = s;

                }
            }
            OperationController sve = new OperationController();
            TimeSpan interval = new TimeSpan(12, 30, 00);
            List<Operation> sviPregledi = new List<Operation>();
            sviPregledi = sve.GetAll();
            Referral rf = new Referral(1, "", "", 0, "Operisan", dijagnoza);
            List<Referral> li = new List<Referral>();
       

            Operation zaUpdate = new Operation();

            String kombo = (String)combo.SelectedValue;



            String[] novi = kombo.Split(' ');

            String neki = novi[0];


            foreach (Operation doc in sviPregledi)
            {
                if (neki.Equals(doc.id.ToString()))
                {
                    zaUpdate = doc;
                }
            }

            Referral nalazi = new Referral();

            nalazi = zaUpdate.operationReferral;
            if (nalazi == null)
            {

                nalazi = new Referral();
            }

            nalazi = rf;
            OperationController ap = new OperationController();

            
            zaUpdate.operationReferral = nalazi;
      
            ap.Update(null, zaUpdate);





        }
    }
}
