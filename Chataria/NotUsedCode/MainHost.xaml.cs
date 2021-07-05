using Chataria.Core;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Chataria
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainHost : UserControl
    {
        #region Dependency Properties


        

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainHost()
        {
            InitializeComponent();

            // If we are in designmade, show thew current page
            // as the dependency property does not fire 
            //if (DesignerProperties.GetIsInDesignMode(this))
                //MainContent.Content = IoC.Application.CurrentMainContent.ToBasePageMain();

        }

        #endregion

        #region Property Changed Events

        

        #endregion
    }
}
