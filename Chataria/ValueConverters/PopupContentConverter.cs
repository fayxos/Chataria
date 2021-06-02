using System;
using System.Globalization;
using System.Windows;
using Chataria.Core;

namespace Chataria
{
    /// <summary>
    /// A converter that takes in a <see cref="BasePopupViewModel"/> and returns a specific UI control
    /// that should bind to that type of ViewModel
    /// </summary>
    public class PopupContentConverter : BaseValueConverter<PopupContentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ExamplePopupMenuViewModel basePopup)
                return new VerticalMenu { DataContext = basePopup.Content };

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
