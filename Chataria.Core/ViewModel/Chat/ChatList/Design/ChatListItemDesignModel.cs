using System;

namespace Chataria.Core
{
    /// <summary>
    /// The design-time data for a <see cref="ChatListItemViewModel"/>
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatListItemDesignModel()
        {
            Initials = "MG";
            Name = "Mira";
            Message = "This chat app is awesome!";
            ProfilePictureRGB = "5eb3ce";
        }

        #endregion
    }
}
