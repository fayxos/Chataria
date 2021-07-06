using Chataria.Core;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;

namespace Chataria
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to a boolean
    /// </summary>
    public class ApplicationPageToBooleanConverter : BaseValueConverter<ApplicationPageToBooleanConverter>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            // Find the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return false;

                case ApplicationPage.Register:
                    return false;

                case ApplicationPage.Main:
                    return parameter != null ? false : true;

                case ApplicationPage.Settings:
                    return parameter != null ? true : false;

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

