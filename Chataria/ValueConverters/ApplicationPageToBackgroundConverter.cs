using Chataria.Core;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows;

namespace Chataria
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an background color
    /// </summary>
    public class ApplicationPageToBackgroundConverter : BaseValueConverter<ApplicationPageToBackgroundConverter>
    {
        public override object Convert(object value, Type targetType = null, object parameter = null, CultureInfo culture = null)
        {
            // Find the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return Application.Current.FindResource("BackgroundDarkBrush");

                case ApplicationPage.Register:
                    return Application.Current.FindResource("BackgroundDarkBrush");

                case ApplicationPage.Main:
                    return parameter != null ? Application.Current.FindResource("BackgroundLightBrush") : Application.Current.FindResource("BackgroundDarkBrush");

                case ApplicationPage.Settings:
                    return parameter != null ? Application.Current.FindResource("BackgroundDarkBrush") : Application.Current.FindResource("BackgroundLightBrush");

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

