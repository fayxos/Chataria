using Chataria;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Chataria.Core
{
    /// <summary>
    /// The application state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// The current Page of the application
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Main;

        /// <summary>
        /// The view model to use for the current page when the current page changes
        /// NOTE: This is not a live up-to-date view model of the current page
        ///       it is simply used to set the view model of the current page
        ///       at the time it changes
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; } = new ChatMessageListViewModel();

        /// <summary>
        /// True if the side menu should be shown
        /// </summary>
        public bool SideMenuVisible { get; set; } = true;

        /// <summary>
        /// True if the edit profile menu should be shown
        /// </summary>
        public bool EditProfileMenuVisible { get; set; } = false;

        /// <summary>
        /// A flag if image should be shown big
        /// </summary>
        public bool ViewImageOverlayVisible { get; set; }

        /// <summary>
        /// The file path for the image to show big 
        /// </summary>
        public string ViewImageLocalPath { get; set; }

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">the page to go to</param>
        /// <param name="viewModel">The view model, if any, to set explicitly to new page</param>
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            // Always hide settings page if we change pages
            EditProfileMenuVisible = false;

            // Set the current page
            CurrentPage = page;

            // Change the view model
            if (viewModel != null)
                CurrentPageViewModel = viewModel;

            // Show side menu or not?
            if (page == ApplicationPage.Login || page == ApplicationPage.Register)
                SideMenuVisible = false;
            else
                SideMenuVisible = true;

            OnPropertyChanged(nameof(CurrentPage));
        }
    }
}
