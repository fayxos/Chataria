using System;
using System.Windows;
using System.Globalization;

namespace Chataria
{
    /// <summary>
    /// A converter that takes in a bool and converts it to a color (blue if sendby me, otherwise grey)
    /// </summary>
    public class SentByMeToForegroundConverter : BaseValueConverter<SentByMeToForegroundConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Application.Current.FindResource("BackgroundLightBrush") : Application.Current.FindResource("EnabledGreyBrush");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
