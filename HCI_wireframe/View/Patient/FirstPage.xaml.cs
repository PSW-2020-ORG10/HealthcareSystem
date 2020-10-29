using HCI_wireframe.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Class_diagram.Model.Patient;
using HCI_wireframe.View.Patient;

namespace HCI_wireframe
{
    /// <summary>
    /// Interaction logic for FirstPage.xaml
    /// </summary>
    public partial class FirstPage : UserControl
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            accountButton.Focus();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.LeftCtrl)
            {
                if (accountButton.IsFocused)
                {
                    appointmentsButton.Focus();
                }
                else if (appointmentsButton.IsFocused)
                {
                    makeApButton.Focus();
                }
                else if (makeApButton.IsFocused)
                {
                    historyButton.Focus();
                }
                else if (historyButton.IsFocused)
                {
                    weekButton.Focus();
                }
                else if (weekButton.IsFocused)
                {
                    emergencyButton.Focus();
                }
                else if (emergencyButton.IsFocused)
                {
                    notificationButton.Focus();
                }
                else if (notificationButton.IsFocused)
                {
                    questionButton.Focus();
                }
                else if (questionButton.IsFocused)
                {
                    questionarieButton.Focus();
                }
                else if (questionarieButton.IsFocused)
                {
                    helpButton.Focus();
                }
                else if (helpButton.IsFocused)
                {
                    settingsButton.Focus();
                }
                else if (settingsButton.IsFocused)
                {
                    logOutButton.Focus();
                }

            }
            
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.RightCtrl)
            {

                if (appointmentsButton.IsFocused)
                {
                    accountButton.Focus();
                }
                else if (makeApButton.IsFocused)
                {
                    appointmentsButton.Focus();
                }
                else if (historyButton.IsFocused)
                {
                    makeApButton.Focus();
                }
                else if (weekButton.IsFocused)
                {
                    historyButton.Focus();
                }
                else if (emergencyButton.IsFocused)
                {
                    weekButton.Focus();
                }
                else if (notificationButton.IsFocused)
                {
                    emergencyButton.Focus();
                }
                else if (questionButton.IsFocused)
                {
                    notificationButton.Focus();
                }
                else if (questionarieButton.IsFocused)
                {
                    questionButton.Focus();
                }
                else if (helpButton.IsFocused)
                {
                    questionarieButton.Focus();
                }
                else if (settingsButton.IsFocused)
                {
                    helpButton.Focus();
                }
                else if (logOutButton.IsFocused)
                {
                    settingsButton.Focus();
                }
            }

            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.O)
            {
                        File_Name.Focus();
                 
            }


            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.Q)
            {
                var s = new AccountSettings();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.W)
            {
                var s = new Settings();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
          
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.K)
            {
                var s = new Help();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.A)
            {
                var s = new AskAQuestion();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.F)
            {
                var s = new FillInAQuestionarie();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D)
            {
                string sMessageBoxText = "Are you sure you want to log out?";
                string sCaption = "Log out";

                MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
                MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

                switch (rsltMessageBox)
                {
                    case MessageBoxResult.Yes:
                        var s = new PatientMainWindow();
                        s.Show();
                        break;

                    case MessageBoxResult.No:

                        break;

                    case MessageBoxResult.Cancel:

                        break;
                }
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.Z)
            {

                var s = new MyAppointments();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);

            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.X)
            {
                var s = new MedicalHistory();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.L)
            {
                var s = new MedicalTherapyOnAWeeklyBasis();
                s.Show();
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.V)
            {
                var s = new EmergencyPhoneNumbers();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.N)
            {
                var s = new Notification();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.M)
            {
                var s = new MakeAnAppointment();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);

            }

        }

        private void accountButton_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ToolTip tt = (ToolTip)(sender as Control).ToolTip;
            //Places the Tooltip under the control rather than at the mouse position
            tt.PlacementTarget = (UIElement)sender;
            tt.Placement = PlacementMode.Right;
            tt.PlacementRectangle = new Rect(0, (sender as Control).Height, 0, 0);
            //Shows tooltip if KeyboardFocus is within.
            tt.IsOpen = (sender as Control).IsKeyboardFocusWithin;
        }

        private void accountButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new AccountSettings();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }

        private void appointmentsButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new MyAppointments();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }

        private void makeApButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new MakeAnAppointment();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }

        private void historyButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new MedicalHistory();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }

        private void weekButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new MedicalTherapyOnAWeeklyBasis();
            s.Show();
        }

        private void emergencyButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new EmergencyPhoneNumbers();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }

        private void notificationButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new Notification();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }

        private void questionButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new AskAQuestion();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }

        private void questionarieButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new FillInAQuestionarie();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new Help();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }

        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new Settings();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            string sMessageBoxText = "Are you sure you want to log out?";
            string sCaption = "Log out";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    var s = new PatientMainWindow();

                    s.Show();


                    break;

                case MessageBoxResult.No:

                    break;

                case MessageBoxResult.Cancel:

                    break;
            }
        }
    }
}
