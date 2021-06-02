using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using Chataria;

namespace Chataria.Core
{

    public class LoginViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The commant to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The commant to register
        /// </summary>
        public ICommand RegisterCommand { get; set; }


        #endregion

        #region Constructor

        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
        }

        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/>passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
        {
            await RunCommand(() => LoginIsRunning, async () =>
            {
                // TODO: Fake login...
                await Task.Delay(1000);

                // Ok succesfully logged in... now get users data
                // TODO: Ask server for users info


                // TODO: Remove this with real information pulled from our database in future
                IoC.Profile.Username = new TextEntryViewModel { Label = "Username", OriginalText = $"Fayxos {DateTime.Now.ToLocalTime()}" };
                IoC.Profile.Name = new TextEntryViewModel { Label = "Name", OriginalText = "Felix Haag" };
                IoC.Profile.Email = new TextEntryViewModel { Label = "Email", OriginalText = "Email@ermail.de" };
                IoC.Profile.Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
                IoC.Profile.PostCount = 1;
                IoC.Profile.FollowerCount = 200;
                IoC.Profile.FollowingCount = 100;
                IoC.Profile.FriendCount = 20;

                // Go to chat page
                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Main);

                //var email = Email;

                //// IMPORTANT: Never store unsecure password in variable like this
                //var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });
        }

        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/>passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task RegisterAsync()
        {
            // TODO: Go to register page
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register);

            await Task.Delay(1);
        }
    }
}
