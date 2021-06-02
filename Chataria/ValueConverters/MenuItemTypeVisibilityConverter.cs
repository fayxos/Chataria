using System;
using System.Windows;
using System.Globalization;
using Chataria.Core;

namespace Chataria
{
    /// <summary>
    /// A converter that takes in a <see cref="MenuItemType"/> and returns a <see cref="Visibility"/>
    /// based on the given Parameter being the same as the menu item style
    /// </summary>
    public class MenuItemTypeVisibilityConverter : BaseValueConverter<MenuItemTypeVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // if we have no parameter return invisibility
            if (parameter == null)
                return Visibility.Collapsed;

            // Try and convert parameter string to enum
            if (!Enum.TryParse(parameter as string, out MenuItemType type))
                return Visibility.Collapsed;

            // Return visible if the parameter matches the type
            return (MenuItemType)value == type ? Visibility.Visible : Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
