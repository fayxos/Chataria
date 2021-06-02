using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using Chataria;

namespace Chataria.Core
{
    /// <summary>
    /// The view model for a register screen
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the register command is running
        /// </summary>
        public bool RegisterIsRunning { get; set; }

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

        public RegisterViewModel()
        {
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await RegisterAsync(parameter));
            LoginCommand = new RelayCommand(async () => await LoginAsync());
        }

        #endregion

        /// <summary>
        /// Attempts to register a new user
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/>passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task RegisterAsync(object parameter)
        {
            await RunCommand(() => RegisterIsRunning, async () =>
            {
                await Task.Delay(5000);
            });
        }

        /// <summary>
        /// Takes the user to the login page
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/>passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task LoginAsync()
        {
            // TODO: Go to register page
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);

            await Task.Delay(1);
        }
    }
}
