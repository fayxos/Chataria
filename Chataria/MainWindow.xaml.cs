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
        public static ApplicationViewModel ApplicationViewModel => new(); // ApplicationViewModel

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new WindowViewModel(this);
        }
    }
}
