using System;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using Chataria;
using Dna;

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
                // Call the server and attempt to login with credentials
                // TODO: Moves all URLs and api rotes to static class in core
                var result = await WebRequests.PostAsync<ApiResponse<LoginResultApiModel>>(
                    "http://localhost:5001/api/login", 
                    new LoginCredentialsApiModel
                    {
                        UsernameOrEmail = Email,
                        Password = (parameter as IHavePassword).SecurePassword.Unsecure(),
                    });

                // If there was no response, bad data, or a response with an error message...
                if(result == null || result.ServerResponse == null || !result.ServerResponse.Successful)
                {
                    // Default error message
                    // TODO: Localize strings
                    var message = "Unknown error from server call";

                    // If we got a response from the server...
                    if (result?.ServerResponse != null)
                        // Set message to servers response
                        message = result.ServerResponse.ErrorMessage;
                    // If we have a result but deserialized failed...
                    else if (!string.IsNullOrWhiteSpace(result?.RawServerResponse))
                        // Set error message
                        message = $"Unexpected response from server. {result.RawServerResponse}";
                    // If we have a result but no server response details at all...
                    else if (result != null)
                        //  Set message to standard HTTP server response details
                        message = $"Failed to communicate with server. Status code {result.StatusCode}. {result.StatusDescription}";

                    // Display error
                    await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                    {
                        // TODO: Localize strings
                        Title = "Login Failed",
                        Message = message
                    });

                    // We are done
                    return;
                }

                // Successfully logged in... now get users data
                var userData = result.ServerResponse.Response;

                // Store this in the client data store
                await IoC.ClientDataStore.SaveLoginCredentialsAsync(new LoginCredentialsDataModel
                {
                    Email = userData.Email,
                    FirstName = userData.FirstName,
                    LastName = userData.LastName,
                    Username = userData.Username,
                    Token = userData.Token
                });

                // Load new settings
                await IoC.Profile.LoadAsync();

                // Go to chat page
                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Main);

                //var email = Email;

                //// IMPORTANT: Never store insecure password in variable like this
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
