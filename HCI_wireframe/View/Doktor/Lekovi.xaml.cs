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
using Class_diagram.Model.Hospital;


using System.ComponentModel;
using System.Drawing;


namespace Klinika
{
    /// <summary>
    /// Interaction logic for Lekovi.xaml
    /// </summary>
   
    public partial class Lekovi : UserControl
    {
        private string datumRodjenja;
        public ObservableCollection<Medicine> ListaLekari
        {
            get;
            set;
        }
        public string DatumRodjenja
        {
            get { return datumRodjenja; }
            set
            {
                if (datumRodjenja != value)
                {
                    datumRodjenja = value;
                    OnPropertyChanged("DatumRodjenja");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));



            }
        }

        List<Medicine> doktori = new List<Medicine>();
        public Lekovi()
        {

            InitializeComponent();
            this.DataContext = this;
            List<Medicine> lista = new List<Medicine>();

            MedicineController DoctorContr = new MedicineController();

            lista = DoctorContr.GetAll();

            //dataGridEquipment.DataContext = lista;

            foreach (Medicine ee in lista)
            {
                doktori.Add(new Medicine { name = ee.name, quantity = ee.quantity, room = ee.room});



            }



            dataGriLekovi.ItemsSource = doktori;




        }


        List<Medicine> filterModeLisst = new List<Medicine>();


      
        private void Pretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            filterModeLisst.Clear();

            if (Pretraga.Text.Equals(""))
            {
                filterModeLisst.AddRange(doktori);
            }
            else
            {
                foreach (Medicine anim in doktori)
                {

                    if (anim.name.ToUpper().Contains(Pretraga.Text.ToUpper()))
                    {
                        filterModeLisst.Add(anim);
                    }
                }
            }

            dataGriLekovi.ItemsSource = filterModeLisst.ToList();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
          /*  StringBuilder sb = new StringBuilder();
            MedicineController mContr = new MedicineController();
            List<Medicine> pacijenti = mContr.GetAll();

            String datumPocetka = datePicker.Text;
            String[] delovi = datumPocetka.Split('/');
            int mesec = int.Parse(delovi[1]);
            int dan = int.Parse(delovi[0]);
            int godina = int.Parse(delovi[2]);

            String datumKraja = datePicker1.Text;
            String[] delovi1 = datumKraja.Split('/');
            int mesec1 = int.Parse(delovi1[1]);
            int dan1 = int.Parse(delovi1[0]);
            int godina1 = int.Parse(delovi1[2]);

            DateTime doKad = new DateTime(godina1, mesec1, dan1, 0, 0, 0);
            DateTime odKad = new DateTime(godina, mesec, dan, 0, 0, 0);
            
            double razlika = (doKad.Date - odKad.Date).Days;
            foreach (Medicine m in pacijenti)
            {
                sb.Append("Lek:     " + m.Name + "\n");
                sb.Append("Potrosnja u unetom preiodu     " + m.dnevnaPotrosnja * razlika + "\n");
                
                sb.Append("\n ----------------------------------------- \n");

            }
            String upis = sb.ToString();
            String pdfText = upis;

            using (PdfDocument document = new PdfDocument())
            {
                //Add a page to the document
                PdfPage page = document.Pages.Add();

                //Create PDF graphics for a page
                PdfGraphics graphics = page.Graphics;

                //Set the standard font
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

                //Draw the text
                
                graphics.DrawString(pdfText, font, PdfBrushes.Black, new PointF(0, 0));
                //String b = bingPathToAppDir(@"JsonFiles\output.pdf");
                //Save the document
                document.Save("output4.pdf");


            }
            System.Diagnostics.Process.Start(@"output4.pdf");
*/
        }
        
       
    }
}

