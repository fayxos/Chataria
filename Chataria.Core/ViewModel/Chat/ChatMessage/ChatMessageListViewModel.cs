using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;

namespace Chataria.Core
{
    /// <summary>
    /// A view model for a chat message thread list
    /// </summary>
    public class ChatMessageListViewModel : BaseViewModel
    {
        // personViewModel Things
        #region Public Properties

        /// <summary>
        /// A flag indicating if the send image overlay should be visible
        /// </summary>
        public bool SendImageOverlayVisible { get; set; }

        /// <summary>
        /// The path of the image to send
        /// </summary>
        public string LocalImagePath { get; set; }

        /// <summary>
        /// The chat thread items for the list
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> Items { get; set; }

        /// <summary>
        /// True to show the attchment menu, false to hide it
        /// </summary>
        public bool AttachmentMenuVisible { get; set; } = false;

        /// <summary>
        /// True to show the any attchment menu, false to hide it
        /// </summary>
        public bool AnyPopupVisible => AttachmentMenuVisible;

        /// <summary>
        /// The view model for the attachment menu
        /// </summary>
        public ExamplePopupMenuViewModel AttachmentMenu { get; set; }

        /// <summary>
        /// The messsage text for the current message being written
        /// </summary>
        public string PendingMessageText { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command for when the attachment button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        /// <summary>
        /// The command to close the image attachment overlay
        /// </summary>
        public ICommand CLoseImageAttachment { get; set; }

        /// <summary>
        /// The command for when the area outside of any popup is clicked
        /// </summary>
        public ICommand PopupClickawayCommand { get; set; }

        /// <summary>
        /// The commmand for when the user clicks the send button
        /// </summary>
        public ICommand SendCommand { get; set; }

        /// <summary>
        /// Command for clicking on picture icon
        /// </summary>
        public ICommand PictureCommand { get; set; }

        /// <summary>
        /// Command for clicking on camera icon
        /// </summary>
        public ICommand CameraCommand { get; set; }

        /// <summary>
        /// Command for clicking on document icon
        /// </summary>
        public ICommand DocumentCommand { get; set; }

        /// <summary>
        /// Command for clicking on contact icon
        /// </summary>
        public ICommand ContactCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatMessageListViewModel()
        {
            // Create commands
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickawayCommand = new RelayCommand(PopupClickaway);
            SendCommand = new RelayCommand(Send);
            PictureCommand = new RelayCommand(AttachPicture);
            CameraCommand = new RelayCommand(AttachCamera);
            DocumentCommand = new RelayCommand(AttachDocument);
            ContactCommand = new RelayCommand(AttachContact);
            CLoseImageAttachment = new RelayCommand(CloseImageAttach);

            // Make a default menu
            AttachmentMenu = new ExamplePopupMenuViewModel();
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// When the attachment button is clicked show/hide the attachment popup
        /// </summary>
        public void AttachmentButton()
        {
            // Toggle menu visibility
            AttachmentMenuVisible ^= true;

        }

        public void CloseImageAttach()
        {
            // Set visibility to false
            SendImageOverlayVisible = false;

            // Clear Local Image Path
            LocalImagePath = string.Empty;
        }

        /// <summary>
        /// When the pupup clickaway area is clicked hide any popup
        /// </summary>
        public void PopupClickaway()
        {
            // Toggle menu visibility
            AttachmentMenuVisible = false;

        }

        /// <summary>
        /// When the send button is clicked, send the message
        /// </summary>
        public void Send()
        {
            //IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            //{
            //    Title = "Send Message",
            //    Message = "Thank you for writing a nice message",
            //    OkText = "OKidOkI"
            //});

            if (Items == null)
                Items = new ObservableCollection<ChatMessageListItemViewModel>();

            string newMessage = "";

            // Check that message text isn't string.empty
            if (PendingMessageText != null)
                // Get string without white spaces at the end and beginning
                newMessage = PendingMessageText.Trim();



            // Check that message isn't empty
            if (newMessage.Length > 0 || LocalImagePath != null)
            {
                // Fake send a new text message
                Items.Add(new ChatMessageListItemViewModel
                {
                    Message = newMessage.Length > 0 ? PendingMessageText : null,
                    ImageAttachment = LocalImagePath != null ? new ChatMessageListItemImageAttachmentViewModel
                    {
                        LocalFilePath = LocalImagePath
                    } : null,
                    MessageSentTime = DateTime.UtcNow,
                    SentByMe = true,
                    SenderName = "Felix Haag",
                    NewItem = true
                }) ;

                // Clear the pending message text
                PendingMessageText = string.Empty;

                // Clear the local image path
                LocalImagePath = null;

                SendImageOverlayVisible = false;
            }
        }



        /// <summary>
        /// When the picture attachment button is clicked
        /// </summary>
        public void AttachPicture()
        {
            // Hide Popup menu
            AttachmentMenuVisible = false;

            // Make the overlay visible
            SendImageOverlayVisible = true;
        }

        /// <summary>
        /// When the camera attachment button is clicked
        /// </summary>
        public static void AttachCamera()
        {

        }

        /// <summary>
        /// When the document attachment button is clicked
        /// </summary>
        public static void AttachDocument()
        {

        }

        /// <summary>
        /// When the contact attachment button is clicked
        /// </summary>
        public static void AttachContact()
        {

        }

        #endregion 
    }
}
