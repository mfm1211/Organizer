using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace OrganizerWPF.Converters
{
    public class IntToVisibilityConverter : IValueConverter
    {
        public bool InverseConverting { get; set; } = false;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;


            if (!InverseConverting)
                return (System.Convert.ToInt32(value) != 0) ? Visibility.Visible : Visibility.Collapsed;
            else
                return (System.Convert.ToInt32(value) != 0) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
