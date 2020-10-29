using HCI_wireframe.View.Patient;
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

namespace HCI_wireframe
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl 
    {
        public static bool notificationsEnabled = false;
        public bool _isToolTipVisible = true;
        public Settings()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            YES_tooltip.Focus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.H)
            {
                MessageBox.Show(
                    "- Use LEFT and RIGHT CTRL to move withind buttons.\n" +
                    "- Use CTRL + O to select menu bar - FILE.\n" +
                    "- Use ENTER to select the button.\n" +
                  
                    "- Use ENTER/SPACE to close this message.\n", "HELP");
            }
          
          
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.LeftCtrl)
            {
               
                 if (YES_tooltip.IsFocused)
                {
                    NO_tooltip.Focus();
                }
                else if (NO_tooltip.IsFocused)
                {
                    editButton.Focus();
                }
                else if (editButton.IsFocused)
                {
                    backButton.Focus();
                }
                else if (helpButton.IsFocused)
                {
                    YES_tooltip.Focus();
                }
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.RightCtrl)
            {
              
              
                if (NO_tooltip.IsFocused)
                {
                    YES_tooltip.Focus();
                }
                else if (editButton.IsFocused)
                {
                    NO_tooltip.Focus();
                }
                else if (backButton.IsFocused)
                {
                    editButton.Focus();
                }
                else if (YES_tooltip.IsFocused)
                {
                    helpButton.Focus();
                }
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.O)
            {

                File_Name.Focus();

            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.Q )
            {
                var s = new AccountSettings();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.W )
            {
                var s = new Settings();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }

            
          
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.K )
            {
                var s = new Help();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.A )
            {
                var s = new AskAQuestion();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.F )
            {
                var s = new FillInAQuestionarie();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D )
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
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.L )
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
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.N )
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

        private void editButton_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ToolTip tt = (ToolTip)(sender as Control).ToolTip;
            //Places the Tooltip under the control rather than at the mouse position
            tt.PlacementTarget = (UIElement)sender;
            tt.Placement = PlacementMode.Right;
            tt.PlacementRectangle = new Rect(0, (sender as Control).Height, 0, 0);
            //Shows tooltip if KeyboardFocus is within.
            tt.IsOpen = (sender as Control).IsKeyboardFocusWithin;
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

        private void helpButton_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ToolTip tt = (ToolTip)(sender as Control).ToolTip;
            //Places the Tooltip under the control rather than at the mouse position
            tt.PlacementTarget = (UIElement)sender;
            tt.Placement = PlacementMode.Right;
            tt.PlacementRectangle = new Rect(0, (sender as Control).Height, 0, 0);
            //Shows tooltip if KeyboardFocus is within.
            tt.IsOpen = (sender as Control).IsKeyboardFocusWithin;

        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                   "- Use LEFT and RIGHT CTRL to move withind buttons.\n" +
                   "- Use CTRL + O to select menu bar - FILE.\n" +
                   "- Use ENTER to select the button.\n" +

                   "- Use ENTER/SPACE to close this message.\n", "HELP");
        }

        private void YES_tooltip_Click(object sender, RoutedEventArgs e)
        {
            this._isToolTipVisible = true;

            Style style = new Style(typeof(ToolTip));
            style.Setters.Add(new Setter(UIElement.VisibilityProperty, Visibility.Collapsed));
            style.Seal();

            foreach (Window window in Application.Current.Windows)
            {

                window.Resources.Remove(typeof(ToolTip)); //show
                _isToolTipVisible = true;

            }
        }

        private void NO_tooltip_Click(object sender, RoutedEventArgs e)
        {
            string sMessageBoxText = "Are you sure you want to disable tooltips?";
            string sCaption = "Tooltips";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    this._isToolTipVisible = false;

                    Style style = new Style(typeof(ToolTip));
                    style.Setters.Add(new Setter(UIElement.VisibilityProperty, Visibility.Collapsed));
                    style.Seal();

                    foreach (Window window in Application.Current.Windows)
                    {
                        window.Resources.Add(typeof(ToolTip), style); //hide
                        _isToolTipVisible = false;

                    }
                    break;

                case MessageBoxResult.No:

                    break;

                case MessageBoxResult.Cancel:

                    break;
            }
           
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new EditAccount();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new FirstPage();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }
    }
}
