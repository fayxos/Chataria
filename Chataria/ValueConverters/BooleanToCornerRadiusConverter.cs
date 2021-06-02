using System;
using System.Windows;
using System.Globalization;

namespace Chataria
{
    /// <summary>
    /// A converter that takes in a boolean (has text) and returns a corner radius
    /// </summary>
    public class BooleanToCornerRadiusConverter : BaseValueConverter<BooleanToCornerRadiusConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "15 15 0 0" : "15";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
