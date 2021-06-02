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
        /// Number of Posts
        /// </summary>
        public int PostCount { get; set; }

        /// <summary>
        /// Number of Followers
        /// </summary>
        public int FollowerCount { get; set; }

        /// <summary>
        /// Number of Followings
        /// </summary>
        public int FollowingCount { get; set; }

        /// <summary>
        /// Number of Friends
        /// </summary>
        public int FriendCount { get; set; }

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
        /// The command to clear the users data from teh view model
        /// </summary>
        public ICommand ClearUserDataCommand { get; set; }

        /// <summary>
        /// The command to show the posts
        /// </summary>
        public ICommand ShowPostsCommand { get; set; }

        /// <summary>
        /// The commmand to show the followers
        /// </summary>
        public ICommand ShowFollowersCommand { get; set; }

        /// <summary>
        /// The commmand to show the followings
        /// </summary>
        public ICommand ShowFollowingsCommand { get; set; }

        /// <summary>
        /// The commmand to show the friends
        /// </summary>
        public ICommand ShowFriendsCommand { get; set; }

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

            // TODO: Remove this once the real back-edn is ready
            Username = new TextEntryViewModel { Label = "Username", OriginalText = "Fayxos" };
            Name = new TextEntryViewModel { Label = "Name", OriginalText = "Felix Haag" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "Email@ermail.de" };
            Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
            PostCount = 1;
            FollowerCount = 200;
            FollowingCount = 100;
            FriendCount = 20;

            // TODO: Get from localization
            LogoutButtonText = "Logout";
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// When the attachment button is clicked show/hide the attachment popup
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
            FriendCount = 0;
            FollowerCount = 0;
            FollowingCount = 0;
            PostCount = 0;
        }

        #endregion
    }
}
