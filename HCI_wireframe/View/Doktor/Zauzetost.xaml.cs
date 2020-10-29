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
using HCI_wireframe.View.Doktor;

namespace Klinika
{
    /// <summary>
    /// Interaction logic for Zauzetost.xaml
    /// </summary>
    public partial class Zauzetost : UserControl
    {
        public Zauzetost()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                Panel.Children.Clear();
                UserControl usc = new ZakazivanjePregleda();
                Panel.Children.Add(usc);
           

        }
    }
}
