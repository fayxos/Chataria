using System;
using System.Windows;
using System.Globalization;

namespace Chataria
{
    /// <summary>
    /// A converter that takes in a boolean and parameter
    /// if parameter null if true Collapsed else Visible
    /// if not parameter null if true Visible else Collapsed
    /// </summary>
    public class SentByMeToVisibilityConverter : BaseValueConverter<SentByMeToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
                return (bool)value ? Visibility.Collapsed : Visibility.Visible;
            else
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
