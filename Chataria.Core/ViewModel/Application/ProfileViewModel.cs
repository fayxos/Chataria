using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using Chataria;

namespace Chataria.Core
{

    public class ProfileViewModel : BaseViewModel
    {
        #region Singleton

        public static ProfileViewModel Instance => new();

        #endregion

        #region Public Properties


        /// <summary>
        /// The current users bio
        /// </summary>
        public string Bio { get; set; }

        /// <summary>
        /// The current users name
        /// </summary>
        public TextEntryViewModel Name { get; set; }

        /// <summary>
        /// The current users username
        /// </summary>
        public TextEntryViewModel Username { get; set; }

        /// <summary>
        /// The current users email
        /// </summary>
        public TextEntryViewModel Email { get; set; }

        /// <summary>
        /// The current users password
        /// </summary>
        public PasswordEntryViewModel Password { get; set; }

        /// <summary>
        /// Text for the logout button
        /// </summary>
        public string LogoutButtonText { get; set; }
        

        #endregion

        #region Commands

        /// <summary>
        /// The command to edit the profile
        /// </summary>
        public ICommand EditProfileCommand { get; set; }

        /// <summary>
        /// The command to close the profile menu
        /// </summary>
        public ICommand CloseEditProfileMenuCommand { get; set; }

        /// <summary>
        /// The command to logout the application
        /// </summary>
        public ICommand LogoutCommand { get; set; }

        /// <summary>
        /// The command to clear the users data from the view model
        /// </summary>
        public ICommand ClearUserDataCommand { get; set; }

        /// <summary>
        /// Loads the settings data from the client data store
        /// </summary>
        public ICommand LoadCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProfileViewModel()
        {
            // Create commands
            EditProfileCommand = new RelayCommand(EditProfile);
            CloseEditProfileMenuCommand = new RelayCommand(CloseEditProfileMenu);
            LogoutCommand = new RelayCommand(Logout);
            ClearUserDataCommand = new RelayCommand(ClearUserData);
            LoadCommand = new RelayCommand(async () => await LoadAsync());

            

            // TODO: Get from localization
            LogoutButtonText = "Logout";
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// When the attachment button is clicked show/hide the attachment pop-up
        /// </summary>
        public void EditProfile()
        {
            IoC.Application.EditProfileMenuVisible = true;
        }


        public void CloseEditProfileMenu()
        {
            IoC.Application.EditProfileMenuVisible = false;
        }

        /// <summary>
        /// Logs the user out
        /// </summary>
        public void Logout()
        {
            // TODO: Confirm the user wants to logout

            // TODO: Clear any user data/cache

            // Clean all application level view models that contain
            // any information about the current user
            ClearUserData();

            // Go to login page
            IoC.Application.GoToPage(ApplicationPage.Login);
        }

        /// <summary>
        /// Clears any data specific to the current user
        /// </summary>
        public void ClearUserData()
        {
            // Clear all view models containing user info
            Username = null;
            Name = null;
            Email = null;
            Password = null;
        }


        /// <summary>
        /// Sets the settings view model properties based on the data in the client data store
        /// </summary>
        public async Task LoadAsync()
        {
            // Get the stored credentials
            var storedCredentials = await IoC.ClientDataStore.GetLoginCredentialsAsync();

            Name = new TextEntryViewModel { Label = "Name", OriginalText = $"{storedCredentials?.FirstName} {storedCredentials?.LastName}" };
            Username = new TextEntryViewModel { Label = "Username", OriginalText = $"{storedCredentials?.Username}" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = $"{storedCredentials?.Email}" };
            Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
        }

        #endregion
    }
}
