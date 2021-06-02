using System.Collections.Generic;

namespace Chataria.Core
{
    /// <summary>
    /// The design time data for a <see cref="MenuViewModel"/>
    /// </summary>
    public class MenuDesignModel : MenuViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance
        /// </summary>
        public static MenuDesignModel Instance => new();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MenuDesignModel()
        {
            Items = new List<MenuItemViewModel>(new[]
            {
                new MenuItemViewModel { Type = MenuItemType.Header, Text = "Design time header..."},
                new MenuItemViewModel { Text = "Menu Item 1", Icon = IconType.File },
                new MenuItemViewModel { Text = "Menu Item 2", Icon = IconType.Picture },
            });
        }

        #endregion
    }
}
 