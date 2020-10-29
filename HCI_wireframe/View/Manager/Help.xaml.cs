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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : UserControl
    {
        public Help()
        {
         
            InitializeComponent();
        }
            private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
      {
         //myMediaElement.Volume = (double)volumeSlider.Value;
      }

      // Change the speed of the media.
      private void ChangeMediaSpeedRatio(object sender, RoutedPropertyChangedEventArgs<double> args)
      {
         //myMediaElement.SpeedRatio = (double)speedRatioSlider.Value;
      }

      // When the media opens, initialize the "Seek To" slider maximum value
      // to the total number of miliseconds in the length of the media clip.
      private void Element_MediaOpened(object sender, EventArgs e)
      {
         timelineSlider.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
      }

      // When the media playback is finished. Stop() the media to seek to media start.
      private void Element_MediaEnded(object sender, EventArgs e)
      {
         myMediaElement.Stop();
      }

      // Jump to different parts of the media (seek to).
      private void SeekToMediaPosition(object sender, RoutedPropertyChangedEventArgs<double> args)
      {
         int SliderValue = (int)timelineSlider.Value;

         // Overloaded constructor takes the arguments days, hours, minutes, seconds, milliseconds.
         // Create a TimeSpan with miliseconds equal to the slider value.
         TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
         myMediaElement.Position = ts;
      }

     

        private void Button_Copy_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Play();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            myMediaElement.Pause();
        }

        private void Button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            myMediaElement.Stop();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            GridMain.Children.Clear();
            UserControl usc = new Notifications();
            GridMain.Children.Add(usc);


        }
    }
}

