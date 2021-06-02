using Chataria.Core;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;

namespace Chataria.Core
{
    /// <summary>
    /// A view model for any popup menus
    /// </summary>
    public class ExamplePopupMenuViewModel : BasePopupViewModel
    {
        #region Constructor

        public ExamplePopupMenuViewModel()
        {
            Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>(new[]
                {
                    new MenuItemViewModel { Text = "Attach a file...", Type= MenuItemType.Header },
                    new MenuItemViewModel { Text = "From Computer", Icon = IconType.File },
                    new MenuItemViewModel { Text = "From Pictures", Icon = IconType.Picture },
                })
            };
        }

        #endregion
    }
}
