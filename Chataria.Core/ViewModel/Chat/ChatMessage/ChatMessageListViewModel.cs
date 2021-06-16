using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;
using System.Linq;

namespace Chataria.Core
{
    /// <summary>
    /// A view model for a chat message thread list
    /// </summary>
    /// personViewModel Things
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Protected Members

        /// <summary>
        /// The last searched text in this list
        /// </summary>
        protected string mLastSearchText;

        /// <summary>
        /// the text to search for in the search command
        /// </summary>
        protected string mSearchText;

        /// <summary>
        /// The chat thread items for the list
        /// </summary>
        protected ObservableCollection<ChatMessageListItemViewModel> mItems;

        /// <summary>
        /// A flag indicating if the search dialog is open
        /// </summary>
        protected bool mSearchIsOpen;

        #endregion

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
        /// NOTE: Do not call Items.Add to add messages to this list
        ///       as it will make the FilteredItems out of sync
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> Items 
        {
            get => mItems;
            set
            {
                // Make sure list has changed
                if (mItems == value)
                    return;

                // Update value
                mItems = value;

                // Update filtered list to match
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(mItems);
            }
        }

        /// <summary>
        /// The chat thread items for the list that include any search filtering
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> FilteredItems { get; set; }

        /// <summary>
        /// The title of this chat list
        /// </summary>
        public string DisplayTitle { get; set; }

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

        /// <summary>
        /// The text to search for when we do a search
        /// </summary>
        public string SearchText
        {
            get => mSearchText;
            set
            {
                // Check value is different
                if (mSearchText == value)
                    return;

                // Update value
                mSearchText = value;

                // If the search text is empty...
                if (string.IsNullOrEmpty(SearchText))
                    // Search to restore messages
                    Search();
            }
        }

        /// <summary>
        /// A flag indicating if the search dialog is open
        /// </summary>
        public bool SearchIsOpen
        {
            get => mSearchIsOpen;
            set
            {
                // Check value has changed
                if (mSearchIsOpen == value)
                    return;

                // Update value
                mSearchIsOpen = value;

                // If dialog closes...
                if (!mSearchIsOpen)
                    // Clear search text
                    SearchText = string.Empty;
            }
        }

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

        /// <summary>
        /// The command for when the user wants to search
        /// </summary>
        public ICommand SearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to open the search dialog
        /// </summary>
        public ICommand OpenSearchCommand { get; set; }

        /// <summary>
        /// The command for when the user wants to close the search dialog
        /// </summary>
        public ICommand CloseSearchCommand { get; set; }

        /// <summary>
        /// The command for when the user want to clear the searchtext
        /// </summary>
        public ICommand ClearSearchCommand { get; set; }

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

            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearSearchCommand = new RelayCommand(ClearSearch);

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

            // Ensure lists are not null
            if (Items == null)
                Items = new ObservableCollection<ChatMessageListItemViewModel>();
            if (FilteredItems == null)
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
                var message = new ChatMessageListItemViewModel
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
                };

                // Add message to both lists
                Items.Add(message);
                FilteredItems.Add(message);

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

        /// <summary> 
        /// Searches the current message list and filters the view
        /// </summary>
        public void Search()
        {
            // Make sure we don't re-search the same text
            if ((string.IsNullOrEmpty(mLastSearchText) && string.IsNullOrEmpty(SearchText)) ||
                string.Equals(mLastSearchText, SearchText))
                return;

            // If we have no search text, or no items
            if (string.IsNullOrEmpty(SearchText) || Items == null || Items.Count <= 0)
            {
                // Make filtered list the same
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items ?? Enumerable.Empty<ChatMessageListItemViewModel>());

                // Set last search
                mLastSearchText = SearchText;

                return;
            }

            // Find all items that contain the given text
            // TODO: Make more efficient search
            // Clear messages without text
            FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(
                Items.Where(item => item.Message != null));

            FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(
                FilteredItems.Where(item => item.Message.ToLower().Contains(SearchText.ToLower())));

            // Set last search
            mLastSearchText = SearchText;
        }

        /// <summary> 
        /// Opens the search dialog
        /// </summary>
        public void OpenSearch() => SearchIsOpen = true;

        /// <summary> 
        /// Closes the search dialog
        /// </summary>
        public void CloseSearch() => SearchIsOpen = false;

        /// <summary> 
        /// Clears the search text
        /// </summary>
        public void ClearSearch()
        {
            // If there is some search text
            if (!string.IsNullOrEmpty(SearchText))
                // Clear the text
                SearchText = string.Empty;
            // Otherwise...
            else
                // Close search dialog
                SearchIsOpen = false;
        }

        #endregion 
    }
}
