using System;
using System.Windows;
using System.Globalization;

namespace Chataria
{
    /// <summary>
    /// A converter that takes in a bool and converts it to a alignment (right if sendby me, otherwise left)
    /// </summary>
    public class SentByMeToAlignmentConverter : BaseValueConverter<SentByMeToAlignmentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? HorizontalAlignment.Right : HorizontalAlignment.Left;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
