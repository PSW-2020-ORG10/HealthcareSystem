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
using System.Windows.Shapes;
using HCI_wireframe.View.Doktor;

namespace Klinika
{
    /// <summary>
    /// Interaction logic for Nalog.xaml
    /// </summary>
    public partial class Nalog : Window , INotifyPropertyChanged 
    {

        public event PropertyChangedEventHandler PropertyChanged;

        TranslationSource ts = new TranslationSource();
        public Nalog()
        {
            InitializeComponent();
            DataContext = this;
        }


        private void Zakazi_click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new ZakazivanjePregleda();
            Panel.Children.Add(usc);
        }


        private void Feedback_click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new Feedback();
            Panel.Children.Add(usc);
        }
        private void Pacijenti_click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new RegistrovaniPacijenti();
            Panel.Children.Add(usc);
        }
        private void Nalaz_click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new Nalaz();
            Panel.Children.Add(usc);
        }
        private void Licni_click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new Doktor();
            Panel.Children.Add(usc);

        }
        private void Lekovi_click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new Lekovi();
            Panel.Children.Add(usc);
        }
        private void Zauzetost_click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new RezervisaniiTermini();
            Panel.Children.Add(usc);
        }

        private void LekoviZ_click(object sender, RoutedEventArgs e)
        {
            Panel.Children.Clear();
            UserControl usc = new LekoviZahtevi();
            Panel.Children.Add(usc);
        }



        private void ObavestenjaPacijenti_click(object sender, RoutedEventArgs e)
        {

            Panel.Children.Clear();
            UserControl usc = new ObavestenjaPacijenata();
            Panel.Children.Add(usc);
        }
        private void Recept_click(object sender, RoutedEventArgs e)
        {

            Panel.Children.Clear();
            UserControl usc = new Operacija();
            Panel.Children.Add(usc);
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Panel.Background.Equals(Brushes.White))
            {
                Panel.Background = Brushes.LightGray;

            }
            else if (Panel.Background.Equals(Brushes.LightGray))
            {
                Panel.Background = Brushes.White;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GlavnidoktorProzor glavni = new GlavnidoktorProzor();
            glavni.Show();
        }

        private void langComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            String language = cb.SelectedItem.ToString();
            String tag = language.Split(' ')[2];
            if (tag.Equals("en-US"))
            {
                TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }
            else
            {
                TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("sr-LATN-CS");
            }

        }
    }
}
