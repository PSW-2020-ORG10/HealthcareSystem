using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using Class_diagram.Contoller;
using HCI_wireframe.Model.Doctor;
using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using System.Text.RegularExpressions;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
namespace ProjekatHCI
{
    /// <summary>
    /// Interaction logic for IzvestajLekara.xaml
    /// </summary>
    public partial class IzvestajLekara : UserControl, INotifyPropertyChanged
    {

        private string datumod;
        private string datumdo;
        public IzvestajLekara()
        {
            InitializeComponent();
            this.DataContext = this;

            DoctorController DoctorContr = new DoctorController();
            List<DoctorUser> lista = new List<DoctorUser>();
            lista = DoctorContr.GetAll();
            List<DoctorUser> doktori = new List<DoctorUser>();
            //dataGridEquipment.DataContext = lista;

            foreach (DoctorUser ee in lista)
            {
                doktori.Add(new DoctorUser { id = ee.id, firstName = ee.firstName, secondName = ee.secondName, uniqueCitizensidentityNumber = ee.uniqueCitizensidentityNumber, dateOfBirth = ee.dateOfBirth, phoneNumber = ee.phoneNumber, email = ee.email, password = ee.password });



            }
            foreach (DoctorUser lekar in doktori)
            {
                ListaLekara.Items.Add(lekar.firstName + " " + lekar.secondName + " " + "(" + lekar.speciality + ")" + lekar.email);

            }

            ListaLekara.SelectedIndex = 0;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }


        private void ListaLekara_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selektovano = ListaLekara.SelectedItem.ToString();
                string[] tokens = selektovano.Split(' ');
                string email = tokens[3];
                string ordinacija = tokens[4];


                emailLekara.Text = email;

                setButtonVisibility();
            }
            catch (Exception ex)
            {
                emailLekara.Text = "";

                setButtonVisibility();

            }
        }

        public String DatumOD
        {
            get { return datumod; }
            set
            {
                if (value != datumod)
                {
                    datumod = value;
                    OnPropertyChanged("DatumOD");
                }
            }
        }
        public String DatumDO
        {
            get { return datumdo; }
            set
            {
                if (value != datumdo)
                {
                    datumdo = value;
                    OnPropertyChanged("DatumDO");
                }
            }
        }
        public void Generisi_click(object sender, RoutedEventArgs e)
        {
          /*  using (PdfDocument document = new PdfDocument())
            {
                //Add a page to the document
                PdfPage page = document.Pages.Add();

                //Create PDF graphics for a page
                PdfGraphics graphics = page.Graphics;

                //Set the standard font
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                String textPDF = getText();
                //Draw the text
                graphics.DrawString(textPDF, font, PdfBrushes.Black, new PointF(0, 0));

                //Save the document
                document.Save("output8.pdf");


            }
            System.Diagnostics.Process.Start(@"output8.pdf");*/

        }

        private String getText()
        {
            String b = bingPathToAppDir(@"JsonFiles\appointments.json");
            StringBuilder sb = new StringBuilder();
            DoctorController doctorController = new DoctorController();
            List<DoctorUser> doktori = doctorController.GetAll();
            DoctorUser trazenidoktor = new DoctorUser();
            List<DoctorAppointment> appointmentList = new List<DoctorAppointment>();
            AppointmentRepository epr = new AppointmentRepository(b);

            appointmentList = epr.GetAll();


            foreach (DoctorUser r in doktori)
            {
                if (r.email.Equals(emailLekara.Text.ToString()))
                {
                    trazenidoktor = r;

                }
            }
            sb.Append("Izvestaj o zauzetosti " + ListaLekara.Text.ToString().Split(' ')[0] + " " + ListaLekara.Text.ToString().Split(' ')[1] + "\n " +
                " za  vremenski period od:  " + "" + datumOD.Text.ToString() + "\n do: " + datumDO.Text.ToString() + " \n\n");
            int broj = 0;
            foreach (DoctorAppointment d in appointmentList)
            {
                if (d.doctor.email.ToString().Equals(emailLekara.Text.ToString())) 
                {

                    String datum = d.date;
                    String[] delovi = datum.Split('/');
                    int mesec = int.Parse(delovi[1]);
                    int dan = int.Parse(delovi[0]);
                    int godina = int.Parse(delovi[2]);

                    DateTime datumPregleda = new DateTime(godina, mesec, dan, 0, 0, 0);

                    String unetDatum = datumOD.Text;
                    String[] delovi2 = unetDatum.Split('/');
                    int mesec2 = int.Parse(delovi2[1]);
                    int dan2 = int.Parse(delovi2[0]);
                    int godina2 = int.Parse(delovi2[2]);

                    DateTime pocetnidatum = new DateTime(godina2, mesec2, dan2, 0, 0, 0);

                    String unetDatum2 = datumDO.Text;
                    String[] delovi3 = unetDatum2.Split('/');
                    int mesec3 = int.Parse(delovi3[1]);
                    int dan3 = int.Parse(delovi3[0]);
                    int godina3 = int.Parse(delovi3[2]);

                    DateTime krajnjidatum = new DateTime(godina3, mesec3, dan3, 0, 0, 0);

                    if (pocetnidatum < krajnjidatum)
                    {
                        if (datumPregleda < krajnjidatum && datumPregleda > pocetnidatum)
                        {

                            sb.Append("Datum pregleda: " + d.date + "\n");
                            sb.Append("Pregled zakazan za pacijenta: " + d.patient.firstName + " " + d.patient.secondName + "\n");
                            sb.Append("Vreme u koje je pregled zakazan: " + d.time.ToString() + "\n");
                            sb.Append("Prostorija u kojoj je pregled zakazan: " + d.roomid + "\n");
                            sb.Append("*******************************************************************");

                        }
                    }




                }


                broj++;



            }
            return sb.ToString();
        }

        public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
                System.IO.Path.GetFullPath(System.IO.Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }

        public void Odustani_Click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new PocetnaStranica();
            Panel.Children.Add(usc);
        }
        public void Pomoc_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ovde mozete obaviti genrerisanje izvestaja." +
                "\n Odaberite vremenski period za koji zelite da prikazate izvestaj koristeci ponudjeni 'date picker'." +
                "\n Klikinite na dugme 'GENERISI' da biste preuzeli pdf fajl sa izvestajem.");
        }
        private void setButtonVisibility()
        {
            if (Regex.Match(datumDO.Text, @"^\d{2}/\d{2}/\d{4}$").Success && Regex.Match(datumOD.Text, @"^\d{2}/\d{2}/\d{4}$").Success &&
                datumDO.Text.ToString() != "" && datumOD.Text.ToString() != "" && ListaLekara.SelectedItem.ToString() != "")

            {

                generisi.IsEnabled = true;


            }



            else
            {
                generisi.IsEnabled = false;



            }

        }
        private void datumDO_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }
        private void DatumOD_TextChanged(object sender, TextChangedEventArgs e)
        {
            setButtonVisibility();
        }
    }
}
