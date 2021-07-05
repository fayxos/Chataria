using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Chataria.Core
{
    /// <summary>
    /// A view model for each chat list item in the overview chat list
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// The display name of this chat list
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The latest message from this chat
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The initials to show the profile picture
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// The RGB values (in hex) for the background color of profile picture 
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        /// <summary>
        /// True if there are unread messages in this chat 
        /// </summary>
        public bool NewContentAvailable { get; set; }

        /// <summary>
        /// True if this item is selected
        /// </summary>
        public bool IsSelected { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Opens the current message thread
        /// </summary>
        public ICommand OpenMessageCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatListItemViewModel()
        {
            // Create Commands
            OpenMessageCommand = new RelayCommand(OpenMessage);
        }

        #endregion

        #region Command Methods

        private void OpenMessage()
        {
            // Unselect other chat
            foreach (ChatListItemViewModel item in ChatListDesignModel.Items)
            {
                item.IsSelected = false;
            }

            // Make the chat selected
            IsSelected = true;

            IoC.Application.GoToPage(ApplicationPage.Main, new ChatMessageListViewModel
            {
                DisplayTitle = Name,

                // Comes from the server later
                Items = new ObservableCollection<ChatMessageListItemViewModel>
                {
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        MessageSentTime = DateTime.UtcNow,
                        SenderName = "Luke",
                        SentByMe = true
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received message",
                        MessageSentTime = DateTime.UtcNow,
                        SenderName = "Parnell",
                        SentByMe = false
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        MessageSentTime = DateTime.UtcNow,
                        SenderName = "Luke",
                        SentByMe = true
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received message",
                        MessageSentTime = DateTime.UtcNow,
                        SenderName = "Parnell",
                        SentByMe = false
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        MessageSentTime = DateTime.UtcNow,
                        SenderName = "Luke",
                        SentByMe = true
                    },
                    new ChatMessageListItemViewModel
                    {
                        ImageAttachment = new ChatMessageListItemImageAttachmentViewModel
                        {
                            ThumbnailUrl = "http://anywhere",
                        },  
                        MessageSentTime = DateTime.UtcNow,
                        SenderName = "Parnell",
                        SentByMe = false
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        ImageAttachment = new ChatMessageListItemImageAttachmentViewModel
                        {
                            ThumbnailUrl = "http://anywhere",
                        },
                        MessageSentTime = DateTime.UtcNow,
                        SenderName = "Luke",
                        SentByMe = true
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received message",
                        MessageSentTime = DateTime.UtcNow,
                        SenderName = "Parnell",
                        SentByMe = false
                    },
                }
            });
        }

        #endregion

    }
}
