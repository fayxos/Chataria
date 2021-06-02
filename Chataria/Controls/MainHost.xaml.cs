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

        /// <summary>
        /// The current page to show in the page host
        /// </summary>
        public MainContent CurrentMainContent
        {
            get => (MainContent)GetValue(CurrentMainContentProperty);
            set => SetValue(CurrentMainContentProperty, value);
        }

        /// <summary>
        /// Registers <see cref="CurrentMainContent"/> as a Dependency Property
        /// </summary>
        public static readonly DependencyProperty CurrentMainContentProperty =
            DependencyProperty.Register(nameof(CurrentMainContent), typeof(MainContent), typeof(MainHost), new UIPropertyMetadata(default(MainContent), null, CurrentMainContentPropertyChanged));




        /// <summary>
        /// The current page to show in the page host
        /// </summary>
        public BaseViewModel CurrentPageViewModel
        {
            get => (BaseViewModel)GetValue(CurrentPageViewModelProperty);
            set => SetValue(CurrentPageViewModelProperty, value);
        }

        /// <summary>
        /// Registers <see cref="CurrentPageViewModel"/> as a Dependency Property
        /// </summary>
        public static readonly DependencyProperty CurrentPageViewModelProperty =
            DependencyProperty.Register(nameof(CurrentPageViewModel), typeof(BaseViewModel), typeof(MainHost), new UIPropertyMetadata());

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
            if (DesignerProperties.GetIsInDesignMode(this))
                MainContent.Content = IoC.Application.CurrentMainContent.ToBasePageMain();

        }

        #endregion


        #region Property Changed Events

        /// <summary>
        /// Called when the <see cref="CurrentMainPage"/> value has Changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static object CurrentMainContentPropertyChanged(DependencyObject d, object value)
        {
            // Get current values
            var currentMainPage = (MainContent)d.GetValue(CurrentMainContentProperty);
            var currentPageViewModel = d.GetValue(CurrentPageViewModelProperty);

            // Get the frames
            var PageFrame = (d as MainHost).MainContent;

            // If the current page hasn't changed
            // Just update the view model
            if (PageFrame.Content is BasePageMain page &&
                page.ToMainContent() == currentMainPage) 
            {
                // Just update the view model
                page.ViewModelObject = currentPageViewModel;

                return value;
            }

            

            PageFrame.Content = currentMainPage.ToBasePageMain(currentPageViewModel);

            return value;
        }

        #endregion
    }
}
