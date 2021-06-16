using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Chataria.Core
{
    /// <summary>
    /// The design-time data for a <see cref="ChatMessageListViewModel"/>
    /// </summary>
    public class ChatMessageListDesignModel : ChatMessageListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatMessageListDesignModel Instance => new ChatMessageListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatMessageListDesignModel()
        {
            DisplayTitle = "Test";

            Items = new ObservableCollection<ChatMessageListItemViewModel>
            {
                new ChatMessageListItemViewModel
                {
                    SenderName = "Jesse",
                    Message = "I'm about to wipe out the old server. We need to update the old server to Windows 2016",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false,
                },
                new ChatMessageListItemViewModel
                {
                    SenderName = "Felix",
                    Message = "Let me now when you manage to spin up the new 2016 server",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = true,
                },
                new ChatMessageListItemViewModel
                {
                    SenderName = "Jesse",
                    Message = "The new server is up. Go to 192.168.0.1.\r\nUsername is admin passwor is O8ssw0rd",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false,
                },
            };
        }

        #endregion
    }
}
