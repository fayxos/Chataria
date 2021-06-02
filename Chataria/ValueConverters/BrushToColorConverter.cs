using System;
using System.Windows;
using System.Globalization;
using System.Windows.Media;

namespace Chataria
{
    /// <summary>
    /// A converter that takes in an RGB string such as FF00FF and converts it to WPF brush/>
    /// </summary>
    public class BrushToColorConverter : BaseValueConverter<BrushToColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Color.FromRgb(
                (value as SolidColorBrush).Color.R,
                (value as SolidColorBrush).Color.G,
                (value as SolidColorBrush).Color.B
            );
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
