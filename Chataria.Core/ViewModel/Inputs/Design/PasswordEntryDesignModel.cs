namespace Chataria.Core
{
    /// <summary>
    /// The design-time data for a <see cref="PasswordEntryViewModel"/>
    /// </summary>
    public class PasswordEntryDesignModel : PasswordEntryViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance
        /// </summary>
        public static PasswordEntryDesignModel Instance => new();

        #endregion

        #region Constructor

        public PasswordEntryDesignModel()
        {
            Label = "Password";
            FakePassword = "********";
        }



        #endregion
    }
}
