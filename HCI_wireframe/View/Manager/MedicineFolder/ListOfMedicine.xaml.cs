using Class_diagram.Contoller;
using Class_diagram.Model.Hospital;
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
using WpfApp2.MedicineFolder;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.IO;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for ListOfMedicine.xaml
    /// </summary>
    public partial class ListOfMedicine : UserControl
    {
        List<Lista> li = new List<Lista>();
        MedicineController MedContr = new MedicineController();
        List<Medicine> lista = new List<Medicine>();
        public class Lista
        {

            public string Name { get; set; }

            public string Last { get; set; }



            public Lista()
            {

            }

        }

        public ListOfMedicine()
        {
            InitializeComponent();

            lista = MedContr.GetAll();
            List<Medicine> oprema = new List<Medicine>();


            foreach (Medicine ee in lista)
            {
                if (ee.isConfirmed)
                {
                    li.Add(new Lista { Name = ee.name });
                }
            }
            dataGridEquipment.ItemsSource = li;
        }

        private void Add_new_medicine(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new MedicineFolder.AddMedicine();
            GridMain.Children.Add(usc);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public static string bingPathToAppDir(string localPath)
        {
            string currentDir = Environment.CurrentDirectory;
            DirectoryInfo directory = new DirectoryInfo(
            System.IO.Path.GetFullPath(System.IO.Path.Combine(currentDir, @"..\..\" + localPath)));
            return directory.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*using (PdfDocument document = new PdfDocument())
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
                document.Save("output7.pdf");


            }
            System.Diagnostics.Process.Start(@"output7.pdf");*/



        }


        private String getText()
        {
            StringBuilder sb = new StringBuilder();
            MedicineController medController = new MedicineController();
            List<Medicine> lekovi = medController.GetAll();

           
            sb.Append("                    Current Medicine Quantity Report\n\n\n");


            foreach (Medicine r in lekovi)
            {
                sb.Append("Medicine:     " + r.name + "\n");
                sb.Append("Current quantity:     " + r.quantity + "\n");
               
                sb.Append("\n --------------------------------------------- \n");
            }

            

            return sb.ToString();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            UserControl usc = new MedicineFolder.DeclinedMedicine();
            GridMain.Children.Add(usc);

           
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string name1 = sender.ToString();
            string[] words = name1.Split(':');

            string[] words1 = name1.Split(' ');
            string id = words1[1];


            lista = MedContr.GetAll();



            foreach (Medicine ee in lista)
            {

                if (ee.name.Equals(id))
                {
                    GridMain.Children.Clear();
                    UserControl usc = new MedicineClass(ee);
                    GridMain.Children.Add(usc);


                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            List<Lista> filtered = new List<Lista>();

            foreach (Lista ee in li)
            {

                if (ee.Name.ToLower().Contains(SearchBox.Text.ToLower()))
                {


                    filtered.Add(new Lista { Name = ee.Name });


                }


            }

            dataGridEquipment.ItemsSource = filtered;
            foreach (Lista ee in filtered)
            {
                Console.WriteLine(ee.Name);

            }
        }

    }
}
