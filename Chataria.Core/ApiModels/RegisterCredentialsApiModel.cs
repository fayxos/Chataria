namespace Chataria.Core
{
    /// <summary>
    /// The credentials for an API client to register on the server
    /// </summary>
    public class RegisterCredentialsApiModel
    {
        #region Public Properties

        /// <summary>
        /// The users username or email
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The users email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The users Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The users FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The users LastName
        /// </summary>
        public string LastName { get; set; }

        #endregion
    }
}
