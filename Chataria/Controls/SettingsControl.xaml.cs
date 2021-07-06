using Chataria.Core;
using System.Windows.Controls;

namespace Chataria
{
    /// <summary>
    /// Interaction logic for EditProfile.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();

            // Set data context to profile view model
            DataContext = IoC.Profile;
        }
    }
}
