using System.Collections.Generic;

namespace Chataria.Core
{
    /// <summary>
    /// A view model for the overview chat list item in the overview chat list
    /// </summary>
    public class ChatListViewModel : BaseViewModel
    {
        /// <summary>
        /// The chat list items for the list
        /// </summary>
        public static List<ChatListItemViewModel> Items { get; set; }
    }
}
