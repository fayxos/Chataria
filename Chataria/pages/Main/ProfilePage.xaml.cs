using Chataria.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chataria
{
    /// <summary>
    /// Interaktionslogik für ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : BasePageMain<ProfileViewModel>
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ProfilePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        public ProfilePage(ProfileViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion
    }
}
