using System;
using System.Windows;
using System.Globalization;

namespace Chataria
{
    /// <summary>
    /// A converter that takes in a bool and converts it to a alignment (right if sendby me, otherwise left)
    /// </summary>
    public class SentByMeToColumnConverter : BaseValueConverter<SentByMeToColumnConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(parameter == null)
                return (bool)value ? "1" : "0";
            else
                return (bool)value ? "0" : "1";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
