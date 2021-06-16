using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Chataria.Core
{
    /// <summary>
    /// The design-time data for a <see cref="ChatListViewModel"/>
    /// </summary>
    public class ChatListDesignModel : ChatListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatListDesignModel Instance => new ChatListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Initials = "L",
                    Message = "This chat app is awesome",
                    ProfilePictureRGB = "5eb3ce"
                },
                new ChatListItemViewModel
                {
                    Name = "Jesse",
                    Initials = "J",
                    Message = "Hey dude, here are the new icons",
                    ProfilePictureRGB = "fe4503",
                    IsSelected = true
                },
                new ChatListItemViewModel
                {
                    Name = "Mira",
                    Initials = "M",
                    Message = "The new server is upm got 192.168.1.1",
                    ProfilePictureRGB = "00d405",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Initials = "L",
                    Message = "This chat app is awesome",
                    ProfilePictureRGB = "5eb3ce"
                },
                new ChatListItemViewModel
                {
                    Name = "Jesse",
                    Initials = "J",
                    Message = "Hey dude, here are the new icons",
                    ProfilePictureRGB = "fe4503",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Name = "Mira",
                    Initials = "M",
                    Message = "The new server is upm got 192.168.1.1",
                    ProfilePictureRGB = "00d405",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Initials = "L",
                    Message = "This chat app is awesome",
                    ProfilePictureRGB = "5eb3ce"
                },
                new ChatListItemViewModel
                {
                    Name = "Jesse",
                    Initials = "J",
                    Message = "Hey dude, here are the new icons",
                    ProfilePictureRGB = "fe4503",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Name = "Mira",
                    Initials = "M",
                    Message = "The new server is upm got 192.168.1.1",
                    ProfilePictureRGB = "00d405"
                },
            };
        }

        #endregion
    }
}
