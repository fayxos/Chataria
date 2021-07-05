using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows;
using Chataria.Core;

namespace Chataria
{
    /// <summary>
    /// A base page for all pages to gain functionality
    /// </summary>
    public class BasePageMain : UserControl
    {
        #region Private Member

        /// <summary>
        /// The view model associated with this page
        /// </summary>
        private object mViewModel;

        #endregion

        #region Public Properties

        /// <summary>
        /// The view model associated with this page
        /// </summary>
        public object ViewModelObject
        {
            get => mViewModel;
            set
            {
                // If nothing has changed, return
                if (mViewModel == value)
                    return;

                // Update the model
                mViewModel = value;

                // Fire the view model changed method
                OnViewModelChanged();

                // Set the dataContext for this page
                DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        public BasePageMain()
        {
            // Listen out for the page loading
            Loaded += BasePageMain_LoadedAsync;
        }

        #endregion

        #region Animation Load / Unload

        /// <summary>
        /// Once the page is loaded, perform any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePageMain_LoadedAsync(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Visible;
        }

        #endregion

        /// <summary>
        /// Fired when the view model changes
        /// </summary>
        protected virtual void OnViewModelChanged()
        {

        }
    }

    /// <summary>
    /// A main base page with added ViewModel suport
    /// </summary>
    public class BasePageMain<VM> : BasePageMain
        where VM : BaseViewModel, new()
    {
        #region Public Properties

        /// <summary>
        /// The view model associated with this page
        /// </summary>
        public VM ViewModel
        {
            get => (VM)ViewModelObject;
            set => ViewModelObject = value;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BasePageMain() : base()
        {
            // Create a default view model
            ViewModel = IoC.Get<VM>();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific viewModel to use if any</param>
        public BasePageMain(VM specificViewModel = null) : base()
        {
            // Set the specific view model
            if (specificViewModel != null)
                ViewModel = specificViewModel;
            else
                // Create a default view model
                ViewModel = IoC.Get<VM>();
        }

        #endregion
    }
}
