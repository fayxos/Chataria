using Chataria.Core;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Chataria
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class SideMenuHost : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// The current page to show in the page host
        /// </summary>
        public UserControl CurrentSideMenuContent
        {
            get => (UserControl)GetValue(CurrentSideMenuContentProperty);
            set => SetValue(CurrentSideMenuContentProperty, value);
        }

        /// <summary>
        /// Registers <see cref="CurrentSideMenuContent"/> as a Dependency Property
        /// </summary>
        public static readonly DependencyProperty CurrentSideMenuContentProperty =
            DependencyProperty.Register(nameof(CurrentSideMenuContent), typeof(UserControl), typeof(SideMenuHost), new UIPropertyMetadata(CurrentSideMenuContentPropertyChanged));

        /// <summary>
        /// The current page to show in the page host
        /// </summary>
        public BaseViewModel CurrentSideMenuContentViewModel
        {
            get => (BaseViewModel)GetValue(CurrentSideMenuContentViewModelProperty);
            set => SetValue(CurrentSideMenuContentViewModelProperty, value);
        }

        /// <summary>
        /// Registers <see cref="CurrentSideMenuContentViewModel"/> as a Dependency Property
        /// </summary>
        public static readonly DependencyProperty CurrentSideMenuContentViewModelProperty =
            DependencyProperty.Register(nameof(CurrentSideMenuContentViewModel), typeof(BaseViewModel), typeof(SideMenuHost), new UIPropertyMetadata());

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SideMenuHost()
        {
            InitializeComponent();

            // If we are in design mode, show thew current page
            // as the dependency property does not fire 
            if (DesignerProperties.GetIsInDesignMode(this))
                Frame.Content = new ChatListControl();
            
        }

        #endregion

        #region Property Changed Events

        /// <summary>
        /// Called when the <see cref="CurrentSideMenuContent"/> value has Changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void CurrentSideMenuContentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Get the frames
            var frame = (d as SideMenuHost).Frame;

            // If page did not change, return
            if (e.NewValue == frame.Content)
                return;

            // Set the new page content
            frame.Content = e.NewValue;
        }

        #endregion
    }
}
