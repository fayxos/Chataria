using System.Collections.Generic;

namespace Chataria.Core
{
    /// <summary>
    /// The design-time data for a <see cref="ProfileDesignModel"/>
    /// </summary>
    public class ProfileDesignModel : ProfileViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ProfileDesignModel Instance => new();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProfileDesignModel()
        {
            Username = new TextEntryViewModel { Label = "Username", OriginalText = "Fayxos" };
            Name = new TextEntryViewModel { Label = "Name", OriginalText = "Felix Haag" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "Email@ermail.de" };
            Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
        }

        #endregion
    }
}
