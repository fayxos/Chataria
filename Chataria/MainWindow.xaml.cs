using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Diagnostics;
using System.Windows.Media;
using Chataria.Core;

namespace Chataria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ToggleButton[] buttons = new ToggleButton[5];

        public static ApplicationViewModel ApplicationViewModel => new(); // ApplicationViewModel

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new WindowViewModel(this);
            // TODO: Go to Person Page
            button.IsChecked = true;
            buttons[0] = button;
            buttons[1] = button1;
            buttons[2] = button2;
            buttons[3] = button3;
            buttons[4] = button4;
        }

        private void Person_Button(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as ToggleButton).IsChecked)
            {
                IoC.Application.ChangeMainContent(MainContent.Person, IoC.Application.CurrentPageViewModel);
                button1.IsChecked = false;
                button2.IsChecked = false;
                button3.IsChecked = false;
                button4.IsChecked = false;
            }
            else
            {
                bool enabled = false;
                foreach (ToggleButton actual_button in buttons)
                {
                    if ((bool)(actual_button).IsChecked)
                    {
                        enabled = true;
                    }
                }
                if (enabled != true)
                {
                    button.IsChecked = true;
                }
            }
        }

        private void Group_Button(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as ToggleButton).IsChecked)
            {
                IoC.Get<ApplicationViewModel>().ChangeMainContent(MainContent.Group);
                button.IsChecked = false;
                button2.IsChecked = false;
                button3.IsChecked = false;
                button4.IsChecked = false;
            }
            else
            {
                bool enabled = false;
                foreach (ToggleButton actual_button in buttons)
                {
                    if ((bool)(actual_button).IsChecked)
                    {
                        enabled = true;
                    }
                }
                if (enabled != true)
                {
                    button1.IsChecked = true;
                }
            }
        }

        private void Globus_Button(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as ToggleButton).IsChecked)
            {
                IoC.Get<ApplicationViewModel>().ChangeMainContent(MainContent.Globe);
                button.IsChecked = false;
                button1.IsChecked = false;
                button3.IsChecked = false;
                button4.IsChecked = false;
            }
            else
            {
                bool enabled = false;
                foreach (ToggleButton actual_button in buttons)
                {
                    if ((bool)(actual_button).IsChecked)
                    {
                        enabled = true;
                    }
                }
                if (enabled != true)
                {
                    button2.IsChecked = true;
                }
            }
        }

        private void User_Button(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as ToggleButton).IsChecked)
            {
                IoC.Get<ApplicationViewModel>().ChangeMainContent(MainContent.Profile);
                button.IsChecked = false;
                button1.IsChecked = false;
                button2.IsChecked = false;
                button4.IsChecked = false;
            }
            else
            {
                bool enabled = false;
                foreach (ToggleButton actual_button in buttons)
                {
                    if ((bool)(actual_button).IsChecked)
                    {
                        enabled = true;
                    }
                }
                if (enabled != true)
                {
                    button3.IsChecked = true;
                }
            }
        }

        private void Settings_Button(object sender, RoutedEventArgs e)
        {
            if ((bool)(sender as ToggleButton).IsChecked)
            {
                IoC.Get<ApplicationViewModel>().ChangeMainContent(MainContent.Settings);
                button.IsChecked = false;
                button1.IsChecked = false;
                button2.IsChecked = false;
                button3.IsChecked = false;
            }
            else
            {
                bool enabled = false;
                foreach (ToggleButton actual_button in buttons)
                {
                    if ((bool)(actual_button).IsChecked)
                    {
                        enabled = true;
                    }
                }
                if (enabled != true)
                {
                    button4.IsChecked = true;
                }
            }
        }

        private void Info_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                string urlEncoded = @"https://www.youtube.com/watch?v=ZOD4prdydcI";
                var builder = new UriBuilder(urlEncoded);
                Process.Start(builder.ToString());
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("There was an Error! Can't open website.");
            }
        }

        private void AppWindow_Deactivated(object sender, EventArgs e)
        {
            // Show overlay if we lose focus
            (DataContext as WindowViewModel).DimmableOverlayVisible = true;
        }

        private void AppWindow_Activated(object sender, EventArgs e)
        {
            // Hide overlay if we are focused
            (DataContext as WindowViewModel).DimmableOverlayVisible = false;
        }
    }
}
