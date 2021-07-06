using Chataria.Core;
using System.Security;

namespace Chataria
{
    /// <summary>
    /// Interaktionslogik für LoginPage.xaml
    /// </summary>
    public partial class SettingsPage : BasePage<LoginViewModel>
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SettingsPage()
        {
            InitializeComponent();

            // Set data context to profile view model
            DataContext = IoC.Profile;
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        public SettingsPage(LoginViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();

            // Set data context to profile view model
            DataContext = IoC.Profile;
        }

        #endregion
    }
}
