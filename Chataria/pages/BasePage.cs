﻿using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows;
using Chataria.Core;
using System.ComponentModel;

namespace Chataria
{
    /// <summary>
    /// The base page for all pages to gain functionality
    /// </summary>
    public class BasePage : UserControl
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

                // Set the dataContext for this page
                DataContext = mViewModel;
            }
        }

        /// <summary>
        /// The animation the play when the page is first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRigth;

        /// <summary>
        /// The animation the play when the page is funloaded loaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// The time any slide animation takes to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;

        /// <summary>
        /// A flag to indicate if this page should aniamte out on load 
        /// Useful for when moving the page to another frame
        /// </summary>
        public bool ShouldAnimateOut { get; set; }

        #endregion

        #region Constructor

        public BasePage()
        {
            // Don't border animating in design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            // If we are animating in, hide to begin with
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;


            // Listen out for the page loading
            Loaded += BasePage_LoadedAsync;
        }

        #endregion

        #region Animation Load / Unload

        /// <summary>
        /// Once the page is loaded, perform any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_LoadedAsync(object sender, RoutedEventArgs e)
        {

            // If we are stup to animate out on load
            if (ShouldAnimateOut)
                // Animate the page in
                await AnimateOutAsync();
            // Otherwise
            else
                // Animate the page in
                await AnimateInAsync();
        }

        /// <summary>
        /// Animates the page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateInAsync()
        {
            // Make sure we have something to do
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRigth:
                    // Start the animation
                    await this.SlideAndFadeInAsync(AnimationSlideInDirection.Right, false, SlideSeconds, size: (int)Application.Current.MainWindow.Width);

                    break;
            }
        }

        /// <summary>
        /// Animates the Page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOutAsync()
        {
            // Make sure we have something to do
            if (PageUnloadAnimation == PageAnimation.None)
                return;

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    // Start the animation
                    await this.SlideAndFadeOutAsync(AnimationSlideInDirection.Left, SlideSeconds, size: (int)Application.Current.MainWindow.Width - 350);

                    break;
            }
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
    /// A base page with added ViewModel suport
    /// </summary>
    public class BasePage<VM> : BasePage
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
        public BasePage() : base()
        {
            // Create a default view model
            ViewModel = IoC.Get<VM>();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        /// <param name="specificViewModel">The specific viewModel to use if any</param>
        public BasePage(VM specificViewModel = null) : base()
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
