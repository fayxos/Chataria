﻿using System;
using System.Windows;
using System.Globalization;

namespace Chataria
{
    /// <summary>
    /// A converter that takes in a date and converts it to a user friendly time
    /// </summary>
    public class TimeToDisplayTimeConverter : BaseValueConverter<TimeToDisplayTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the time passed in
            var time = (DateTimeOffset)value;


            //// If it is today....
            //if (time.Date == DateTimeOffset.UtcNow.Date)
            // Return just time
            //return time.ToLocalTime().ToString("HH:mm");

            // Otherwise, return a full date
            //return time.ToLocalTime().ToString("HH:mm, MMM, yyyy");

            return time.ToLocalTime().ToString("HH:mm");

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
