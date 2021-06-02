using Chataria.Core;
using System.Drawing;
using System.Windows;

namespace Chataria.Core
{
    /// <summary>
    /// A view model for any popup menus
    /// </summary>
    public class BasePopupViewModel : BaseViewModel
    {
       #region Public Properties

        /// <summary>
        /// The background color of the bubble in ARGB value
        /// </summary>
        public string BubbleBackground { get; set; }

        /// <summary>
        ///  The lignment of the bubble arrow
        /// </summary>
        public ElementHorizontalAlignemnt ArrowAlignment { get; set; }

        /// <summary>
        /// The content inside of this popup menu
        /// </summary>
        public MenuViewModel Content { get; set; }

        #endregion

        #region Constructor

        public BasePopupViewModel()
        {
            // Set default values
            // TODO: Move Colors into Core
            BubbleBackground = "99AAB5";
            ArrowAlignment = ElementHorizontalAlignemnt.Left;
        }

        #endregion
    }
}
