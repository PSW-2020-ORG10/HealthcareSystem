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
using HCI_wireframe.View.Sekretar;

namespace ProjekatHCI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowSekretar : Window
    {
        public MainWindowSekretar()
        {
        
            InitializeComponent();
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "Zakazivanje":
                    var s = new ZakazivanjePregleda();
                    Panel.Children.Clear();
                    Panel.Children.Add(s);
                    break;
                case "Registracija":
                    var r = new RegistracijaPacijenata();
                    Panel.Children.Clear();
                    Panel.Children.Add(r);
                    break;
                case "Lekari":
                    var l = new Lekari();
                    Panel.Children.Clear();
                    Panel.Children.Add(l);
                    break;
                case "RegistrovaniPacijenti":
                    var p = new RegistrovaniPacijenti();
                    Panel.Children.Clear();
                    Panel.Children.Add(p);
                    break;
                case "GuestPacijenti":
                    var g = new GuestPacijenti();
                    Panel.Children.Clear();
                    Panel.Children.Add(g);
                    break;
                case "PopunjeniTermini":
                    var t = new PopunjeniTermini();
                    Panel.Children.Clear();
                    Panel.Children.Add(t);
                    break;
                case "PodeliUtiske":
                    var u = new Utisak();
                    Panel.Children.Clear();
                    Panel.Children.Add(u);
                    break;
                case "ZauzetostLekara":
                    var i = new IzvestajLekara();
                    Panel.Children.Clear();
                    Panel.Children.Add(i);
                    break;

                default:
                    break;
            }
        }

        private void Grafik_Click(object sender, RoutedEventArgs e)
        {
            var s = new GrafickiPrikaz();
            Panel.Children.Clear();
            Panel.Children.Add(s);

        }

        private void Pocetna_Click(object sender, RoutedEventArgs e)
        {
            var s = new PocetnaStranica();
            Panel.Children.Clear();
            Panel.Children.Add(s);
        }


        private void MojiPodaci_Click(object sender, RoutedEventArgs e)
        {
            var s = new MojiPodaci();
            Panel.Children.Clear();
            Panel.Children.Add(s);

        }
        private void IzmeniPodatke_Click(object sender, RoutedEventArgs e)
        {
            var s = new IzmenaPodataka();
            Panel.Children.Clear();
            Panel.Children.Add(s);

        }
        private void Odjava_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Da li ste sigurni da želite da se odjavite?", "Odjava", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Login login = new Login();
                    this.Close();
                    login.Show();
                    break;
                case MessageBoxResult.No:
                    this.Show();
                    break;

            }



        }

        private void RasporedSala_Click(object sender, RoutedEventArgs e)
        {
            var s = new RasporedSala();
            Panel.Children.Clear();
            Panel.Children.Add(s);

        }
        private void RasporedLekara_Click(object sender, RoutedEventArgs e)
        {
            var s = new RasporedLekara();
            Panel.Children.Clear();
            Panel.Children.Add(s);
        }


    }
}
