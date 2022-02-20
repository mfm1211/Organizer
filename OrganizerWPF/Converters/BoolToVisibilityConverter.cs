using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace OrganizerWPF.Converters
{
    class BoolToVisibilityConverter : IValueConverter
    {
        public bool IsSuccessTrue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if(IsSuccessTrue)
                return System.Convert.ToBoolean(value) ? Visibility.Visible : Visibility.Collapsed;
            else
                return System.Convert.ToBoolean(value) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
