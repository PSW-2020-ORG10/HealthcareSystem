using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Drawing;
using Class_diagram.Model.Patient;
using Class_diagram.Model.Doctor;
using System.Text.RegularExpressions;

using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.ComponentModel;
using System.Drawing;

using Class_diagram.Contoller;

namespace HCI_wireframe
{
    /// <summary>
    /// Interaction logic for MedicalTherapyOnAWeeklyBasis.xaml
    /// </summary>
    public partial class MedicalTherapyOnAWeeklyBasis : Window
    {
        string myProperty = App.Current.Properties["Patientid"].ToString();
        PatientUser ovajPacijent = new PatientUser();
        public List<DoctorAppointment> AppointmentList { get; set; }
        public List<DoctorAppointment> AppointmentListAll { get; set; }
        public MedicalTherapyOnAWeeklyBasis()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Date_TextBox.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.B)
            {
                this.Close();
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.H)
            {
                MessageBox.Show(
                    "- Use CTRL + B to return to the first page.\n" +
                    "- Use LEFT CTRL and RIGHT CTRL to move within fields.\n" +
                    "- Use ENTER/SPACE to close this message.", "HELP");
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.LeftCtrl)
            {
                if (helpButton.IsFocused)
                {
                    Date_TextBox.Focus();
                }
               else if (Date_TextBox.IsFocused)
                {
                    pdfButton.Focus();
                }
               else if (pdfButton.IsFocused)
                {
                    backButton.Focus();
                }

            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.RightCtrl)
            {
                if (Date_TextBox.IsFocused)
                {
                    helpButton.Focus();
                }
                else if (pdfButton.IsFocused)
                {
                    Date_TextBox.Focus();
                }
                else if (backButton.IsFocused)
                {
                    pdfButton.Focus();
                }

            }
          

        }

        private void backButton_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ToolTip tt = (ToolTip)(sender as Control).ToolTip;
            //Places the Tooltip under the control rather than at the mouse position
            tt.PlacementTarget = (UIElement)sender;
            tt.Placement = PlacementMode.Right;
            tt.PlacementRectangle = new Rect(0, (sender as Control).Height, 0, 0);
            //Shows tooltip if KeyboardFocus is within.
            tt.IsOpen = (sender as Control).IsKeyboardFocusWithin;
        }
       

        private String getText()
        {
            StringBuilder sb = new StringBuilder();
            PatientController patientController = new PatientController();
            List<PatientUser> pacijenti = patientController.GetAll();
            AppointmentList = new List<DoctorAppointment>();
            AppointmentListAll =new List<DoctorAppointment>();
            AppointmentController appointmentController = new AppointmentController();
            AppointmentListAll = appointmentController.GetAll();
            ovajPacijent = patientController.GetByid(int.Parse(myProperty));
            foreach (DoctorAppointment doctorApp in AppointmentListAll)
            {
                PatientUser idPacijent = doctorApp.patient;
                if (idPacijent.id == ovajPacijent.id)
                {
                    AppointmentList.Add(doctorApp);
                }
            }

            sb.Append("Therapy report for the week that begins with the day\n  " + "" + Date_TextBox.Text+" \n\n");
             if (AppointmentList == null)
            {
                
            }
            else
            {
                foreach (DoctorAppointment d in AppointmentList)
                {

                    String datum = d.date;
                    String[] delovi = datum.Split('/');
                    int mesec = int.Parse(delovi[1]);
                    int dan = int.Parse(delovi[0]);
                    int godina = int.Parse(delovi[2]);

                    DateTime dPregled = new DateTime(godina, mesec, dan, 0, 0, 0);

                    String unetDatum = Date_TextBox.Text;
                    String[] delovi2 = unetDatum.Split('/');
                    int mesec2 = int.Parse(delovi2[1]);
                    int dan2 = int.Parse(delovi2[0]);
                    int godina2 = int.Parse(delovi2[2]);

                    DateTime dUnet = new DateTime(godina2, mesec2, dan2, 0, 0, 0);

                    List<Referral> rfLista = d.referral;
                    if (rfLista != null)
                    {
                        foreach (Referral r in rfLista)
                        {

                            String doKad2 = r.takeMedicineUntil;
                            String[] delovi3 = doKad2.Split('/');
                            int mesec3 = int.Parse(delovi3[1]);
                            int dan3 = int.Parse(delovi3[0]);
                            int godina3 = int.Parse(delovi3[2]);

                            DateTime doKad = new DateTime(godina3, mesec3, dan3, 0, 0, 0);
                            int kolicina = r.quantityPerDay;


                            if (dUnet.Date < doKad.Date)
                            {
                                if (dPregled.Date < dUnet.Date)

                                {
                                    double razlika = (doKad.Date - dUnet.Date).Days;
                                    sb.Append("Medicine:     " + r.medicine + "\n");
                                    sb.Append("Daily quantity:     " + r.quantityPerDay + "\n");
                                    sb.Append("Tako medicine another      " + razlika + "     days");
                                    sb.Append("\n ************************************ \n");
                                }

                            }

                        }

                    }
                }
            }

            return sb.ToString();
        }

        private void pdfButton_Click(object sender, RoutedEventArgs e)
    {       if (Date_TextBox.Text.Equals("") )
            {
                MessageBox.Show("You must enter a date!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
             else if (!Regex.Match(Date_TextBox.Text, @"^([0-9]{2}/[0-9]{2}/[0-9]{4})$").Success) {

                MessageBox.Show("You must enter a valid date format!\n\n dd/mm/yyyy", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
               /* using (PdfDocument document = new PdfDocument())
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
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                    "- Use CTRL + B to return to the first page.\n" +
                    "- Use LEFT CTRL and RIGHT CTRL to move within fields.\n" +
                    "- Use ENTER/SPACE to close this message.", "HELP");
        }
    }
}
